Feature: Login Functionality Authentication
	In order to login
	As a registered user
	I want to enter my username and password

@Rohan_LoginAuthentication
@AjaySingh
@Must
Scenario: Presence of Username Field
	Given I am on Home Page
	When I click on Login button on the menu bar
	Then I should see a username field in the login section

@Rohan_LoginAuthentication
@AjaySingh
@Must
Scenario: Presence of Password field
	Given I am on Home Page
	When I click on Login button on the menu bar
	Then I should see a password field in the login section

@Rohan_LoginAuthentication
@AjaySingh
@Must
Scenario: Presence of Login button
	Given I am on Home Page
	When I click on Login button on the menu bar
	Then I should see a Login button in the login section

@Rohan_LoginAuthentication
@AjaySingh
@Must
Scenario: Presence of Reset button
	Given I am on Home Page
	When I click on Login button on the menu bar
	Then I should see a Reset button in the login section

@Rohan_LoginAuthentication
@AjaySingh
@Must
#works for browser versions supporting HTML5
Scenario: Presence of Placeholders on Username and Password field
	Given I am on Home Page
	When I click on Login button on the menu bar
	Then I should see a placeholder 'Username' on username field
	And I should see a placeholder 'Password' on password field

@Rohan_LoginAuthentication
@AjaySingh
@Must
Scenario Outline: Successful Login
	Given I am on Login Section
	When I enter username "<Username>" and password "<Password>"
	And I click on Login button
	Then I am logged in
	Examples: 
	| Username            | Password  |
	| admin@protiviti.com | Admin@123 |
	| Test4@protiviti.com | Test@123  |
	| Test2@protiviti.com | Test@123  |

@Rohan_LoginAuthentication
@AjaySingh
@Must
Scenario Outline: Unsuccessful Login
	Given I am on Login Section
	When I enter username "<Username>" and password "<Password>"
	And I click on Login button
	Then I see an alert for the invalid login
	And I click on OK
	Examples: 
	| Username                   | Password  |
	| helloadmin@protiviti.co.in | Admin@123 |
	| admin@protiviti.co.in      | Admin@456 |
	| helloadmin@protiviti.co.in | Admin@456 |

@Rohan_LoginAuthentication
@AjaySingh
@Must
Scenario Outline: Reset button functionality
	Given I am on Login Section
	When I enter username "<Username>" and password "<Password>"
	And I click on Reset button
	Then Username and Password fields should be reset
	Examples: 
	| Username                   | Password  |
	| helloadmin@protiviti.co.in |           |
	| admin@protiviti.co.in      | Admin@123 |
	|                            |           |
	|                            | Admin@456 |



