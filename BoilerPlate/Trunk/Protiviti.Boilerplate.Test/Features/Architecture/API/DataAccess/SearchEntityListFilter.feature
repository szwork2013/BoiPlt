@ignore 
#@Sprint1 @AlokGupta @Must
Feature: SearchEntityListFilter
	In order to retrieve a filtered list of entities of a type
	As a developer
	I want to work with an example

Scenario: Retrieve filtered list of entities of a type
	Given I am a developer when I want to retrieve a filered list of entities of a type
	When I make a call to "breeze/ApplicationWizard/Application" webapi and given a filter "filter"
	Then I should get a filtered list of applications from database
