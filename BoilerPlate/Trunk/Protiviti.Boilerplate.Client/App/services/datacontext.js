var serviceId = 'datacontext';
angular.module('app').factory(serviceId, ['$window', 'common', 'config', 'entityManagerFactory', function ($window, common, config, emFactory) {
        return new Application.Services.Datacontext($window, common, config, emFactory);
    }]);

var Application;
(function (Application) {
    (function (Services) {
        var Datacontext = (function () {
            function Datacontext($window, common, config, emFactory) {
                this.EntityQuery = breeze.EntityQuery;
                this.executeQuery = function (query, takeFirst) {
                    var window = this.$window;
                    return query.using(this.manager).execute().then(querySuccess, queryError);

                    function querySuccess(data, status, headers) {
                        return takeFirst ? data.results[0] : data.results;
                    }

                    function queryError(error) {
                        window.alert(error.message);
                    }
                };
                this.common = common;
                this.config = config;
                this.$window = $window;
                this.$q = common.$q;
                this.manager = emFactory.newManager();
            }
            Datacontext.prototype.getMetadata = function () {
                if (!this.manager.metadataStore.hasMetadataFor(this.config.remoteApiServiceBase)) {
                    return this.common.$q.when(this.manager.metadataStore.fetchMetadata(this.config.remoteApiServiceBase));
                }
                return this.common.$q.when(true);
            };

            Datacontext.prototype.getPeople = function () {
                var people = [
                    { firstName: 'Ajay', lastName: 'Singh', division: 'PSS', location: 'India' },
                    { firstName: 'Alok', lastName: 'Gupta', division: 'PSS', location: 'Chicago' },
                    { firstName: 'Ajay', lastName: 'Singh', division: 'PSS', location: 'India' },
                    { firstName: 'Ajay', lastName: 'Singh', division: 'PSS', location: 'India' }
                ];
                return this.$q.when(people);
            };

            Datacontext.prototype.getImplementedTechnologies = function () {
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
                    { name: 'Katana', url: 'http://katanaproject.codeplex.com/' }
                ];
                return this.$q.when(implementedTechnologies);
            };
            Datacontext.prototype.getUpcomingTechnologies = function () {
                var upcomingTechnologies = [
                    { name: 'Signalr', url: 'http://www.asp.net/signalr' }
                ];
                return this.$q.when(upcomingTechnologies);
            };

            Datacontext.prototype.getPatterns = function () {
                var patterns = [
                    { name: 'Repository', url: '' },
                    { name: 'Unit Of Work', url: '' }
                ];
                return this.$q.when(patterns);
            };
            Datacontext.prototype.getChangesCount = function () {
                return this.manager.getChanges().length;
            };
            Datacontext.prototype.getHasChanges = function () {
                return this.manager.hasChanges();
            };
            return Datacontext;
        })();
        Services.Datacontext = Datacontext;
    })(Application.Services || (Application.Services = {}));
    var Services = Application.Services;
})(Application || (Application = {}));
//# sourceMappingURL=datacontext.js.map
