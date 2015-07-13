@ignore
#@Sprint1 @AlokGupta @Must
Feature: SearchEntityList
	In order to retrieve all entities of a type
	As a developer
	I want to work with an example

Scenario: Retrieve all entities of a type
	Given I am a developer when I want to retrieve all entities of a type
	When I make a call to "breeze/ApplicationWizard/Application" webapi
	Then I should get all the applications from database
