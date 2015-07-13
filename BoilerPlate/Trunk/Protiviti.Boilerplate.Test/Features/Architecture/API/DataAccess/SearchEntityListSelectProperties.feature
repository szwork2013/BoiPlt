@ignore 
#@Sprint1 @AlokGupta @Must
Feature: SearchEntityListSelectProperties
	In order to retrieve a list of entities of a type and create a projection
	As a developer
	I want to work with an example

Scenario: Retrieve all entities of a type and create projection
	Given I am a developer when I want to retrieve all entities of a type and create a projection
	When I make a call to "breeze/ApplicationWizard/Application" webapi and given a list of columns "selectColumns"
	Then I should get selected columns of the applications in the database



