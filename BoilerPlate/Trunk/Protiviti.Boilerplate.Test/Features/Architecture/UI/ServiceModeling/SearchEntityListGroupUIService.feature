@ignore 
#@Sprint1 @AlokGupta @Must
Feature: SearchEntityListGroupUIService
	In order to retrieve a grouped list of entities of a type from client code
	As a developer
	I want to work with an example

Scenario: Retrieve grouped list of entities of a type from client code
	Given I am a developer when I want to retrieve a grouped list of entities of a type from client code
	When I make a call to "/#/Application" page
	Then I provide a group by property "groupBy" in group edit box
	Then I click on search 
	Then I should see a grouped list of applications
