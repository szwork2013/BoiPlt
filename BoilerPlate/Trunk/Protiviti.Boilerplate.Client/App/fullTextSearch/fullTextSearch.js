(function () {
    'use strict';
    var controllerId = 'fulltextsearch';
    angular.module('app').controller(controllerId, ['$scope', 'common', 'dataservice', fulltextsearch]);

    function fulltextsearch($scope, common, dataservice) {

        // Standard initialization
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        dataservice.initialize("Search");
        dataservice.manager.dataService.hasServerMetadata = false;

        // Properties
        $scope.news = {
            title: 'Protiviti Boilerplate',
            description: 'Protiviti Boilerplate'
        };
        $scope.searchResults = [];
        $scope.title = 'Full Text Search';
        $scope.allowCollapse = "true";
        $scope.filter = "Online Training";

        // Methods
        $scope.getSearchResults = function () {
            // Clear old criteria before setting up new criteria
            dataservice.clear();
            dataservice.filter = $scope.filter;

            return dataservice.search('SearchResults', (function (response) {
                if (response.results != null) {
                    $scope.searchResults = response.results;
                }
            }), (function (error) {
                alert("Error running search: " + error);
            }));
        }

        this.activate = function () {
            var promises = [$scope.getSearchResults()];
            common.activateController(promises, controllerId).then(function () {
                log('Activated Full text Search View');
            });
        }

        // Activate current controller
        this.activate();
    }
})();

