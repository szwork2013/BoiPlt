Feature: ChangePassword
	In order to change my account password
	As a registered user
	I want to navigate to change password page and change the password

@Shruti
Scenario: Presence of Old Password field
	Given I am logged in
	When I click on Change password in profile drop down menu item
	Then I should see a old password field in the Change Password section	

@Shruti
Scenario: Presence of New Password field
	Given I am logged in
	When I click on Change password in profile drop down menu item
	Then I should see a new password field in the Change Password section	

@Shruti
Scenario: Presence of Confirm Password field
	Given I am logged in
	When I click on Change password in profile drop down menu item
	Then I should see a confirm password field in the Change Password section

@Shruti
Scenario: Empty mandatory field should show validation message
	Given I am logged in
	And I click on Change password in profile drop down menu item
	When I clear the old password field	
	And I click save
	Then I should see a validation message for old password

@Shruti
Scenario: Same old and new password should not be accepted
	Given I am logged in
	And I click on Change password in profile drop down menu item
	When I add a new password
	And  I add same text as old password
	And I click save
	Then I should see a validation message for same passwords
