var Protiviti;
(function (Protiviti) {
    (function (Boilerplate) {
        (function (Client) {
            (function (Modules) {
                'use strict';

                var app = angular.module(Modules.Core.Name);

                app.config([
                    '$provide', function ($provide) {
                        $provide.decorator('$exceptionHandler', ['$delegate', 'config', 'logger', extendExceptionHandler]);
                    }]);

                function extendExceptionHandler($delegate, config, logger) {
                    var appErrorPrefix = config.appErrorPrefix;
                    var logError = logger.getLogFn('app', 'error');
                    return function (exception, cause) {
                        $delegate(exception, cause);
                        if (appErrorPrefix && exception.message.indexOf(appErrorPrefix) === 0) {
                            return;
                        }

                        var errorData = { exception: exception, cause: cause };
                        var msg = appErrorPrefix + exception.message;
                        logError(msg, errorData, true);
                    };
                }
            })(Client.Modules || (Client.Modules = {}));
            var Modules = Client.Modules;
        })(Boilerplate.Client || (Boilerplate.Client = {}));
        var Client = Boilerplate.Client;
    })(Protiviti.Boilerplate || (Protiviti.Boilerplate = {}));
    var Boilerplate = Protiviti.Boilerplate;
})(Protiviti || (Protiviti = {}));
//# sourceMappingURL=config.exceptionHandler.js.map
