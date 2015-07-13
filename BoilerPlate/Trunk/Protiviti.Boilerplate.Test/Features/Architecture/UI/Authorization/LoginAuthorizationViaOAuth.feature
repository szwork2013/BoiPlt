Feature: Login Functionality Authorization
	In order to login
	As a registered user
	I want to enter my username and password

@Rohan_LoginAuthorization
@AjaySingh
@Must
Scenario: Employees Menu Item Inaccessible without login 
	Given I am not logged in 
	When I view the top menu navigation bar
	Then I should not see the 'Employees' menu item

@Rohan_LoginAuthorization
@AjaySingh
@Must
Scenario: Presence of Employees Menu Item on Admin Login
	Given I login as admin
	When I view the top menu navigation bar 
	Then I should see the 'Employees' menu item
	And User logs out

@Rohan_LoginAuthorization
@AjaySingh
@Must
Scenario Outline: Presence of Employees Menu Item on Member Login
	Given I login as a member with username "<Username>" and password "<Password>"
	When I view the top menu navigation bar
	Then I should see the 'Employees' menu item
	And User logs out
	Examples:
	| Username            | Password  |
	| Test3@protiviti.com | Test@123  |

@Rohan_LoginAuthorization
@AjaySingh
@Must
Scenario Outline: Employees Menu Item Inaccessible to Non-Admin Non-Member Users
	Given I login as non-admin non-member user with username "<Username>" and password "<Password>"
	When I view the top menu navigation bar
	Then I should not see the 'Employees' menu item
	And User logs out
	Examples: 
	| Username            | Password  |
	| Test4@protiviti.com | Test@123  |

@Rohan_LoginAuthorization
@AjaySingh
@Must
Scenario: Presence of Manage Menu Item on Admin Login
	Given I login as admin
	When I view the top menu navigation bar
	Then I should see the 'Manage' menu item
	And I should see the 'All Users' and 'Roles' in the dropdown
	And User logs out

@Rohan_LoginAuthorization
@AjaySingh
@Must
Scenario: Manage Menu Item Inaccessible without login
	Given I am not logged in
	When I view the top menu navigation bar
	Then I should not see the 'Manage' menu item

@Rohan_LoginAuthorization
@AjaySingh
@Must
Scenario Outline: Manage Menu Item Inaccessible on Member Login
	Given I login as a member with username "<Username>" and password "<Password>"
	When I view the top menu navigation bar
	Then I should not see the 'Manage' menu item
	And User logs out
	Examples: 
	| Username            | Password  |
	| Test3@protiviti.com | Test@123  |

@Rohan_LoginAuthorization
@AjaySingh
@Must
Scenario Outline: Manage Menu Item Inaccessible to Non-Admin Non-Member Users
	Given I login as non-admin non-member user with username "<Username>" and password "<Password>"
	When I view the top menu navigation bar
	Then I should not see the 'Manage' menu item
	And User logs out
	Examples: 
	| Username            | Password  |
	| Test4@protiviti.com | Test@123  |










