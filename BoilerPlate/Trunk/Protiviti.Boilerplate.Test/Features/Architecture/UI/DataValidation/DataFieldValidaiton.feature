Feature: CDS Initiative task details field validation
	As a user on the CDS Initiatives page who is editing a task
	I want to know which fields are required and if the data I have entered on the page is incorrect
	So that I don't save an entry that has errors


	@Sprint1 @MikeWzorek @BenBloomfield
Scenario: Enter values into all fields and save
	Given I am viewing the first task for the first CDS Initiative
	When I enter a task name
	And I select an initiative contact
	And I enter a valid email
	And I select a start date
	And I enter a description
	And I enter a valid URL
	And I click Save
	Then I should see the new task name
	And I should see my selected initiative contact
	And I should see my entered email
	And I should see my selected start date
	And I should see my entered description
	And I should see my entered URL

	@Sprint1 @MikeWzorek @BenBloomfield
Scenario: Do not complete required fields
	Given I am viewing the first task for the first CDS Initiative
	When I do not enter a task name
	Then I should see the task name required message

	@Sprint1 @MikeWzorek @BenBloomfield
Scenario: Enter an invalid task URL
	Given I am viewing the first task for the first CDS Initiative
	When I enter an invalid URL
	Then I should see the  URL is not valid message
	
	@Sprint1 @MikeWzorek @BenBloomfield
Scenario: Enter an invalid email
	Given I am viewing the first task for the first CDS Initiative
	When I enter an invalid email
	Then I should see the email is not valid message

