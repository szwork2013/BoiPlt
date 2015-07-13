@ignore 
#@Sprint1 @AlokGupta @Must
Feature: SearchEntityListFilterUIService
	In order to retrieve a filtered list of entities of a type from client code
	As a developer
	I want to work with an example

Scenario: Retrieve filtered list of entities of a type from client code
	Given I am a developer when I want to retrieve a filtered list of entities of a type
	When I make a call to "/#/Application" page
	Then I provide a filter "filter" in filter edit box
	Then I click on search 
	Then I should see a filtered list of applications

