@Sprint0 @AlokGupta @Must
Feature: AccessBreezeControllerSingleEntityFrameworkContext
	In order to create and use a breeze controller that utilizes an entity framework database context
	As a developer
	I want to work with an example

Scenario: Access Breeze Controller Single Entity Framework Context
	Given I am a developer when I want to create and use a breeze controller to access entity framework database context
	When I make a call to "/breeze/ApplicationWizard/Metadata" webapi
	Then I should see meta data information

