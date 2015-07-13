Feature: FileUpload
	In order to upload a file 
	As a user
	I want to select a file from my local machine  

@Rohan_FileUpload
@Shruti
@Must
@Current
Scenario: Presence of File Upload Grid
	Given I am on Grid Demo Page
	When I view Kendo File Upload section
	Then I should see an empty Grid
	And Grid has following column names:
	| File Name | File Size | File Type | Upload Date Time |

@Rohan_FileUpload
@Shruti
@Must
@Current
Scenario: Presence of Select Files button
	Given I am on Grid Demo Page
	When I view Kendo File Upload section
	Then I should see a Select File button
 
@Rohan_FileUpload
@Shruti
@Must
@Current
Scenario: Upload button is displayed on file selection
	Given I am on Grid Demo Page
	When I select a file
	Then I should see the Upload button 

@Rohan_FileUpload
@Shruti
@Must
@Current
Scenario: Remove icon is displayed on file selection
	Given I am on Grid Demo Page
	When I select a file
	Then I should see a remove icon for removing the selected file 

@Rohan_FileUpload
@Shruti
@Must
@Current
Scenario Outline: Selecting a file from local machine
	Given I see a data grid with the "<Column Name>" column names
	When I select a file
	Then I should see the selected file in the textfield below
	Examples: 
	| Column Name      |
	| File Name        |
	| File Size        |
	| File Type        |
	| Upload Date Time |
	
@Rohan_FileUpload
@Shruti	
@Must
@Current
Scenario: Removing the selected item
	Given I have selected one file 
	When I click on Remove icon
	Then Selected file should be removed

@Rohan_FileUpload	 
@Shruti
@Must
@Current
Scenario: File Upload after removing the selected file
	Given I have selected one file
	When I click on Remove icon
	And I click on Upload button
	Then File should not be uploaded

@Rohan_FileUpload
@Shruti
@Must
@Current
Scenario Outline: Relevant file details in file upload grid
	Given I am on Grid Demo Page
	When I select a file "<File Name>" 
	And I click on Upload button
	Then Grid should display File Name
	And Grid should display File Size
	And Grid should display File Type
	And Grid should display Upload Date Time
	Examples: 
	| File Name    | 
	| Lighthouse   |
