@Sprint0 @AlokGupta @Must
Feature: DocumentSubscribeProjectAlerts
	In order to susbcribe to project aletrs to review all check-in messages
	As a developer
	I want to read steps to subscribe project alerts

Scenario: Document Subscribe Project Alerts
	Given I am a Team Foundation Server User
	When I enter page reference DocumentSubscribeProjectAlerts "Development/Setup/SubscribeProjectAlerts"
	Then I should see the documentation on how to subscribe to TFS alerts "Subscribe Project Alerts"
