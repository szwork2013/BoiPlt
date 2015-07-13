(function () {
    'use strict';
    var controllerId = 'dataGridController';
    angular.module('app').controller(controllerId, ['$scope', 'common', dataGrid]);

    function dataGrid($scope, common) {

        // Standard initialization
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        // Properties
        $scope.programsGridDataServiceName = "/Protiviti.Boilerplate.Server/breeze/ApplicationWizard/Programs";
        $scope.odataProgrmasGridDataServiceName = "/Protiviti.Boilerplate.Server/odata/Programs";
        $scope.applicationsGridDataServiceName = "/Protiviti.Boilerplate.Server/breeze/ApplicationWizard/Applications?$expand=Program,Applicant,Invoice,Invoice/Payment";
        $scope.odataApplicationsGridDataServiceName = "/Protiviti.Boilerplate.Server/odata/Applications?$expand=Program,Applicant";
        $scope.applicationsWithCountGridDataServiceName = "/Protiviti.Boilerplate.Server/breeze/ApplicationWizard/ApplicationsWithTotalItemsCount";
        $scope.news = {
            title: 'Protiviti AngularJS POC',
            description: 'Protiviti AngularJS POC'
        };
        $scope.title = 'Programs in Kendo Grid';
        $scope.programsGridColumns = [{
            field: "Name", title: "Program Name", type: "string", width: "30%"
        }, {
            field: "Code", title: "Code", type: "string", width: "20%"
        }, {
            field: "Cost", title: "Cost", type: "number", width: "15%"
        }, {
            field: "Location", title: "Location", type: "string", width: "20%"
        }, {
            field: "Duration", title: "Duration", type: "number", width: "15%"
        }];
        $scope.applicationsGridColumns = [{
            field: "Name", title: "Application Name", type: "string", width: "10%"
        }, {
            field: "Status", title: "Status", type: "string", width: "10%"
        }, {
            field: "Program.Name", title: "Program", type: "string", width: "10%"
        }, {
            field: "Applicant.FirstName", title: "Applicant", type: "string", width: "10%"
        }, {
            field: "Applicant.Email", title: "Email", type: "string", width: "10%"
        }, {
            field: "Applicant.CompanyName", title: "Company", type: "string", width: "10%"
        }, {
            field: "Applicant.Department", title: "Department", type: "string", width: "10%"
        }, {
            field: "Invoice.Amount", title: "Amount", type: "number", width: "10%"
        }, {
            field: "Invoice.Payment.AccountNumber", title: "Account", type: "number", width: "10%"
        }, {
            field: "Invoice.Payment.RoutingNumber", title: "Routing", type: "number", width: "10%"
        }];

        // Methods
        $scope.getProgramsGrid = function () {
            return {
                dataSource: {
                    type: "odata",
                    transport: {
                        read: {
                            url: $scope.programsGridDataServiceName,
                            dataType: "json"
                        },
                        parameterMap: function (options, type) {
                            var paramMap = kendo.data.transports.odata.parameterMap(options);
                            delete paramMap.$inlinecount;
                            delete paramMap.$format;
                            return paramMap;

                        }
                    },
                    schema: {
                        data: function (data) {
                            return data;
                        },
                        total: function (data) {
                            return data.length;
                        }
                    },
                    pageSize: 3
                },
                groupable: true,
                sortable: true,
                filterable: true,
                pageable: true,
                columns: $scope.programsGridColumns
            };
        };

        $scope.getApplicationsGrid = function () {
            return {
                dataSource:
                    {
                        type: "GET",
                        transport: {
                            read: $scope.applicationsGridDataServiceName
                        },
                        pageSize: 3
                    },
                groupable: true,
                sortable: true,
                filterable: true,
                pageable: true,
                columns: $scope.applicationsGridColumns
            };
        };

        $scope.getApplicationsServerPagingGrid = function () {
            return {
                dataSource:
                    {
                        type: "GET",
                        transport: {
                            read: $scope.applicationsWithCountGridDataServiceName
                        },
                        pageSize: 2,
                        serverPaging: true,
                        schema: {
                            data: function (data) {
                                return data.data;
                            },
                            total: function (data) {
                                return data.total;
                            }
                        },
                    },
                groupable: true,
                pageable: true,
                columns: $scope.applicationsGridColumns
            };
        };

        this.activate = function () {
            var promises = [];
            common.activateController(promises, controllerId).then(function () {
                log('Activated Data Grid View');
            });
        }

        // Activate current controller
        this.activate();
    };
})();