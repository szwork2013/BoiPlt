@Sprint2 @AlokGupta @Must
Feature: TestDriverHelperFramework
	In order to utilize test driver helper framework
	As a developer
	I want to work with an example

Scenario: Utilize Driver Helper
	Given I am a developer when to find element by id
	When I make a call to "/#/Programs" page
	Then I should be able to call driver helper methods

Scenario: Find element by id
	Given I am a developer when to find element by id
	When I make a call to "/#/Programs" page
	Then I should be able to call "GetElementById"

Scenario: Find element by name
	Given I am a developer when to find element by name
	When I make a call to "/#/Programs" page
	Then I should be able to call "GetElementByName"

Scenario: Find element by link text
	Given I am a developer when to find element by link text
	When I make a call to "/#/Programs" page
	Then I should be able to call "GetElementByLinkText"

Scenario: Check existence of an element by id
	Given I am a developer when tto check existence of an element by id
	When I make a call to "/#/Programs" page
	Then I should be able to call "HasElementById"
	
Scenario: Check existence of an element by name
	Given I am a developer when to check existence of an element by name
	When I make a call to "/#/Programs" page
	Then I should be able to call "HasElementByName"

Scenario: Check existence of an element by link text
	Given I am a developer when to check existence of an element by link text
	When I make a call to "/#/Programs" page
	Then I should be able to call "HasElementByLinkText"
