@Sprint1 @AlokGupta @Must
Feature: SearchEntityListWithExpandedEntitiesUIService
	In order to retrieve entities with sub entities from client code
	As a developer
	I want to work with an example

Scenario: Retrieve all application from client code
	Given I am a developer when I want to retrieve all applications with applicant, program, invoice and payment from client code
	When I make a call to "#/applications" page
	Then I should see a list of application with program, applicant, invoice and payment information

Scenario: Validate Result Table When Retrieve all applications from client code
	Given I am a developer when I want to retrieve all applications with applicant, program, invoice and payment from client code
	When I make a call to "#/applications" page
	Then I should see results in a table "Applications-Results-Table"

Scenario: Validate Application Name Column When Retrieve all applications from client code
	Given I am a developer when I want to retrieve all applications with applicant, program, invoice and payment from client code
	When I make a call to "#/applications" page
	Then I should see name column "Applications-Results-Header-Name"

Scenario: Validate Application Status Column When Retrieve all applications from client code
	Given I am a developer when I want to retrieve all applications with applicant, program, invoice and payment from client code
	When I make a call to "#/applications" page
	Then I should see status column "Applications-Results-Header-Status"

Scenario: Validate Program Name Column When Retrieve all applications from client code
	Given I am a developer when I want to retrieve all applications with applicant, program, invoice and payment from client code
	When I make a call to "#/applications" page
	Then I should see program name column "Applications-Results-Header-ProgramName"

Scenario: Validate Applicant Name Column When Retrieve all applications from client code
	Given I am a developer when I want to retrieve all applications with applicant, program, invoice and payment from client code
	When I make a call to "#/applications" page
	Then I should see applicant name column "Applications-Results-Header-ApplicantName"

Scenario: Validate Applicant Email Column When Retrieve all applications from client code
	Given I am a developer when I want to retrieve all applications with applicant, program, invoice and payment from client code
	When I make a call to "#/applications" page
	Then I should see applicant email column "Applications-Results-Header-ApplicantEmail"

Scenario: Validate Applicant Company Column When Retrieve all applications from client code
	Given I am a developer when I want to retrieve all applications with applicant, program, invoice and payment from client code
	When I make a call to "#/applications" page
	Then I should see applicant company column "Applications-Results-Header-ApplicantCompany"

Scenario: Validate Applicant Department Column When Retrieve all applications from client code
	Given I am a developer when I want to retrieve all applications with applicant, program, invoice and payment from client code
	When I make a call to "#/applications" page
	Then I should see applicant department column "Applications-Results-Header-ApplicantDepartment"

Scenario: Validate Application Invoice Amount Column When Retrieve all applications from client code
	Given I am a developer when I want to retrieve all applications with applicant, program, invoice and payment from client code
	When I make a call to "#/applications" page
	Then I should see invoice amount column "Applications-Results-Header-InvoiceAmount"

Scenario: Validate Application Invoice Payment Account Number Column When Retrieve all applications from client code
	Given I am a developer when I want to retrieve all applications with applicant, program, invoice and payment from client code
	When I make a call to "#/applications" page
	Then I should see payment account number column "Applications-Results-Header-PaymentAccountNumber"

Scenario: Validate Application Invoice Payment Routing Number Column When Retrieve all applications from client code
	Given I am a developer when I want to retrieve all applications with applicant, program, invoice and payment from client code
	When I make a call to "#/applications" page
	Then I should see payment routing number column "Applications-Results-Header-PaymentRoutingNumber"
