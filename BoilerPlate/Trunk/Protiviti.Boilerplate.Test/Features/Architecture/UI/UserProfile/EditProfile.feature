Feature: EditProfile
	In order to update my profile details
	As a registered user
	I want to edit and save my details

@Shruti
Scenario: Presence of Salutation drop down
	Given I am logged in
	When I click on Change Profile in profile drop down menu item
	Then I should see a salutation drop down in the Update User Profile section	

@Shruti
Scenario: Presence of First Name field
	Given I am logged in
	When I click on Change Profile in profile drop down menu item
	Then I should see a first name text field in the Update User Profile section

@Shruti
Scenario: Presence of Last Name field
	Given I am logged in
	When I click on Change Profile in profile drop down menu item
	Then I should see a last name text field in the Update User Profile section

@Shruti
Scenario: Presence of Suffix field
	Given I am logged in
	When I click on Change Profile in profile drop down menu item
	Then I should see a suffix text field in the Update User Profile section

@Shruti
Scenario: Presence of Title field
	Given I am logged in
	When I click on Change Profile in profile drop down menu item
	Then I should see a title text field in the Update User Profile section

@Shruti
Scenario: Presence of Phone Number field
	Given I am logged in
	When I click on Change Profile in profile drop down menu item
	Then I should see a phone text field in the Update User Profile section

@Shruti
Scenario: Presence of Cell Number field
	Given I am logged in
	When I click on Change Profile in profile drop down menu item
	Then I should see a cell text field in the Update User Profile section

@Shruti
Scenario: Presence of Address Line 1 field
	Given I am logged in
	When I click on Change Profile in profile drop down menu item
	Then I should see a address lineOne text field in the Update User Profile section

@Shruti
Scenario: Presence of Address Line 2 field
	Given I am logged in
	When I click on Change Profile in profile drop down menu item
	Then I should see a address lineTwo text field in the Update User Profile section

@Shruti
Scenario: Presence of City field
	Given I am logged in
	When I click on Change Profile in profile drop down menu item
	Then I should see a city text field in the Update User Profile section

@Shruti
Scenario: Presence of Country drop down field
	Given I am logged in
	When I click on Change Profile in profile drop down menu item
	Then I should see a country drop down in the Update User Profile section

@Shruti
Scenario: Presence of State drop down field
	Given I am logged in
	When I click on Change Profile in profile drop down menu item
	Then I should see a state drop down in the Update User Profile section

@Shruti
Scenario: Clicking cancel redirects to dashboard
	Given I am logged in
	And I click on Change Profile in profile drop down menu item
	When I click cancel	
	Then I should be redirected to dashboard

@Shruti
Scenario: Updating first name
	Given I am logged in
	And I click on Change Profile in profile drop down menu item
	When I edit the first name 
	And I click save
	Then the change should be saved

@Shruti
Scenario: Updating last name
	Given I am logged in
	And I click on Change Profile in profile drop down menu item
	When I edit the last name 
	And I click save
	Then the change should be saved

@Shruti
Scenario: Add a suffix saves successfully
	Given I am logged in
	And I click on Change Profile in profile drop down menu item
	When I add the suffix
	And I click save
	Then the change should be saved

@Shruti
Scenario: Empty mandatory field should show validation message
	Given I am logged in
	And I click on Change Profile in profile drop down menu item
	When I clear the first name field	
	And I click save
	Then I should see a validation message

@Shruti
Scenario: Empty non-mandatory field should save the changes
	Given I am logged in
	And I click on Change Profile in profile drop down menu item
	When I clear the suffix field	
	And I click save
	Then I should see a validation message

@Shruti
Scenario: Updating two fields together
	Given I am logged in
	And I click on Change Profile in profile drop down menu item
	When I edit the last name 
	And I add the suffix
	And I click save
	Then I should see a validation message

@Shruti
Scenario: Updating first name and then canceling
	Given I am logged in
	And I click on Change Profile in profile drop down menu item
	When I edit the first name 
	And I click cancel
	Then I should be redirected to dashboard

@dbTesting
@Preiksha
Scenario: Updating first name and validating with database
	Given I am logged in
	And I click on Change Profile in profile drop down menu item
	When I edit the first name 
	And I click save
	Then the change should be saved
	And the changes should reflect in the database

@dbTesting
@Preiksha
Scenario: Updating first name and then canceling and validating with database
	Given I am logged in
	And I click on Change Profile in profile drop down menu item
	When I edit the first name 
	And I click cancel
	Then I should be redirected to dashboard
	And the changes should not be reflected in the database

@dbTesting
@Preiksha
Scenario Outline: To validate schema of fields having fixed length
	Given The "<Field>" and its <MaxLength> on the front end
	When  I access the column schema from the database
	Then the length for the field should be same
	Examples: 
	| Field | MaxLength |
	| Phone | 15        |
	| Cell  | 15        |

@dbTesting
@Preiksha
Scenario: Updating record by filling all the mandatory fields and validating with the database
Given I am logged in
And I click on Change Profile in profile drop down menu item
When I edit Field and change it to Value = "!@#$ABc123" 
| Field          |   
| Suffix         | 
| Title          | 
| Fax            | 
| Address Line 2 |
| Postal Code    | 
And I click save
Then the change should be saved
And the value = "!@#$ABc123" should be reflected for updated Field in the database 
| Field          |   
| Suffix         | 
| Title          | 
| Fax            | 
| Address Line 2 |
| Postal Code    | 
