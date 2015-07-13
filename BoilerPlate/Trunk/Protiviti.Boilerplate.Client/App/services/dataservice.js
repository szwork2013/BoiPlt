(function () {
    'use strict';
    var serviceId = 'dataservice';
    angular.module('app').factory(serviceId, ['common', 'breeze', 'config', 'model', function (common, breeze, config, model) { return new dataservice(common, breeze, config, model); }]);

    function dataservice(common, breeze, config, model) {
        var entityNames = model.entityNames;
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(serviceId);
        var logError = getLogFn(serviceId, 'error');
        var logSuccess = getLogFn(serviceId, 'success');
        // Standard initialization
        this.common = common;
        this.FilterQueryOp = breeze.FilterQueryOp;
        this.dataserviceserveraddress = '/Protiviti.Boilerplate.Server/breeze/';

        // Initializes breeze entity manager and entity query
        this.initialize = function (dataservicename, baseUrl) {
            var self = this;
            this.dataserviceaddress = (baseUrl != null ? baseUrl : this.dataserviceserveraddress) + dataservicename;
            this.manager = new breeze.EntityManager({
                dataService: new breeze.DataService({
                    serviceName: this.dataserviceaddress,
                    hasServerMetadata: true
                }),
                metadataStore: createMetaDataStore()
            });
            this.query = breeze.EntityQuery;
        };

        this.serviceManager = function () {
            return this.manager;
        }

        function createMetaDataStore() {
            var store = new breeze.MetadataStore({ namingConvention: breeze.NamingConvention.none });
            model.configureMetadataStore(store);
            return store;
        }

        // Clears old criteria
        this.clear = function () {
            this.filter = null;
            this.orderBy = null;
            this.select = null;
            this.skip = null;
            this.take = null;
            this.expand = null;
        }

        // Create a new predicate
        this.getPredicate = function (property, operator, value) {
            return new breeze.Predicate(property, operator, value);
        }

        // Fetches all entities of a type
        this.get = function (entityName, success, failure) {
            var query = this.query.from(entityName);
            return this.executeQuery(query, success, failure);
        };

        this.getAll = function (entityName, success, failure) {
            var _query = this.query.from(entityName);

            if (this.expand) {
                _query = _query.expand(this.expand);
            }

            return _query
                .using(this.manager).execute()
                .then(success, failure);
        }

        // Searches entities for a given set of criteria
        this.search = function (entityName, success, failure) {
            var query = this.query.from(entityName);
            if (this.filter != null) {
                query = query.where(this.filter);
            }
            if (this.orderBy != null) {
                query = query.orderBy(this.orderBy);
            }
            if (this.select != null) {
                query = query.select(this.select);
            }
            if (this.skip != null) {
                query = query.skip(this.skip);
            }
            if (this.take != null) {
                query = query.take(this.take);
            }
            if (this.expand != null) {
                query = query.expand(this.expand);
            }

            return this.executeQuery(query, success, failure);
        };

        // Saves changes
        this.saveChanges = function (success, failure) {
            if (this.manager.hasChanges()) {
                return this.manager.saveChanges().then(success, failure || saveFailed);
            }
            function saveFailed(error) {
                var msg = config.appErrorPrefix + 'Save failed: ' +
                    breeze.saveErrorMessageService.getErrorMessage(error);
                error.message = msg;
                logError(msg, error);
                throw error;
            }
        };

        // Helper methods
        this.executeQuery = function (query, success, failure) {
            if (this.manager.dataService.hasServerMetadata)
                return this.getMetadata().then(query.using(this.manager).execute().then(success).catch(failure));
            else
                return query.using(this.manager).execute().then(success).catch(failure);
        };

        this.getMetadata = function () {
            if (!this.manager.metadataStore.hasMetadataFor(this.dataserviceaddress)) {
                return this.common.$q.when(this.manager.metadataStore.fetchMetadata(this.dataserviceaddress));
            }
            return this.common.$q.when(true);
        };


        // Wait to call until entityTypes are loaded in metadata
        function registerResourceNames(metadataStore) {
            var types = metadataStore.getEntityTypes();
            types.forEach(function (type) {
                if (type instanceof breeze.EntityType) {
                    set(type.shortName, type);
                }
            });

            //In case we reuse Person model object and name the Person something else like "Contact" or "User" in the model.
            var personEntityName = entityNames.person;
            ['Contact'].forEach(function (r) {
                set(r, personEntityName);
            });

            function set(resourceName, entityName) {
                metadataStore.setEntityTypeForResourceName(resourceName, entityName);
            }
        }

        this.extendInitiativeMetadata = function () {
            model.extendMetadata(this.manager.metadataStore);
            registerResourceNames(this.manager.metadataStore);
        }
    }
})();
