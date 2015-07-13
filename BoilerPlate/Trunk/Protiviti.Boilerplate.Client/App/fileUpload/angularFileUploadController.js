"use strict";


var app = angular.module('fileUpload', ['angularFileUpload']);
var version = angular.module('angularFileUpload').version;

app.controller('angularFileUploadController', ['$scope', '$q', '$http', '$timeout', '$compile', '$upload', 'config', 'common', 'dataservice', 'fileUploadService',
    function ($scope, $q, $http, $timeout, $compile, $upload, config, common, dataservice, fileUploadService) {
        //$scope.usingFlash = FileAPI && FileAPI.upload != null;
        $scope.fileReaderSupported = true;// window.FileReader != null && (window.FileAPI == null || FileAPI.html5 != false);

        $scope.changeAngularVersion = function () {
            window.location.hash = $scope.angularVersion;
            window.location.reload(true);
        };

        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        // Initialize dataservice with a web api controller
        dataservice.initialize("File", config.remoteApiServiceBase);

        $scope.pagingInfo = {
            page: 1,
            itemsPerPage: 10,
            orderBy: 'CreatedDate',
            nameFilter: '',
            totalItems: 100,
            reverse: true
        };


        activate();

        $scope.uploadedFiles = [];
        $scope.files = [];
        $scope.fileTitle = "";
        $scope.downloadURL = "";
        $scope.existingUploadedFiles = [];

        $scope.angularVersion = window.location.hash.length > 1 ? (window.location.hash.indexOf('/') === 1 ?
                window.location.hash.substring(2) : window.location.hash.substring(1)) : '1.2.20';

        $scope.uploadPic = function (files) {
            $scope.formUpload = true;
            if (files != null) {
                angular.forEach(files, function (f) {
                    if (f.size > 104857600) {
                        alert('Sorry, file size must be under 100MB');
                    }
                });
                $scope.files = files;
                var promise = asyncReadFile($scope.files)

                promise.then(function (greeting) {
                    uploadFileToDb();
                });
            }
        }

        function asyncReadFile(files) {
            var deferred = $q.defer();

            //counter to keep track if all files are read or not
            var fileCount = 0;

            angular.forEach(files, function (f) {
                //create a new reader for each file or else there will be a conflict while reading dataurl
                var reader = new FileReader();

                reader.readAsDataURL(f);
                reader.onloadend = function (evt) {
                    var strtIndex = evt.target.result.toString().indexOf("base64");
                    var fileImg = evt.target.result.toString().substring(strtIndex + 7, evt.target.result.length);
                    var fileType = evt.target.result.toString().substring(5, strtIndex - 1);

                    //set properties of each file as uploaded
                    f.FileImage = fileImg;
                    f.FileType = fileType;
                    f.FileName = f.name;
                    f.FileSize = f.size;
                    f.Title = $scope.fileTitle ? $scope.fileTitle : f.name.substr(0, f.name.lastIndexOf('.'));// in case of drag and drop take file name as title
                    f.CreatedDate = Date.now();

                    fileCount++;
                };
            });

            setTimeout(function () {
                if (fileCount == files.length) {
                    deferred.resolve("");
                    //uploadFileToDb();
                }
                else {
                    deferred.reject("");
                }
            }, 1000);

            return deferred.promise;
        }


        var uploadFileToDb = function () {
            fileUploadService.angularUploadFile($scope.files).success(function () {
                $scope.searchFiles();
                angular.forEach($scope.files, function (f) {
                    var tempArray = $scope.uploadedFiles;
                    tempArray.unshift(f);

                    //sorting the array to match the current order
                    if (!$scope.pagingInfo.reverse)
                        tempArray.sort(compare);
                    else
                        tempArray.sort(compareReverse);

                    //keep track of items on a page 
                    if (tempArray.length > $scope.pagingInfo.itemsPerPage)
                        tempArray = tempArray.slice(0, $scope.pagingInfo.itemsPerPage);

                    $scope.uploadedFiles = tempArray;
                });
            }).error(function (error, statusCode) {
                //in case the file upload is unsuccessful, remove file and show message
                $scope.picFile[0] = null;
                document.getElementById("picFile").value = "";
                alert("Upload Unsuccessful!");
            });
        }

        //functions for sorting as per current sort
        function compare(elemOne, elemTwo) {
            var attrOne = elemOne[$scope.pagingInfo.orderBy];
            var attrTwo = elemTwo[$scope.pagingInfo.orderBy];

            if ($scope.pagingInfo.orderBy == "CreatedDate")
            {
                attrOne = moment(elemOne[$scope.pagingInfo.orderBy]).format();
                attrTwo = moment(elemTwo[$scope.pagingInfo.orderBy]).format();
            }
            if (attrOne < attrTwo)
                return -1;
            if (attrOne > attrTwo)
                return 1;
            return 0;
        }

        function compareReverse(elemOne, elemTwo) {
            var attrOne = elemOne[$scope.pagingInfo.orderBy];
            var attrTwo = elemTwo[$scope.pagingInfo.orderBy];

            if ($scope.pagingInfo.orderBy == "CreatedDate") {
                attrOne = moment(elemOne[$scope.pagingInfo.orderBy]).format();
                attrTwo = moment(elemTwo[$scope.pagingInfo.orderBy]).format();
            }
            if (attrOne > attrTwo)
                return -1;
            if (attrOne < attrTwo)
                return 1;
            return 0;
        }

        $scope.generateSignature = function () {
            $http.post('/s3sign?aws-secret-key=' + encodeURIComponent($scope.AWSSecretKey), $scope.jsonPolicy).
                success(function (data) {
                    $scope.policy = data.policy;
                    $scope.signature = data.signature;
                });
        }

        $scope.downloadFile = function (id) {
            window.open(config.remoteApiServiceBase + 'file/download?fileId=' + id, '_blank');
        }

        $scope.deleteFile = function (id) {
            if ($scope.confirmDelete()) {
                fileUploadService.deleteFile(id).success(function () {
                    $scope.searchFiles();
                });
            }
        }

        //edit file details
        $scope.editFile = function(id)
        {
            //in order to keep existing values
            angular.copy($scope.uploadedFiles, $scope.existingUploadedFiles);

            angular.forEach($scope.uploadedFiles, function (file) {
                if (file.Id == id)
                    file.isEditMode = true;
            });
        }

        $scope.saveEditToDb = function (editedFile) {
            if (typeof (editedFile.FileName) != "undefined" && typeof (editedFile.Title) != "undefined") {
                fileUploadService.editFile(editedFile).success(function () {
                    editedFile.isEditMode = false;
                });
            }
        }

        $scope.cancelEdit = function(editedFile){
            editedFile.isEditMode = false;

            angular.forEach($scope.existingUploadedFiles, function (file) {
                if (file.Id == editedFile.Id){
                    editedFile.Title = file.Title
                    editedFile.FileName = file.FileName;
                }
            });
        }

        //  #region file upload js
        if (localStorage) {
            $scope.s3url = localStorage.getItem("s3url");
            $scope.AWSAccessKeyId = localStorage.getItem("AWSAccessKeyId");
            $scope.acl = localStorage.getItem("acl");
            $scope.success_action_redirect = localStorage.getItem("success_action_redirect");
            $scope.policy = localStorage.getItem("policy");
            $scope.signature = localStorage.getItem("signature");
        }

        $scope.success_action_redirect = $scope.success_action_redirect || window.location.protocol + "//" + window.location.host;
        $scope.jsonPolicy = $scope.jsonPolicy || '{\n  "expiration": "2020-01-01T00:00:00Z",\n  "conditions": [\n    {"bucket": "angular-file-upload"},\n    ["starts-with", "$key", ""],\n    {"acl": "private"},\n    ["starts-with", "$Content-Type", ""],\n    ["starts-with", "$filename", ""],\n    ["content-length-range", 0, 524288000]\n  ]\n}';
        $scope.acl = $scope.acl || 'private';

        function storeS3UploadConfigInLocalStore() {
            if ($scope.howToSend == 3 && localStorage) {
                localStorage.setItem("s3url", $scope.s3url);
                localStorage.setItem("AWSAccessKeyId", $scope.AWSAccessKeyId);
                localStorage.setItem("acl", $scope.acl);
                localStorage.setItem("success_action_redirect", $scope.success_action_redirect);
                localStorage.setItem("policy", $scope.policy);
                localStorage.setItem("signature", $scope.signature);
            }
        }

        (function handleDynamicEditingOfScriptsAndHtml($scope, $http) {
            $scope.defaultUploadScript = [];
            $http.get('scripts/upload/upload-upload.js').success(function (data) {
                $scope.defaultUploadScript[1] = data; $scope.uploadScript = $scope.uploadScript || data
            });
            $http.get('scripts/upload/upload-http.js').success(function (data) { $scope.defaultUploadScript[2] = data });
            $http.get('scripts/upload/upload-s3.js').success(function (data) { $scope.defaultUploadScript[3] = data });

            $scope.defaultHtml = document.getElementById('editArea').innerHTML.replace(/\t\t\t\t/g, '');

            $scope.editHtml = (localStorage && localStorage.getItem("editHtml" + version)) || $scope.defaultHtml;
            function htmlEdit(update) {
                document.getElementById("editArea").innerHTML = $scope.editHtml;
                $compile(document.getElementById("editArea"))($scope);
                $scope.editHtml && localStorage && localStorage.setItem("editHtml" + version, $scope.editHtml);
                if ($scope.editHtml != $scope.htmlEditor.getValue()) $scope.htmlEditor.setValue($scope.editHtml);
            }
            //$scope.$watch("editHtml", htmlEdit);

            //$scope.$watch("howToSend", function (newVal, oldVal) {
            //    $scope.uploadScript && localStorage && localStorage.setItem("uploadScript" + oldVal + version, $scope.uploadScript);
            //    $scope.uploadScript = (localStorage && localStorage.getItem("uploadScript" + newVal + version)) || $scope.defaultUploadScript[newVal];
            //});

            function jsEdit(update) {
                $scope.uploadScript && localStorage && localStorage.setItem("uploadScript" + $scope.howToSend + version, $scope.uploadScript);
                if ($scope.uploadScript != $scope.jsEditor.getValue()) $scope.jsEditor.setValue($scope.uploadScript);
            }
            //$scope.$watch("uploadScript", jsEdit);

            $scope.htmlEditor = CodeMirror(document.getElementById('htmlEdit'), {
                lineNumbers: true, indentUnit: 4,
                mode: "htmlmixed"
            });
            $scope.htmlEditor.on('change', function () {
                if ($scope.editHtml != $scope.htmlEditor.getValue()) {
                    $scope.editHtml = $scope.htmlEditor.getValue();
                    htmlEdit();
                }
            });
            $scope.jsEditor = CodeMirror(document.getElementById('jsEdit'), {
                lineNumbers: true, indentUnit: 4,
                mode: "javascript"
            });
            $scope.jsEditor.on('change', function () {
                if ($scope.uploadScript != $scope.jsEditor.getValue()) {
                    $scope.uploadScript = $scope.jsEditor.getValue();
                    jsEdit();
                }
            });

            //    #endregion
        })($scope, $http);

        $scope.confirm = function () {
            return confirm('Are you sure? Your local changes will be lost.');
        }

        $scope.confirmDelete = function () {
            return confirm('Are you sure you want to delete the file?');
        }

        //#region paging and filtering
        $scope.selectFirstPage = function () {
            $scope.pagingInfo.page = 1;
            $scope.searchFiles();
        };

        $scope.selectPreviousPage = function (page) {
            if ($scope.pagingInfo.page > 1) {
                $scope.pagingInfo.page = $scope.pagingInfo.page - 1;
                $scope.searchFiles();
            }
        };

        $scope.selectNextPage = function (page) {
            $scope.pagingInfo.page = $scope.pagingInfo.page + 1;
            $scope.searchFiles();
        };

        $scope.sortFiles = function (orderBy) {
            if (orderBy === $scope.pagingInfo.orderBy) {
                $scope.pagingInfo.reverse = !$scope.pagingInfo.reverse;
            } else {
                $scope.pagingInfo.orderBy = orderBy;
                $scope.pagingInfo.reverse = false;
            }
            $scope.pagingInfo.page = 1;
            $scope.searchFiles();
        };

        // Methods
        $scope.searchFiles = function () {
            // Clear old criteria before setting up new criteria
            dataservice.clear();
            dataservice.filter = dataservice.getPredicate("FileName", dataservice.FilterQueryOp.Contains, $scope.pagingInfo.nameFilter);
            if ($scope.pagingInfo.reverse) {
                dataservice.orderBy = $scope.pagingInfo.orderBy + ' desc';
            }
            else {
                dataservice.orderBy = $scope.pagingInfo.orderBy + ' asc';
            }
            dataservice.skip = $scope.pagingInfo.itemsPerPage * ($scope.pagingInfo.page - 1);
            dataservice.take = $scope.pagingInfo.itemsPerPage;
            return dataservice.search('GetUploadedFiles', (function (response) {
                if (response.results != null) {
                    if ((response.results.length == 0) && ($scope.pagingInfo.page > 1)) {
                        $scope.pagingInfo.page = $scope.pagingInfo.page - 1;
                    }
                    else {
                        $scope.uploadedFiles = response.results;                        
                        angular.forEach($scope.uploadedFiles, function (file) {                           
                                file.isEditMode = false;
                        });
                    }

                }
            }), (function (error) {
                alert("Error filtering Files: " + error);
            }));
        }

        // Watch methods
        $scope.$watch('pagingInfo.nameFilter', function () {
            if (!$scope.initializing) {
                $scope.searchFiles();
                $scope.showPager();
            }
        });

        $scope.showPager = function () {
            if ($scope.uploadedFiles.length >= $scope.pagingInfo.itemsPerPage) {
                return true;
            } else { return false };

        }

        // #endregion 
        function activate() {
            var promises = [];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated File Upload View'); });
        }


    }]);