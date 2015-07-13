(function () {
    'use strict';
    var controllerId = 'tracksinfinitescroll';
    angular.module('app').controller(controllerId, ['$scope', 'common', 'dataservice', tracksInfiniteScroll]);

    function tracksInfiniteScroll($scope, common, dataservice) {

        // Standard initialization
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        dataservice.initialize("Album");

        // Properties
        $scope.news = {
            title: 'Protiviti Boilerplate',
            description: 'Protiviti Boilerplate'
        };
        $scope.tracks = [];
        $scope.title = 'Infinite Scroll and Second Level Cache';
        $scope.pagingInfo = {
            page: 1,
            itemsPerPage: 5,
            lastPage: false,
            orderBy: 'ArtistName',
            busy: false
        };

        // Methods
        $scope.getTracks = function () {

            if ($scope.lastPage) return;
            if ($scope.busy) return;
            $scope.busy = true;

            // Clear old criteria before setting up new criteria
            dataservice.clear();
            dataservice.skip = $scope.pagingInfo.itemsPerPage * ($scope.pagingInfo.page - 1);
            dataservice.take = $scope.pagingInfo.itemsPerPage;
            dataservice.orderBy = $scope.pagingInfo.orderBy + ' asc'

            return dataservice.search('Tracks', (function (response) {
                if (response.results != null) {
                    if ((response.results.length == 0) && ($scope.pagingInfo.page > 1)) {
                        $scope.lastPage = true;
                    }
                    else {
                        $scope.pagingInfo.page = $scope.pagingInfo.page + 1;
                        var results = response.results;
                        for (var i = 0; i < results.length; i++) {
                            $scope.tracks.push(results[i]);
                        }
                    }

                    $scope.busy = false;
                }
            }), (function (error) {
                alert("Error running search: " + error);
            }));
        }

        this.activate = function () {
            var promises = [$scope.getTracks()];
            common.activateController(promises, controllerId).then(function () {
                log('Activated Infinite Scroll and Second Level Cache View');
            });
        }

        // Activate current controller
        this.activate();
    }
})();

