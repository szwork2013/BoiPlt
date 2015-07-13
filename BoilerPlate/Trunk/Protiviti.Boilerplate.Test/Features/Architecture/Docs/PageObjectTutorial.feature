Feature: PageObjectTutorial
	In order to help new commers with understanding the page model we are using
	As a team member who would like to get others the help they need
	I want to add a section about the page model in the project documentation

@Sal @Sprint1 @SalehComplete
Scenario: Add Page model tutorial page to the documentations
	Given I am a team member
	When I view the "README" markdown file
	And I click the "Page Model Tutorial" link in the "Solution Architecture" section
	Then I should see the "Page Model Tutorial" page

@Sal @Sprint1
Scenario: Review page model tutorial page 
	Given I am a team member
	When I view the "README" markdown file
#	And I click the "Page Model Tutorial" link in the "Solution Architecture" section
	#Then I should see the "Page Model Tutorial" page
#	And I should see a "Overview" section
#	And the "Overview" section should "Page Object Model is the term that selenium users keep buzzing. Page object is a design pattern that can be implemented as a selenium best practices."
#	And I should see a "Some of the advantages of page object pattern as listed below," section
  #  And I should see a "Example of Page Object which models the Google search page:" section
	
 
