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
    public class EditProfileSteps
    {
        string _errorMessage = "not present !";

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            LoginPage.GoTo();
            LoginPage.UserLoginUsername("Test1@protiviti.com");
            LoginPage.UserLoginPassword("Test@123");
            LoginPage.ClickLoginButton();
            SeleniumController.CheckUrlOfPage("http://localhost/Protiviti.Boilerplate.Client/#/");
        }

        [Given(@"I click on Change Profile in profile drop down menu item")]
        public void GivenIClickOnChangeProfileInProfileDropDownMenuItem()
        {
            UserProfilePage.ClickChangeProfileItem();
        }
        
        [When(@"I click on Change Profile in profile drop down menu item")]
        public void WhenIClickOnChangeProfileInProfileDropDownMenuItem()
        {
            UserProfilePage.ClickChangeProfileItem();
        }

        [When(@"I click cancel")]
        public void WhenIClickCancel()
        {
            UserProfilePage.ClickCancelButton();
        }

        [When(@"I edit the first name")]
        public void WhenIEditTheFirstName()
        {
            UserProfilePage.EditFirstName();
        }

        [When(@"I edit the last name")]
        public void WhenIEditTheLastName()
        {
            UserProfilePage.EditLastName();
        }

        [When(@"I add the suffix")]
        public void WhenIAddTheSuffix()
        {
            UserProfilePage.AddSuffix();
        }

        [When(@"I clear the first name field")]
        public void WhenIClearTheFirstNameField()
        {
            UserProfilePage.EmptyFirstName();
        }

        [When(@"I clear the suffix field")]
        public void WhenIClearTheSuffixField()
        {
            UserProfilePage.EmptySuffix();
        }

        [When(@"I click save")]
        public void WhenIClickSave()
        {
            UserProfilePage.ClickSaveButton();
        }

        [Then(@"I should see a salutation drop down in the Update User Profile section")]
        public void ThenIShouldSeeASalutationDropDownInTheUpdateUserProfileSection()
        {
            Assert.IsTrue(UserProfilePage.IsSalutationDropdownPresent(), "Salutation drop down" + _errorMessage);
        }

        [Then(@"I should see a first name text field in the Update User Profile section")]
        public void ThenIShouldSeeAFirstNameTextFieldInTheUpdateUserProfileSection()
        {
            Assert.IsTrue(UserProfilePage.IsFirstNameTextFieldPresent(), "First name text field" + _errorMessage);
        }

        [Then(@"I should see a last name text field in the Update User Profile section")]
        public void ThenIShouldSeeALastNameTextFieldInTheUpdateUserProfileSection()
        {
            Assert.IsTrue(UserProfilePage.IsLastNameTextFieldPresent(), "Last name text field" + _errorMessage);            
        }

        [Then(@"I should see a suffix text field in the Update User Profile section")]
        public void ThenIShouldSeeASuffixTextFieldInTheUpdateUserProfileSection()
        {
            Assert.IsTrue(UserProfilePage.IsSuffixTextFieldPresent(), "Suffix text field" + _errorMessage);
        }

        [Then(@"I should see a title text field in the Update User Profile section")]
        public void ThenIShouldSeeATitleTextFieldInTheUpdateUserProfileSection()
        {
            Assert.IsTrue(UserProfilePage.IsTitleTextFieldPresent(), "Title text field" + _errorMessage);
        }

        [Then(@"I should see a phone text field in the Update User Profile section")]
        public void ThenIShouldSeeAPhoneTextFieldInTheUpdateUserProfileSection()
        {
            Assert.IsTrue(UserProfilePage.IsPhoneTextFieldPresent(), "Phone text field" + _errorMessage);            
        }

        [Then(@"I should see a cell text field in the Update User Profile section")]
        public void ThenIShouldSeeACellTextFieldInTheUpdateUserProfileSection()
        {
            Assert.IsTrue(UserProfilePage.IsCellTextFieldPresent(), "Cell Phone text field" + _errorMessage);            
        }

        [Then(@"I should see a address lineOne text field in the Update User Profile section")]
        public void ThenIShouldSeeAAddressLineOneTextFieldInTheUpdateUserProfileSection()
        {
            Assert.IsTrue(UserProfilePage.IsAddressLine1TextFieldPresent(), "Address Line 1 text field" + _errorMessage);            
        }

        [Then(@"I should see a address lineTwo text field in the Update User Profile section")]
        public void ThenIShouldSeeAAddressLineTwoTextFieldInTheUpdateUserProfileSection()
        {
            Assert.IsTrue(UserProfilePage.IsAddressLine2TextFieldPresent(), "Address Line 2 text field" + _errorMessage);            
        }

        [Then(@"I should see a city text field in the Update User Profile section")]
        public void ThenIShouldSeeACityTextFieldInTheUpdateUserProfileSection()
        {
            Assert.IsTrue(UserProfilePage.IsCityTextFieldPresent(), "City text field" + _errorMessage);            
        }

        [Then(@"I should see a country drop down in the Update User Profile section")]
        public void ThenIShouldSeeACountryDropDownInTheUpdateUserProfileSection()
        {
            Assert.IsTrue(UserProfilePage.IsCountryDropDowmPresent(), "Country drop down" + _errorMessage);            
        }

        [Then(@"I should see a state drop down in the Update User Profile section")]
        public void ThenIShouldSeeAStateDropDownInTheUpdateUserProfileSection()
        {
            Assert.IsTrue(UserProfilePage.IsStateDropDowmPresent(), "State drop down" + _errorMessage);            
        }

        [Then(@"I should be redirected to dashboard")]
        public void ThenIShouldBeRedirectedToDashboard()
        {           
           Assert.IsTrue(UserProfilePage.IsOnDashboard(), "Cancel button is not working!");            

        }

        [Then(@"the change should be saved")]
        public void ThenTheChangeShouldBeSaved()
        {
            Assert.IsTrue(UserProfilePage.IsSaveSuccess(), "Error on saving changes");
        }

        [Then(@"I should see a validation message")]
        public void ThenIShouldSeeAValidationMessage()
        {
            Assert.IsTrue(UserProfilePage.IsFirstNameErrorVisible(), "First Name error not displayed");
        }

        [Then(@"changes should not be saved")]
        public void ThenChangesShouldNotBeSaved()
        {
            Assert.IsTrue(UserProfilePage.IsOnDashboard(), "Cancel not working");
        }

        #region db

        [Then(@"the changes should reflect in the database")]
        public void ThenTheChangesShouldReflectInTheDatabase()
        {
            UserProfilePage.ConfirmUpdatedFirstName();
        }

        [Then(@"the changes should not be reflected in the database")]
        public void ThenTheChangesShouldNotBeReflectedInTheDatabase()
        {
            UserProfilePage.ConfirmNoChangesOccur();

        }

        [Given(@"The ""(.*)"" and its (.*) on the front end")]
        public void GivenTheAndItsOnTheFrontEnd(string p0, string p1)
        {
            UserProfilePage.MaxLengthOnFrontEnd(p0,p1);
        }

        [When(@"I access the column schema from the database")]
        public void WhenIAccessTheColumnSchemaFromTheDatabase()
        {
            UserProfilePage.LengthValueInDB();
        }

        [Then(@"the length for the field should be same")]
        public void ThenTheLengthForTheFieldShouldBeSame()
        {
            UserProfilePage.CompareLength();
        }

        [When(@"I edit Field and change it to Value = ""(.*)""")]
        public void WhenIEditFieldAndChangeItToValue(string p0, Table table)
        {
            int i;
            int j = (table.RowCount) - 1;
            string val1;
            for (i = 0; i <= j; i++)
            {
                val1 = table.Rows[i][0];
                UserProfilePage.EnterChangedValues(val1,p0);
            }    
        }

        [Then(@"the value = ""(.*)"" should be reflected for updated Field in the database")]
        public void ThenTheValueShouldBeReflectedForUpdatedFieldInTheDatabase(string p0, Table table)
        {
            int i;
            int j = (table.RowCount) - 1;
            string val1;
            for (i = 0; i <= j;i++ )
            {
                val1 =table.Rows[i][0];
                UserProfilePage.CompareValuesWithDatabase(p0, val1);
            }
        }





        #endregion
    }
}
