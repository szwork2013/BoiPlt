<link href="../../../../Content/Site.css" rel="stylesheet"/>

Overview
=============
Forms authentication uses an application ticket that represents user's identity and keeps it inside user agent's cookie. 
When user first accesses a resource requiring authorization, it will redirect user to login page. After the user provides credentials,
 your application code will validate the user name and password and build user claims including user's name, roles, etc. 
After passing claims to the Forms authentication middleware, it will convert it to an application ticket and serialize, encrypt 
and encode it into a ticket token. Then, send it out as a cookie. When the next time user sends request with the cookie, 
the middleware will validate it and convert the ticket token back to claims principal and save it in HttpContext.User, 
which will shared across ASP.NET pipeline.

ASP.NET also has a forms authentication support through the FormsAuthenticationModule, which, however, can only support applications hosted on ASP.NET and doesn't have claim support . Here is a rough feature comparison list:

<table id="formsauthentication">
<tr>
  <th>Features</th>
  <th>Asp.Net Forms Authentication</th>
  <th>OWIN Forms Authentication</th>
</tr>
<tr><td>Cookie Authentication</td><td>Yes</td><td>Yes</td></tr>
<tr><td>Cookieless Authentication</td><td>Yes</td><td>No</td></tr>
<tr><td>Expiration</td><td>Yes</td><td>Yes</td></tr>
<tr><td>Sliding Expiration</td><td>Yes</td><td>Yes</td></tr>
<tr><td>Token Protection</td><td>Yes</td><td>Yes</td></tr>
<tr><td>Claims Support</td><td>No</td><td>Yes</td></tr>
<tr><td>Web Farm Support</td><td>Yes</td><td>Yes</td></tr>
<tr><td>Unauthorized Redirection</td><td>Yes</td><td>Yes</td></tr>
</table>

###OWIN Forms authentication options
It provides two options

* Application SignIn Cookie (UseApplicationSignInCookie() extension method)
* External SignIn Cookie (UseExternalSignInCookie() extension method)

###Resources

* [Understanding OWIN Forms authentication in MVC 5](http://blogs.msdn.com/b/webdev/archive/2013/07/03/understanding-owin-forms-authentication-in-mvc-5.aspx)
* Dissecting the Web API Individual Accounts Template
    * [Overview](http://leastprivilege.com/2013/11/25/dissecting-the-web-api-individual-accounts-templatepart-1-overview/)
    * [Local Accounts](http://leastprivilege.com/2013/11/26/dissecting-the-web-api-individual-accounts-templatepart-2-local-accounts/)
    * [External Accounts](http://leastprivilege.com/2013/11/26/dissecting-the-web-api-individual-accounts-templatepart-3-external-accounts/)


<p class="updated">Updated on 9/25/2014 by Ajay Singh</p>
<p class="reviewed">Reviewed on 9/25/2014 by Ajay Singh</p>
