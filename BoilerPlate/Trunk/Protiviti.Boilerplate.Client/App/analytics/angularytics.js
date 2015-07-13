(function () {
    'use strict';
    var controllerId = 'angularytics';
    angular.module('app').controller(controllerId, ['$scope', 'common', 'dataservice', angularytics]);

    function angularytics($scope, common, dataservice) {

        // Standard initialization
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        this.activate = function () {
            var promises = [];
            common.activateController(promises, controllerId).then(function () {
                log('Activated Angularytics View');
            });
        }

        // Activate current controller
        this.activate();
    }
})();
