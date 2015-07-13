@Sprint0 @AlokGupta @Must
Feature: DefineEntityWithForeignKey
	In order to create an entity with foreign key property
	As a developer
	I want to work with an example

Scenario: Defnie an Entity With Foreign Key Property
	Given I am a developer when I want to create an entity with foreign key property
	When I make a call to "breeze/ApplicationWizard/Metadata" webapi
	Then I should see application entity with applicant id property
