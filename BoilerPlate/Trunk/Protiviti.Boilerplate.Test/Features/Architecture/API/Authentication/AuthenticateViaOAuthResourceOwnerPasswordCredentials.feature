@Sprint1 @AjaySingh
@Authentication
Feature: OAuthResourceOwnerPasswordCredentialsGrant
	In order to provide authentication feature in Asp.Net web Api
	As a team member
	I want to use the OAuth resource owner password credential grant feature

#OAuth grant_type="password"
#Post body request structure is "grant_type=<grant type>&username=<user name>&password=<password>"

@OAuthResourceOwnerPasswordCredentialsGrant
Scenario: Validate OAuth Token Access URL
	Given I am a team member and I want to get access token for accessing secured API resources
	And I created the post request "grant_type=password&username=admin@protiviti.com&password=Admin@123"
	When I make a call to "/token" 
	Then I should get a valid response

@OAuthResourceOwnerPasswordCredentialsGrant
Scenario: Resource Owner Get Access Token By Passing Valid Credentials and Grant Type
	Given I am a team member and I want to get access token for accessing secured API resources
	And I created the post request "grant_type=password&username=admin@protiviti.com&password=Admin@123"
	When I make a call to "/token" 
	Then I should get the access token
	
@OAuthResourceOwnerPasswordCredentialsGrant
Scenario: Authorization Server Must Return the Same UserName As Passed With Valid Credentials
	Given I am a team member and I want to get access token for accessing secured API resources
	And I created the post request "grant_type=password&username=admin@protiviti.com&password=Admin@123"
	When I make a call to "/token" 
	Then I should get the access token
	And I should get the same username as passed with credentials for e.g. admin@protiviti.com

@OAuthResourceOwnerPasswordCredentialsGrant
Scenario: Valid Access Token Expiration Is Set For 1 Day
	Given I am a team member and I want to get access token for accessing secured API resources
	And I created the post request "grant_type=password&username=admin@protiviti.com&password=Admin@123"
	When I make a call to "/token" 
	Then I should get the access token which expires in 1 day

@OAuthResourceOwnerPasswordCredentialsGrant
Scenario: Valid Request With Valid Credentials Returns Bearer Access Token Type
	Given I am a team member and I want to get access token for accessing secured API resources
	And I created the post request "grant_type=password&username=admin@protiviti.com&password=Admin@123"
	When I make a call to "/token" 
	Then I should get the access token
	And I should get the Bearer access token type

@OAuthResourceOwnerPasswordCredentialsGrant
Scenario: Accessing Secured Resource Using Valid Access Token
	Given I am a team member and I want to access secured API resource
	And I have a valid access token 
	When I make a call to secure resource employee "/api/employee"
	Then I should get the list of employees where total count should be greater than Zero

@OAuthResourceOwnerPasswordCredentialsGrant
Scenario Outline: Resource Owner Credentials Grant Fail if Pass Incorrect Request Parameter Values for GrantType, UserName and Password
	Given I am a team member and I want to get access token for accessing secured API resources
	And I created the post request with incorrect values for parameters grant_type "<granttype>" , username "<username>" and password "<password>"
	When I make a call to "/token" 
	Then I should not get the access token
Examples: 
	| granttype     | username            | password     | remarks                  |
	| password      | testuser            | Admin@123    | Invalid user Name        |
	| password      | admin@protiviti.com | testpassword | Invalid password         |
	| testgranttype | admin@protiviti.com | Admin@123    | Invalid grant type       |
	| testgranttype | testuser            | testpassword | All 3 values are invalid |

@OAuthResourceOwnerPasswordCredentialsGrant
Scenario Outline: Resource Owner Credentials Grant Return Error "invalid_grant" if Pass Incorrect UserName and Password
	Given I am a team member and I want to get access token for accessing secured API resources
	And I created the post request with incorrect values for parameters username "<username>" and password "<password>"
	When I make a call to "/token" 
	Then I should get error of invalid grant
Examples: 
	| username            | password     | remarks                 |
	| testuser            | Admin@123    | Invalid user Name       |
	| admin@protiviti.com | testpassword | Invalid password        |
	| testuser            | testpassword | Both values are invalid |

@OAuthResourceOwnerPasswordCredentialsGrant
Scenario: Resource Owner Credentials Grant Return Error "unsupported_grant_type" if Pass Invalid Grant Type
	Given I am a team member and I want to get access token for accessing secured API resources
	And I created the post request with invalid grant type "grant_type=<testgranttype>&username=admin@protiviti.com&password=Admin@123"
	When I make a call to "/token" 
	Then I should get error of unsupported grant type

@OAuthResourceOwnerPasswordCredentialsGrant
Scenario: Resource Owner Credentials Grant Fails if Valid Grant Type But Not Of Resource Owner Credentials Type i.e password
	Given I am a team member and I want to get access token for accessing secured API resources
	And I created the post request with incorrect grant type "grant_type=client_credentials&username=admin@protiviti.com&password=Admin@123"
	When I make a call to "/token" 
	Then I should get error of unauthorized client