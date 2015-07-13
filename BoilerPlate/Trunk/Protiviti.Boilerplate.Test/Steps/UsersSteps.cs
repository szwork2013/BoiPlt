using System;
using TechTalk.SpecFlow;
using Protiviti.Boilerplate.Test.Support;
using Protiviti.Boilerplate.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System.Collections;

namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class UsersSteps
    {
        string _errorMessage = "not present !";
                
        [Given(@"I am on Users section")]
        public void GivenIAmOnUsersSection()
        {
            UsersPage.UserSection();          
        }
        
        [Given(@"I am on Assign Roles Screen of user with ""(.*)""")]
        public void GivenIAmOnAssignRolesScreenOfUserWith(string email)
        {
            SeleniumController.SleepWaitTime(2000);
            LoginPage.GoTo();
            LoginPage.AdminLoginUsername();
            LoginPage.AdminLoginPassword();
            LoginPage.ClickLoginButton();
            UsersPage.GoTo();
            UsersPage.ClickEditIcon(email);
        }


        [Given(@"I have searched email ""(.*)""")]
        public void GivenIHaveSearchedEmail(string email)
        {
            UsersPage.SearchEmail(email);
        }

        [Given(@"I click on Edit Icon for a particular user with ""(.*)""")]
        public void GivenIClickOnEditIconForAParticularUserWith(string email)
        {
            UsersPage.ClickEditIcon(email);
        }

        [When(@"I navigate to Users section")]
        public void WhenINavigateToUsersSection()
        {
            UsersPage.GoTo();
        }

        [Then(@"The panel header should be '(.*)'")]
        public void ThenThePanelHeaderShouldBe(string header)
        {
            UsersPage.PanelHeader(header);
        }

        [When(@"I click on Collapse/Expand arrow")]
        public void WhenIClickOnCollapseExpandArrow()
        {
            UsersPage.ClickExpandCollapseArrow();
        }

        [When(@"I click on ""(.*)"" button")]
        public void WhenIClickOnButton(string button)
        {
            UsersPage.ClickRegisterButton(button);  
        }

        [When(@"I click on Remove Icon")]
        public void WhenIClickOnRemoveIcon()
        {
            UsersPage.ClickRemoveIcon();
        }

        //[When(@"I click on '(.*)'")]
        //public void WhenIClickOn(string button)
        //{
        //    SeleniumController.SleepWaitTime(2000);
        //    Assert.IsTrue(UsersPage.isRemoveAlertPresent(), "Alert window !" + _errorMessage);
        //    UsersPage.ClickDeleteUserButton(button);            
        //}

        [When(@"I click on Delete User")]
        public void WhenIClickOnDeleteUser()
        {
            UsersPage.ClickDeleteUserButton();     
        }


        [When(@"I click on Remove Icon for a particular user with ""(.*)""")]
        public void WhenIClickOnRemoveIconForAParticularUserWith(string email)
        {
            SeleniumController.SleepWaitTime(2000);
            UsersPage.DeleteParticularUser(email);
        }

        [When(@"I click on activate button for a particular user with ""(.*)""")]
        public void WhenIClickOnActivateButtonForAParticularUserWith(string email)
        {
            UsersPage.ClickActivateButtonForUser(email);
            Assert.IsTrue(UsersPage.IsActivateAlertPresent(), "Alert window !" + _errorMessage);
            UsersPage.ClickActivateUserButton();   
        }        

        [When(@"I click on the Role to be assigned")]
        public void WhenIClickOnTheRoleToBeAssigned()
        {
            UsersPage.RoleCheckboxValueAdded();
            UsersPage.ClickRoleCheckbox();
        }

        [When(@"I click on assigned role")]
        public void WhenIClickOnAssignedRole()
        {
            SeleniumController.SleepWaitTime(2000);
            UsersPage.RoleCheckboxValueRemoved();
            UsersPage.ClickRoleCheckbox();
        }

        [When(@"I click on activate button for a particular user with ""(.*)"" and click cancel")]
        public void WhenIClickOnActivateButtonForAParticularUserWithAndClickCancel(string email)
        {
            UsersPage.ClickActivateButtonForUser(email);
            Assert.IsTrue(UsersPage.IsActivateAlertPresent(), "Alert window !" + _errorMessage);
            UsersPage.ClickCancelActivateUserButton();   
        }

        [When(@"I click on Edit Icon for a particular user with ""(.*)""")]
        public void WhenIClickOnEditIconForAParticularUserWith(string email)
        {
            UsersPage.ClickEditIcon(email);
        }

        [When(@"I leave the new password field empty")]
        public void WhenILeaveTheNewPasswordFieldEmpty()
        {
            UsersPage.EmptyNewPasswordField();
        }

        [When(@"I leave fill a different confirm password")]
        public void WhenILeaveFillADifferentConfirmPassword()
        {
            UsersPage.DifferentConfirmPassword();
        }

        [When(@"I click on submit button")]
        public void WhenIClickOnSubmitButton()
        {
            UsersPage.ClickSubmitButton();
        }

        [When(@"I fill an invalid new password")]
        public void WhenIFillAnInvalidNewPassword()
        {
            UsersPage.InvalidNewPassword();
        }

        [When(@"I fill the same confirm password")]
        public void WhenIFillTheSameConfirmPassword()
        {
            UsersPage.PopulateSameConfirmPwd();
        }

        [When(@"I fill the same valid confirm password")]
        public void WhenIFillTheSameValidConfirmPassword()
        {
            UsersPage.PopulateSameValidConfirmPwd();
        }


        [When(@"I fill a valid new password")]
        public void WhenIFillAValidNewPassword()
        {
            UsersPage.ValidNewPassword();
        }


        [Then(@"I should see a Users panel")]
        public void ThenIShouldSeeAUsersPanel()
        {
           Assert.IsTrue(UsersPage.PanelPresent(),"Users Panel" +_errorMessage);
        }

        [Then(@"I should see a Search box in the panel")]
        public void ThenIShouldSeeASearchBoxInThePanel()
        {
            Assert.IsTrue(UsersPage.SearchBoxPresent(), "SearchBox" + _errorMessage);
            
        }

        [Then(@"Search box should have a placeholder '(.*)'")]
        public void ThenSearchBoxShouldHaveAPlaceholder(string text)
        {
            UsersPage.PlaceholderSearchBox(text);
        }

        [Then(@"I should see a '(.*)' button")]
        public void ThenIShouldSeeAButton(string button)
        {
            if (button == "Search")
                UsersPage.SearchButtonPresent(button);
            else if(button=="Register")
                UsersPage.RegisterButtonPresent(button);
        }

        [Given(@"The Users panel is collapsed")]
        public void GivenTheUsersPanelIsCollapsed()
        {
            UsersPage.IsPanelCollapsed();
        }

        [Then(@"The panel should collapse")]
        public void ThenThePanelShouldCollapse()
        {
            UsersPage.UsersPanelCollapse();
        }

        [Then(@"The panel should expand")]
        public void ThenThePanelShouldExpand()
        {
            Assert.IsTrue(UsersPage.UsersPanelExpand(), "Panel not expanded on click !");
        }

        [Then(@"I should see a '(.*)' button in the footer")]
        public void ThenIShouldSeeAButtonInTheFooter(string buttonTxt)
        {
            if (buttonTxt == "First Page")
                Assert.IsTrue(UsersPage.PagingFirstPage(buttonTxt), "First Page button" + _errorMessage);
            else if (buttonTxt == "Previous Page")
                Assert.IsTrue(UsersPage.PagingPreviousPage(buttonTxt), "Previous Page button" + _errorMessage);
            else if(buttonTxt=="Next Page")
                Assert.IsTrue(UsersPage.PagingNextPage(buttonTxt), "Next Page button" + _errorMessage);
                
        }

        [Then(@"I should see the current page number")]
        public void ThenIShouldSeeTheCurrentPageNumber()
        {
            Assert.IsTrue(UsersPage.PagingPageNumber(),"Current page number"+_errorMessage);
        }

        [Then(@"There should be table headers as '(.*)','(.*)','(.*)','(.*)','(.*)','(.*)' with the users data")]
        public void ThenThereShouldBeTableHeadersAsWithTheUsersData(string header1, string header2, string header3, string header4, string header5, string header6)
        {
            UsersPage.PanelTableHeaders(header1, header2, header3, header4, header5,header6);
        }

        [Then(@"I should see a Remove Icon")]
        public void ThenIShouldSeeARemoveIcon()
        {
            Assert.IsTrue(UsersPage.RemoveIconPresent(),"Remove Icon/s"+_errorMessage);
        }

        [Then(@"I should see a Edit icon")]
        public void ThenIShouldSeeAEditIcon()
        {
            Assert.IsTrue(UsersPage.EditIconPresent(), "Edit Icon/s" + _errorMessage);
        }

        [When(@"I click on Edit Icon for user with ""(.*)""")]
        public void WhenIClickOnEditIconForUserWith(string email)
        {
            UsersPage.ClickEditIcon(email);   
        }

        [Then(@"I should be navigated to Registration form")]
        public void ThenIShouldBeNavigatedToRegistrationForm()
        {
           UsersPage.NavigationRegistrationForm();   
        }

        [Then(@"The user with ""(.*)"" should be inactive")]
        public void ThenTheUserWithShouldBeRemovedFromUsersSection(string email)
        {
            SeleniumController.SleepWaitTime(3000);
            UsersPage.SearchEmail(email);
            Assert.IsTrue(UsersPage.IsUserActive(), "User still active !");
            UsersPage.ActivateUserAgain(email);
        }

        
        [Then(@"I should be navigated to Assign Roles screen")]
        public void ThenIShouldBeNavigatedToAssignRolesScreen()
        {
            Assert.IsTrue(UsersPage.AssignRolesSection(), "Assign Roles section" + _errorMessage);
            
        }

        [Then(@"I should see a '(.*)' button on the top")]
        public void ThenIShouldSeeAButtonOnTheTop(string text)
        {
            UsersPage.BacktolistButton(text);
        }

        [Then(@"The Role should be added to the User")]
        public void ThenTheRoleShouldBeAddedToTheUser()
        {
           Assert.IsTrue(UsersPage.RoleAdded(),"Role Not added !");  
        }

        [Then(@"The Assigned Role should be removed")]
        public void ThenTheAssignedRoleShouldBeRemoved()
        {
            Assert.IsTrue(UsersPage.RoleRemoved(), "Role Not removed !");  
        }        

        [Then(@"the activate button for ""(.*)"" should be visible")]
        public void ThenTheActivateButtonForShouldBeVisible(string email)
        {
            Assert.IsTrue(UsersPage.IsActivateButtonPresent(email), "Activate button not found!");
        }

        [Then(@"the user with ""(.*)"" should be activated")]
        public void ThenTheUserWithShouldBeActivated(string email)
        {
            Assert.IsTrue(UsersPage.IsDeleteButtonPresent(email), "User not activated");
        }

        [Then(@"the user with ""(.*)"" should not be activated")]
        public void ThenTheUserWithShouldNotBeActivated(string email)
        {
            Assert.IsTrue(UsersPage.IsActivateButtonPresent(email), "User not activated");
        }

        [Then(@"the Edit Password section is visible")]
        public void ThenTheEditPasswordSectionIsVisible()
        {
            Assert.IsTrue(UsersPage.IsEditPwdSectionPresent(), "Edit Password Section Missing!");
        }

        [Then(@"the required validation message is displayed")]
        public void ThenTheRequiredValidationMessageIsDisplayed()
        {
            Assert.IsTrue(UsersPage.IsRequiredPresent(), "Required Validation not Present!");
        }

        [Then(@"the validation message for different confirm password is displayed")]
        public void ThenTheValidationMessageForDifferentConfirmPasswordIsDisplayed()
        {
            UsersPage.IsDifferenConfirmPwdValidationPresent();
        }

        [Then(@"the validation message for invalid password is displayed")]
        public void ThenTheValidationMessageForInvalidPasswordIsDisplayed()
        {
            UsersPage.IsInvalidPwdValidationPresent();
        }

        [Then(@"the success message is displayed")]
        public void ThenTheSuccessMessageIsDisplayed()
        {
            UsersPage.IsSuccessMsgPresent();
        }

        #region db
        [Then(@"The user should be displayed as inactive in the database")]
        public void ThenTheUserShouldBeDisplayedAsInactiveInTheDatabase()
        {
            UsersPage.IsActiveDB();
        }
        #endregion

    }
}
