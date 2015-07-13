(function () {
    'use strict';
    var controllerId = 'serverquerygrid';
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
        $scope.pagingInfo = {
            page: 1,
            itemsPerPage: 7,
            orderBy: 'Name',
            nameFilter: '',
            totalItems: 100,
            reverse: false
        };

        // Methods
        $scope.searchPrograms = function () {
            // Clear old criteria before setting up new criteria
            dataservice.clear();

            dataservice.filter = dataservice.getPredicate("Name", dataservice.FilterQueryOp.Contains, $scope.pagingInfo.nameFilter);
            if ($scope.pagingInfo.reverse) {
                dataservice.orderBy = $scope.pagingInfo.orderBy + ' desc';
            }
            else {
                dataservice.orderBy = $scope.pagingInfo.orderBy + ' asc';
            }
            dataservice.skip = $scope.pagingInfo.itemsPerPage * ($scope.pagingInfo.page - 1);
            dataservice.take = $scope.pagingInfo.itemsPerPage;
            return dataservice.search('Programs', (function (response) {
                if (response.results != null) {
                    if ((response.results.length == 0) && ($scope.pagingInfo.page > 1)) {
                        $scope.pagingInfo.page = $scope.pagingInfo.page - 1;
                    }
                    else {
                        $scope.programs = response.results;
                    }
                }
            }), (function (error) {
                alert("Error filtering programs: " + error);
            }));
        }
        $scope.sortPrograms = function (orderBy) {
            if (orderBy === $scope.pagingInfo.orderBy) {
                $scope.pagingInfo.reverse = !$scope.pagingInfo.reverse;
            } else {
                $scope.pagingInfo.orderBy = orderBy;
                $scope.pagingInfo.reverse = false;
            }
            $scope.pagingInfo.page = 1;
            $scope.searchPrograms();
        };
        $scope.filterPrograms = function () {
            $scope.pagingInfo.page = 1;
            $scope.searchPrograms();
        }
        $scope.selectFirstPage = function () {
            $scope.pagingInfo.page = 1;
            $scope.searchPrograms();
        };
        $scope.selectPreviosPage = function (page) {
            if ($scope.pagingInfo.page > 1) {
                $scope.pagingInfo.page = $scope.pagingInfo.page - 1;
                $scope.searchPrograms();
            }
        };
        $scope.selectNextPage = function (page) {
            $scope.pagingInfo.page = $scope.pagingInfo.page + 1;
            $scope.searchPrograms();
        };

        this.activate = function () {
            var promises = [$scope.searchPrograms()];
            common.activateController(promises, controllerId).then(function () {
                log('Activated server paging grid View');
            });
        }

        // Activate current controller
        this.activate();
    }
})();

