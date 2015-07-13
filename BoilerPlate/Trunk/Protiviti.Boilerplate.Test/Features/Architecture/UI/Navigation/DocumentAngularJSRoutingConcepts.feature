@MikeWzorek @Sprint0
Feature: Document UI Navigation and Routing Concepts
	In order to document UI Navigation and Routing  concepts
	As a team member
	I want to create content in the solution so team members can review and understand the boilerplate navigation architecture.

@MikeWzorek @Sprint0
Scenario: Specify a section that should be on a page
  Given I have access to the solution
  Then I should be able to define a scenario with the following step
  """
  Then I should see a "Getting Started" section
  """
  And the step should verify the current page has an h2 with the text specified in the parameter

@MikeWzorek @Sprint0
Scenario: Specify a set of links that should be in a section
  Given I have access to the solution
  Then I should be able to define a scenario with the following step
  """
  And the "Getting Started" section should contain links to the the following pages
  | LinkText												|
  | AngularUI Router Wiki									|
  | AngularUI Router as infrastructure of a large scale app |
  | Limitations of Angular ngRoute provider					|
  | Difference between ngRouter and ui-router				|
  | AngularJS 2.0 Routing Design Document					|
  """
  And the step should verify the current page has an h2 with the text specified in the parameter 
  And the step should verify the page has the specified links before the next h2 

@MikeWzorek @Sprint0
Scenario: Follow a link on a page
  Given I have access to the solution
  Then I should be able to define a scenario with the following step
  """
  And I click the "AngularUI Router Wiki" link
  """
  And the step should verify the current page has an h2 with the text specified in the parameter

@MikeWzorek @Sprint0
Scenario: Describe the content of a section
  Given I have access to the solution
  Then I should be able to define a scenario with the following step
  """
  And the page should "give an overview of the AngularUI Router routing framework"
  """
  And the step should do nothing but pass

@MikeWzorek @Sprint0
Scenario: Documentation Scenario Example 1
  Given I am a developer
  When I view the "ReadMeSample" markdown file
  Then I should see a "Sample Section" section
  And the "Sample Section" section should contain links to the the following pages
  | LinkText      |
  | Sample Page 1 |
  | Sample Page 2 |
  | Sample Page 3 |

@MikeWzorek @Sprint0
Scenario: Documentation Scenario Example 2
	Given I am a developer
	When I view the "ReadMeSample" markdown file
  And I click the "Sample Page 1" link
	Then I should see the "Sample Page 1" page
  And the page should "say I am an example of a page in the documentation"
