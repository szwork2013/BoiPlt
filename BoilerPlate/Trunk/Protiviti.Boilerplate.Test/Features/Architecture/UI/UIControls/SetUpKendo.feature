Feature: SetUpKendo
	In order to use modern input controls
	As a programmer
	I want to utilize Kendo UI in the solution

@ignore
#@Kendo @Bootstrap @Setup @Sprint0 @Shira
Scenario: Utilize Kendo UI
	Given I have a web application with UI project Protiviti.Boilerplate.Client that uses Bootstrap
	When I press install Kendo files with just the necessary features
	Then There should be a javascript file with name starting with 'kendo.custom.min_' in the Scripts folder of the Protiviti.BoilerPlate.Client project
	And The kendo.custom.min file should specify the Kendo version used in the filename
	And index.html should contain a script include for the kendo.custom.min file
	And The css file kendo.common-bootstrap.min.css should exist in the Content folder of the Protiviti.BoilerPlate.Client project
	And The css file kendo.bootstrap.min.css should exist in the Content folder of the Protiviti.BoilerPlate.Client project
	And index.html should contain link tags to include kendo.common-bootstrap.min.css and kendo.bootstrap.min.css
	And The Angular module definition in app.js should declare a dependency on kendo.directives
