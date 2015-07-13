Feature: Dashboard
	In order to view the dashboard page 
	as a boilerplate solution user 
	I want to navigate to the dashboard page 

@Hanna
@Must
@Sprint0
@Sprint1
Scenario: View dashboard page 
	Given I am a boilerplate solution user
	And I navigate to the boilerplate site 
	Then the Dashboad page is displayed 

@Hanna
@Must
@Sprint0
@Sprint1
Scenario Outline: Click a link on the dashboard page 
	Given I am a boilerplate solution user 
	And I navigate to the boilerplate site 
	Then I can click "<link>" in the Technology Overview table on the Dashboard page 
	Examples: 
		| link                                     |
		| Entity Framework                         |
		| AngularJs                                |
		| Breezejs                                 |
		| Bootstrap                                |
		| Asp.Net WebApi (CORS, Attribute Routing) |
		| Semantic Logging                         |
		| Typescript                               |
		| Asp.Net Identity                         |
		| Owin                                     |
		| Katana                                   |

@Hanna
@Should
@Sprint0
@Sprint1
Scenario: View header on the dashboard page 
	Given I am a boilerplate solution user
	And I navigate to the boilerplate site 
	Then the main navigation header bar is displayed