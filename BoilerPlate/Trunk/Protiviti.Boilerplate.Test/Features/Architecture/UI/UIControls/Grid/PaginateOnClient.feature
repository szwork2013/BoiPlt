﻿Feature: PaginateOnClient
	In order to optimize subsequent page loads for a small data set
	As a user
	I want to be able to retrieve data for my grid from the server all at once but display only one page at a time

Background: 
	Given a database table "Data" having the following rows:
		| MyString | MyInt | MyDecimal | MyFloat | FirstName | LastName |
		| abc      | 5     | 1.463     | 1.463   | Jane      | Doe      |
		| def      | 1     | 1.464     | 1.464   | Julie     | Doe      |
		| aaa      | 323   | 74.34     | 12.12   | Stanley   | Brady    |
		| lalalala | 52    | -12.0     | 345.2   | Horace    | Franklin |
		| ccc      | 5     | 1.463     | 1.463   | Phillip   | Brown    |
		| ccc      | 1     | 1.464     | 1.464   | Ralph     | Stoller  |
		| abd      | 334   | 74.34     | 12.12   | Alice     | Brady    |
		| baa      | 5     | -12.0     | 345.2   | Aaliyah   | Franklin |
		| ras      | 5214  | 1.463     | 1.463   | Jane      | Doe      |
		| ak       | 1     | 1.464     | 1.464   | Sherice   | James    |
		| out      | 31    | 74.34     | 12.12   | Stanley   | Green    |

@ignore
#@Sprint0 @Shira
Scenario: Grid shows the correct page numbers
	Given I am viewing a client-side paginated grid generated from table "Data"
	And the grid has 3 lines per page
	When I view the grid
	Then page numbers show in the standard format for the grid control

@ignore
#@Sprint0 @Shira
Scenario: First page loads with server side pagination
	Given I have a link to the page with a client-side paginated grid generated from table "Data"
	And the grid has 3 lines per page
	When I click the link to the grid
	Then The page with the grid loads and all of the lines of data are retrieved from the server
	And The first 3 lines of data are displayed in the grid
	And the page number 1 is highlighted
@Ignore
#@Sprint0 @Shira
Scenario: Clicked page number loads one page of data from the server
	Given I am viewing a client-side paginated grid generated from table "Data"
	And the grid has 3 lines per page
	When I click on page 3
	Then nothing is retrieved from the server 
	And Lines 7-9 are displayed in the grid
	And the page number 3 is highlighted

	
