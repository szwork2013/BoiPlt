var Application;
(function (Application) {
    (function (Services) {
        'use strict';
        var serviceId = 'fileService';
        angular.module('app').factory(serviceId, [
            '$http', '$rootScope', 'config', 'common', 'localStorageService',
            function ($http, $rootScope, config, common, localStorageService) {
                return new Application.Services.FileService($http, $rootScope, config, common, localStorageService);
            }]);

        var FileService = (function () {
            function FileService($http, $rootScope, config, common, localStorageService) {
                this.$rootScope = $rootScope;
                this.$http = $http;
                this.config = config;
                this.common = common;
                this.$q = common.$q;
                this.localStorageService = localStorageService;
            }
            FileService.prototype.uploadFile = function (file) {
                var _response;
                this.$http.post(this.config.remoteApiServiceBase + 'File/UploadFile', file).then(function (response) {
                    _response = response;
                });
                return this.$q.when(_response);
            };

            FileService.prototype.angularUploadFile = function (file) {
                var _response;
                this.$http.post(this.config.remoteApiServiceBase + 'File/UploadFile', file).then(function (response) {
                    _response = response;
                });
                return this.$q.when(_response);
            };
            return FileService;
        })();
        Services.FileService = FileService;
    })(Application.Services || (Application.Services = {}));
    var Services = Application.Services;
})(Application || (Application = {}));
//# sourceMappingURL=fileService.js.map
