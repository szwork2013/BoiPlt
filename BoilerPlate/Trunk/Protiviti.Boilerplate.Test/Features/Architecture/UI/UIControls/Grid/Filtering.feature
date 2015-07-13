Feature: Filtering
	In order to allow the user to search for relevant data records
	As a user
	I want to enter filter criteria and see filtered results in my grid

Scenario Outline: Filtering a grid by one column
    Given I am viewing a grid
    When I apply a(n) <type of filter> filter to a column of <data type> type
    Then the grid should show only rows with column value <description of match> filter value
    Examples:
    | type of filter           | data type | description of match     |
    | equals                   | any       | equal to                 |
    | not equals               | any       | not equal to             |
    | contains                 | string    | containing               |
    | starts with              | string    | starting with            |
    | ends with                | string    | ending with              |
    | greater than             | numeric   | greater than             |
    | less than                | numeric   | less than                |
    | greater than or equal to | numeric   | greater than or equal to |
    | less than or equal to    | numeric   | less than or equal to    |

Scenario: Filtering a grid by multiple columns
	Given I am viewing a grid
	When I apply filters to multiple columns
	Then the grid should show only rows with column values matching all of the filters entered