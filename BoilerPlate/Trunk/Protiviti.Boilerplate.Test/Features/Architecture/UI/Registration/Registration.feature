Feature: Registration
	In order to register on the site 
	As a boilerplate solution user
	I want to submit my contact information on the registration page 


@Hanna @Chandana @must
Scenario: Successful Registration
	Given I am on the registration page
	And I fill all the required fields with red asterisks 
	| Required Fields |
	| Email |
	| Confirm Email |  
	| Password |
	| Confirm Password |
	| First Name |
	| Last Name|
	| Phone Number |
	| Country|
	| AddressLine1 |
	| City |
	| State/Province |
	| User Agreement |
	When I click Submit button
	Then the form should be validated
	And I should be registered 

@Hanna @Chandana @must
Scenario: Submit button is required to complete registration
	Given I am on the registration page
	Then the Submit button should be displayed

@Hanna @Chandana @must
Scenario: Form cannot be submitted when required fields are partially filled 
	Given I am on the registration page
	And I fill in required fields partially
	When I click Submit button
	Then the form should be validated

	
@Hanna @Chandana @must
Scenario: Form is submitted when both required and non-required fields are filled 
	Given I am on the registration page
	And I fill in all the required fields and some non required fields
	When I click Submit button 
	Then the form should be validated


#@Hanna @Chandana @must
#Scenario: Non-required fields are not required to complete registration
	#Given I am on the registration page
	#And I see all the non required fields with no red asterisks
	#| Non-required Fields |
	#| Salutation  |
	#| Title |  
	#| Suffix |
	#| Fax |
	#| Cell |
	#| AddressLine2|
	#| Zip/Postal Code |
	#When I click Submit button
	#And no error message should be displayed if anything is missing

@Hanna @Chandana @must
Scenario: User agreement acceptance is required to complete registration
	Given I am on the registration page
	And I check user agreement checkbox
	When I click Submit button
	Then the T&C selection should be validated if checked

@Hanna @Chandana @could
Scenario: Clicking the Cancel button cancels registration
	Given I am on the registration page
	When I click Cancel button
	Then I should be taken to the home page

@Hanna @Chandana  @must
Scenario: All expected fields are listed on the registration page 
	Given I am on the registration page
	Then I should see Email field
	And I see Confirm Email field
	And I see Password field
	And I see Confirm Password field
	And I see First Name field
	And I see Last Name field
	And I see Phone Number field
	And I see Country field
	And I see Address Line 1 field
	And I see Address Line 2 field
	And I see City field
	And I see State/Province field
	And I see Salutation field
	And I see Title field
	And I see Suffix field
	And I see Fax field
	And I see Cell field
	And I see Zip/Postal code field

@Hanna @Chandana @should
Scenario: Email is in right format
	Given I am on the registration page
	And I enter value into email and confirm email fields 
	When I click Submit button
	Then the email should be validated for correct format

@Hanna @Chandana @should
Scenario: Email is in incorrect format
	Given I am on the registration page
	And I enter incorrect value into email and confirm email fields 
	When I click Submit button
	Then the email should be validated for incorrect format

@Hanna @Chandana @should
Scenario: Email fields are validated for match
	Given I am on the registration page
	And I enter value into email and confirm email fields 
	When I click Submit button
	Then the emails should be validated for match
	
	@Hanna @Chandana @should
Scenario: Email fields dont match
	Given I am on the registration page
	And I enter value into email and confirm email fields that don't match 
	When I click Submit button
	Then the emails should be validated for non match

@Hanna @Chandana @should
Scenario: Password format is validated
	Given I am on the registration page
	And I enter value into password and confirm password fields 
	When I click Submit button
	Then the password should be validated for correct format

@Hanna @Chandana @should
Scenario: Password fields are validated for match
	Given I am on the registration page
	And I enter value into password and confirm password fields 
	When I click Submit button
	Then the passwords should be validated for match

	@Hanna @Chandana @should
Scenario: Password fields dont match
	Given I am on the registration page
	And I enter value into password and confirm password fields that don't match each other
	When I click Submit button
	Then the passwords should be validated for non match

	@Hanna @Chandana @should
Scenario: Phone number is in correct format
	Given I am on the registration page
	And I enter value into phone number field 
	When I click Submit button
	Then the phone number should be validated for correct format

	@Hanna @Chandana @should
Scenario: Phone number is in incorrect format
	Given I am on the registration page
	And I enter invalid value into phone number field 
	When I click Submit button
	Then the phone number should be validated for incorrect format
	
#@Hanna @Chandana @must
#Scenario: Only the required fields are filled in to complete registration
	#Given I am on the registration page
	#And I fill all the required fields with red asterisks	
	#When I click Submit button
