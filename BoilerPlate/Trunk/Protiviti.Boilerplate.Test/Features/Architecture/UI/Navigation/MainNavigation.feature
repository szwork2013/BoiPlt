Feature: MainNavigation
	In order to browse the site
	As a user
	I want to use the navigation bar

@MikeWzorek @Sprint0 @BenBloomfield
Scenario: Browse to CDS Initiatives page
	Given I am at the application "Home" page
	When I press the "Navigate" tab
	Then the CDS Initiatives page should load 
