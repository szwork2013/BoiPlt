Feature: Sorting
	In order to allow the user to order results in a grid
	As a user
	I want to sort grid data by the columns that the user selects

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
		| FullName  | string  |
	
Scenario Outline: Sorting a grid
	Given I am viewing a grid
	When I click sort <sort direction> on column <column name>
	Then the grid results should be sorted <sort method>
	Examples:
	| sort direction | data type | sort method                |
	| ascending      | MyString  | alphabetically             |
	| descending     | MyString  | reverse-alphabetically     |
	| ascending      | MyInteger | in numerical order         |
	| descending     | MyInteger | in reverse-numerical order |
	| ascending      | MyDecimal | in numerical order         |
	| descending     | MyDecimal | in reverse-numerical order |
	| ascending      | MyFloat   | in numerical order         |
	| descending     | MyFloat   | in reverse-numerical order |
	| ascending      | FullName  | alphabetically             |
	| descending     | FullName  | reverse-alphabetically     |

Scenario: Sorting a grid by multiple columns
	Given I am viewing a grid
	When I sort by MyString, then by MyInteger, then by MyDecimal
	Then the grid should sort by all of those columns, in the order in which the sorts were applied
