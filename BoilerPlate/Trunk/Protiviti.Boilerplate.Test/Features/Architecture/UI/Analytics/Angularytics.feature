@ignore 
#@Sprint4 @AlokGupta @Must
Feature: Angularytics
	In order to provide analytical data in a report
	As a developer
	I want to work with an example

Scenario: View Analytical Data
	Given I am a developer when I want to provide analytical data from current site
	When I make a call to "#/angularytics" page
	Then I should see analytical data

