using System;
using TechTalk.SpecFlow;
using Protiviti.Boilerplate.Test.Pages;
using System.Windows.Forms;
using System.Threading;

namespace Protiviti.Boilerplate.Test
{
    [Binding]
    public class RolesSteps
    {

        [Given(@"I login as Admin")]
        public void GivenILoginAsAdmin()
        {
            RolePage.LoginAsAdmin();

        }

        [When(@"I click on Roles from the Navigation bar")]
        public void WhenIClickOnRolesFromTheNavigationBar()
        {
            RolePage.NavigateToRoles();
        }

        [Then(@"The table header should be '(.*)'")]
        public void ThenTheTableHeaderShouldBe(string p0)
        {
            RolePage.HasHeaderAsRoles(p0);
        }

        [Given(@"I am on the Roles section")]
        public void GivenIAmOnTheRolesSection()
        {
            RolePage.LoginAsAdmin();
            RolePage.NavigateToRoles();
        }

        [Given(@"I am on the Roles Page")]
        public void GivenIAmOnTheRolesPage()
        {
            RolePage.LoginAsAdmin();
            RolePage.NavigateToRoles();
            //Console.WriteLine("I am on the role page");

        }


        [Given(@"I am on the Add Role section")]
        public void GivenIAmOnTheAddRoleSection()
        {
            RolePage.LoginAsAdmin();
            RolePage.NavigateToRoles();
            //Console.WriteLine("I am on the add role section");
            RolePage.ClickOnAddRoles();
        }

        [Given(@"I am on Edit Roles of ""(.*)""")]
        public void GivenIAmOnEditRolesOf(string p0)
        {
            RolePage.LoginAsAdmin();
            RolePage.NavigateToRoles();
            RolePage.HasHeaderAsRoles("Roles");
            RolePage.ClickOnEditRole(p0);
        }


        [When(@"I click on the arrow")]
        public void WhenIClickOnTheArrow()
        {
            RolePage.ClickOnArrow();
        }

        [When(@"I double click on the arrow")]
        public void WhenIDoubleClickOnTheArrow()
        {
            //Click to collapse
            RolePage.ClickOnArrow();
            //Click to expand
            RolePage.ClickOnArrow();
        }

        [When(@"I click on the Add button")]
        public void WhenIClickOnTheAddButton()
        {
            RolePage.ClickOnAddRoles();
        }

        [When(@"I view the Roles table")]
        public void WhenIViewTheRolesTable()
        {
            RolePage.CheckForRolesTable(); // issue
        }

        [When(@"I enter ""(.*)""")]
        public void WhenIEnter(string p0)
        {
            RolePage.EnterRoleName(p0);
        }

        [When(@"I click on Add button")]
        public void WhenIClickOnAddButton()
        {
            // Thread.Sleep(3000);
            RolePage.ClickAdd();
        }

        [When(@"I enter ""(.*)"" in the Search")]
        public void WhenIEnterInTheSearch(string p0)
        {
            RolePage.EnterValueInSearch(p0);
        }

        [When(@"I click on Search button")]
        public void WhenIClickOnSearchButton()
        {
            RolePage.ClickSearch();
        }

        [When(@"I Click on edit of ""(.*)""")]
        public void WhenIClickOnEditOf(string p0)
        {
            RolePage.ClickOnEditRole(p0);
        }

        [When(@"I change the ""(.*)"" to ""(.*)""")]
        public void WhenIChangeTheTo(string p0, string p1)
        {
            RolePage.UpdateRoleName(p0, p1);
        }

        [When(@"I click on Update button")]
        public void WhenIClickOnUpdateButton()
        {
            RolePage.ClickOnUpdate();
        }

        [When(@"I Click on delete of ""(.*)""")]
        public void WhenIClickOnDeleteOf(string p0)
        {
            RolePage.DeleteRole(p0);
        }

        [When(@"I Click on Delete Role in the pop-up")]
        public void WhenIClickOnDeleteRoleInThePop_Up()
        {
            Thread.Sleep(2000);
            RolePage.ClickOnConfirmDelete();
        }

        [When(@"I click the ""(.*)"" button")]
        public void WhenIClickTheButton(string p0)
        {
            RolePage.ClickOnPaginationBtn(p0);
        }



        [Then(@"The grid should collapse")]
        public void ThenTheGridShouldCollapse()
        {
            RolePage.CheckCollapse();
            //Re expand the grid to avoid issue of hidden elements
            RolePage.ClickOnArrow();
        }

        [Then(@"The grid should expand")]
        public void ThenTheGridShouldExpand()
        {
            RolePage.CheckExpand();
        }

        [Then(@"Add Roles page should be displayed")]
        public void ThenAddRolesPageShouldBeDisplayed()
        {
            RolePage.HasHeaderAsAddRoles();
        }

        [Then(@"an hyperlink '(.*)' should be displayed")]
        public void ThenAnHyperlinkShouldBeDisplayed(string p0)
        {
            RolePage.HasBackToListLink(p0);
        }

        [Then(@"A label '(.*)' with an input box should be displayed")]
        public void ThenALabelWithAnInputBoxShouldBeDisplayed(string p0)
        {
            RolePage.HasLabelAsAddRole(p0);
        }

        [Then(@"An Add button should be displayed")]
        public void ThenAnAddButtonShouldBeDisplayed()
        {
            RolePage.HasAddBtn();
            RolePage.NavigatetoRolePage();
        }

        [Then(@"I should see a placeholder '(.*)' on search input field")]
        public void ThenIShouldSeeAPlaceholderOnSearchInputField(string p0)
        {
            RolePage.CheckForSearchtext(p0);
        }

        [Then(@"Search button should be displayed")]
        public void ThenSearchButtonShouldBeDisplayed()
        {
            RolePage.HasSearchBtn();
        }

        [Then(@"I should see a Table with header as '(.*)'")]
        public void ThenIShouldSeeATableWithHeaderAs(string p0)
        {
            RolePage.HasRoleAsTableHeader(p0);
        }

        [Then(@"a pop up '(.*)' should be displayed")]
        public void ThenAPopUpShouldBeDisplayed(string p0)
        {
            RolePage.CheckPopUpTitle(p0);
        }

        [Then(@"a message'(.*)' should be displayed")]
        public void ThenAMessageShouldBeDisplayed(string p0)
        {
            RolePage.CheckPopUpMessage(p0);
            //RolePage.CheckMessage()
        }

        [Then(@"either a message '(.*)' or '(.*)' should be displayed")]
        public void ThenEitherAMessageOrShouldBeDisplayed(string p0, string p1)
        {
            //ScenarioContext.Current.Pending();
            RolePage.CheckAddNewRoleMessage(p0, p1);
            RolePage.NavigatetoRolePage();

        }


        [Then(@"an error message for duplicate '(.*)' should be displayed")]
        public void ThenAnErrorMessageForDuplicateShouldBeDisplayed(string p0)
        {
            RolePage.CheckDuplicateNameMessage(p0);
            RolePage.NavigatetoRolePage();
        }

        [Then(@"Add button should not get enabled")]
        public void ThenAddButtonShouldNotGetEnabled()
        {
            RolePage.AddBtnShouldBeDisabled();
            RolePage.NavigatetoRolePage();
        }

        [Then(@"I should see role having the same name as ""(.*)""")]
        public void ThenIShouldSeeRoleHavingTheSameNameAs(string p0)
        {
            RolePage.VerifySearchResult(p0);
            RolePage.ClearSearchBox();
        }


        [Then(@"I should navigate to Edit Role ""(.*)"" page")]
        public void ThenIShouldNavigateToEditRolePage(string p0)
        {
            RolePage.UpdateRolesHeader(p0);
        }

        [Then(@"An Update button should be displayed")]
        public void ThenAnUpdateButtonShouldBeDisplayed()
        {
            RolePage.HasUpdateBtn();
            //RolePage.NavigatetoRolePage();
        }

        [Then(@"Cancel button should be displayed")]
        public void ThenCancelButtonShouldBeDisplayed()
        {
            RolePage.HasCancelbtn();
        }

        static int flag = 0;
        [Then(@"Delete Role button should be displayed")]
        public void ThenDeleteRoleButtonShouldBeDisplayed()
        {
            flag = RolePage.HasDeletebtn();
        }

        [Then(@"I should not see the ""(.*)"" in Roles table")]
        public void ThenIShouldNotSeeTheInRolesTable(string p0)
        {
            RolePage.CheckElementIsDeleted(p0);
            RolePage.ClearSearchBox();
        }

        [Then(@"I should see First Page button in the footer")]
        public void ThenIShouldSeeFirstPageButtonInTheFooter()
        {
            RolePage.HasFirstPagebtn();
        }

        [Then(@"I should see Previous Page button in the footer")]
        public void ThenIShouldSeePreviousPageButtonInTheFooter()
        {
            RolePage.HasPreviousPagebtn();
        }

        [Then(@"I should see Next Page button in the footer")]
        public void ThenIShouldSeeNextPageButtonInTheFooter()
        {
            RolePage.HasNextPagebtn();
        }

        [Then(@"I should see the current page number as  ""(.*)""")]
        public void ThenIShouldSeeTheCurrentPageNumberAs(string p0)
        {
            RolePage.CheckForCurrentPage(p0);
        }

        [Then(@"I should navigate to ""(.*)"" page")]
        public void ThenIShouldNavigateToPage(string p0)
        {
            RolePage.CheckPageNumber(p0);
            //RolePage.CheckNumberOfRecords();
        }

        #region db
        [Then(@"I should not see the ""(.*)"" in Roles table in database")]
        public void ThenIShouldNotSeeTheInRolesTableInDatabase(string p0)
        {
            RolePage.DeletedRoleAndValidateDb(p0);
        }
        #endregion
    }
}

