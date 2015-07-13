(function () {
    'use strict';
    var controllerId = 'dashboard';
    angular.module('app').controller(controllerId, ['common', 'datacontext', dashboard]);

    function dashboard(common, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: 'Protiviti AngularJS POC',
            description: 'Protiviti AngularJS POC'
        };
        vm.people = [];
        vm.technologies = [];
        vm.upcomingTechnologies = [];
        vm.patterns = [];
        vm.title = 'Dashboard';

        activate();

        function activate() {
            var promises = [getPeople(), getTechnologies(), getUpcomingTechnologies(), getPatterns()];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Dashboard View'); });
        }


        function getPeople() {
            return datacontext.getPeople().then(function (data) {
                return vm.people = data;
            });
        }

        function getTechnologies() {
            return datacontext.getImplementedTechnologies().then(function (data) {
                return vm.technologies = data;
            });
        }
        function getUpcomingTechnologies() {
            return datacontext.getUpcomingTechnologies().then(function (data) {
                return vm.upcomingTechnologies = data;
            });
        }
        function getPatterns() {
            return datacontext.getPatterns().then(function (data) {
                return vm.patterns = data;
            });
        }
    }
})();