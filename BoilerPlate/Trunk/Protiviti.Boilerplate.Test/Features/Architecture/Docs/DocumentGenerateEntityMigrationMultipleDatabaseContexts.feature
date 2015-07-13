@Sprint0 @AlokGupta @Must
Feature: DocumentGenerateEntityMigrationMultipleDatabaseContexts
	In order to generate entity migration for a database context while working for a solution with multiple database contexts
	As a developer
	I want to read steps to generate entity migration

Scenario: Document Generate Entity Migration Multiple Database Contexts
	Given I am a developer
	When I enter page reference GenerateEntityMigrationMultipleDatabaseContexts "Architecture/API/DataAccess/GenerateEntityMigrationMultipleDatabaseContexts"
	Then I should see the documentation on how to add migration for a database context "Entity migration for a database context"
