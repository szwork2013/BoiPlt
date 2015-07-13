Feature: SettingUpSolutionDocumentation
	As a project new team member
	I want a document that explain how to setup the solution
	So that I can setup the solution.

@Julia @Sprint0
#Scenario: Solution setup instruction
#	Given I am I have not solution setup
#	When I view the solution Setup instruction document
#	Then I should see instructions on how to get solution
#	And Trouble shooting tips

@Julia @Sprint0
Scenario: Link to solution setup instruction
	Given I am a team member
	When I view the "README" markdown file
	Then I should see a "Getting Started" section
	When I click the "Solution Setup" link
	Then I should see the "Solution Setup Instructions" page

	
