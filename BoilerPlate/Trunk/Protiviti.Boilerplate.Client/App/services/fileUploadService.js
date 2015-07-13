(function () {
    'use strict';
    var serviceId = 'fileUploadService';
    angular.module('app').factory(serviceId, [
           '$http', '$rootScope', 'config', 'common',
           function ($http, $rootScope, config, common) {
               return new fileUploadService($http, $rootScope, config, common);
           }]);

    function fileUploadService($http, $rootScope, config, common) {
        this.$rootScope = $rootScope;
        this.$http = $http;
        this.config = config;
        this.common = common;
        this.$q = common.$q;

        this.angularUploadFile = function (file) {
            return this.$http.post(this.config.remoteApiServiceBase + 'file/uploadFile' , file);
        }

        this.getUploadedFiles = function (file) {
            return this.$http.get(this.config.remoteApiServiceBase + 'file/getUploadedFiles');
        }

        this.deleteFile = function (id) {
            return this.$http.post(this.config.remoteApiServiceBase + 'file/deleteFile?id='+ id);
        }

        this.editFile = function (editedFile) {
            return this.$http.post(this.config.remoteApiServiceBase + 'file/editFile', editedFile);
        }
    }
})();
