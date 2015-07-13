/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../scripts/typings/breeze/breeze.d.ts" />


module Protiviti.Boilerplate.Client.Controllers {
    'use strict';
    var controllerId = 'employeeEditController';
    angular.module('app').controller(controllerId, ['$rootScope', '$window', '$scope', '$location', '$routeParams', '$stateParams',
        '$timeout', '$state', 'config', 'common', 'dataservice', 'modalService', employeeEditController]);

    function employeeEditController($rootScope, $window, $scope, $location, $routeParams, $stateParams, $timeout, $state, config, common, dataservice, modalService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var employeeId = ($stateParams.employeeId) ? parseInt($stateParams.employeeId) : 0, timer, onRouteChangeOff;

        $scope.employee = {};
        $scope.states = [];
        $scope.title = (employeeId > 0) ? 'Edit' : 'Add';
        $scope.buttonText = (employeeId > 0) ? 'Update' : 'Add';
        $scope.updateStatus = false;
        $scope.message = "";
        $scope.savedSuccessfully = false;
        // Initialize dataservice with a web api controller
        dataservice.initialize("Employee", config.remoteApiServiceBase);

        // Properties
        $scope.initializing = true;
        $scope.news = {
            title: 'Protiviti Boilerplate',
            description: 'Protiviti Boilerplate'
        };

        $scope.isStateSelected = function (employeeStateId, stateId) {
            return employeeStateId === stateId;
        };

        $scope.saveEmployee = function () {
            if ($scope.editForm.$valid) {
                dataservice.saveChanges().then(function (response) {
                    $scope.savedSuccessfully = true;
                    if (employeeId > 0) {
                        $scope.message = 'Employee updated successfully.';
                    }
                    else {
                        $scope.message = 'Employee added successfully. You will be redirected to main list in 2 secs.';
                        startTimer();
                    }
                }), (function (error) {
                    $scope.savedSuccessfully = false;
                    $scope.message = error;
                });
            }
        };

        $scope.back = function () {
            var mgr = dataservice.serviceManager();
            mgr.rejectChanges();
            dataservice.clear();
            $state.go('employees');
        }

        // Methods
        $scope.init = function (employeeId) {
            // Clear old criteria before setting up new criteria
            dataservice.clear();
            dataservice.expand = 'Division,Designation';
            dataservice.filter = dataservice.getPredicate("ID", dataservice.FilterQueryOp.Equals, employeeId);
            // Retrieve related entities

            return dataservice.search('Employees', (function (response) {
                if (response.results != null && response.results.length >= 1) {
                    $scope.employee = response.results[0];
                }
                else {
                    var mgr = dataservice.serviceManager();
                    dataservice.getMetadata().then(function () {
                        $scope.employee = mgr.createEntity('Employee', { FirstName: '', LastName: '', IsActive: true });
                    });

                }
            }), (function (error) {
                    alert("Error loading employee: " + error);
                }));
        }


        var startTimer = function () {
            var timer = $timeout(function () {
                $timeout.cancel(timer);
                $state.go('employees');
            }, 2000);
        }

        function activate() {
            var promises = [$scope.init(employeeId)];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Employee Add View'); });
        }

        activate();

    }
}