@ignore
#@Sprint1 @AjaySingh @Must
#@Authentication
Feature: OwinFormsAuthentication
	In order to provide authentication feature in Asp.Net web Api
	As a team member
	I want to use the OWIN forms authentication feature

@ignore
#@FormsAuthentication
Scenario: Protected Request Should Redirect To Login
	Given I want to access any protected resource say /employee
	When I access the page
	Then I should be redirected to "/login" page
	And I should get the HTTP status code of 302 i.e. "Redirect" 

@ignore
#@FormsAuthentication
Scenario: Protected Custom Request Should Redirect To Custom Login
	Given I want to access custom protected resource say /protected/customredirect
	When I access the page
	Then I should be redirected to "/customredirect" page
	And I should get the HTTP status code of 302 i.e. "Redirect" 

@ignore
#@FormsAuthentication
Scenario: SignIn Causes Default Cookie To Be Created
	Given I want to SignIn into portal
	When I SignIn into the portal
	Then I should get the default cookie containing following values
	| Value      |
	| ; path/    |
	| ; HttpOnly |
	| ; expires= |
	| ; domain=  |
	| ;secure    |

@ignore
#@FormsAuthentication
Scenario: Cookie Options Alter Set Cookie Header
	Given I want to change cookie options
	And I change the "CookieSecure" to "Never"
	When I SignIn into the portal
	Then I should not receive the "secure" key the cookie

@ignore
#@FormsAuthentication
Scenario: Cookie Contains the Identity
	Given I SignIn in portal using valid username "Admin"
	When I SignIn into the portal
	Then I should receive the cookie containing username "Admin"

@ignore
#@FormsAuthentication
Scenario: Cookie Stops Working After Expiration
	Given I want to SignIn into Portal
	And Cookie is expired
	When I SignIn into portal
	Then Logged in username "Admin" is not there in cookie

@ignore
#@FormsAuthentication
Scenario: Cookie Expiration Can Be Overridden In Sign in
	Given I am a developer and I want to override cookie expiration time from 10 mins to 5 mins
	And I set the expiration time to 5 minutes
	When I SignIn into the portal
	Then I should see the new cookie expiration set to 5 minutes

@ignore 
#@FormsAuthentication
Scenario: Cookie Expiration Can Be Overridden In Event
	Given I am a developer and I want to override cookie expiration time from 10 mins to 4 mins
	And I set the expiration time to 4 minutes
	When I SignIn into the portal
	Then I should see the new cookie expiration set to 4 minutes

@ignore
#@FormsAuthentication
Scenario: Cookie Is Renewed With Sliding Expiration
	Given I am a developer and I want to test the sliding expiration feature of cookie
	And The initial expiration time is set to 5 minutes
	And I am already SignIn
	When I make the call say 2 minutes after the signin then the cookie expiration is renewed to 5 minutes

@ignore	
#@FormsAuthentication
Scenario: Ajax Request Redirects As Extra Header On Http Status Code 200
	Given I am a developer and I want to test the AJAX request
	When I make a ajax request to "/api/employee"
	Then I should be able to get "X-Responded-JSON" header key in response from service