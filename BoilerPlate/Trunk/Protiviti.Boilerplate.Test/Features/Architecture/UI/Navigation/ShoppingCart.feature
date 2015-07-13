Feature: ShoppingCart
	In order to purchase items 
	As a boilerplate user 
	I want to be able to create a shopping cart 

@Hanna 
@Chandana 
@could
@Sprint1
Scenario: A category section is displayed on the Welcome page
	Given I have clicked the Examples link in the header 
	And I have clicked the Shop link 
	Then a section titled Categories is displayed 

@Hanna 
@Chandana 
@could
@Sprint1
Scenario: A Search button is displayed on the Welcome page 
	Given I have clicked the Examples link in the header 
	And I have clicked the Shop link 
	Then a button titled Search is displayed 

@Hanna 
@Chandana 
@could
@Sprint1
Scenario: Category section is filterable by product name
	Given I have clicked the Examples link in the header 
	And I have clicked the Shop link 
	Then I can filter the Categories section by following attributes: product name. 
	
@Hanna 
@Chandana 
@could
@Sprint1
Scenario: Category section is filterable by price
	Given I have clicked the Examples link in the header 
	And I have clicked the Shop link 
	Then I can filter the Categories section by following attributes: price. 