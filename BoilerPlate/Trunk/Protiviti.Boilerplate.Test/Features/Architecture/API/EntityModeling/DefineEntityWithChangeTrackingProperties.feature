@Sprint0 @AlokGupta @Must
Feature: DefineEntityWithChangeTrackingProperties
	In order to create an entity with change tracking properties
	As a developer
	I want to work with an example

Scenario: Defnie an Entity With Change Tracking Properties
	Given I am a developer when I want to create an entity with change tracking properties
	When I make a call to "breeze/ApplicationWizard/Metadata" webapi
	Then I should see application entity with created and last changed date properties
