@Sprint1 @AlokGupta @Must
Feature: SearchEntityListUIService
	In order to retrieve all entities of a type from client code
	As a developer
	I want to work with an example

Scenario: Retrieve all programs from client code
	Given I am a developer when I want to retrieve all programs from client code
	When I make a call to "#/programs" page
	Then I should see a list of programs

Scenario: Validate Result Table When Retrieve all programs from client code
	Given I am a developer when I want to retrieve all programs from client code
	When I make a call to "#/programs" page
	Then I should see results in a table "Programs-Results-Table"

Scenario: Validate Name Column When Retrieve all programs from client code
	Given I am a developer when I want to retrieve all programs from client code
	When I make a call to "#/programs" page
	Then I should see name column "Programs-Results-Header-Name"

Scenario: Validate Code Column When Retrieve all programs from client code
	Given I am a developer when I want to retrieve all programs from client code
	When I make a call to "#/programs" page
	Then I should see code column "Programs-Results-Header-Code"

Scenario: Validate Cost Column When Retrieve all programs from client code
	Given I am a developer when I want to retrieve all programs from client code
	When I make a call to "#/programs" page
	Then I should see cost column "Programs-Results-Header-Cost"

Scenario: Validate Duration Column When Retrieve all programs from client code
	Given I am a developer when I want to retrieve all programs from client code
	When I make a call to "#/programs" page
	Then I should see duration column "Programs-Results-Header-Duration"

Scenario: Validate Location Column When Retrieve all programs from client code
	Given I am a developer when I want to retrieve all programs from client code
	When I make a call to "#/programs" page
	Then I should see location column "Programs-Results-Header-Location"