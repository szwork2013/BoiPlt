@Sprint0 @AlokGupta @Must
Feature: DefineEntityWithMultipleForeignKeys
	In order to create an entity with multiple foreign keys
	As a developer
	I want to work with an example

Scenario: Defnie an Entity With Multiple Foreign Keys
	Given I am a developer when I want to create an entity with multipe foreign keys
	When I make a call to "breeze/ApplicationWizard/Metadata" webapi
	Then I should see application entity with applicant, program, invoice id properties