(function () {
    'use strict';

    var serviceId = 'entityManagerFactory';
    angular.module('app').factory(serviceId, ['breeze', 'config', 'common', emFactory]);

    function emFactory(breeze, config, common) {
        // use Web API OData to query and save
        //sbreeze.config.initializeAdapterInstance('dataService', 'webApiOData', true);

        // Convert server-side PascalCase to client-side camelCase property names
        breeze.NamingConvention.camelCase.setAsDefault();
        // Do not validate when we attach a newly created entity to an EntityManager.
        // We could also set this per entityManager
        new breeze.ValidationOptions({ validateOnAttach: false }).setAsDefault();

        var serviceName = config.remoteApiServiceBase;

        var factory = {
            newManager: newManager
        };

        return factory;

        function newManager() {
            var ms = new breeze.MetadataStore();
            var mgr = new breeze.EntityManager({
                serviceName: config.remoteApiServiceBase + 'employee',
                metadataStore: ms
            });
            return mgr;
        }

    }
})();