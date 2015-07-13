@Sprint1 @AlokGupta @Must
Feature: ServerQuery
	In order to view a entity list that supports server-side paging, sorting and filtering
	As a developer
	I want to work with an example

Scenario: Retrieve all programs and display in server-side query table
	Given I am a developer when I want to retrieve all programs to display in server-side query
	When I make a call to "#/serverquerygrid" page
	Then I should see a "Programs" table
