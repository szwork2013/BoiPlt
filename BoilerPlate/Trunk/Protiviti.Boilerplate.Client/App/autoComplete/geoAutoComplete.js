(function () {
    'use strict';
    var controllerId = 'geoautocomplete';
    angular.module('app').controller(controllerId, ['$scope', 'common', 'dataservice', geoAutoComplete]);

    function geoAutoComplete($scope, common, dataservice) {

        // Standard initialization
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        this.activate = function () {
            var promises = [];
            common.activateController(promises, controllerId).then(function () {
                log('Activated Geo Auto Complete View');
            });
        }

        // Activate current controller
        this.activate();
    }
})();
