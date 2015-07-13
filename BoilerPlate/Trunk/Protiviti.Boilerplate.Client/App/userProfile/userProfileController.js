(function () {
    'use strict';
    var controllerId = 'userProfileController';
    angular.module('app').controller(controllerId, ['$rootScope', '$scope', '$location', '$state', 'common', 'datacontext', 'authService', 'userProfileService', 'modalService', userProfileController]);

    function userProfileController($rootScope, $scope, $location, $state, common, datacontext, authService, userProfileService, modalService) {

        //#region log
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var userEmail = authService.currentUser.userName;

        $scope.savedSuccessfully = false;
        $scope.message = "";


        //#endregion

        //#region scope objects / Variables
        $scope.user = {
            oldPassword: "",
            newPassword: "",
            confirmPassword: ""
        };

        $scope.salutations =
           ["Miss",
           "Mr.",
           "Mrs.",
           "Ms."];

        $scope.countries = ["United States", "India"];
        $scope.validationMessage = "";
        //$scope.stateProvinces =
        //   [
        //        { country: "United States", name: "CA" },
        //        { country: "United States", name: "FL" },
        //        { country: "United States", name: "IL" },
        //        { country: "United States", name: "NY" },
        //        { country: "India", name: "New Delhi" },
        //        { country: "India", name: "Mumbai" },
        //        { country: "India", name: "Chennai" },
        //   ];

        //TODO:Shruti- applying filtering to stateprovines as per country
        $scope.states =
           ["CA", "FL", "IL", "NY", "New Delhi", "Mumbai", "Chennai"];


        $scope.save = function (form) {
            $scope.validationMessage = "";
            if (form.$valid) {
                userProfileService.updateUserProfile(getPersonForSave()).then(function (person) {
                    //callback for update    
                    $scope.savedSuccessfully = true;
                    $scope.message = "Changes saved successfully!";
                    
                    authService.user.displayName = $scope.person.firstName + " " + $scope.person.lastName;
                    $rootScope.$broadcast('userLoggedIn');

                },
                        function (_error) {
                            $scope.savedSuccessfully = true;
                            setErrors(_error);
                        });
            }

            else {
                log("Error on Save")
            }
            form.isSubmitted = true;
        };

        $scope.cancel = function () {
            redirectToDashboard();
        };

        //#endregion


        //#region Private Methods

        function setPersonData(_person) {
            return {
                id: _person.Id,
                email: _person.Contact.Email,
                salutation: _person.Salutation,
                firstName: _person.FirstName,
                lastName: _person.LastName,
                suffix: _person.Suffix,
                title: _person.Title,
                contact: {
                    phone: _person.Contact.Phone,
                    fax: _person.Contact.Fax,
                    cell: _person.Contact.Cell
                },
                address: {
                    country: _person.Address.Country,
                    stateProvince: _person.Address.StateProvince,
                    addressLine1: _person.Address.AddressLine1,
                    addressLine2: _person.Address.AddressLine2,
                    cityLocality: _person.Address.CityLocality,
                    postalcode: _person.Address.PostalCode
                }
            }
        }

        function getPersonForSave() {
            //$scope.person.address.stateProvince = $scope.person.address.stateProvince.name;
            return $scope.person;
        }

        function getModelForPassword() {
            return {
                oldPassword: $scope.user.oldPassword,
                newPassword: $scope.user.newPassword,
                confirmPassword: $scope.user.confirmPassword
            }
        }

        function activate() {
            var promises = [loadData()];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Registration View'); });
        }

        function loadData() {
            userProfileService.getUserProfile().then(function (person) {
                $scope.person = setPersonData(person.data);
            });
        }

        function redirectToDashboard() {
            setTimeout(function () { $state.go('dashboard'); }, 200);
        }

        function setErrors(_error) {
            var errors = [];
            if (!angular.isUndefined(_error.data)) {
                for (var key in _error.data.modelState) {
                    for (var i = 0; i < _error.data.modelState[key].length; i++) {
                        errors.push(_error.data.modelState[key][i]);
                    }
                }
            }
            if (!angular.isUndefined(_error.message))
                errors.push(_error.message);

            $scope.message = "Failed to register user: " + errors.join(' ');
        }

        activate();
        //#endregion

    }
})();