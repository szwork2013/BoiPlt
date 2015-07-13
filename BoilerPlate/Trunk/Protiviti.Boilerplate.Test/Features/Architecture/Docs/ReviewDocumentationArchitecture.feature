Feature: Review Documentation Architecture
	In order to understand how documentation is hosted in the solution
	As a team member
	I want to review documentation that explains the documentation solution structure

@Sprint0 @StewartArmbrecht
Scenario: View the Documenation Architecture Overview
	Given I am a team member
	When I view the "README" markdown file
  And I click the "Documentation" link in the "Solution Architecture" section
  Then I should see the "Documentation Architecture" page
  And I should see an "Overview" section
  And the "Overview" section should "explain how documenation is hosted in the solution"
  And I should see a "Creating Documentation" section
  And the "Creating Documenation" section should "explain how to create documentation from a starting point of just joining the team (nothing installed)"
  And I should see a "Resources" section
  And the "Resources" section should contain the following links
  | LinkText                       |
  | Markdown                       |
  | Markdown Syntax                |
  | Markdown Deep Project          |
  | Test Architecture              |
  | Documentation Features         |
  | Feature or Scenario Completion |
