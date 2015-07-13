@Sprint0 @AlokGupta @Must
Feature: ModifyEntityChangePropertyType
	In order to motify an entity to add change tracking properties
	As a developer
	I want to work with an example

Scenario: Modify Entity to Add Change Tracking Properties
	Given I am a developer when I want to create an entity with change tracking properties
	When I make a call to "breeze/ApplicationWizard/Metadata" webapi
	Then I should see a migraton file im migrations folder and application entity with created and last changed date properties

