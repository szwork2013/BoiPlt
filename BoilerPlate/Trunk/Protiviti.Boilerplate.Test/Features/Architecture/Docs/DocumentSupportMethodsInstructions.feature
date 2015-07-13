Feature: Support Methods Document
	In order to explain helper and utility classes
	As a team member
	I want to create document to list explain these classes

@Sal @Sprint1 
Scenario: How to use Explicit Wait 
	Given I am a team member
	When I view the "README" markdown file
	And I click the "Development" link in the "Process" section
	And I click the "Support and Utility Classes" link
	Then I should see the "Support and Utilities" page
