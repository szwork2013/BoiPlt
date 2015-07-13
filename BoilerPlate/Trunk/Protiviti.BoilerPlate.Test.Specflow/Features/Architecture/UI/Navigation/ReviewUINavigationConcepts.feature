@web
Feature: Review UI Navigation and Routing Concepts
  In order to understand the solution's UI navigation/routing architecture and technologies
  As a developer
  I would like to be able to review documentation on UI navigation

Scenario: Review UI Navigation and Routing Overview
	Given I am a developer
	When I view the "README" markdown file
	Then I should see a "Getting Started" section
  And the "Getting Started" section should "give an overview of the architecture and techonogies used for the application"
  And the "Getting Started" section should contain links to the the following pages
  | LinkText												|
  | AngularUI Router Wiki									|
  | AngularUI Router as infrastructure of a large scale app |
  | Limitations of Angular ngRoute provider					|
  | Difference between ngRouter and ui-router				|
  | AngularJS 2.0 Routing Design Document					|
   

Scenario: Review AngularUI Router Wiki
	Given I am a developer
	When I view the "Readme" markdown file
  And I click the "AngularUI Router Wiki" link
	Then I should see the "AngularUI Router Wiki" page
  And the page should "give an overview of AngularUI Router including a guide, API, and sample."

Scenario: Review AngularUI Router as infrastructure of a large scale app
	Given I am a developer
	When I view the "Readme" markdown file
  And I click the "AngularUI Router as infrastructure of a large scale app" link
	Then I should see the "AngularUI Router as infrastructure of a large scale app" page
  And the page should "provide a methodology to use UI-Router to organize the UI for large scale applications"

Scenario: Review Limitations of Angular ngRoute provider
	Given I am a developer
	When I view the "Readme" markdown file
  And I click the "Limitations of Angular ngRoute provider" link
	Then I should see the "Advanced routing and resolves" page
  And the page should "provide further overview of AngularUI router and detail nested resolves with AngularUI Router"

 Scenario: Review ui-router example
	Given I am a developer
	When I view the "Readme" markdown file
  And I click the "ui-router example" link
	Then I should see the "Learning AngularJS Part 5: Routing or Views Switching" page
  And the page should "give a setp by step example of how to use ui-router with nested views."

   Scenario: Review AngularJS 2.0 Routing Design Document
	Given I am a developer
	When I view the "Readme" markdown file
  And I click the "AngularJS 2.0 Routing Design Document" link
	Then I should see the "Routing in AngularJS 2.0 Google doc" page
  And the page should "provide insight into the direction the AngularJS team plans to go down regarding routing for their 2.0 release"
