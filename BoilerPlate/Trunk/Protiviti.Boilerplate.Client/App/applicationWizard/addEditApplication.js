(function () {
    'use strict';
    var controllerId = 'addEditApplication';
    angular.module('app').controller(controllerId, ['$scope', '$routeParams', '$stateParams', 'common', 'dataservice', 'editableOptions', addEditApplication]);

    function addEditApplication($scope, $routeParams, $stateParams, common, dataservice, editableOptions) {

        // Standard initialization
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        dataservice.initialize("ApplicationWizard");

        // Properties
        $scope.news = {
            title: 'Protiviti Boilerplate',
            description: 'Protiviti Boilerplate'
        };
        $scope.application = {};
        $scope.title = 'Add / Edit Application';
        $scope.applicationId = $stateParams.applicationId;

        // Watch methods
        $scope.$watch('application.Name', function (newValue, oldValue) {
            if ((oldValue != undefined) && newValue !== oldValue) {
                $scope.saveApplication();
            }
        });

        // Methods
        $scope.getApplication = function (applicationId) {
            // Clear old criteria before setting up new criteria
            dataservice.clear();

            if (applicationId != null) {
                // Get the application by id
                dataservice.filter = dataservice.getPredicate("Id", dataservice.FilterQueryOp.Equals, applicationId);
            }
            else {
                // Get previously started application
                dataservice.filter = dataservice.getPredicate("Status", dataservice.FilterQueryOp.Equals, "New");
            }

            // Retrieve related entities
            dataservice.expand = 'Program, Applicant, Invoice, Invoice.Payment';

            return dataservice.search('Applications', (function (response) {
                if (response.results != null) {
                    if (response.results.length >= 1)
                        $scope.application = response.results[0];
                }
                else {
                    // Create new application if application does not exists - TODO
                }
            }), (function (error) {
                alert("Error loading application: " + error);
            }));
        }
        $scope.saveApplication = function () {
            return dataservice.saveChanges((function (response) {
                var data = response;
            }), (function (error) {
                alert("Error saving application: " + error);
            }));
        }

        this.activate = function () {
            var promises = [$scope.getApplication($scope.applicationId)];
            common.activateController(promises, controllerId).then(function () {
                log('Activated Add / Edit Application View');
            });
        }

        // Activate current controller
        this.activate();
    }
})();

