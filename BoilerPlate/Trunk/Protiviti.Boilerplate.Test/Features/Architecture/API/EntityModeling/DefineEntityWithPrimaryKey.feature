@Sprint0 @AlokGupta @Must
Feature: DefineEntityWithPrimaryKey
	In order to create an entity with primary key property
	As a developer
	I want to work with an example

Scenario: Defnie an Entity With Primary Key Property
	Given I am a developer when I want to create an entity with primary key property
	When I make a call to "breeze/ApplicationWizard/Metadata" webapi
	Then I should see program entity with id property