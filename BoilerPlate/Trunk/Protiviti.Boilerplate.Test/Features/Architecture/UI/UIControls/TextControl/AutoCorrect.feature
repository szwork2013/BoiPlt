Feature: AutoCorrect
	In order to ensure that my data conforms to specific formats
	As a user
	I want to have my data autocorrected in cases when that is easy to do

Scenario Outline: Enter characters and click tab key to run client side validation
	Given I have a text input field taking data of type <type>
	When I enter <entry> into the field and tab away
	Then the value entered should be automatically corrected to <corrected value>
	Examples: 
	| type     | entry  | corrected value |
	| currency | 12.344 | 12.34           |
	| currency | 12.345 | 12.35           |