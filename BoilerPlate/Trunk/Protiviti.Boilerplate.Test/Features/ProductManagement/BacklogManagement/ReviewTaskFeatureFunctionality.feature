@Sprint0 @StewartArmbrecht
Feature: Review Task Feature Functionality
	In order to understand how features are used to manage activities that need to be performed that don't result in documenation and do not result in working software
	As a team member
	I want to review documentation that explains Task Features

Scenario: Navigate to Task Features Information
	Given I am a team member
	When I view the "README" markdown file
  And I click the "Product Management" link
  And I click the "Task Features" link
  Then I should see the "Task Features" page
  And I should see a "Overview" section
  And the "Overview" section should "explain how features and scenarios are used to manage non-documentation and non-development activities"
  And I should see a "Step Types" section
  And the "Step Types" section should "cover the various steps that can be used to create a task scenarios"
  And I should see a "Examples" section
  And the "Examples" section should "provide a list of pointers to example task features in the solution"