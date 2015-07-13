Feature: Users
	In order to manage all users 
	As an admin
	I want to navigate to All Users page

@Rohan_UsersSection
@Must
Scenario: Presence of Users section
	Given I login as admin
	When I navigate to Users section
	Then I should see a Users panel
	And The panel header should be 'Users'

@Rohan_UsersSection
@Must
Scenario: Presence of Search Box
	Given I login as admin
	When I navigate to Users section
	Then I should see a Search box in the panel
	And Search box should have a placeholder 'Search...'

@Rohan_UsersSection
@Must
Scenario: Presence of Search Button
	Given I login as admin
	When I navigate to Users section
	Then I should see a 'Search' button

@Rohan_UsersSection
@Must
Scenario: Presence of Register button
	Given I login as admin
	When I navigate to Users section
	Then I should see a 'Register' button

@Rohan_UsersSection
@Must
Scenario: Collapse functionality of Users panel
	Given I am on Users section
	When I click on Collapse/Expand arrow
	Then The panel should collapse

@Rohan_UsersSection
@Must
Scenario: Expand functionality of Users panel
	Given I am on Users section
	And The Users panel is collapsed
	When I click on Collapse/Expand arrow
	Then The panel should expand

@Rohan_UsersSection
@Must
Scenario: Pagination of Users panel
	Given I login as admin
	When I navigate to Users section
	Then I should see a 'First Page' button in the footer
	And I should see a 'Previous Page' button in the footer
	And I should see the current page number
	And I should see a 'Next Page' button in the footer

@Rohan_UsersSection
@Must
Scenario: Appropriate User Details in Users Panel
	Given I login as admin
	When I navigate to Users section
	Then There should be table headers as 'Id','Email','Full Name','Phone','Address','Active' with the users data

@Rohan_UsersSection
@Must
Scenario: Presence of Remove Icon
	Given I login as admin
	When I navigate to Users section
	Then I should see a Remove Icon 

@Rohan_UsersSection
@Must
Scenario: Presence of Edit Icon
	Given I login as admin
	When I navigate to Users section
	Then I should see a Edit icon

@Rohan_UsersSection
@Must
Scenario: Register Button Functionality
	Given I am on Users section
	When I click on "Register" button
	Then I should be navigated to Registration form

@Rohan_UsersSection
@Must
Scenario Outline: Remove User 
	Given I am on Users section
	When I click on Remove Icon for a particular user with "<Email>"
	And I click on Delete User
	Then The user with "<Email>" should be inactive
	Examples: 
	| Email               |
	| Test5@protiviti.com |
	

@Rohan_UsersSection
@Must
Scenario Outline: Assign Roles Screen
	Given I am on Users section
	When I click on Edit Icon for user with "<Email>"
	Then I should be navigated to Assign Roles screen
	And I should see a 'Back to list' button on the top
	Examples: 
	| Email               |
	| Test1@protiviti.com |
	| Test4@protiviti.com |

@Rohan_UsersSection
@Must 
Scenario Outline: Assign Roles to User
	Given I am on Assign Roles Screen of user with "<Email>"
	When I click on the Role to be assigned
	Then The Role should be added to the User
	Examples: 
	| Email |
	| Test1@protiviti.com |
	| Test4@protiviti.com |

@Rohan_UsersSection
@Must
Scenario Outline: Remove the assigned role
	Given I am on Assign Roles Screen of user with "<Email>"
	When I click on assigned role
	Then The Assigned Role should be removed
	Examples: 
	| Email |
	| Test1@protiviti.com |
	| Test4@protiviti.com |

@Shruti
Scenario Outline: Presence of Activate button
	Given I am on Users section
	And I have searched email "<Email>"
	When I click on Remove Icon for a particular user with "<Email>"
	And I click on Delete User
	Then the activate button for "<Email>" should be visible
	Examples: 
	| Email               |
	| Test5@protiviti.com |

@Shruti
#should be executed after 'Presence of Activate button'
Scenario Outline: Clicking of Activate button
	Given I am on Users section
	And I have searched email "<Email>"
	When I click on activate button for a particular user with "<Email>"
	Then the user with "<Email>" should be activated
	Examples: 
	| Email               |
	| Test5@protiviti.com |

@Shruti
#should be executed after 'Presence of Activate button'
Scenario Outline: Cancel should not activate user
	Given I am on Users section
	And I have searched email "<Email>"
	When I click on activate button for a particular user with "<Email>" and click cancel
	Then the user with "<Email>" should not be activated
	Examples: 
	| Email               |
	| Test1@protiviti.com |
	| Test2@protiviti.com |


@Shruti
Scenario Outline: Presence of Edit Password for users section
	Given I am on Users section
	And I have searched email "<Email>"
	When I click on Edit Icon for a particular user with "<Email>"
	Then the Edit Password section is visible
	Examples: 
	| Email               |
	| Test1@protiviti.com |
	| Test2@protiviti.com |
	

@Shruti
Scenario Outline: Validation message is displayed on empty mandatory fields
	Given I am on Users section
	And I have searched email "<Email>"
	And I click on Edit Icon for a particular user with "<Email>"
	When I leave the new password field empty
	Then the required validation message is displayed
	Examples: 
	| Email               |
	| Test1@protiviti.com |
	| Test2@protiviti.com |
	

@Shruti
Scenario Outline: Validation message is displayed on different confirm password
	Given I am on Users section
	And I have searched email "<Email>"
	And I click on Edit Icon for a particular user with "<Email>"
	When I leave fill a different confirm password
	And I click on submit button
	Then the validation message for different confirm password is displayed 
	Examples: 
	| Email               |
	| Test1@protiviti.com |
	| Test2@protiviti.com |
	

@Shruti
Scenario Outline: Validation message is displayed for an invalid password 
	Given I am on Users section
	And I have searched email "<Email>"
	And I click on Edit Icon for a particular user with "<Email>"
	When I fill an invalid new password
	And  I fill the same confirm password
	And I click on submit button
	Then the validation message for invalid password is displayed 
	Examples: 
	| Email               |
	| Test1@protiviti.com |
	| Test2@protiviti.com |
	

@Shruti
Scenario Outline: Successful change password
	Given I am on Users section
	And I have searched email "<Email>"
	And I click on Edit Icon for a particular user with "<Email>"
	When I fill a valid new password
	And  I fill the same valid confirm password
	And I click on submit button
	Then the success message is displayed 
	Examples: 
	| Email               |
	| Test2@protiviti.com |

@dbTesting
@Pending
@Preiksha
Scenario Outline: Remove User and validate with database
	Given I am on Users section
	When I click on Remove Icon for a particular user with "<Email>"
	And I click on Delete User
	Then The user should be displayed as inactive in the database
	Examples: 
	| Email               |
	| Test2@protiviti.com |
	


	


	






	
