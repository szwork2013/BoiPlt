(function () {
    'use strict';
    var controllerId = 'changePasswordController';
    angular.module('app').controller(controllerId, ['$rootScope', '$timeout', '$scope', '$location', '$state', 'common', 'datacontext', 'authService', 'userProfileService', 'modalService', changePasswordController]);

    function changePasswordController($rootScope, $timeout, $scope, $location, $state, common, datacontext, authService, userProfileService, modalService) {

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
        $scope.save = function (form) {
            $scope.message = "";
            if (form.$valid) {

                var model = getModelForPassword();
                if (model.oldPassword == model.newPassword) {
                    var _error = { message: "New Password can not be same as old password." }
                    setErrors(_error);
                }
                else {
                    userProfileService.updateUserPassword(model).then(function (response) {
                        //callback for update password
                        $scope.savedSuccessfully = true;
                        $scope.message = "Password Updated Successfully!. You will redirected to login page in 4 secs for re-login.";
                        authService.logout();
                        startTimer();
                    },
                            function (_error) {
                                $scope.savedSuccessfully = true;
                                setErrors(_error);
                            }
                            );
                }

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
        function getModelForPassword() {
            return {
                oldPassword: $scope.user.oldPassword,
                newPassword: $scope.user.newPassword,
                confirmPassword: $scope.user.confirmPassword
            }
        }

        function activate() {
            var promises = [];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Registration View'); });
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

        var startTimer = function () {
            var timer = $timeout(function () {
                $timeout.cancel(timer);
                $state.go('login');
            }, 4000);
        }

        activate();
        //#endregion

    }
})();