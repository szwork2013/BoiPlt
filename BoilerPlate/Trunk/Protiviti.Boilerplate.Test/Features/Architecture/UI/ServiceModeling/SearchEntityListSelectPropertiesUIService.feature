@ignore
#@Sprint1 @AlokGupta @Must
Feature: SearchEntityListSelectPropertiesUIService
	In order to retrieve a list of entities of a type from client code and create a projection
	As a developer
	I want to work with an example

Scenario: Retrieve all entities of a type and create projection from client code
	Given I am a developer when I want to retrieve a projected list of entities from client code
	When I make a call to "/#/Application" page
	Then I provide select columns list "selectColumns" in select edit box
	Then I click on search 
	Then I should see a projected list of applications

