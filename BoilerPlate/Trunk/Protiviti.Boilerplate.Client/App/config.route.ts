module Protiviti.Boilerplate.Client.Modules {
    'use strict'
    export class Core {
        private static _name: string = "core";
        public static get Name(): string { return this._name; }
    }

    var app = angular.module(Core.Name, [
        'ngRoute',              // routing
        'ui.router',            // ui-router (advanced AngularJS routing library)
        'common'
    ]);

    // Collect the routes
    app.constant('routes', getUIRouterRoutes());

    // Configure the routes and route resolvers
    app.config(['$urlRouterProvider', '$stateProvider', 'routes',
        ($urlRouterProvider, $stateProvider, routes) => new RouteConfigurator($urlRouterProvider, $stateProvider, routes)]);


    export class RouteConfigurator {
        constructor($urlRouterProvider, $stateProvider, routes) {
            routes.forEach(r => {
                $stateProvider.state(r.state, r);
            });
            $urlRouterProvider.otherwise('/');
        }
    }

    // Define ui-router v0.2.11 routes
    function getUIRouterRoutes() {
        var viewBase = '/Protiviti.Boilerplate.Client/app/';
        return [
            {
                url: '/',
                templateUrl: viewBase + 'dashboard/dashboard.html',
                state: 'dashboard',
                settings: {
                    nav: 1,
                    content: '<i class="fa fa-dashboard"></i> Dashboard'
                }
            },
            {
                url: '/employees',
                templateUrl: viewBase + 'employee/employee.html',
                controller: 'employee',
                state: 'employees',
                access: {
                    loginRequired: true,
                    permissions: ['Member']
                },
                settings: {
                    nav: 3,
                    content: '<i class="fa fa-lock"></i> Employees'
                }
            },
            {
                url: '/employee/:employeeId',
                templateUrl: viewBase + 'employee/addEmployee.html',
                controller: 'employeeEditController',
                state: 'addEmployee',
                access: {
                    loginRequired: true,
                    permissions: ['Member']
                },
                settings: {
                    nav: 2,
                    content: '<i class="fa fa-lock"></i> Admin'
                }
            },
            {
                url: '/initiatives',
                templateUrl: viewBase + 'initiative/initiatives.html',
                // Can pass in 'Controller As' syntax.  No need for ng-controller in view.
                // Reference scope variables in view with alias("vm").
                controller: 'initiatives as vm',
                state: 'initiatives',
                // Gives optional map of dependencies which should be injected into controller
                resolve: {
                    initiativeData: function (initiativeService) {
                        initiativeService.init('CdsInitiatives');
                        return initiativeService.getAll()
                            .then(
                            function (data) { return data; },
                            function (error) { alert('Error: ' + error); }
                            );
                    }
                },
                settings: {
                    nav: 3,
                    content: '<i class="fa fa-lock"></i> Nav Demo'
                }
            },
            {
                url: '/{initiativeId:[0-9]{1,4}}',
                templateUrl: viewBase + 'initiative/initiatives.detail.html',
                state: 'initiatives.detail',
                // Objects belonging to the parent view can be injected into nested view (initiativeData).
                controller: ['$scope', '$stateParams', 'common', 'initiativeData',
                    function ($scope, $stateParams, common, initiativeData) {
                        $scope.initiative = common.findById(initiativeData, $stateParams.initiativeId);
                    }],
                settings: {}
            },
            {
                url: '/{taskId}',
                templateUrl: viewBase + 'initiative/initiatives.detail.task.html',
                state: 'initiatives.detail.task',
                controller: ['$scope', '$stateParams', 'common', 'contacts',
                    function ($scope, $stateParams, common, contacts) {
                        $scope.task = common.findById($scope.initiative.Tasks, $stateParams.taskId);
                        $scope.contacts = contacts;
                    }],
                resolve: {
                    contacts: function (dataservice) {
                        dataservice.clear();
                        return dataservice.getAll('Persons', success, failure);

                        function success(data) {
                            return data.results;
                        }

                        function failure(error) {
                            alert('Error: ' + error);
                        }
                    }
                },
                settings: {}
            }, {
                url: '/gridDemo',
                templateUrl: viewBase + 'kendo/gridDemo.html',
                state: 'gridDemo',
                controller: 'gridDemoController',
                settings: {
                    nav: 3,
                    content: '<i class="fa fa-lock"></i> Grid Demo'
                }
            }, {
                url: '/dataGrid',
                templateUrl: viewBase + 'kendo/dataGrid.html',
                state: 'dataGrid',
                //access: {
                //    loginRequired: false,
                //    permissions: ['Admin']
                //},
                controller: 'dataGridController',
                settings: {
                    nav: 3,
                    content: '<i class="fa fa-lock"></i> Data Grid'
                }
            }, {
                url: '/login/{redirect}',
                templateUrl: viewBase + 'authentication/html/login.html',
                state: 'login',
                controller: 'loginController',
                settings: {
                    nav: 4,
                    content: '<i class="fa fa-lock"></i> Login'
                }
            },
            {
                url: '/signup',
                templateUrl: viewBase + 'authentication/html/signup.html',
                state: 'signup',
                settings: {
                    nav: 5,
                    content: '<i class="fa fa-lock"></i> Signup'
                }
            },
            {
                url: '/programs',
                templateUrl: viewBase + 'applicationwizard/program.html',
                state: 'programs',
                controller: 'program',
                settings: {
                    nav: 6,
                    content: '<i class="fa fa-lock"></i> Programs'
                }
            },
            {
                url: '/applications',
                templateUrl: viewBase + 'applicationwizard/application.html',
                state: 'applications',
                controller: 'application',
                settings: {
                    content: '<i class="fa fa-lock"></i> Applications'
                }
            },
            {
                url: '/application/applicationId=:applicationId',
                templateUrl: viewBase + 'applicationwizard/addEditApplication.html',
                state: 'addEditApplication',
                controller: 'addEditApplication'
            },
            {
                url: '/registration',
                templateUrl: viewBase + 'registration/registration.html',
                state: 'registration',
                settings: {
                    nav: 7,
                    content: '<i class="fa fa-lock"></i> Registration'
                }
            },
            {
                url: '/serverquerygrid',
                templateUrl: viewBase + 'applicationwizard/serverQueryGrid.html',
                state: 'serverquerygrid',
                controller: 'serverquerygrid',
                settings: {
                    nav: 6,
                    content: '<i class="fa fa-lock"></i> Server Side Paging'
                }
            },
            {
                url: '/clicktoedit',
                templateUrl: viewBase + 'clickToEdit/clickToEdit.html',
                state: 'clicktoedit',
                controller: 'clicktoedit',
            },
            {
                url: '/fulltextsearch',
                templateUrl: viewBase + 'fullTextSearch/fullTextSearch.html',
                state: 'fulltextsearch',
                controller: 'fulltextsearch',
            },
            {
                url: '/tracksinfinitescroll',
                templateUrl: viewBase + 'infiniteScroll/tracksInfiniteScroll.html',
                state: 'tracksinfinitescroll',
                controller: 'tracksinfinitescroll',
            },
            {
                url: '/angularytics',
                templateUrl: viewBase + 'analytics/angularytics.html',
                state: 'angularytics',
                controller: 'angularytics',
            },
            {
                url: '/geoautocomplete',
                templateUrl: viewBase + 'autoComplete/geoAutoComplete.html',
                state: 'geoautocomplete',
                controller: 'geoautocomplete',
            },
            {
                url: '/roles',
                templateUrl: viewBase + 'roleManager/html/list.html',
                state: 'roles',
                controller: 'ListRolesController'
            },
            {
                url: '/roles/roleId=:roleId',
                templateUrl: viewBase + 'roleManager/html/edit.html',
                state: 'addEditRole',
                controller: 'EditRoleController'
            },
            {
                url: '/users',
                templateUrl: viewBase + 'userManager/html/list.html',
                state: 'users',
                controller: 'ListUsersController'
            },
            {
                url: '/users/userId=:userId',
                templateUrl: viewBase + 'userManager/html/edit.html',
                state: 'addEditUser',
                controller: 'UpdateUserRolesController'
            },
            {
                url: '/externallogins',
                templateUrl: viewBase + 'userManager/html/listExternalLogins.html',
                state: 'externallogins',
                controller: 'ListExternalLoginsController'
            },
            {
                url: '/associate',
                templateUrl: viewBase + 'authentication/html/associate.html',
                state: 'associate',
                controller: 'associateController'
            },
            {
                url: '/verifycode',
                templateUrl: viewBase + 'authentication/html/verifycode.html',
                state: 'verifycode',
                controller: 'verifyCodeController'
            },         ,
            {
                url: '/not-authorised',
                templateUrl: viewBase + 'authentication/html/not-authorized.html',
                state: '/not-authorised'
            },
            {
                url: '/changeProfile',
                templateUrl: viewBase + 'userProfile/userProfile.html',
                state: 'changeProfile',
                controller: 'userProfileController'
            },
            {
                url: '/changePassword',
                templateUrl: viewBase + 'userProfile/userPassword.html',
                state: 'changePassword',
                controller: 'changePasswordController'
            },
            {
                url: '/angularFileUpload',
                templateUrl: viewBase + 'fileupload/html/angularfileupload.html',
                state: 'angularFileUpload',
                controller: 'angularFileUploadController'
            }                                 
        ];
    };

}