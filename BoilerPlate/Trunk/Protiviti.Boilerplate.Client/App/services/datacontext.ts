/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
var serviceId = 'datacontext';
angular.module('app').factory(serviceId, ['$window', 'common', 'config', 'entityManagerFactory', ($window, common, config, emFactory) => new Application.Services.Datacontext($window, common, config, emFactory)]);

module Application.Services {

    export interface IDatacontext {
        getPeople(): ng.IPromise<any>;
        getHasChanges(): ng.IPromise<boolean>;
        getImplementedTechnologies(): ng.IPromise<any>;
        getUpcomingTechnologies(): ng.IPromise<any>;
        getPatterns(): ng.IPromise<any>;
    }

    export class Datacontext implements IDatacontext {

        private common: any;
        private config: any;
        private $window: any;
        private $q: ng.IQService;
        private manager: any;
        private EntityQuery = breeze.EntityQuery;

        constructor($window: any, common: any, config: any, emFactory: any) {
            this.common = common;
            this.config = config;
            this.$window = $window;
            this.$q = common.$q;
            this.manager = emFactory.newManager();
        }


        executeQuery = function (query, takeFirst) {
            var window = this.$window;
            return query.using(this.manager).execute().then(querySuccess, queryError);

            function querySuccess(data, status, headers) {
                return takeFirst ? data.results[0] : data.results;
            }

            function queryError(error) {
                window.alert(error.message);
            }
        }

       getMetadata(): ng.IPromise<any> {
            if (!this.manager.metadataStore.hasMetadataFor(this.config.remoteApiServiceBase)) {
                return this.common.$q.when(this.manager.metadataStore.fetchMetadata(this.config.remoteApiServiceBase));
            }
            return this.common.$q.when(true);
        }

        public getPeople(): ng.IPromise<any> {
            var people = [
                { firstName: 'Ajay', lastName: 'Singh', division: 'PSS', location: 'India' },
                { firstName: 'Alok', lastName: 'Gupta', division: 'PSS', location: 'Chicago' },
                { firstName: 'Ajay', lastName: 'Singh', division: 'PSS', location: 'India' },
                { firstName: 'Ajay', lastName: 'Singh', division: 'PSS', location: 'India' },
            ];
            return this.$q.when(people);
        }

        public getImplementedTechnologies(): ng.IPromise<any> {
            var implementedTechnologies = [
                { name: 'Entity Framework', url: 'http://www.asp.net/entity-framework' },
                { name: 'AngularJs', url: 'http://www.angularjs.org' },
                { name: 'Breezejs', url: 'http://www.breezejs.com' },
                { name: 'Bootstrap', url: 'http://getbootstrap.com/' },
                { name: 'Asp.Net WebApi (CORS, Attribute Routing)', url: 'http://www.asp.net/web-api' },
                { name: 'Semantic Logging', url: 'http://msdn.microsoft.com/en-us/library/dn440729(v=pandp.60).aspx' },
                { name: 'Typescript', url: 'http://www.typescriptlang.org/' },
                { name: 'Asp.Net Identity', url: 'http://www.asp.net/identity' },
                { name: 'Owin', url: 'http://owin.org/' },
                { name: 'Katana', url: 'http://katanaproject.codeplex.com/' },
            ];
            return this.$q.when(implementedTechnologies);
        }
        public getUpcomingTechnologies(): ng.IPromise<any> {
            var upcomingTechnologies = [
                { name: 'Signalr', url: 'http://www.asp.net/signalr' },
            ];
            return this.$q.when(upcomingTechnologies);
        }

        public getPatterns(): ng.IPromise<any> {
            var patterns = [
                { name: 'Repository', url: '' },
                { name: 'Unit Of Work', url: '' },
            ];
            return this.$q.when(patterns);
        }
        private getChangesCount() {
            return this.manager.getChanges().length;
        }
        public getHasChanges(): ng.IPromise<boolean> {
            return this.manager.hasChanges();
        }


    }
}