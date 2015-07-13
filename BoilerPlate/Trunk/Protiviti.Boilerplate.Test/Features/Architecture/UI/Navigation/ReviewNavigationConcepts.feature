Feature: Review UI Navigation Documentation
	In order understand the Boilerplate navigation architecture and technologies
	As a developer
	I want to review documentation that explains the boilerplate navigation and routing
	
 @Sprint0
Scenario: Navigate to Documentation Features Information
	Given I am a team member
	When I view the "README" markdown file
	And I click the "UI" link
	And I click the "Navigation and Routing" link
	Then I should see the "Navigation" page
	And I should see a "Overview" section
	And the "Overview" section should "explain AngularUI Router"
	And I should see a "Getting Started" section
	And the "Getting Started" section should "list steps to start using UI-Router"
	And I should see a "Links" section
	And the "Links" section should contain the following links
	  | LinkText												|
	  | AngularUI Router Wiki									|
	  | AngularUI Router as infrastructure of a large scale app |
	  | limitations of Angular ngRoute provider					|
	  | Difference between ngRouter and ui-router				|
	  | AngularJS 2.0 Routing Design Document					|
	And I should see a "Examples" section
	And the "Examples" section should "provide a list of pointers to example documentation features in the solution"

