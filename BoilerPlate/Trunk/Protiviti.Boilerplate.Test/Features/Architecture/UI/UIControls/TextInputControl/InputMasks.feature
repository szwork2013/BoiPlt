Feature: InputMasks
	In order to ensure that my data conforms to specific formats
	As a user
	I want to enter data in fields equipped with input masks

Scenario Outline: Enter characters
	Given I have a text input field with a <type> mask having specific format <format>
	When I enter <entry> into the field
	Then <result> should be accepted and show in the field
	And <rejected values> should be rejected and should not show in the field
	And an error message <should show error> flash in red below the field saying <error message> when the invalid values are entered and then disappear when the final values are entered
	Examples:
	| type     | format       | entry       | result     | rejected values | should show error | error message                                                       |
	| date     | "mm/dd/yyyy" | 123/        | 12/        | 3               | should            | "Value must be a date in format 'mm/dd/yyyy'."                      |
	| date     | "mm/dd/yyyy" | 6/14/2014   | 6/14/2014  | no values       | should not        | n/a                                                                 |
	| currency | standard     | 12a4.235    | 124.23     | a5              | should            | "Value must be a currency amount with 2 numbers after the decimal." |
	| email    | standard     | abc@12#.com | abc@12.com | #               | should            | "Value must be a properly formatted email address."                 |

Scenario: Validate upon focus change
	Given I have a text input field with a <type> mask having specific format <format>
	When I enter <entry> into the field and click on another field
	Then <result> should be accepted and show in the field as I enter it
	And an error message should show when in red below the field saying <error message> when my focus changes to another field
	Examples:
	| type  | format   | entry       | result | error message                                       |
	| email | standard | abc@12#.com | abc@12 | "Value must be a properly formatted email address." |
