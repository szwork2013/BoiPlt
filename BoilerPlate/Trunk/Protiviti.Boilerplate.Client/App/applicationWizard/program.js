(function () {
    'use strict';
    var controllerId = 'program';
    angular.module('app').controller(controllerId, ['$scope', 'common', 'dataservice', program]);

    function program($scope, common, dataservice) {

        // Standard initialization
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        // Initialize dataservice with a web api controller
        dataservice.initialize("ApplicationWizard");

        // Properties
        $scope.initializing = true;
        $scope.news = {
            title: 'Protiviti Boilerplate',
            description: 'Protiviti Boilerplate'
        };
        $scope.programs = [];
        $scope.title = 'Programs';
        $scope.allowCollapse = "true";
        $scope.nameFilter = '';
        $scope.orderBy = '';
        $scope.orderByOptions = [
              { name: 'Name' },
              { name: 'Code' },
              { name: 'Cost' },
              { name: 'Duration' },
              { name: 'Location' }
        ];

        // Watch methods
        $scope.$watch('nameFilter', function () {
            if (!$scope.initializing) $scope.searchPrograms();
        });
        $scope.$watch('orderBy', function () {
            if (!$scope.initializing) $scope.searchPrograms();
        });

        // Methods
        $scope.getPrograms = function () {
            return dataservice.get('Programs', (function (response) {
                if (response.results != null) {
                    $scope.programs = response.results;
                    $scope.initializing = false;
                }
            }), (function (error) {
                alert("Error loading programs: " + error);
            }));
        }
        $scope.searchPrograms = function () {
            // Clear old criteria before setting up new criteria
            dataservice.clear();

            dataservice.filter = dataservice.getPredicate("Name", dataservice.FilterQueryOp.Contains, $scope.nameFilter);
            dataservice.orderBy = $scope.orderBy.name;
            return dataservice.search('Programs', (function (response) {
                if (response.results != null) {
                    $scope.programs = response.results;
                }
            }), (function (error) {
                alert("Error filtering programs: " + error);
            }));
        }

        this.activate = function () {
            var promises = [$scope.getPrograms()];
            common.activateController(promises, controllerId).then(function () {
                log('Activated Program View');
            });
        }

        // Activate current controller
        this.activate();
    }
})();

