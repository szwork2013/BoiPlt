OWIN
=====================
OWIN defines a standard interface between .NET web servers and web applications. The goal of the OWIN 
interface is to decouple server and application, encourage the development of simple modules for .NET 
web development, and, by being an open standard, stimulate the open source ecosystem of .NET web development tools. 

[For more details](http://owin.org/)


Katana
------
Katana is a flexible set of components (projects) for building and hosting OWIN-based web applications.
It is Microsoft implementation of OWIN specifications in collaboration with community of open source developers.
As part this project, Microsoft initially implemented security related components knows as "Middlewares". Below is the high level architecture diagram

<img src="/Protiviti.Boilerplate.Docs/images/Authentication/owin1.png" style="width:80%;height:80%" alt="OWIN" />

<img src="/Protiviti.Boilerplate.Docs/images/Authentication/owin2.png" style="width:80%;height:80%" alt="OWIN Runtime"/>

![OWIN Hosting](/Protiviti.Boilerplate.Docs/images/Authentication/owin3.png)

Currently, two hosts are provided to host the OWIN based web applications.

###Hosting Options
* Microsoft.Owin.Host.HttpListener - OWIN server built on the .NET Framework's HttpListener class. Currently the default server used for self-hosting
* Microsoft.Owin.Host.SystemWeb - OWIN server that enables OWIN-based applications to run on IIS using the ASP.NET request pipeline.

###Security Components
Following are key security component that Microsoft developed as part of this OWIN implementation so far.

* Microsoft.Owin.Security.OAuth - Middleware that enables an application to support any standard OAuth 2.0 authentication workflow.
* Microsoft.Owin.Security.ActiveDirectory - Middleware that enables an application to use Microsoft's technology for authentication.
* Microsoft.Owin.Security.Cookies - Middleware that enables an application to use cookie based authentication, similar to ASP.NET's forms authentication.
* Microsoft.Owin.Security.Facebook - Middleware that enables an application to support Facebook's OAuth 2.0 authentication workflow.
* Microsoft.Owin.Security.Google - Contains middlewares to support Google's OpenId and OAuth 2.0 authentication workflows.
* Microsoft.Owin.Security.Jwt - Middleware that enables an application to protect and validate JSON Web Tokens.
* Microsoft.Owin.Security.MicrosoftAccount - Middleware that enables an application to support the Microsoft Account authentication workflow.
* Microsoft.Owin.Security.OpenIdConnect - Middleware that enables an application to use OpenIdConnect for authentication.
* Microsoft.Owin.Security.Twitter - Middleware that enables an application to support Twitter's OAuth 2.0 authentication workflow.
* Microsoft.Owin.Security.WsFederation - Middleware that enables an application to use WsFederation for authentication.

###Resources

* [OWIN](http://owin.org/)
* [OWIN and Katana](http://www.asp.net/aspnet/overview/owin-and-katana)
* [Getting Started With Katana](http://msdn.microsoft.com/en-us/magazine/dn451439.aspx)

Authentication is implemented using the Owin middleware out of box component developed by Microsoft 
as a part of project Katana.

##Current Implementation
Currently the Protiviti.Boilerplate.Server project implements OAuth security middleware "Bearer Token" option only. 

In future we are planning to implement the following 

* Microsoft.Owin.Security.OAuth
    * Refersh Token, Two Factor Authentication etc implementation are currently pending.
* Microsoft.Owin.Security.ActiveDirectory
* Microsoft.Owin.Security.Cookies


### Prerequisites
* Visual Studio 2013 templates by default come with OWIN middle setup for you. When you install new project by selecting "Asp.Net Web Application" web template, 
you get following 2 files created

* "Startup.cs" at the root of the project
* "Startup.Auth.cs" under the "App_Start" folder. This file contains the OWIN security middleware component configuration.

By convention, "Startup.cs" is first file to execute in the application life cycle, so if you want you can get rid of the "Global.asax" file.


###Important Notes
* As a part recent decision, Microsoft is going to end the .Net 4.0 support by 2016. Hence all latest component only support .Net 4.5

<p class="updated">Updated on 11/21/2014 by Ajay Singh</p>
<p class="reviewed">Reviewed on 11/24/2014 by Ajay Singh</p>
