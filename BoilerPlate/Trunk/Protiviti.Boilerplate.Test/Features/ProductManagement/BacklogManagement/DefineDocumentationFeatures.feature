@Sprint0 @StewartArmbrecht
Feature: Define Documentation Features
	In order to control what documentation is created by the team
	As a team member
	I want to be able to define a set of features that spcifify what documentation should be created using a generic set of step definitions

Scenario: Specify a page to load
  Given I have access to the solution
  Then I should be able to define a scenario with the following step
  """
  When I view the "ReadMe" markdown file
  """
  And the step should load a browser and point it at the URL that renders the markdown file

Scenario: Specify a title for a page
  Given I have access to the solution
  Then I should be able to define a scenario with the following step
  """
  Then I should see the "README" page
  """
  And the step should verify the current page has an h1 with the text specified in the parameter

Scenario: Specify a section that should be on a page
  Given I have access to the solution
  Then I should be able to define a scenario with the following step
  """
  Then I should see a "Getting Started" section
  """
  And the step should verify the current page has an h2 with the text specified in the parameter

Scenario: Specify a set of links that should be in a section
  Given I have access to the solution
  Then I should be able to define a scenario with the following step
  """
  And the "Getting Started" section should contain the following links
  | LinkText                          |
  | Installing the Prerequisites      |
  | Getting Access to the Source Code |
  | Running the Application           |
  """
  And the step should verify the current page has an h2 with the text specified in the parameter 
  And the step should verify the page has the specified links before the next h2 

Scenario: Follow a link on a page
  Given I have access to the solution
  Then I should be able to define a scenario with the following step
  """
  And I click the "Installing the Prerequisites" link
  """
  And the step should verify the current page has an anchor with the text specified in the parameter

Scenario: Follow a link in a section
  Given I have access to the solution
  Then I should be able to define a scenario with the following step
  """
  And I click the "Installing the Prerequisites" link in the "Getting Started" section
  """
  And the step should verify the current page has an anchor with the text specified in the parameter in the section specified

Scenario: Describe the content of a section
  Given I have access to the solution
  Then I should be able to define a scenario with the following step
  """
  And the "Overview" section should "give an overview of the steps for installing all components need to run the solution"
  """
  And the step should do nothing but pass

Scenario: Documenation Scenario Page Structure Validation Example
  Given I am a developer
  When I view the "ReadMeSample" markdown file
  Then I should see a "Sample Section" section
  And the "Sample Section" section should contain the following links
  | LinkText      |
  | Sample Page 1 |
  | Sample Page 2 |
  | Sample Page 3 |

Scenario: Documenation Scenario Page Location Validation Example
	Given I am a developer
	When I view the "ReadMeSample" markdown file
  And I click the "Sample Page 1" link
	Then I should see the "Sample Page 1" page
  And the page should "say I am an example of a page in the documentation"

Scenario: Click Link in a Section
	Given I am a developer
	When I view the "ReadMeSample" markdown file
  And I click the "Sample Page X" link in the "Sample Section X" section
	Then I should see the "Sample Page X" page
  And the page should "say I am an example of a page in the documentation"

Scenario: Validate a List Item is in a Section
	Given I am a developer
	When I view the "ReadMeSample" markdown file
  And I click the "Sample Page X" link in the "Sample Section X" section
	Then I should see the "Sample Page X" page
  And I should see a "Sample Section Y" section
  And the "Sample Section Y" section should include a list item with the text "This is my list item"

Scenario: Validate a List Item is in a Section When the List Item Contains a Quote By Using Two Single Quotes
	Given I am a developer
	When I view the "ReadMeSample" markdown file
  And I click the "Sample Page X" link in the "Sample Section X" section
	Then I should see the "Sample Page X" page
  And I should see a "Sample Section Y" section
  And the "Sample Section Y" section should include a list item with the text "This is my list item ''with a quote''"

Scenario: Documenation Scenario Page Deep Location Validation Example
	Given I am a developer
	When I view the "ReadMeSample" markdown file
  And I click the "Sample Page 1" link
  And I click the "Sample Page 1.1" link
	Then I should see the "Sample Page 1.1" page
  And the page should "say I am an example of a page in the documentation"
