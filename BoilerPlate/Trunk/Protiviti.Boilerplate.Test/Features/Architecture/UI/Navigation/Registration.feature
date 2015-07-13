Feature: Registration
	In order to register on the site 
	As a boilerplate solution user
	I want to submit my contact information on the registration page 


@Hanna
Scenario: Successful Registration
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

Scenario: Submit button is required to complete registration
Scenario: Required fields are required to complete registration
Scenario: Non-required fields are not required to complete registration
Scenario: T&C selection is required to complete registration
Scenario: Clicking the Cancel button cancels registration
Scenario: All expected fields are listed on the registration page 