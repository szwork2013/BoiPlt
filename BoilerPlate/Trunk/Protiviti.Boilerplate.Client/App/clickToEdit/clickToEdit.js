(function () {
    'use strict';
    var controllerId = 'clicktoedit';
    angular.module('app').controller(controllerId, ['$scope', 'common', 'dataservice', 'editableOptions', clicktoedit]);

    function clicktoedit($scope, common, dataservice, editableOptions) {

        // Standard initialization
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        $scope.user = {
            email: 'alok.gupta@protiviti.com',
            tel: '630-209-4861',
            number: 29,
            range: 10,
            url: 'http://www.protiviti.com',
            search: 'Custom Development',
            color: '#6a4415',
            date: null,
            time: '12:30',
            datetime: null,
            month: null,
            week: null
        };

        this.activate = function () {
            var promises = [];
            common.activateController(promises, controllerId).then(function () {
                log('Activated Click to Edit View');
            });
        }

        // Activate current controller
        this.activate();
    }
})();
