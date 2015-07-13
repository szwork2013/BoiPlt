Feature: RegisterUserTest
	In order to make sure the user Registerdation is working.

@Sal
@Sprint0
Scenario: Go to Registeration and fill the user info
	Given I am on the "Employee" Page
	And I click the regsitration link
	When I fill in the user info and click register
	Then registration of a new user should be completed successfully
