(function () {
    'use strict';
    var controllerId = 'application';
    angular.module('app').controller(controllerId, ['$scope', 'common', 'dataservice', application]);

    function application($scope, common, dataservice) {

        // Standard initialization
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        dataservice.initialize("ApplicationWizard");

        // Properties
        $scope.news = {
            title: 'Protiviti Boilerplate',
            description: 'Protiviti Boilerplate'
        };
        $scope.applications = [];
        $scope.title = 'Applications';
        $scope.allowCollapse = "true";

        // Methods
        $scope.getApplications = function () {
            // Clear old criteria before setting up new criteria
            dataservice.clear();

            // Retrieve related entities
            dataservice.expand = 'Program, Applicant, Invoice, Invoice.Payment';

            return dataservice.search('Applications', (function (response) {
                if (response.results != null) {
                    $scope.applications = response.results;
                }
            }), (function (error) {
                alert("Error loading applications: " + error);
            }));
        }

        this.activate = function () {
            var promises = [$scope.getApplications()];
            common.activateController(promises, controllerId).then(function () {
                log('Activated Application View');
            });
        }

        // Activate current controller
        this.activate();
    }
})();

