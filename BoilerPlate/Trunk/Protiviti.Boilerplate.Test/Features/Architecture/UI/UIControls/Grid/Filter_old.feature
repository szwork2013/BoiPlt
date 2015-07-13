Feature: Filter_old
	In order to allow the user to search for relevant data records
	As a user
	I want to enter filter criteria and see filtered results in my grid

Background: 
	Given a database table having the following rows:
		| MyString | MyInt | MyDecimal | MyFloat | FirstName | LastName |
		| abc      | 5     | 1.463     | 1.463   | Jane      | Doe      |
		| def      | 1     | 1.464     | 1.464   | Julie     | Doe      |
		| aaa      | 3     | 74.34     | 12.12   | Stanley   | Brady    |
		| baa      | 5     | -12.0     | 345.2   | Horace    | Franklin |

	And a grid having the following columns and column types:
		| Column    | Type    |
		| MyString  | string  |
		| MyInt     | integer |
		| MyDecimal | decimal |
		| MyFloat   | float   |
		| FirstName | string  |
		| LastName  | string  |
		| FullName  | string  |


Scenario Outline: Filtering a grid by one column
    Given I am viewing a grid
    When I apply a(n) <type of filter> filter with filter value <filter value> to column <column> type
    Then the grid should show <result count> rows with MyString values of <MyString values> 
    Examples:
    | type of filter           | filter value | column    | result count | MyString values |
    | equals                   | Doe          | LastName  | 2            | abc,def         |
    | not equals               | Doe          | LastName  | 2            | aaa, baa        |
    | contains                 | ra           | LastName  | 2            | aaa,baa         |
    | starts with              | B            | LastName  | 1            | aaa             |
    | ends with                | n            | LastName  | 1            | baa             |
    | greater than             | 1.464        | MyDecimal | 1            | aaa             |
    | less than                | 1.464        | MyDecimal | 2            | abc,baa         |
    | greater than or equal to | 345.2        | MyFloat   | 1            | baa             |
    | less than or equal to    | 1.464        | MyDecimal | 3            | abc, def, baa   |


Scenario: Filtering a grid by multiple columns
	Given I am viewing a grid
	When I apply filters LastName = Doe and MyInt=5
	Then the grid should show only the row with MyString=abc