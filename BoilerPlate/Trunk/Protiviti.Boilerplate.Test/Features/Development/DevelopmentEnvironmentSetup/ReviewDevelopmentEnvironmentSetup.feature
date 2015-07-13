@web
Feature: Review Development Environment Setup
  In order to understand how to run a local instance of the application
  As a developer
  I would like to be able to review documentation on the setup the application

Scenario: Review Development Environment Setup Overview
	Given I am a developer
	When I view the "README" markdown file
	Then I should see a "Getting Started" section
    And the "Getting Started" section should "give an overview of the activities that need to be performed to setup a local instance of the solution"
    And the "Getting Started" section should contain links to the the following pages
	| LinkText                          |
	| Installing the Prerequisites      |
	| Getting Access to the Source Code |
	| Running the Application           |
   

Scenario: Review Installation Prerequisites
	Given I am a developer
	When I view the "Readme" markdown file
	And I click the "Installing the Prerequisites" link
	Then I should see the "Installing the Prerequisites" page
	And the page should "Steps to Build and Run Solution"

Scenario: Review Getting Access to the Source Code
	Given I am a developer
	When I view the "Readme" markdown file
	And I click the "Getting Access to the Source Code" link
	Then I should see the "Accessing the Source Code" page
	And the page should "Steps to Build and Run Solution"

@ignore
Scenario: Review Running the Application
	Given I am a developer
	When I view the "Readme" markdown file
	And I click the "Running the Application" link
	Then I should see the "Running the Application" page
	And the page should "provide an overview of how to run the application and explain what happens the first time the developer runs the application"
