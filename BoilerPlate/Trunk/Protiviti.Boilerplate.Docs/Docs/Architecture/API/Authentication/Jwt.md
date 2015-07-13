JSON Web Token
=====================
JSON Web Token is a security token which acts as a container for claims about the user, it can be transmitted easily between the Authorization server (Token Issuer), and the Resource server (Audience), the claims in JWT are encoded using JSON which make it easier to use especially in applications built using JavaScript.

JSON Web Tokens can be signed following the JSON Web Signature (JWS) specifications, as well it can be encrypted following the JSON Web Encryption (JWE) specifications, in our case we will not transmit any sensitive data in the JWT payload, so we’ll only sign this JWT to protect it from tampering during the transmission between parties.

###JSON Web Token Format
---------------

JWT is a string which consists of following 3 parts separated by dot(.)

* Header
* Payload
* Signature

Sample JSON Web Token

        {
          "unique_name": "SysAdmin",
          "sub": "SysAdmin",
          "role": [
            "Admin",
            "Member"
          ],
          "iss": "http://localhost/protiviti.boilerplate.server",
          "aud": "379ee8430c2d421380a713458c23ef74",
          "exp": 1414283602,
          "nbf": 1414281802
        }



All those claims are not mandatory in order to build JWT. In our case we’ll always use those set of claims in the JWT we are going to issue, those claims represent the below:

* The “sub” (subject) and “unique_claim” claims represent the user name this token issued for.
* The “role” claim represents the roles for the user.
* The “iss” (issuer) claim represents the Authorization server (Token Issuer) party.
* The “aud” (audience) claim represents the recipients that the JWT is intended for (Relying Party – Resource Server).
* The “exp” (expiration time) claim represents the expiration time of the JWT, this claim contains UNIX time value.
* The “nbf” (not before) claim represent the time which this JWT must not be used before, this claim contains UNIX time vale.


Lastly the signature part of the JWT is created by taking the header and payload parts, base 64 URL encode them, then concatenate them with “.”, then use the “alg” defined in the 
"header" part to generate the signature, in our case “HMAC-SHA256″. The resulting part of this signing process is byte array which should be base 64 URL encoded 
then concatenated with the "header".<payload> to produce a complete JWT.

###Enable JWT in Boilerplate Server Project
-------------------------------------------

In "Startup.Auth.cs" file perform the following actions

   * Step 1: Comment out the following lines

            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
           

   * Step 2: Uncomment the following lines

            
            var client = IdentityConstants.Clients.Find(x => x.Id == IdentityConstants.AudienceId);

            AccessTokenFormat = new CustomJwtFormat(client.AllowedOrigin)
   * Step 3: Uncomment the region "JSON Web Token"

In "ApplicationOAuthProvider.cs" file perform the following actions

   * Step 1: Comment out the following lines

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, OAuthDefaults.AuthenticationType);

   * Step 2: Uncomment the following lines

            var oAuthIdentity = new ClaimsIdentity("JWT");

           
###Resources

* [OWIN](http://owin.org/)
* [JWT In Web Api2](http://bitoftech.net/2014/10/27/json-web-token-asp-net-web-api-2-jwt-owin-authorization-server/)
* [JWT Claims](http://self-issued.info/docs/draft-ietf-oauth-json-web-token.html#Claims)



<p class="updated">Updated on 11/25/2014 by Ajay Singh</p>
<p class="reviewed">Reviewed on 11/25/2014 by Ajay Singh</p>
