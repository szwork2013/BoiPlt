Feature: ReviewPerformanceTestingResearchDoc
	In order to confirm a performance research document is added
	As a team member
	I want to navigate through the document page and look for the file

@TylorMondragon
Scenario: Review Performance Notes Document
	Given I am at the document homepage
	When I click on test hyperlink
	And I am at the test architecture page
	And I click Visual Studio Performance hyperlink
	Then performance research notes page should load
