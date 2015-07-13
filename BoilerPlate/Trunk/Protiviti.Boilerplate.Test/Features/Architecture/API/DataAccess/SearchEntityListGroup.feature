@ignore 
#@Sprint1 @AlokGupta @Must
Feature: SearchEntityListGroup
	In order to retrieve a grouped list of entities of a type
	As a developer
	I want to work with an example

Scenario: Retrieve grouped list of entities of a type
	Given I am a developer when I want to retrieve a grouped list of entities of a type
	When I make a call to "breeze/ApplicationWizard/Application" webapi and given a group by property "groupBy"
	Then I should get a grouped list of applications from database

