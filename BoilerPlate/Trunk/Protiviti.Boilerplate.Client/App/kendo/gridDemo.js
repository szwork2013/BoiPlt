/// <reference path="../common/logger.js" />
(function () {
    'use strict';
    var controllerId = 'gridDemoController';
    angular.module('app').controller(controllerId, ['$scope', '$location', 'common', 'datacontext', 'fileService', 'modalService', gridDemo]);

    function gridDemo($scope, $location, common, datacontext, fileService, modalService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        //var vm = this;
        $scope.news = {
            title: 'Protiviti AngularJS POC',
            description: 'Protiviti AngularJS POC'
        };
        $scope.technologies = [{ name: 'Angular', version: '1.3.0', description: 'UI Framework' },
                                { name: 'Angular UI Router', version: '??' },
                                { name: 'Breeze', version: '1.5.0', description: 'Client side data retrieval framework' },
        ];
        $scope.title = 'Technologies';
        $scope.allowCollapse = "true";
        
        var data = [{ MyString: 'abc', MyInt: 5, MyDecimal: 1.463, MyFloat: 1.463, FirstName: 'Jane', LastName: 'Doe' },
            { MyString: 'def', MyInt: 1, MyDecimal: 1.464, MyFloat: 1.463, FirstName: 'Julie', LastName: 'Doe' },
            { MyString: 'aaa', MyInt: 3, MyDecimal: 74.34, MyFloat: 12.12, FirstName: 'Stanley', LastName: 'Brady' },
            { MyString: 'baa', MyInt: 5, MyDecimal: -12.0, MyFloat: 345.2, FirstName: 'Horace', LastName: 'Franklin' },
        { MyString: 'abc', MyInt: 5, MyDecimal: 1.463, MyFloat: 1.463, FirstName: 'Jane', LastName: 'Doe' },
            { MyString: 'def', MyInt: 1, MyDecimal: 1.464, MyFloat: 1.463, FirstName: 'Julie', LastName: 'Doe' },
            { MyString: 'aaa', MyInt: 3, MyDecimal: 74.34, MyFloat: 12.12, FirstName: 'Stanley', LastName: 'Brady' },
            { MyString: 'baa', MyInt: 5, MyDecimal: -12.0, MyFloat: 345.2, FirstName: 'Horace', LastName: 'Franklin' },
        { MyString: 'abc', MyInt: 5, MyDecimal: 1.463, MyFloat: 1.463, FirstName: 'Jane', LastName: 'Doe' },
            { MyString: 'def', MyInt: 1, MyDecimal: 1.464, MyFloat: 1.463, FirstName: 'Julie', LastName: 'Doe' },
            { MyString: 'aaa', MyInt: 3, MyDecimal: 74.34, MyFloat: 12.12, FirstName: 'Stanley', LastName: 'Brady' },
            { MyString: 'baa', MyInt: 5, MyDecimal: -12.0, MyFloat: 345.2, FirstName: 'Horace', LastName: 'Franklin' },
        { MyString: 'abc', MyInt: 5, MyDecimal: 1.463, MyFloat: 1.463, FirstName: 'Jane', LastName: 'Doe' },
            { MyString: 'def', MyInt: 1, MyDecimal: 1.464, MyFloat: 1.463, FirstName: 'Julie', LastName: 'Doe' },
            { MyString: 'aaa', MyInt: 3, MyDecimal: 74.34, MyFloat: 12.12, FirstName: 'Stanley', LastName: 'Brady' },
            { MyString: 'baa', MyInt: 5, MyDecimal: -12.0, MyFloat: 345.2, FirstName: 'Horace', LastName: 'Franklin' },
        { MyString: 'abc', MyInt: 5, MyDecimal: 1.463, MyFloat: 1.463, FirstName: 'Jane', LastName: 'Doe' },
            { MyString: 'def', MyInt: 1, MyDecimal: 1.464, MyFloat: 1.463, FirstName: 'Julie', LastName: 'Doe' },
            { MyString: 'aaa', MyInt: 3, MyDecimal: 74.34, MyFloat: 12.12, FirstName: 'Stanley', LastName: 'Brady' },
            { MyString: 'baa', MyInt: 5, MyDecimal: -12.0, MyFloat: 345.2, FirstName: 'Horace', LastName: 'Franklin' },
        { MyString: 'abc', MyInt: 5, MyDecimal: 1.463, MyFloat: 1.463, FirstName: 'Jane', LastName: 'Doe' },
            { MyString: 'def', MyInt: 1, MyDecimal: 1.464, MyFloat: 1.463, FirstName: 'Julie', LastName: 'Doe' },
            { MyString: 'aaa', MyInt: 3, MyDecimal: 74.34, MyFloat: 12.12, FirstName: 'Stanley', LastName: 'Brady' },
            { MyString: 'baa', MyInt: 5, MyDecimal: -12.0, MyFloat: 345.2, FirstName: 'Horace', LastName: 'Franklin' },
        { MyString: 'abc', MyInt: 5, MyDecimal: 1.463, MyFloat: 1.463, FirstName: 'Jane', LastName: 'Doe' },
            { MyString: 'def', MyInt: 1, MyDecimal: 1.464, MyFloat: 1.463, FirstName: 'Julie', LastName: 'Doe' },
            { MyString: 'aaa', MyInt: 3, MyDecimal: 74.34, MyFloat: 12.12, FirstName: 'Stanley', LastName: 'Brady' },
            { MyString: 'baa', MyInt: 5, MyDecimal: -12.0, MyFloat: 345.2, FirstName: 'Horace', LastName: 'Franklin' },
        { MyString: 'abc', MyInt: 5, MyDecimal: 1.463, MyFloat: 1.463, FirstName: 'Jane', LastName: 'Doe' },
            { MyString: 'def', MyInt: 1, MyDecimal: 1.464, MyFloat: 1.463, FirstName: 'Julie', LastName: 'Doe' },
            { MyString: 'aaa', MyInt: 3, MyDecimal: 74.34, MyFloat: 12.12, FirstName: 'Stanley', LastName: 'Brady' },
            { MyString: 'baa', MyInt: 5, MyDecimal: -12.0, MyFloat: 345.2, FirstName: 'Horace', LastName: 'Franklin' },
        { MyString: 'abc', MyInt: 5, MyDecimal: 1.463, MyFloat: 1.463, FirstName: 'Jane', LastName: 'Doe' },
            { MyString: 'def', MyInt: 1, MyDecimal: 1.464, MyFloat: 1.463, FirstName: 'Julie', LastName: 'Doe' },
            { MyString: 'aaa', MyInt: 3, MyDecimal: 74.34, MyFloat: 12.12, FirstName: 'Stanley', LastName: 'Brady' },
            { MyString: 'baa', MyInt: 5, MyDecimal: -12.0, MyFloat: 345.2, FirstName: 'Horace', LastName: 'Franklin' },
        { MyString: 'abc', MyInt: 5, MyDecimal: 1.463, MyFloat: 1.463, FirstName: 'Jane', LastName: 'Doe' },
            { MyString: 'def', MyInt: 1, MyDecimal: 1.464, MyFloat: 1.463, FirstName: 'Julie', LastName: 'Doe' },
            { MyString: 'aaa', MyInt: 3, MyDecimal: 74.34, MyFloat: 12.12, FirstName: 'Stanley', LastName: 'Brady' },
            { MyString: 'baa', MyInt: 5, MyDecimal: -12.0, MyFloat: 345.2, FirstName: 'Horace', LastName: 'Franklin' },
        { MyString: 'abc', MyInt: 5, MyDecimal: 1.463, MyFloat: 1.463, FirstName: 'Jane', LastName: 'Doe' },
            { MyString: 'def', MyInt: 1, MyDecimal: 1.464, MyFloat: 1.463, FirstName: 'Julie', LastName: 'Doe' },
            { MyString: 'aaa', MyInt: 3, MyDecimal: 74.34, MyFloat: 12.12, FirstName: 'Stanley', LastName: 'Brady' },
            { MyString: 'baa', MyInt: 5, MyDecimal: -12.0, MyFloat: 345.2, FirstName: 'Horace', LastName: 'Franklin' },
        { MyString: 'abc', MyInt: 5, MyDecimal: 1.463, MyFloat: 1.463, FirstName: 'Jane', LastName: 'Doe' },
            { MyString: 'def', MyInt: 1, MyDecimal: 1.464, MyFloat: 1.463, FirstName: 'Julie', LastName: 'Doe' },
            { MyString: 'aaa', MyInt: 3, MyDecimal: 74.34, MyFloat: 12.12, FirstName: 'Stanley', LastName: 'Brady' },
            { MyString: 'baa', MyInt: 5, MyDecimal: -12.0, MyFloat: 345.2, FirstName: 'Horace', LastName: 'Franklin' },
        { MyString: 'abc', MyInt: 5, MyDecimal: 1.463, MyFloat: 1.463, FirstName: 'Jane', LastName: 'Doe' },
            { MyString: 'def', MyInt: 1, MyDecimal: 1.464, MyFloat: 1.463, FirstName: 'Julie', LastName: 'Doe' },
            { MyString: 'aaa', MyInt: 3, MyDecimal: 74.34, MyFloat: 12.12, FirstName: 'Stanley', LastName: 'Brady' },
            { MyString: 'baa', MyInt: 5, MyDecimal: -12.0, MyFloat: 345.2, FirstName: 'Horace', LastName: 'Franklin' },
        { MyString: 'abc', MyInt: 5, MyDecimal: 1.463, MyFloat: 1.463, FirstName: 'Jane', LastName: 'Doe' },
            { MyString: 'def', MyInt: 1, MyDecimal: 1.464, MyFloat: 1.463, FirstName: 'Julie', LastName: 'Doe' },
            { MyString: 'aaa', MyInt: 3, MyDecimal: 74.34, MyFloat: 12.12, FirstName: 'Stanley', LastName: 'Brady' },
            { MyString: 'baa', MyInt: 5, MyDecimal: -12.0, MyFloat: 345.2, FirstName: 'Horace', LastName: 'Franklin' },
        { MyString: 'abc', MyInt: 5, MyDecimal: 1.463, MyFloat: 1.463, FirstName: 'Jane', LastName: 'Doe' },
            { MyString: 'def', MyInt: 1, MyDecimal: 1.464, MyFloat: 1.463, FirstName: 'Julie', LastName: 'Doe' },
            { MyString: 'aaa', MyInt: 3, MyDecimal: 74.34, MyFloat: 12.12, FirstName: 'Stanley', LastName: 'Brady' },
            { MyString: 'baa', MyInt: 5, MyDecimal: -12.0, MyFloat: 345.2, FirstName: 'Horace', LastName: 'Franklin' },
        { MyString: 'abc', MyInt: 5, MyDecimal: 1.463, MyFloat: 1.463, FirstName: 'Jane', LastName: 'Doe' },
            { MyString: 'def', MyInt: 1, MyDecimal: 1.464, MyFloat: 1.463, FirstName: 'Julie', LastName: 'Doe' },
            { MyString: 'aaa', MyInt: 3, MyDecimal: 74.34, MyFloat: 12.12, FirstName: 'Stanley', LastName: 'Brady' },
            { MyString: 'baa', MyInt: 5, MyDecimal: -12.0, MyFloat: 345.2, FirstName: 'Horace', LastName: 'Franklin' }, { MyString: 'abc', MyInt: 5, MyDecimal: 1.463, MyFloat: 1.463, FirstName: 'Jane', LastName: 'Doe' },
            { MyString: 'def', MyInt: 1, MyDecimal: 1.464, MyFloat: 1.463, FirstName: 'Julie', LastName: 'Doe' },
            { MyString: 'aaa', MyInt: 3, MyDecimal: 74.34, MyFloat: 12.12, FirstName: 'Stanley', LastName: 'Brady' },
            { MyString: 'baa', MyInt: 5, MyDecimal: -12.0, MyFloat: 345.2, FirstName: 'Horace', LastName: 'Franklin' }
        ];
        console.log("ran controller code")
        var localDataSource = new kendo.data.DataSource({ data: data, pageSize: 3 });

        var localColumns = [
                    { field: "MyString", title: "MyString" },
                    { field: "MyInt", title: "MyInt" },
                    { field: "MyDecimal", title: "MyDecimal" },
                    { field: "MyFloat", title: "MyFloat" },
                    { field: "FirstName", title: "FirstName" },
                    { field: "LastName", title: "LastName" }
        ];

        // Local readonly data grid with many options explained (some commented out)
        $scope.localDataGridWithSortFilterOptions = function () {
            return {
                dataSource: localDataSource,
                autobind: false, // Seems not to work here - should prevent from initial binding - http://docs.telerik.com/kendo-ui/api/javascript/ui/grid
                scrollable: false,
                sortable: true,
                groupable: false,
                pageable: true, // This provides client side pagination
                filterable: { // This limits the filter criteria. 
                    mode: "row",
                    extra: false,
                    operators: {
                        string: {
                            startswith: "Starts with",
                            eq: "Is equal to",
                            neq: "Is not equal to",
                            contains: "Contains",
                            doesnotcontain: "Does not contain",
                            endswith: "Ends with"                            
                        }
                        // For other data types' operators, drill down into the data type in this document:
                        // http://docs.telerik.com/kendo-ui/api/jsp/grid/filterable-operators
                    }
                },
                
                columns: [
                    {field: "MyString", title: "My String"}, 
                    {field: "MyInt", title: "My Int"},
                    {field: "MyDecimal", title: "My Decimal"},
                    {field: "MyFloat", title: "My Float"},
                    {field: "FirstName", title: "First Name"},
                    {field: "LastName", title: "Last Name"}
                ]
            };
        };


        // Local editable data grid with just edit/delete functionality, local data
        $scope.localEditableDataGridOptions = function () {
            return {
                dataSource: localDataSource,
                editable: "inline", // Add capability to edit/delete
                columns: [
                    {field: "MyString", title: "My String"}, 
                    {field: "MyInt", title: "My Int"},
                    {field: "MyDecimal", title: "My Decimal"},
                    {field: "MyFloat", title: "My Float"},
                    {field: "FirstName", title: "First Name"},
                    {field: "LastName", title: "Last Name"},
                    { command: ["edit", "destroy"] } // Button for edit/delete
                    // Note: See http://docs.telerik.com/kendo-ui/api/javascript/ui/grid 
                    // for sample of how to execute custom code on button click
                    // and for sample of how to change button texts
                ]
            };
        };

        // Remote data grid with bare minimum - only columns and datasource configured
        $scope.remoteDataGridOptions = function () {
            return {
                dataSource:
                    {
                    type: "odata",
                    transport: {
                        //read: function (options) {
                        //    options.success(options.data); // where data is the local data array
                        //},
                        read: "http://demos.telerik.com/kendo-ui/service/Northwind.svc/Customers"
                    },
                    serverPaging: true,
                    serverSorting: true,
                    serverFiltering: true,
                    pageSize: 5
                },
                columns: [{
                    field: "ContactName",
                    title: "Contact Name",
                    width: 200
                }, {
                    field: "ContactTitle",
                    title: "Contact Title"
                }, {
                    field: "CompanyName",
                    title: "Company Name"
                }, {
                    field: "Country",
                    width: 150
                }]
            };
        };

        // Remote data grid with bare minimum - only columns and datasource configured
        $scope.groupableAggregatedDataGridOptions = function () {
            return {
                dataSource:
                    {
                        type: "odata",
                        transport: {
                            //read: function (options) {
                            //    options.success(options.data); // where data is the local data array
                            //},
                            read: "http://demos.telerik.com/kendo-ui/service/Northwind.svc/Customers"
                        },
                        serverPaging: true,
                        serverSorting: true,
                        serverFiltering: true,
                        pageSize: 5
                    },
                groupable: true,
                columns: [{
                    field: "ContactName",
                    title: "Contact Name",
                    width: 200,
                    groupable: false
                }, {
                    field: "ContactTitle",
                    title: "Contact Title",
                    groupable: false
                }, {
                    field: "CompanyName",
                    title: "Company Name",
                    groupable: false
                }, {
                    field: "Country",
                    width: 150,
                    groupable: true,
                    aggregates: ["count", "min", "max"],
                    groupFooterTemplate: "country total: #: count #, min: #: min #, max: #: max #"
                }]
            };
        };

        var fileUploadDataSource=new kendo.data.DataSource({ data: []});
         // Remote data grid with bare minimum - only columns and datasource configured
        $scope.fileUploadDataGridOptions = function () {
            return {
                dataSource:fileUploadDataSource,
                columns: [{
                    field: "FileName",
                    title: "File Name",
                    width: 200
                }, {
                    field: "FileSize",
                    title: "File Size"
                    },
                   {
                        field: "FileType",
                        title: "File Type"
                        },
                            {
                    field: "UploadedDateTime",
                    title: "Upload Date Time"
                }, ]
            };
    };

        var griddata = [];
        
        $scope.onSelect = function (e) {
            $.map(e.files, function (file) {
                griddata.push(populateGrid(file));
            })
        };
       
        //return the file details for each file passed
        var populateGrid = function (file) {
            return ({ FileName: file.name, FileSize: file.size, FileType: file.extension, UploadedDateTime: new Date().toDateString() +" - "+ new Date().toLocaleTimeString()  });
        }

        $scope.uploadFiles = function (e) {
            fileService.uploadFile(griddata).then(function (response) {
            });

            $.map(griddata, function (data) {
                return fileUploadDataSource.add(data);
            });

            griddata = [];
        }

        $scope.onRemove = function (e) {
            updateGridData(e.files);           
        }

        var updateGridData = function (files) {
            $.map(files, function (f) {
                //on removing a file- delete from grid data so that the file doesn't upload
                var pos = griddata.map(function (x) { return x.FileName }).indexOf(f.name);
                if(pos > -1)
                    griddata.splice(pos, 1);
            })
        }
    };
})();