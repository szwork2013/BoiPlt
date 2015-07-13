Feature: EmployeesSection
	In order to manage all employees
	As an administrator
	I want to navigate to Employees page

@Rohan_EmployeesSection
Scenario Outline: Add a new employee
	Given I login as administrator
	And I navigate to Employees page
	When I click on Add button at the top right corner
	And I enter "<First Name>" in First Name field
	And I enter "<Last Name>" in Last Name field
	And I enter "<Division>" in Division field
	And I enter "<Designation>" in Designation field
	And I enter "<Location>" in Location field
	And I click on Add Employee button 
	Then The employee "<First Name>" should be added
	Examples: 
	| First Name | Last Name | Division | Designation | Location |
	| Employee1  | Employee  | 2        | 2           | India    |


@Rohan_EmployeesSection
Scenario Outline: Remove existing employee
	Given I login as administrator
	And I navigate to Employees page
	And Employee "<First Name>" "<Last Name>" "<Division>" "<Designation>" "<Location>" exists
	When I click on Delete icon for employee "<First Name>"
	Then The employee with "<First Name>" should be removed
	Examples: 
	| First Name | Last Name | Division | Designation | Location |
	| Employee1  | Employee  | 2        | 2           | India    |

@Rohan_EmployeesSection
Scenario Outline: Update Employee details
	Given I login as administrator
	And I navigate to Employees page
	When I click on update icon for employee "<First Name>"
	And I update "<First Name>" in First Name field
	And I update "<Last Name>" in Last Name field
	And I update "<Division>" in Division field
	And I update "<Designation>" in Designation field
	And I update "<Location>" in Location field
	And I click on the Update button 
	Then The employee "<First Name>" details should be updated
	Examples: 
	| First Name | Last Name | Division | Designation | Location |
	| Employee1  | Employee  | 1        | 1           | India    |



	
