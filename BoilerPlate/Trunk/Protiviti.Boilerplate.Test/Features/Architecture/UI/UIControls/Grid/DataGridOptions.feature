@Sprint1 @AlokGupta @Must
Feature: DataGridOptions
	In order to view a entity list in a Kendo Grid and test various options like sort, filter
	As a developer
	I want to work with an example

Scenario: Sort By Cost in Programs Kendo Grid
	Given I am a developer when I want to retrieve all programs to display in Kendo Grid
	When I make a call to "#/dataGrid" page
	Then I should see a "Programs - OData Web Api" grid
	Then I click on "Cost" column header

Scenario: Sort By Code in Programs Kendo Grid
	Given I am a developer when I want to retrieve all programs to display in Kendo Grid
	When I make a call to "#/dataGrid" page
	Then I should see a "Programs - OData Web Api" grid
	Then I click on "Code" column header

Scenario: Sort By Duration in Programs Kendo Grid
	Given I am a developer when I want to retrieve all programs to display in Kendo Grid
	When I make a call to "#/dataGrid" page
	Then I should see a "Programs - OData Web Api" grid
	Then I click on "Duration" column header

Scenario: Sort By Location in Programs Kendo Grid
	Given I am a developer when I want to retrieve all programs to display in Kendo Grid
	When I make a call to "#/dataGrid" page
	Then I should see a "Programs - OData Web Api" grid
	Then I click on "Location" column header

Scenario: Sort By Program Name in Programs Kendo Grid
	Given I am a developer when I want to retrieve all programs to display in Kendo Grid
	When I make a call to "#/dataGrid" page
	Then I should see a "Programs - OData Web Api" grid
	Then I click on "Program Name" column header

Scenario: Sort By Application Name in Applications Kendo Grid
	Given I am a developer when I want to retrieve all applications to display in Kendo Grid
	When I make a call to "#/dataGrid" page
	Then I should see a "Applications - Client Paging" grid
	Then I click on "Application Name" column header

Scenario: Sort By Application Status in Applications Kendo Grid
	Given I am a developer when I want to retrieve all applications to display in Kendo Grid
	When I make a call to "#/dataGrid" page
	Then I should see a "Applications - Client Paging" grid
	Then I click on "Status" column header
