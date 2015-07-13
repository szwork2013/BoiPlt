@sprint0
@BenBloomfield

Feature: MultipleBrowserSupportTest
	In order to verify our boilerplate works in more than one kind of browser
	As a QA team member
	I want to view our applicaiton in Firefox and Chrome and IE

Scenario: Check browser compatability for Internet Explorer
	Given I have set up my local host
	And I have selected browse with Internet Explorer
	When I start without debugging
	Then I should be able to view our site in Internet Explorer
