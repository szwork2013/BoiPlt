Authorization
=============

Currently boilerplate implemented the authorization both on server and client side.

###Server Side

On server side, the Boilerplate server project relies on Asp.Net Web Api Authorization attribute which internally uses the Asp.Net Identity claims for authorization.
Identity claims are new inbuilt feature of .Net which was earlier available as a separate module (WIF). Claims helps in implementing the security in more featurefull 
way as compared to older membership system. In new Asp.Net identity system it is quite easy to add any custom property or field in user profile say <b>"Age"</b>
and used that as claims to build certain business logic against that.

As a part of authentication process, apart from authentication token server is also sending following properties to client.

* User Name
* Display Name
* Roles

###Client Side

Client mainly uses the <b>"Roles"</b> property received from server as a part of authorization token to perform following operations

To implement Authorization in our app, we have following 3 options

*   <b>UI manipulation</b> (Show or hide different elements or section of screen)
    To achieve this, we have added angular directive named <b>"access"</b>. The code of this directive is under <b>"app/authentication/directives"</b> folder of client project.
    To hide any element, you need to use this directive as an attribute on element passing different roles as comma separated values for which the element is accessible.
    for e.g. say "Employee" menu item is only accessible to authenticated user with "Member" role, then we need to do like this 
    
        <li ui-sref-active="active" access="Member"><a ui-sref="employees" id="employees">Employees</a></li>

        <li class="ui-sref-active" dropdown" access="Admin">
            <a id="adminsection" href="javascript:void(0);" class="dropdown-toggle" data-toggle="dropdown">Manage <span class="caret"></span></a>
            <ul class="dropdown-menu" role="menu">
                <li><a id="mnuRoles" ui-sref="roles">Roles</a></li>
                <li role="presentation" class="divider"></li>
                <li><a id="allusers" ui-sref="users">All Users</a></li>
                <li><a ui-sref="externallogins">External Logins</a></li>
            </ul>
        </li>

    In above li's notice the usage of <b>"access"</b> attribute.

*   <b>Secure Routes</b> 
     <br />To secure routes, you need to add the following property and set it's value in config.route.ts file
    
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
            }

    In above notice the usage of <b>"access"</b> attribute. In this we have two (2) properties

        * loginRequired: requires either true or false. if set to true then for any unauthorized request system with redirect the user to login page otherwise redirect to not-authorized page.
        * permissions: contails user roles who all are allowed to access this route.



*   <b>Http Interceptor</b> 
    <br /> we have added angular factory (app/authentication/services/authInterceptorService.ts) which intercepts every http request that sends from client. it performs following 2 tasks

    * Add authentication token in authorization property of request header if available 
    * Catch error response and perform different operations based on Http Status code
      <br>for e.g.  if received 401 and user is not authenticated then redirects him to login page.
      
<br />

            switch (rejection.status) {
                case 401: // UnAuthorized Request
                    /*
                        * If user is logged in and even then we are receiving the unauthorized response then
                        * most probably the requested resource is also protected "Roles" and "Users" level security
                        * then in this case redirect to not-authorized page rather than on login page
                        */
                    var authData = localStorageService.get(Modules.Authentication.bearerTokenName);
                    if (authData) {
                        $location.path(Modules.Authentication.Routes.notAuthorized);
                    } else {
                        $rootScope.$broadcast(Modules.Authentication.events.redirectToLogin, null);
                    }
                    break;
                default:
            }

<br />
<p class="updated">Updated on 11/21/2014 by Ajay Singh</p>
<p class="reviewed">Reviewed on 11/22/2014 by Ajay Singh</p>
