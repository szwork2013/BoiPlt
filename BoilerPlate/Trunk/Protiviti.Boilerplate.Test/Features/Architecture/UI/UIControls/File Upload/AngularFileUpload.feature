Feature: AngularFileUpload
	In order to upload a file 
	As a user
	I want to select a file from my local machine and click on 'Submit' button

@Rohan_AngularFileUpload
@Must
Scenario: Presence of FileName text-field
	Given I am on Home Page
	When I navigate to File Upload page
	Then I should see a FileTitle text-field

@Rohan_AngularFileUpload
@Must
@AngularFileUpload
Scenario: Presence of FileTitle label
	Given I am on Home Page
	When I navigate to File Upload page
	Then I should see a 'File Title' label

@Rohan_AngularFileUpload
@Must
@AngularFileUpload
Scenario: Presence of File Name label
	Given I am on Home Page
	When I navigate to File Upload page
	Then I should see a 'File Name' label

@Rohan_AngularFileUpload
@Must
@AngularFileUpload
Scenario: Presence of Submit button
	Given I am on Home Page
	When I navigate to File Upload page
	Then I should see 'Submit' button

@Rohan_AngularFileUpload
@Must
@AngularFileUpload
Scenario Outline: Submit Button Disabled on No File Selection
	Given I am on File Upload page
	When I enter "<FileTitle>" in FileTitle text-field
	And I don't select any file 
	Then Submit button should be disabled
	Examples: 
	| FileTitle |
	| file1     |
	| file2     |

@Rohan_AngularFileUpload
@Must
@AngularFileUpload
Scenario Outline: Submit Button Enabled on File Selection
	Given I am on File Upload page
	When I enter "<FileTitle>" in FileTitle text-field
	And I select file "<File>"
	Then Submit button should be enabled
	Examples: 
	| FileTitle | File       |
	| file3     | Desert     |

@Could	
#Could be implemented in future
Scenario Outline:  Progress Bar on File Upload
	Given I am on File Upload page
	When I enter "<FileTitle>" in FileTitle text-field
	And I select file "<File>"
	And I click on 'Submit' button
	Then I should see the progress bar
	And The progress bar should display upload percentage '%'
	Examples: 
	| FileTitle | File       |
	| file5     | Desert     |	

@Could
#Could be implemented in future
Scenario Outline: Successful Upload
	Given I am on File Upload page
	When I enter "<FileTitle>" in FileTitle text-field
	And I select file "<File>"
	And I click on 'Submit' button
	Then I should see a message 'Upload Successful'
	And The progress bar shows '100' percentage  
	Examples: 
	| FileTitle | File       |
	| file6     | Desert     |

@Rohan_AngularFileUpload
@Must
@AngularFileUpload
Scenario: Presence of Uploaded Files Grid
	Given I am on Home Page
	When I navigate to File Upload page
	Then I should see a 'Uploaded Files' Grid having following column names :
	| Name | Title | Uploaded Date | Size(Kb) |
	
@Rohan_AngularFileUpload
@Must
@AngularFileUpload
Scenario: Pagination of Uploaded Files Grid
	Given I am on File Upload page
	When I view the Uploaded Files Grid
	Then I should see a button for "First Page"
	And I should see a button for "Previous Page"
	And I should see a button for "Next Page"
	And I should see the current page number

@Pending
@AngularFileUpload
Scenario Outline: Sorting Uploaded Files Grid
	Given I am on File Upload page
	And I see Uploaded Files Grid
	When I click sort "<Sort Direction>" on column "<Column Name>"
	Then The grid results should be sorted "<Sort Method >"
	Examples: 
	| Sort Direction | Column Name | Sort Method                |
	| Ascending      | Name        | Alphabetically             |
	| Descending     | Name        | Reverse-Alphabetically     |
	| Ascending      | Title       | Alphabetically             |
	| Descending     | Title       | Reverse-Alphabetically     |
	| Ascending      | Upload Date | YY-MM-DD wise              |
	| Descending     | Upload Date | YY-MM-DD wise              |
	| Ascending      | Size(Bytes) | in Numerical order         |
	| Descending     | Size(Bytes) | in Reverse-Numerical order |


@Rohan_AngularFileUpload
@Must
@AngularFileUpload
Scenario: Presence of Search Field in Uploaded Files Grid
	Given I am on File Upload page
	When I view the Uploaded Files Grid
	Then I should see a Search field 
	And I should see a placeholder 'Search File Name...' on Search field
	
@Rohan_AngularFileUpload
@Must
@AngularFileUpload
Scenario: Presence of Search Button
	Given I am on File Upload page
	When I view the Uploaded Files Grid
	Then I should see a 'Search' button

@ignore
#@dbTesting@Preiksha@Pending@AngularFileUpload
Scenario Outline: Validating values with db on Successful Upload
	Given I am on File Upload page
	When I enter "<FileTitle>" in FileTitle text-field
	And I select file "<File>"
	And I click on 'Submit' button
	Then I should see a message 'Upload Successful'
	And The values should get added in the database  
	Examples: 
	| FileTitle | File       |
	| Test1     | Desert     |

@Rohan_AngularFileUpload
@Must
@AngularFileUpload
Scenario: Presence of Delete icon 
	Given I am on File Upload page
	When I view the Uploaded Files Grid
	Then I should see the remove icon for each uploaded file in the grid 

@Rohan_AngularFileUpload
@Must 
@AngularFileUpload
Scenario Outline: Deleting an uploaded file
	Given I am on File Upload page
	And I upload the file "<FileName>" with title "<TitleName>"
	When I delete the file "<FileName>" with title "<TitleName>"
	Then The file "<FileName>" with title "<TitleName>" should be deleted from the Uploaded Files Grid
	Examples: 
	| FileName       | TitleName   |
	| Jellyfish.jpg  | uploadfile1 |







	



