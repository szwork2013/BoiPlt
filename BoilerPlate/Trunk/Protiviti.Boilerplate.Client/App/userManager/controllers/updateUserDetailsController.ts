﻿/// <reference path="../../../scripts/typings/breeze/breeze.d.ts" />

module Protiviti.Boilerplate.Client.Controllers {
    'use strict';
    var controllerId = Modules.UserManager.controllers.updateUserDetails;
    angular.module(Modules.UserManager.Name).controller(controllerId,
        ['$rootScope', '$scope', '$state', '$routeParams', '$stateParams', '$http', 'modalService', 'common', 'authService', 'breeze', 'dataservice', 'config', EditUserController]);

    function EditUserController($rootScope, $scope, $state, $routeParams, $stateParams, $http, modalService, common, authService, breeze, dataservice, config) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var path = '';
        var userId = ($stateParams.userId) ? $stateParams.userId : '';
        // Initialize dataservice with a web api controller
        dataservice.initialize("UserManager", config.remoteApiServiceBase);

        // Properties
        $scope.initializing = true;
        $scope.news = {
            title: 'Protiviti Boilerplate',
            description: 'Protiviti Boilerplate'
        };
        $scope.user = {};
        $scope.roles = [];
        $scope.oldUser = {};
        $scope.selectedRoles = { roles: ['Admin'] };
        $scope.newUser = { Id: '', Name: '' };
        $scope.userId = userId;
        $scope.title = (userId.length <= 0) ? 'Add user' : 'Assign roles to  user';
        $scope.buttonText = (userId.length <= 0) ? 'Add' : 'Update';

        $scope.isExternalLogin = false;
        $scope.savedSuccessfully = false;
        $scope.validationMessage = "";

        $scope.message = '';
        //$scope.showPager = false;

        $scope.back = function () {
            var mgr = dataservice.serviceManager();
            mgr.rejectChanges();
            dataservice.clear();
            if ($scope.isExternalLogin) {
                $state.go('externallogins');
            }
            else {
                $state.go('users');
            }
        }

       // Methods
        $scope.getUser = function (userId) {
            // Clear old criteria before setting up new criteria
            dataservice.clear();
            dataservice.filter = dataservice.getPredicate("UserName", dataservice.FilterQueryOp.Equals, userId);
            // Retrieve related entities
            dataservice.expand = 'Roles,Logins';
            return dataservice.search('Users', (function (response) {
                if (response.results != null && response.results.length >= 1) {
                    if (response.results.length >= 1)
                        $scope.user = response.results[0];
                    $scope.isExternalLogin = (response.results[0].Logins.length > 0 ? true : false);
                    //Load all roles list
                    $http.get(Modules.RoleManager.BaseUrl + '/Roles').then(function (response) {
                        $scope.roles = response.data;
                        $scope.selectExistingRoles();
                    }), (function (error) {
                        //alert("Error saving role: " + error);
                    });
                }
                else {
                    //dataservice.clear();
                    //var mgr = dataservice.serviceManager();

                    //var userType = mgr.metadataStore.getEntityType("IdentityUser");

                    //userType.setProperties({ autoGeneratedKeyType: breeze.AutoGeneratedKeyType.Identity });

                    //$scope.user = mgr.createEntity(userType, { Name: '' });

                }
            }), (function (error) {
                    alert("Error loading user: " + error);
                }));
        }

        $scope.setRole = function (role) {
            var userRoleInfo = {
                Id: $scope.user.Id,
                RoleId: role.Id,
                RoleName: role.Name

            }
            $http.post(Modules.UserManager.BaseUrl + '/UpdateRoles', userRoleInfo).then(function (response) {
                if (response.data.Succeeded == true) {
                    $scope.message = "Role (" + role.Name + ") " + (angular.isDefined(role.Selected) && role.Selected == true ? 'added' : 'removed') + " successfully";
                }

            }), (function (error) {
                $scope.message = error;
                //alert("Error saving user: " + error);
            });
        }

        $scope.selectExistingRoles = function () {
            angular.forEach($scope.roles, function (item) {
                angular.forEach($scope.user.Roles, function (role) {
                    if (item.Id == role.RoleId) {
                        item.Selected = true;
                    }
                });
            });
        }

        $scope.saveUser = function () {
            var newUser = {
                Id: $scope.user.Id,
                Name: $scope.user.Name,
            }
            var data;
            if (userId.length <= 0) {
                $http.post(Modules.UserManager.BaseUrl + '/SaveChanges', newUser).then(function (response) {
                    data = response.data;
                    showSuccessMessage(data);

                }), (function (error) {
                    alert("Error saving user: " + error);
                });
            }
            else {
                $http.put(Modules.UserManager.BaseUrl + '/UpdateUser', newUser).then(function (response) {
                    data = response.data;
                    showSuccessMessage(data);
                }), (function (error) {
                    alert("Error updating user: " + error);
                });
            }                                                  
        }

        $scope.changePwd = function (form) {
            if (form.$valid) {
                var model = getModelForPassword();     
                console.log(model);
                $http.post(config.remoteApiServiceBase + "Account/AdminChangeUserPassword?userId="+ $scope.user.Id.toString(), model).success(function (response: any) {
                    $scope.savedSuccessfully = true;
                    $scope.validationMessage = " User Password Changed Successfully!";                    
                    
                }).error(function (error) {
                    console.log(error);
                    var errors = [];
                    for (var key in error.modelState) {
                        for (var i = 0; i < error.modelState[key].length; i++) {
                            errors.push(error.modelState[key][i]);
                        }
                    }                      
                    $scope.savedSuccessfully = false;
                    $scope.validationMessage = "Failed to register user: " + errors.join(' ');
                    });
;
            }
            else {
                log("Error on Save")
                console.log(form);
            }
            form.isSubmitted = true;
        }

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

        function getModelForPassword() {
            return {
                //oldPassword: $scope.user.oldPassword,
                newPassword: $scope.newPassword,
                confirmPassword: $scope.confirmPassword
            }
        }

        function showSuccessMessage(data) {
            if (data.Succeeded == true) {
                var modalOptions = {
                    actionButtonText: 'Ok',
                    headerText: 'Users ' + (userId.length < 0 ? 'Creation' : 'Updation'),
                    bodyText: 'user ' + (userId.length < 0 ? 'created' : 'updated') + ' successfully'
                };

                modalService.showModal({}, modalOptions).then(function (result) {
                    if (result === 'ok') {
                        $state.go('users');
                    }
                });
            }
            else {
                $scope.errorMessage = data.Errors[0];

            }
        }

        function activate() {
            var promises = [$scope.getUser($scope.userId)];
            $scope.message = "";
            common.activateController(promises, controllerId)
                .then(function () {
                    log('Activated Edit user View');
                });
        }

        activate();
    }
}