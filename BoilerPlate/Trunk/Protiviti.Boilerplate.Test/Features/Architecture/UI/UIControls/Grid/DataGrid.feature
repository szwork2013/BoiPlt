@Sprint1 @AlokGupta @Sal @Must
Feature: DataGrid
	In order to view a entity list in a Kendo Grid
	As a developer
	I want to work with an example

Scenario: Retrieve all programs and display in Kendo Grid
	Given I am a developer when I want to retrieve all programs to display in Kendo Grid
	When I make a call to "#/dataGrid" page
	Then I should see a "Programs - OData Web Api" grid

Scenario: Retrieve all applications and display in Kendo Grid
	Given I am a developer when I want to retrieve all applications to display in Kendo Grid
	When I make a call to "#/dataGrid" page
	Then I should see a "Applications - Client Paging" grid
