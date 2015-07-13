module Application.Services {
'use strict'
var serviceId = 'fileService';
    angular.module('app').factory(serviceId, ['$http', '$rootScope', 'config', 'common', 'localStorageService',
        ($http, $rootScope, config, common, localStorageService) => new Application.Services.FileService($http, $rootScope, config, common, localStorageService)]);

    export interface IFileService {
        uploadFile(file: any): ng.IPromise<any>;
    }

    export class FileService implements IFileService {
        private config: any;
        private $rootScope: any;
        private common: any;
        private $q: ng.IQService;
        private localStorageService: any;
        private $http: any;

        constructor($http: any, $rootScope: any, config: any, common: any, localStorageService: any) {
            this.$rootScope = $rootScope;
            this.$http = $http;
            this.config = config;
            this.common = common;
            this.$q = common.$q;
            this.localStorageService = localStorageService;           
        }
      
        public uploadFile(file: any): ng.IPromise<any> {
            var _response: any;
            this.$http.post(this.config.remoteApiServiceBase + 'File/UploadFile', file).then(function (response) {
                _response = response;
            });
            return this.$q.when(_response);
        }

        public angularUploadFile(file: any): ng.IPromise<any> {
            var _response: any;
            this.$http.post(this.config.remoteApiServiceBase + 'File/UploadFile', file).then(function (response) {
                _response = response;
            });
            return this.$q.when(_response);
        }

    }

}