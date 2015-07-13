Feature: Validate
	In order to ensure that my data conforms to specific formats
	As a user
	I want input validation errors to show if entered data are invalid

Scenario Outline: Enter characters and click tab key to run client side validation
	Given I have a text input field taking data of type <type>
	When I enter <entry> into the field
	Then a validation message should appear in red below the field saying <error message>.
	Examples: 
	| type     | entry       | error message                                                            |
	| date     | 123/        | "Value must be a valid date in format 'mm/dd/yyyy'."                     |
	| date     | 14/2/2014   | "Value must be a valid date in format 'mm/dd/yyyy'."                     |
	| currency | 123a2.4     | "Value must be a currency amount.                                        |
	| email    | abc@123     | "Value must be a valid email address containing an @ sign and a domain." |
	| email    | myEmail     | "Value must be a valid email address containing an @ sign and a domain." |