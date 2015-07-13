Overview
========
The  OAuth 2.0 framework enables a third-party app to obtain limited access to an HTTP service. 
Instead of using the resource owner’s credentials to access a protected resource, the client obtains an access token 
(which is a string denoting a specific scope, lifetime, and other access attributes). Access tokens are issued to third-party 
clients by an authorization server with the approval of the resource owner.

##OAuth2 Terminology

*   <b>Resource.</b> Some piece of data that can be protected.
*   <b>Resource server.</b> The server that hosts the resource.
*   <b>Resource owner.</b> The entity that can grant permission to access a resource. (Typically the user.)
*   <b>Client:</b> The app that wants access to the resource. In this article, the client is a web browser.
*   <b>Access token.</b> A token that grants access to a resource.
*   <b>Bearer token.</b> A particular type of access token, with the property that anyone can use the token. In other words, a client doesn’t need a cryptographic key or other secret to use a bearer token. For that reason, bearer tokens should only be used over a HTTPS, and should have relatively short expiration times.
*   <b>Authorization server.</b> A server that gives out access tokens.

    An application can act as both authorization server and resource server. 

##Roles

OAuth 2.0 defines the following roles of users and applications:

* Resource Owner
* Resource Server
* Client Application
* Authorization Server

![OAuth2 Roles](/Protiviti.Boilerplate.Docs/images/Authentication/oauth2-roles.png)

##Client Types

The OAuth 2.0 client role is subdivided into a set of client types and profiles.The OAuth 2.0 specification defines two types of clients: 

* <b>Confidential :</b>
    A confidential client is an application that is capable of keeping a client password confidential to the world. This client password is assigned to the client app by the authorization server. This password is used to identify the client to the authorization server, to avoid fraud. An example of a confidential client could be a web app, where no one but the administrator can get access to the server, and see the client password.
* <b>Public :</b>
A public client is an application that is not capable of keeping a client password confidential. For instance, a mobile phone application or a desktop application that has the client password embedded inside it. Such an application could get cracked, and this could reveal the password. The same is true for a JavaScript application running in the users browser. The user could use a JavaScript debugger to look into the application, and see the client password.


##OAuth 2.0 Authorization
When a client applications wants access to the resources of a resource owner, hosted on a resource server, the client application must first obtain an <i>authorization grant</i>. 

####Authorization Grant
The authorization grant is given to a client application by the resource owner, in cooperation with the authorization server associated with the resource server.
The OAuth 2.0 specification lists four different types of authorization grants. Each type has different security characteristics. We have currently implemented the first option.
    
* <b>Resource Owner Password Credentials</b><br />
The Resource Owner Password Credentials flow allows exchanging the username and password of a user for an access token and, optionally, a refresh token. This flow has significantly different security properties than the other OAuth flows. The primary difference is that the user’s password is accessible to the application. This requires strong trust of the application by the user.
<br />![OAuth2 Resource Owner Password Flow](/Protiviti.Boilerplate.Docs/images/Authentication/ResourceOwnerPasswordFlow.png)

* <b>Authorization Code</b><br />
Here is a diagram illustrating the authorization process when using authorization code to authorize a client application:
![OAuth2 Authorization Code Flow](/Protiviti.Boilerplate.Docs/images/Authentication/authorization-auth-code.png)

* <b>Implicit</b><br />
Here is a diagram illustrating the authorization process when using implicit mode to authorize a client application:
![OAuth2 Implicit Flow](/Protiviti.Boilerplate.Docs/images/Authentication/authorization-implicit.png)

* <b>Client Credentials</b> 

###Prerequisites
*Familiarity with OAuth terminology, including Roles, Protocol Flow, and Authorization Grant.

####Note
* Authorization server provider, part of "Protiviti.Boilerplate.Server" project is not intended for creating a secure production app.

###Resources
* [OWIN OAuth 2.0 Authorization Server Implementation for Development only](http://www.asp.net/aspnet/overview/owin-and-katana/owin-oauth-20-authorization-server)
* [Thinktecture Authorization Server](https://github.com/thinktecture/Thinktecture.AuthorizationServer)

<p class="updated">Updated on 11/17/2014 by Ajay Singh</p>
<p class="reviewed">Reviewed on 11/24/2014 by Stewart Armbrecht</p>
