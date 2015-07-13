Feature: Filter
	In order to allow the user to search for relevant data records
	As a user
	I want to enter filter criteria and see filtered results in my grid

@Sprint0 @Shira
Scenario Outline: Filter a grid by one column
    Given I am viewing a grid on the gridDemo page
    When I apply a <filter text> filter with filter value <filter value> to column <column> type
    Then the grid should show <result count> rows with MyString values of <MyString values> 
    Examples:
    | filter text              | filter value | column    | result count | MyString values |
    | Starts with              | Do           | LastName  | 1            | abc      |
    | Is equal to              | Doe          | LastName  | 1            | abc      |
    | Is not equal to          | Doe          | LastName  | 1            | aaa      |
    | Contains                 | ra           | LastName  | 1            | aaa      |
    | Does not contain         | Do           | LastName  | 1            | aaa      |
    | Ends with                | y            | LastName  | 1            | aaa      |
   





