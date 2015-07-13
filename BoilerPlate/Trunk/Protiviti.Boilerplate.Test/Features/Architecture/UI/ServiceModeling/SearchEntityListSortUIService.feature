@ignore 
#@Sprint1 @AlokGupta @Must
Feature: SearchEntityListSortUIService
	In order to retrieve a sorted list of entities of a type from client code
	As a developer
	I want to work with an example

Scenario: Retrieve sorted list of entities of a type from client code
	Given I am a developer when I want to retrieve a sorted list of entities of a type from client code
	When I make a call to "/#/Application" page
	Then I provide a sort order "sortOrder" in sort edit box
	Then I click on search 
	Then I should see a sorted list of applications


