(function () {
    'use strict';

    var serviceId = 'initiativeService';

    angular
        .module('app')
        .service('initiativeService', initiativeService);

    initiativeService.$inject = ['$q', 'common', 'config', 'dataservice'];

    function initiativeService($q, common, config, dataservice) {
        var logError = common.logger.getLogFn(serviceId, 'error');

        //#region Initiative data
        var initaitivesData = [
             {
                 "id": 1,
                 "name": "Sales",
                 "tasks": [
                 {
                     "id": "a",
                     "name": "Find Proposals",
                     "contact": "Bob Barker"
                 },
                 {
                     "id": "b",
                     "name": "Pitch PSS Value",
                     "contact": "Louise Lane"
                 }
                 ]
             },
                {
                    "id": 2,
                    "name": "Onboarding",
                    "tasks": [
					{
					    "id": "a",
					    "name": "Read Employee Manual",
					    "contact": "Michael Jordan"
					},
					{
					    "id": "b",
					    "name": "Build Sample App",
					    "contact": "Barack Obama"
					},
                    {
                    	"id": "c",
                    	"name": "Online Training",
                    	"contact": "Barack Obama"
                    }
                    ]
                },
                {
                    "id": 3,
                    "name": "Knowledge Base",
                    "tasks": [
					{
					    "id": "a",
					    "name": "Develop Boilerplate Solution",
					    "contact": "George Washington"
					},
					{
					    "id": "b",
					    "name": "Research Emerging Technologies",
					    "contact": "John Adams"
					}
                    ]
                },
                {
                    "id": 4,
                    "name": "Training and Certifications",
                    "tasks": [
					{
					    "id": "a",
					    "name": "Collect Team Certs",
					    "contact": "Grover Cleveland"
					},
					{
					    "id": "b",
					    "name": "Identify Relevant Trainings",
					    "contact": "Thomas Jefferson"
					}
                    ]
                }
        ];
        //#endregion

        var service = {
            init: initializeService,
            getAll: getAll
        };

        return service;

        function getAll() {
            var initiatives;
            dataservice.expand = 'Tasks, Tasks.Contact';
            return dataservice.getAll('Initiatives', success, failure);

            function success(data) {
                dataservice.extendInitiativeMetadata();
                initiatives = data.results;
                return initiatives;
            }

            function failure(error) {
                var msg = config.appErrorPrefix + 'Error retrieving data.' + error.message;
                logError(msg, error);
                throw error;
            }
        }

        function initializeService(serviceName) {
            dataservice.initialize(serviceName);
        }

    }
})();