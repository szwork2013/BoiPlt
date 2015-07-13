Feature: Roles
       In order to view/add roles
       As an Admin
       I want to navigate to Roles

@Preiksha_RoleManagement
@AjaySingh
@RoleManagement
@Must
#Current
Scenario: Presence of roles section
       Given I login as Admin
       When I click on Roles from the Navigation bar
       Then The table header should be 'Roles'

@Preiksha_RoleManagement
@AjaySingh
@RoleManagement
@Must
#Current
Scenario Outline: Creating new roles successfully
       Given I am on the Add Role section
       When I enter "<RoleName>"
       And I click on Add button 
       Then either a message 'Role <RoleName> created successfully.' or 'Name <RoleName> is already taken.' should be displayed
       Examples: 
       | RoleName |
       | Check1   |
       | !@Check2 |
       | 1!@#$Aa+ |
       | TestRole     |

@Preiksha_RoleManagement
@AjaySingh
@RoleManagement
@Must
#Current
Scenario Outline: Proper Display of Delete pop-up  
       Given I am on the Roles section
       When I Click on delete of "<RoleName>"
       Then a pop up 'Delete <RoleName>?' should be displayed
       And a message'Are you sure you want to delete this role?' should be displayed
       And Cancel button should be displayed
       And Delete Role button should be displayed
       Examples: 
       | RoleName |
       | TestRole  |

@Preiksha_RoleManagement
@AjaySingh
@RoleManagement
@Must
#Current
Scenario: Proper display of Search Section
       Given I am on the Roles Page
       When I view the Roles table
       Then I should see a placeholder 'Search...' on search input field  
       And Search button should be displayed

@Preiksha_RoleManagement
@AjaySingh
@RoleManagement
@Must
#Current
Scenario: Expand functionality of roles grid
       Given I am on the Roles Page
       When I double click on the arrow 
       Then The grid should expand

@Preiksha_RoleManagement
@AjaySingh
@RoleManagement
@Must
#Pending
Scenario Outline: Roles with blank name should not be saved 
       Given I am on the Add Role section
       When I enter "<RoleName>"
       Then Add button should not get enabled
       Examples: 
       | RoleName |
       |          |

@Preiksha_RoleManagement
@AjaySingh
@RoleManagement
@Must
#Current
Scenario Outline: Role Deletion   
       Given I am on the Roles Page
       When I Click on delete of "<RoleName>"
       And I Click on Delete Role in the pop-up
       Then I should not see the "<RoleName>" in Roles table
       Examples: 
       | RoleName |
       | UpdateRole |
	   | 1!@#$Aa+ |

@Preiksha_RoleManagement
@AjaySingh
@RoleManagement
@Must
#Current
Scenario Outline: Functionality of Pagination
          Given I am on the Roles Page
          When I click the "<Button>" button
          Then I should navigate to "<Page>" page
          Examples: 
          | Button        | Page  |
          | First Page    |Page: 1|

@Preiksha_RoleManagement
@AjaySingh
@RoleManagement
@Must
#Current
Scenario: View Add new roles
       Given I am on the Roles Page
       When I click on the Add button 
       Then Add Roles page should be displayed
       And an hyperlink 'Back to list' should be displayed
       And A label 'Role Name:' with an input box should be displayed
       And An Add button should be displayed


@Preiksha_RoleManagement
@AjaySingh
@RoleManagement
@Must
#Current
Scenario: Display of pagination in the grid
          Given I am on the Roles Page
          When I view the Roles table
          Then I should see First Page button in the footer   
          And I should see Previous Page button in the footer
          And I should see the current page number as  " Page: 1  "  
          And I should see Next Page button in the footer

@Preiksha_RoleManagement
@AjaySingh
@RoleManagement
@Must
#Current
Scenario Outline: Proper display of edit role page 
       Given I am on the Roles Page
       When I Click on edit of "<RoleName>"
       Then I should navigate to Edit Role "<RoleName>" page
       And an hyperlink 'Back to list' should be displayed
       And A label 'Role Name:' with an input box should be displayed
       And An Update button should be displayed
Examples: 
       | RoleName |
       | Member   |


@Preiksha_RoleManagement
@AjaySingh
@RoleManagement
@Must
#Pending
Scenario Outline: Error message on creating role with duplicate name 
       Given I am on the Add Role section
       When I enter "<RoleName>"
       And I click on Add button 
       Then an error message for duplicate 'Name Member is already taken.' should be displayed 
       Examples: 
       | RoleName |
       | Member   |

@Preiksha_RoleManagement
@AjaySingh
@RoleManagement
@Must
#Pending
Scenario Outline: Updating role name 
       Given I am on Edit Roles of "<RoleName>"
       When I change the "<RoleName>" to "<UpdatedRoleName>"
       And I click on Update button
       Then either a message 'Role <UpdatedRoleName> updated successfully.' or 'Name <UpdatedRoleName> is already taken.' should be displayed
       Examples: 
       | RoleName | UpdatedRoleName |
       | TestRole   | UpdateRole          |
       
@Preiksha_RoleManagement
@AjaySingh
@RoleManagement
@Must
#Current
Scenario: Proper display of Roles Table
       Given I am on the Roles section
       When I view the Roles table
       Then I should see a Table with header as 'Role'  
       
       
@Preiksha_RoleManagement
@AjaySingh
@RoleManagement
@Must
#Current
Scenario Outline: Searching existing roles 
       Given I am on the Roles Page
       When I enter "<RoleName>" in the Search
       And I click on Search button 
       Then I should see role having the same name as "<RoleName>" 
       Examples: 
       | RoleName |
       | Member   |

@Preiksha_RoleManagement
@AjaySingh
@RoleManagement
@Must
#Current
Scenario: Collapse functionality of roles grid
       Given I am on the Roles Page
       When I click on the arrow 
       Then The grid should collapse

@dbTesting
@Preiksha
Scenario Outline: Role Deletion and validating with the database  
       Given I am on the Roles Page
       When I Click on delete of "<RoleName>"
       And I Click on Delete Role in the pop-up
       Then I should not see the "<RoleName>" in Roles table in database
       Examples: 
       | RoleName |
       | TestRole   |
	  
 