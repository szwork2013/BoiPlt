Feature: Verification
	In order to get registered on the site
	As a boilerplate solution user
	I want to submit the verification code after submitting my contact information on the registration page

@Rohit_UserVerification @Complete
Scenario: Registration
	Given I am on the home page and click Sign Up
	And I fill all the required fields on the page
	When I click Submit button present on the page
	Then the form should be validated first
	And I should be redirected to the verification page

@Rohit_UserVerification   @Complete
Scenario: UI for Verification page
	Given I have eneterd valid credential in the registartion page
	When I am on Verification Page
	Then I should see following buttons/fields on the page

@Rohit_UserVerification  @Complete
Scenario: Authentication Provider on Verification page
	Given I have eneterd valid credential in the registartion page
	When I am on Verification Page
	Then I should see following authentication methods on the page
	| AuthenticationMethods |
	|SMS |
	|EMail|

@Rohit_UserVerification  @Complete  
Scenario: Unsuccessfull registeration with invalid Registration code
	Given I am on Verification Page
	When I enter invalid verification code
	Then I should get an error message



