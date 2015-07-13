(function () {
    'use strict';
    var controllerId = 'registrationController';
    angular.module('app').controller(controllerId, ['$rootScope', '$scope', '$location', '$state', 'common', 'datacontext', 'authService', 'modalService', registrationController]);

    function registrationController($rootScope, $scope, $location, $state, common, datacontext, authService, modalService) {

        //#region log

        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        activate();

        //#endregion

        //#region scope objects / Variables

        $scope.isInEditMode = true;

        $scope.salutations =
            ["Miss",
            "Mr.",
            "Mrs.",
            "Ms."];

        $scope.countries = ["United States", "India"];

        $scope.stateProvinces =
           [
                { country: "United States", name: "CA" },
                { country: "United States", name: "FL" },
                { country: "United States", name: "IL" },
                { country: "United States", name: "NY" },
                { country: "India", name: "New Delhi" },
                { country: "India", name: "Mumbai" },
                { country: "India", name: "Chennai" },
           ];

        $scope.register = {
            isSubmitted: false,
            email: "",
            confirmEmail: "",
            password: "",
            confirmPassword: "",
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

        $scope.validationMessage = [];
        //#endregion

        //#region Public Methods

        $scope.submit = function (form) {
            $scope.validationMessage = "";
            if (form.$valid) {
                var registerModel = getRegisterModel();

                authService.saveRegistration(registerModel);
            }
            else {
                registrationFailed();
            }
            form.isSubmitted = true;
            return false;
        };

        $scope.cancel = function () {
            location.reload();
        };

        $scope.$on('registerationValidationError', function (event, response) {
            var errors = [];
            //for (var key in response.data.modelState) {
            //    for (var i = 0; i < response.data.modelState[key].length; i++) {
            //        errors.push(response.data.modelState[key][i]);
            //    }
            //}

            for (var key in response.modelState) {
                for (var i = 0; i < response.modelState[key].length; i++) {
                    errors.push(response.modelState[key][i]);
                }
            }

            if (!angular.isUndefined(response.message))
                errors.push(response.message);

            $scope.validationMessage = "Failed to register user: " + errors.join(' ');

        });

        //#endregion

        //#region Private Methods

        function getRegisterModel() {
            return {
                email: $scope.register.email,
                password: $scope.register.password,
                confirmPassword: $scope.register.confirmPassword,
                displayName: $scope.register.firstName + " " + $scope.register.lastName,
                person: {
                    email: $scope.register.email,
                    confirmEmail: $scope.register.confirmEmail,
                    password: $scope.register.password,
                    confirmPassword: $scope.register.confirmPassword,
                    salutation: $scope.register.salutation,
                    firstName: $scope.register.firstName,
                    lastName: $scope.register.lastName,
                    suffix: $scope.register.suffix,
                    title: $scope.register.title,
                    userName: $scope.register.email,
                    contact: {
                        email: $scope.register.email,
                        phone: $scope.register.phone,
                        fax: $scope.register.fax,
                        cell: $scope.register.cell
                    },
                    address: {
                        country: $scope.register.address.country,
                        stateProvince: $scope.register.address.stateProvince.name,
                        addressLine1: $scope.register.address.addressLine1,
                        addressLine2: $scope.register.address.addressLine2,
                        cityLocality: $scope.register.address.city,
                        postalcode: $scope.register.address.postalcode
                    }
                }
            }
        }

        function setAuthorization(displayName) {
            $scope.authentication = authService.authentication();
            $scope.authentication.isAuth = true;
            $scope.authentication.displayName = displayName;
            $rootScope.$broadcast('loginStatusChanged');
            registrationSuccessful();
        }

        function redirectToLogin() {
            setTimeout(function () { $state.go('login'); }, 2000);
        }


        function activate() {
            var promises = [];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Registration View'); });
        }


        function registrationSuccessful() {
            log('Registration was successful');
        }

        function registrationFailed() {
            log('[Error] Registrtion was unsuccessful');
        }

        //#endregion
    }
})();