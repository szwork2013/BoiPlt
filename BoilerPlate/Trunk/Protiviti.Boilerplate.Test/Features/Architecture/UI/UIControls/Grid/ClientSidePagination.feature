Feature: ClientSidePagination
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

@Sprint0 @Shira @Sal @SalehComplete
Scenario: Grid shows the correct page numbers
	Given I am viewing a client-side paginated grid generated from table "Data"
	And the grid "Local Data Grid with Sort and Filter" has 3 lines per page
	When I view the grid
	Then Page numbers showing is total Items devided by lines allowed by grid

@Sprint0 @Shira @Sal  
Scenario: First page loads with server side pagination
	Given I am at the application "Home" page
	When I press the "GridDemo" tab
	And the grid "Local Data Grid with Sort and Filter" has 3 lines per page
	Then The page with the grid loads and all of the lines of data are retrieved from the server
	And The first 3 lines of data are displayed in the grid
	And the page number 1 is highlighted

@ignore
#@Sprint0 @Shira @Sal
Scenario: Clicked page number loads one page of data from the server
	Given I am viewing a client-side paginated grid generated from table "Data"
	And the grid has 3 lines per page
	When I click on page 3
	Then nothing is retrieved from the server 
	And Lines 7-9 are displayed in the grid
	

	
@Sprint0 @Sal @SalehComplete
Scenario: Load the grid demo page
	Given I am at the  "Home" page
	When I press the "GridDemo"
	Then GridDemo Page should successfully load in the browser

@ignore
#@Sal @Sprint0 @AlokGupta
Scenario: Load data from DB to the Grid tables
	Given I am at the  "GridDemo" page
	Then the data populated in the Grid tables should be coming from DB.

