(function () {
    'use strict';

    var controllerId = 'initiatives';

    angular
        .module('app')
        .controller(controllerId, initiatives);

    initiatives.$inject = ['common', 'dataservice', 'initiativeData'];

    function initiatives(common, dataservice, initiativeData) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'CDS Initiatives';
        vm.initiatives = initiativeData;
        vm.toggleSidebar = toggleSidebar;
        vm.save = save;

        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logSuccess = getLogFn(serviceId, 'success');
        var logError = getLogFn(serviceId, 'error');

        activate();

        function activate() {
            var promises = [];
            common.activateController(promises, controllerId)
                .then(function() {
                 log('Activated Initiatives View');
            });
        }


        function save() {
            return dataservice.saveChanges(function(result) {
                logSuccess('Saved data', result, true);
            });
        };

        function toggleSidebar() {
                $(".wrapper").toggleClass("toggled");
        };


    }
})();
