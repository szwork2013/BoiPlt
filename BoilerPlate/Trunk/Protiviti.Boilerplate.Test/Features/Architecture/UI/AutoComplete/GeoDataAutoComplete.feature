@ignore
#@Sprint4 @AlokGupta @Must
Feature: GeoDataAutoComplete
	In order to provide auto complete feature
	As a developer
	I want to work with an example

Scenario: Auto Complete City List
	Given I am a developer when I want to provide a auto complete city list
	When I make a call to "#/geoautocomplete" page
	Then I should be able to type partial city name
	Then I should see list of city pulled from rest api