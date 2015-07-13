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
    public class LoginFunctionalitySteps
    {
        string _errorMessage = "not present !";
        [Given(@"I am on Home Page")]
        public void GivenIAmOnHomePage()
        {   
            HomePage.GoTo();      
        }

        [Given(@"I am on Login Section")]
        public void GivenIAmOnLoginSection()
        {
            LoginPage.GoTo();
        }

        [When(@"I click on Login button on the menu bar")]
        public void WhenIClickOnLoginButtonOnTheMenuBar()
        {
            LoginPage.ClickLoginButtonMenuBar();
        }

              

        [When(@"I click on Login button")]
        public void WhenIClickOnLoginButton()
        {
            LoginPage.ClickLoginButton();            
        }

        [When(@"I enter username ""(.*)"" and password ""(.*)""")]
        public void WhenIEnterUsernameAndPassword(string txtUsername, string txtPassword)
        {
            LoginPage.UserEnterUsernamePassword(txtUsername, txtPassword);
        }

        [When(@"I click on Reset button")]
        public void WhenIClickOnResetButton()
        {
            LoginPage.ClickResetButton();
        }

        [Then(@"I should see a username field in the login section")]
        public void ThenIShouldSeeAUsernameFieldInTheLoginSection()
        {
            Assert.IsTrue(LoginPage.UsernameFieldLoginSection(), "Username Field" +_errorMessage);
        }

        [Then(@"I should see a password field in the login section")]
        public void ThenIShouldSeeAPasswordFieldInTheLoginSection()
        {
            Assert.IsTrue(LoginPage.PasswordFieldLoginSection(), "Password Field" +_errorMessage);            
        }

        [Then(@"I should see a Login button in the login section")]
        public void ThenIShouldSeeALoginButtonInTheLoginSection()
        {
            Assert.IsTrue(LoginPage.LoginButtonLoginSection(), "Login Button"+_errorMessage);          
        }

        [Then(@"I should see a Reset button in the login section")]
        public void ThenIShouldSeeAResetButtonInTheLoginSection()
        {
            Assert.IsTrue(LoginPage.ResetButtonLoginSection(), "Reset Button" +_errorMessage);            
        }

        [Then(@"I should see a placeholder '(.*)' on username field")]
        public void ThenIShouldSeeAPlaceholderOnUsernameField(string phdUsername)
        {
            LoginPage.PlaceholderUsernameField(phdUsername);
        }

        [Then(@"I should see a placeholder '(.*)' on password field")]
        public void ThenIShouldSeeAPlaceholderOnPasswordField(string txtPassword)
        {
            LoginPage.PlaceholderPasswordField(txtPassword);
        }

        [Then(@"I am logged in")]
        public void ThenIAmLoggedIn()
        {
            LoginPage.UserLoggedIn();
        }

       
        [Then(@"I see an alert for the invalid login")]
        public void ThenISeeAnAlertForTheInvalidLogin()
        {
            Assert.IsTrue(LoginPage.isAlertPresent(), "Alert"+_errorMessage);
        }

        [Then(@"I click on OK")]
        public void ThenIClickOnOK()
        {
            SeleniumController.Instance.Driver.SwitchTo().Alert().Accept();
        }
        
        [Then(@"Username and Password fields should be reset")]
        public void ThenUsernameAndPasswordFieldsShouldBeReset()
        {
            Assert.IsTrue(LoginPage.UsernamePasswordFieldsReset(), "Username Password Fields not reset !");   
        }

        [Given(@"I am not logged in")]
        public void GivenIAmNotLoggedIn()
        {
            HomePage.GoTo();
            bool loggedIn =LoginPage.UserLoggedIn();
            if (loggedIn == true)
            {
                SeleniumController.SleepWaitTime(1000);
            }
        
        }

        [When(@"I view the top menu navigation bar")]
        public void WhenIViewTheTopMenuNavigationBar()
        {
            Assert.IsTrue(LoginPage.MenuNavigationBar(), "Navigation Menu Bar" + _errorMessage);
        }

        [Then(@"I should not see the '(.*)' menu item")]
        public void ThenIShouldNotSeeTheMenuItem(string menuItem)
        {
            if (menuItem == "Employees")
            {
                Assert.IsTrue(LoginPage.EmployeesMenuItemNotPresent(menuItem), "Employees menu item present !");
                //LoginPage.LogOutUser();
            }
            else if(menuItem == "Manage")
            {
                Assert.IsTrue(LoginPage.ManageAdminMenuItemNotPresent(menuItem), " Manage menu item present !");
                //LoginPage.LogOutUser();
            }
        }

        [Given(@"I login as admin")]
        public void GivenILoginAsAnAdmin()
        {
            UsersPage.LoginAsAdmin();
        }

        [Then(@"I should see the '(.*)' menu item")]
        public void ThenIShouldSeeTheMenuItem(string menuItem)
        {
            if(menuItem=="Employees")
            {
                Assert.IsTrue(LoginPage.EmployeesMenuItemPresent(menuItem), "Employees menu item" + _errorMessage);
            }
            else if(menuItem=="Manage")
            {
                Assert.IsTrue(LoginPage.ManageAdminMenuItemPresent(menuItem), "Manage menu item" + _errorMessage);
            }
        }

        [Given(@"I login as a member with username ""(.*)"" and password ""(.*)""")]
        public void GivenILoginAsAMemberWithUsernameAndPassword(string username, string password)
        {
            LoginPage.GoTo();
            LoginPage.ClickResetButton();
            LoginPage.UserLoginUsername(username);
            LoginPage.UserLoginPassword(password);
            LoginPage.ClickLoginButton();            
        }


        [Given(@"I login as non-admin non-member user with username ""(.*)"" and password ""(.*)""")]
        public void GivenILoginAsNon_AdminNon_MemberUserWithUsernameAndPassword(string username, string password)
        {
            LoginPage.GoTo();
            LoginPage.ClickResetButton();
            LoginPage.UserLoginUsername(username);
            LoginPage.UserLoginPassword(password);
            LoginPage.ClickLoginButton(); 
            
        }

        [Then(@"I should see the '(.*)' and '(.*)' in the dropdown")]
        public void ThenIShouldSeeTheAndInTheDropdown(string item1, string item2)
        {
            Assert.IsTrue(LoginPage.ManageDropdownItems(item1, item2), "Appropriate dropdown items" + _errorMessage);            
        }

        [Then(@"User logs out")]
        public void ThenUserLogsOut()
        {
            LoginPage.LogOutUser(); 
        }


        
    }
}
