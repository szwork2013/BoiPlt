using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Protiviti.Boilerplate.Test.Support;
using Protiviti.Boilerplate.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class LoginAuthenticationViaExternalSourceSteps
    {
        [Given(@"I am on Login Page")]
        public void GivenIAmOnLoginPage()
        {
            HomePage.GoTo();

        }

        [When(@"I click on Login button on the header")]
        public void WhenIClickOnLoginButtonOnTheHeader()
        {
            LoginPage.GoTo();
        }

        enum Check { PresenceofButton, ButtonClick }; //This takes care of Screnario 1,2 and 3

        [Then(@"I should see following buttons on the page")]
        public void ThenIShouldSeeFollowingButtonsOnThePage(Table table)
        {
            SeleniumController.SleepWaitTime(4000);
            foreach (TableRow row in table.Rows)
            {
                string val = ((string[])row.Values)[0];

                if (val.Contains("Google"))
                {
                    LoginPage.GoogleLoginButtonPresent((int)Check.PresenceofButton);
                    SeleniumController.SleepWaitTime(5000);
                }
                else if (val.Contains("Facebook"))
                {
                    SeleniumController.SleepWaitTime(4000);
                    LoginPage.FacebookLoginButtonPresent((int)Check.PresenceofButton);
                    SeleniumController.SleepWaitTime(5000);
                }
                else if (val.Contains(""))
                {
                    throw new Exception("Button is not present on the Page");

                }
            }
        }

        [Given(@"I am on Login Page and I click on the header")]
        public void GivenIAmOnLoginPageAndIClickOnTheHeader()
        {
            HomePage.GoTo();
            LoginPage.GoTo();
        }

        [When(@"I click on following button")]
        public void WhenIClickOnFollowingButton(Table table)
        {

            foreach (TableRow row in table.Rows)
            {
                string val = ((string[])row.Values)[0].Trim();
                if (val.Contains("Google"))
                {
                    LoginPage.GoogleLoginButtonPresent((int)Check.ButtonClick);
                    LoginPage.PopUpLoginWindow();

                }
                else if (val.Contains("Facebook"))
                {
                    LoginPage.FacebookLoginButtonPresent((int)Check.ButtonClick);
                    LoginPage.PopUpLoginWindow();
                }
                else
                {
                    throw new Exception("No such button exists to click");
                }
            }

        }

        [When(@"I enter valid credentials in the pop-up window")]
        public void WhenIEnterValidCredentialsInThePop_UpWindow()
        {   //PopUpLoginWindow function inside WhenIClickOnFollowingButton() 
            Console.WriteLine("Here user is entering valid credential to login into the portal");
        }

        [When(@"I enter a valid username in the portal to register")]
        public void WhenIEnterAValidUsernameInThePortalToRegister()
        {
            SeleniumController.SleepWaitTime(3000);
            LoginPage.RegisterYourAccount();
        }


        [Then(@"I am successfully logged in")]
        public void ThenIAmSuccessfullyLoggedIn()
        {
            SeleniumController.SleepWaitTime(2000);
            LoginPage.VerifyExternalUserLogin();
        }

        [When(@"I Login with following Accounts")]
        public void WhenILoginWithFollowingAccounts(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                string val = ((string[])row.Values)[0].Trim();

                if (val.Contains("Google"))
                {
                    LoginPage.GoogleLoginButtonPresent((int)Check.ButtonClick);
                    LoginPage.PopUpLoginWindow();
                }
                else if (val.Contains("Facebook"))
                {
                    LoginPage.FacebookLoginButtonPresent((int)Check.ButtonClick);
                    LoginPage.PopUpLoginWindow();
                }
                else
                {
                    throw new Exception("Please log in with the selected account first");
                }
            }
        }

        [Then(@"Registered username should be displayed on the header")]
       public void ThenRegisteredUsernameShouldBeDisplayedOnTheHeader()
        {
           // LoginPage.RegisterYourAccount();
            SeleniumController.SleepWaitTime(2000);
            LoginPage.VerifyExternalUserLogin();
        }

        [When(@"I click on the username displayed on the header")]
        public void WhenIClickOnTheUsernameDisplayedOnTheHeader()
        {
            //LoginPage.RegisterYourAccount();
            SeleniumController.SleepWaitTime(3000);
            LoginPage.ClickExternalUserName();
        }

        [Then(@"following buttons are not displayed")]
        public void ThenFollowingButtonsAreNotDisplayed()
        {
            SeleniumController.SleepWaitTime(2000);
            LoginPage.ExternalDropDownItems();
        }




    }
}
