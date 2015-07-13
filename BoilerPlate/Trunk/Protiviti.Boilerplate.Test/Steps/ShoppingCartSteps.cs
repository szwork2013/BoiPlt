using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using Protiviti.Boilerplate.Test.Pages;

namespace Protiviti.Boilerplate.Test
{
    [Binding]
    public class ShoppingCartSteps
    {
        [Given(@"I have clicked the Examples link in the header")]
        public void GivenIHaveClickedTheExamplesLinkInTheHeader()
        {
            //ExamplesPage.GoTo();
            //Assert.IsTrue(ExamplesPage.IsAt, "Failed to navigate to Examples page"); 
        }
         
        [Given(@"I have clicked the Shop link")]
        public void GivenIHaveClickedTheShopLink()
        {
            //ExamplesPage.GoToShoppingCart();
        }

        [Then(@"a section titled Categories is displayed")]
        public void ThenASectionTitledCategoriesIsDisplayed()
        {
            //Assert.AreEqual("Categories", ExamplesPage.TableTitle, "Table is not displayed");
        }

        [Then(@"a button titled Search is displayed")]
        public void ThenAButtonTitledSearchIsDisplayed()
        {
            //Assert.AreEqual("Search", ExamplesPage.SearchButtonTitle, "Button is not displayed");
        }

        [Then(@"I can filter the Categories section by following attributes: product name\.")]
        public void ThenICanFilterTheCategoriesSectionByFollowingAttributesProductName_()
        {
            //The methods for this section need to be completed in the ExamplesPage file
            //ExamplesPage.FilterByProductName();
            //Assert.IsTrue(ExamplesPage.DoesProductsExistWithProductName()); 
        }

        [Then(@"I can filter the Categories section by following attributes: price\.")]
        public void ThenICanFilterTheCategoriesSectionByFollowingAttributesPrice_()
        {
            //The methods for this section need to be completed in the ExamplesPage file
            //ExamplesPage.FilterByProductName();
            //Assert.IsTrue(ExamplesPage.DoesProductsExistWithPrice()); 
        }

    }
}
