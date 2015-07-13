Feature: LoginAuthenticationViaExternalSource
	In order to login with facebook or google
	As a external user
	I want to be enter my external username and password

@Rohit_ExternalLogin
Scenario: Presence of 'Login with Google+/Facebook' Button
	Given I am on Login Page
	When  I click on Login button on the header
	Then  I should see following buttons on the page 
	| ButtonName |
	| Connect with Google+  |
	| Connect With Facebook |
   #| Connect With Twitter  | --Test will fail as button is not present now
	
	

@Rohit_ExternalLogin
@Must
Scenario: Successful Login with Google Account
	Given I am on Login Page and I click on the header
	When I click on following button
	|ButtonName|
	| Connect with Google+  |
	#| Connect With Twitter  | --Test will fail as functionality is not present now
	And I enter valid credentials in the pop-up window
	And I enter a valid username in the portal to register
	Then I am successfully logged in


@Rohit_ExternalLogin
@Pending
Scenario: Successful Login with Facebook Account
	Given I am on the portal's Login Page and I click on the header
	When I click on following facebook button
	|ButtonName|
	| Connect With Facebook |
	And I enter valid credentials of facebookaccount in the pop-up window
	And I enter a valid username and password in the portal to register
	Then I am successfully logged with fb account


@Rohit_ExternalLogin
@Must
Scenario: To Verify that registered user name is displayed when logged in with Google+
Given I am on Login Page and I click on the header
When I Login with following Accounts
| External Account |
| Google          |
Then Registered username should be displayed on the header

@Rohit_ExternalLogin
@Must
@Pending
Scenario: To Verify that registered user name is displayed when logged in with Facebook
Given I am on the portal's Login Page and I click on the header
When I Login with following facebook Account
| External Account |
| Facebook          |
#| XYZ| --test will fail with inavalid details
Then Registered username on portal should be displayed on the header

@Rohit_ExternalLogin
@Must
Scenario: To Verify that change password and profile options are not displayed to external user
Given I am on Login Page and I click on the header
When I Login with following Accounts
| External Account |
| Google          |
#| XYZ| --test will fail with inavalid details
And I click on the username displayed on the header
Then following buttons are not displayed





