Feature: Nested Navigation With ui-router
	In order to navigate nested/sub views
	As user
	I want to use nested navigation links

@Sprint0 @MikeWzorek @BenBloomfield @Done


@Sprint0 @MikeWzorek @BenBloomfield @Done
Scenario: Simple View the Sales CDS Initiative
Given I am viewing the"CDS Initiatives Page
When I click the Sales link
Then I should see the Sales Title on the page
And I should see "initiatives/1" in the URL
And I should see the Find Proposals Task
And I should see the Pitch PSS Value Task

@Sprint0 @MikeWzorek @BenBloomfield @Done
Scenario: View the details for the Find Proposals Task for the Sales CDS Initiative
Given I am viewing the CDS Initiatives page
And I click the Sales link
When I click the first task name I see
Then I should see "initiatives/1/1" in the URL

@Sprint0 @MikeWzorek @BenBloomfield @Done
Scenario Outline: Navigate to a CDS Initiative
Given I am viewing the CDS Initiatives page
When I click "<initiative name>" link
Then I should see "<id>" in the URL 
Examples: 
		| id | initiative name				| 
		| 1  | Sales						| 
		| 2  | Onboarding					| 
		| 3  | Knowledge Base				|
		| 4  | Training and Certifications	|

	@Sprint0 @BenBloomfield @MikeWzorek @Done
Scenario Outline: View the tasks for a CDS Initiative
Given I am viewing the CDS Initiatives page
When I click "<initiative name>" link
And I click the "<task name>" link
Then I should see the "<task details text>" for that initiative
And I should see "<id>" in the URL 
Examples:
	| initiative name             |task name                       | task details text      | id      |
	| Sales                       | Pitch PSS Value                | Pitch PSS Value      | 1/2     |
	| Onboarding                  | Read Employee Manual           | Read Employee Manual           | 2/3     |
	| Onboarding                  | Build Sample App               | Build Sample App               | 2/4     |
	| Knowledge Base              | Develop Boilerplate Solution   | Develop Boilerplate Solution| 3/6     |
	| Knowledge Base              | Research Emerging Technologies | Research Emerging Technologies | 3/7     |
	| Training and Certifications | Collect Team Certs             | Collect Team Certs   | 4/8     |
	| Training and Certifications | Identify Relevant Trainings    | Identify Relevant Trainings | 4/9     |

