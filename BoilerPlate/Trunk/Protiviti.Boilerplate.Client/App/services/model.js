(function () {
    'use strict';

    var serviceId = 'model';

    angular
        .module('app')
        .factory(serviceId, model);

    model.$inject = ['model.validation'];

    function model(modelValidation) {
        var entityNames = {
            initiative: 'Initiative',
            task: 'InitiativeTask',
            person: 'Person'
        };

        var service = {
            entityNames: entityNames,
            configureMetadataStore: configureMetadataStore,
            extendMetadata: extendMetadata
    };

        return service;

        function configureMetadataStore(metadataStore) {
            registerPerson(metadataStore);

            modelValidation.createAndRegister(entityNames);
        }

        function extendMetadata(metadataStore) {
            modelValidation.applyValidators(metadataStore);
        }

        function registerPerson(metadataStore) {
            metadataStore.registerEntityTypeCtor('Person', Person);

            function Person() { }

            Object.defineProperty(Person.prototype, 'FullName', {
                get: function () {
                    var fn = this.FirstName;
                    var ln = this.LastName;
                    return ln ? fn + ' ' + ln : fn;
                }
            });
        }
    }
})();