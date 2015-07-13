@ignore 
#@Sprint1 @AlokGupta @Must
Feature: SearchEntityListSort
	In order to retrieve a sorted list of entities of a type
	As a developer
	I want to work with an example

Scenario: Retrieve sorted list of entities of a type
	Given I am a developer when I want to retrieve a sorted list of entities of a type
	When I make a call to "breeze/ApplicationWizard/Application" webapi and given a sort "sortOrder"
	Then I should get a sorted list of applications from database
