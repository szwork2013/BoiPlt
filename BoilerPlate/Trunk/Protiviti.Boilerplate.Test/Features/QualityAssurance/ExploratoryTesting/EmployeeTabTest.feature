Feature: EmployeeTabTest
	In order to test the employee page and make sure
	the navigation from the home page is working properly.

@Sal
@Sprint0 @SalehComplete
Scenario: Go to employee tab
	Given I am at the application "Home" page
	When I press the "Employees" tab
	Then the employee page should load
	And username, password, login button and reset fields should be present


