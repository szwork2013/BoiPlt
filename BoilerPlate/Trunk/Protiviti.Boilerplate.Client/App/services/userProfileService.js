(function () {
    'use strict';
    var serviceId = 'userProfileService';
    angular.module('app').factory(serviceId, [
           '$http', '$rootScope', 'config', 'common',
           function ($http, $rootScope, config, common) {
               return new userProfileService($http, $rootScope, config, common);
           }]);

    function userProfileService($http, $rootScope, config, common) {
        this.$rootScope = $rootScope;
        this.$http = $http;
        this.config = config;
        this.common = common;
        this.$q = common.$q;

        //#region Properties

        this.person = {
            email: "",
            salutation: "",
            firstName: "",
            lastName: "",
            suffix: "",
            title: "",
            phone: "",
            fax: "",
            cell: "",
            address: {
                country: "",
                stateProvince: "",
                addressLine1: "",
                addressLine2: "",
                city: "",
                postalcode: ""
            },
            userAgreement: false

        };

        //#endregion

        //#region Load Method

        this.getUserProfile = function () {
            return this.$http.get(this.config.remoteApiServiceBase + 'registration/GetPersonByUserName');
        }

        this.updateUserProfile = function (person) {
            return this.$http.post(this.config.remoteApiServiceBase + 'registration/UpdateUserProfile', person);
        }

        this.updateUserPassword = function (model) {
            return this.$http.post(this.config.remoteApiServiceBase + 'Account/ChangePassword', model);
            }

        //#endregion

        //#region Private Methods

        function setPersonData(_person) {
            return {
                email: _person.UserName,
                confirmEmail: _person.UserName,
               // password: _person.password,
               // confirmPassword: _person.confirmPassword,
                salutation: _person.Salutation,
                firstName: _person.FirstName,
                lastName: _person.LastName,
                suffix: _person.Suffix,
                title: _person.Title,
                phone: _person.Phone,
                fax: _person.Fax,
                cell: _person.Cell,
                address: {
                    country: _person.Address.Country,
                    stateProvince: _person.Address.StateProvince,
                    addressLine1: _person.Address.AddressLine1,
                    addressLine2: _person.Address.AddressLine2,
                    cityLocality: _person.Address.City,
                    postalcode: _person.Address.Postalcode
                }
            }
        }

        //#endregion

    }
})();
