@Sprint0 @StewartArmbrecht
Feature: Review Documentation Feature Functionality
	In order to understand how features are used to manage documentation
	As a team member
	I want to review documentation that explains Documentation Features

Scenario: Navigate to Documentation Features Information
	Given I am a team member
	When I view the "README" markdown file
  And I click the "Product Management" link
  And I click the "Documentation Features" link
  Then I should see the "Documentation Features" page
  And I should see a "Overview" section
  And the "Overview" section should "explain how features and scenarios are used to manage documentation"
  And I should see a "Step Types" section
  And the "Step Types" section should "cover the various steps that can be used to create a documentation scenario"
  And I should see a "Examples" section
  And the "Examples" section should "provide a list of pointers to example documentation features in the solution"

Scenario: Review Section Link Documentation Step
	Given I am a team member
	When I view the "README" markdown file
  And I click the "Product Management" link
  And I click the "Documentation Features" link
  Then I should see the "Documentation Features" page
  And I should see a "Step Types" section
  And the "Step Types" section should include a list item with the text "And I click the "[LINK TEXT]" link in the "[SECTION TITLE]" section"

Scenario: Review Section List Item Documentation Step
	Given I am a team member
	When I view the "README" markdown file
  And I click the "Product Management" link
  And I click the "Documentation Features" link
  Then I should see the "Documentation Features" page
  And I should see a "Step Types" section
  And the "Step Types" section should include a list item with the text "And the ''[SECTION TITLE]'' section should include a list item with the text ''[LIST ITEM TEXT]''"
