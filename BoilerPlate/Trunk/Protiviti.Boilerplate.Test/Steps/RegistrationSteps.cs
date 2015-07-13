using Microsoft.VisualStudio.TestTools.UnitTesting;
using Protiviti.Boilerplate.Test.Pages;
using System;
using TechTalk.SpecFlow;
using System.Threading;

namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class RegistrationSteps
    {
        [Given(@"I am on the registration page")]
        public void GivenIAmOnTheRegistrationPage()
        {
            PageNavigator.NavigatePage("Register");
        }

        #region Form fields
        
        [Then(@"I should see Email field")]
        public void ThenIShouldSeeEmailField()
        {
            Pages.RegistrationPage.HasEmailField();
        }

        [Then(@"I see Confirm Email field")]
        public void ThenISeeConfirmEmailField()
        {
            Pages.RegistrationPage.HasConfirmEmailField();
        }

        [Then(@"I see Password field")]
        public void ThenISeePasswordField()
        {
            Pages.RegistrationPage.HasPasswordField();
        }

        [Then(@"I see Confirm Password field")]
        public void ThenISeeConfirmPasswordField()
        {
            Pages.RegistrationPage.HasConfirmPasswordField();
        }

        [Then(@"I see First Name field")]
        public void ThenISeeFirstNameField()
        {
            Pages.RegistrationPage.HasFirstNameField();
        }

        [Then(@"I see Last Name field")]
        public void ThenISeeLastNameField()
        {
            Pages.RegistrationPage.HasLastNameField();
        }

        [Then(@"I see Phone Number field")]
        public void ThenISeePhoneNumberField()
        {
            Pages.RegistrationPage.HasPhoneField();
        }

        [Then(@"I see Country field")]
        public void ThenISeeCountryField()
        {
            Pages.RegistrationPage.FillCountry();
        }

        [Then(@"I see Address Line (.*) field")]
        public void ThenISeeAddressLineField(int p0)
        {
            if (p0 == 1)
            {
                Pages.RegistrationPage.HasAddressLine1Field();
            }
            else
            {
                Pages.RegistrationPage.HasAddressLine2Field();
            }
        }

        [Then(@"I see City field")]
        public void ThenISeeCityField()
        {
            Pages.RegistrationPage.HasCityField();
        }

        [Then(@"I see State/Province field")]
        public void ThenISeeStateProvinceField()
        {
            Pages.RegistrationPage.HasStateField();
        }

        [Then(@"I see Salutation field")]
        public void ThenISeeSalutationField()
        {
            Pages.RegistrationPage.HasSalutationField();
        }

        [Then(@"I see Title field")]
        public void ThenISeeTitleField()
        {
            Pages.RegistrationPage.HasTitleField();
        }

        [Then(@"I see Suffix field")]
        public void ThenISeeSuffixField()
        {
            Pages.RegistrationPage.HasSuffixField();
        }

        [Then(@"I see Fax field")]
        public void ThenISeeFaxField()
        {
            Pages.RegistrationPage.HasFaxField();
        }

        [Then(@"I see Cell field")]
        public void ThenISeeCellField()
        {
            Pages.RegistrationPage.HasCellField();
        }

        [Then(@"I see Zip/Postal code field")]
        public void ThenISeeZipPostalCodeField()
        {
            Pages.RegistrationPage.HasPostalCodeField();
        }


        #endregion

        #region Email field scenarios

        /// <summary>
        /// Happy path
        /// </summary>
        [Given(@"I enter value into email and confirm email fields")]
        public void GivenIEnterValueIntoEmailAndConfirmEmailFields()
        {
            Pages.RegistrationPage.FillRandomEmail();
        }

        [Given(@"I enter incorrect value into email and confirm email fields")]
        public void GivenIEnterIncorrectValueIntoEmailAndConfirmEmailFields()
        {
            Pages.RegistrationPage.FillEmailIncorrectFormat();
        }

        [Given(@"I enter value into email and confirm email fields that don't match")]
        public void GivenIEnterValueIntoEmailAndConfirmEmailFieldsThatDonTMatch()
        {
            Pages.RegistrationPage.FillEmailsThatDontMatch();
        }

        [Then(@"the emails should be validated for match")]
        public void ThenTheEmailsShouldBeValidatedForMatch()
        {
            Assert.IsTrue(Pages.RegistrationPage.IfEmailsMatch(), "Emails don't match!");
        }

        [Then(@"the emails should be validated for non match")]
        public void ThenTheEmailsShouldBeValidatedForNonMatch()
        {
            Assert.IsTrue(Pages.RegistrationPage.IfEmailsDontMatch(), "Emails match!");
        }

        [Then(@"the email should be validated for incorrect format")]
        public void ThenTheEmailShouldBeValidatedForIncorrectFormat()
        {
            Assert.IsTrue(Pages.RegistrationPage.IfEmailsFormatIsIncorrect(), "Emails are in right format!");
        }

        [Then(@"the email should be validated for correct format")]
        public void ThenTheEmailShouldBeValidatedForCorrectFormat()
        {
            Assert.IsTrue(Pages.RegistrationPage.IfEmailsFormatIsCorrect(), "Email format is incorrect!");
        }



        #endregion

        #region Password fields

        [Given(@"I enter value into password and confirm password fields")]
        public void GivenIEnterValueIntoPasswordAndConfirmPasswordFields()
        {
            Pages.RegistrationPage.FillPassword();
        }

        [Given(@"I enter value into password and confirm password fields that don't match each other")]
        public void GivenIEnterValueIntoPasswordAndConfirmPasswordFieldsThatDonTMatchEachOther()
        {
            Pages.RegistrationPage.FillPasswordsThatDontMatch();
        }

        [Then(@"the passwords should be validated for match")]
        public void ThenThePasswordsShouldBeValidatedForMatch()
        {
            Assert.IsTrue(Pages.RegistrationPage.IfPasswordsMatch(), "Passwords don't match!");
        }

        [Then(@"the passwords should be validated for non match")]
        public void ThenThePasswordsShouldBeValidatedForNonMatch()
        {
            Assert.IsTrue(Pages.RegistrationPage.IfPasswordsDontMatch(), "Passwords match!");
        }

        [Then(@"the password should be validated for correct format")]
        public void ThenThePasswordShouldBeValidatedForCorrectFormat()
        {
        }


        #endregion

        #region Phone

        [Given(@"I enter value into phone number field")]
        public void GivenIEnterValueIntoPhoneNumberField()
        {
            Pages.RegistrationPage.FillPhoneNumber();
        }

        [Given(@"I enter invalid value into phone number field")]
        public void GivenIEnterInvalidValueIntoPhoneNumberField()
        {
            Pages.RegistrationPage.FillInvalidPhoneNumber();
        }
        
        [Then(@"the phone number should be validated for correct format")]
        public void ThenThePhoneNumberShouldBeValidatedForCorrectFormat()
        {
            Assert.IsTrue(Pages.RegistrationPage.IsValidPhone(), "Phone format is incorrect!");
        }

        [Then(@"the phone number should be validated for incorrect format")]
        public void ThenThePhoneNumberShouldBeValidatedForIncorrectFormat()
        {
            Assert.IsTrue(Pages.RegistrationPage.IsInvalidPhone(), "Phone format is correct!");
        }

        #endregion

        #region Required fields

        [Given(@"I fill all the required fields with red asterisks")]
        public void GivenIFillAllTheRequiredFieldsWithRedAsterisks(Table table)
        {
            Pages.RegistrationPage.FillAllRequiredFields();
        }

        [Given(@"I fill in required fields partially")]
        public void GivenIFillInRequiredFieldsPartially()
        {
            Pages.RegistrationPage.FillRequiredFieldsPartially();
        }

        [Given(@"I fill in all the required fields and some non required fields")]
        public void GivenIFillInAllTheRequiredFieldsAndSomeNonRequiredFields()
        {
            Pages.RegistrationPage.FillRequiredAndNonRequiredFields();
        }

        [Given(@"I check user agreement checkbox")]
        public void GivenICheckUserAgreementCheckbox()
        {
            RegistrationPage.AcceptUserAgreement();
        }
        
        #endregion

        #region Submission , Cancelation and Registration
        
        [Then(@"the Submit button should be displayed")]
        public void ThenTheSubmitButtonShouldBeDisplayed()
        {
            Assert.IsTrue(Pages.RegistrationPage.HasSubmitButton(), "Could not find Submit button");
        }

        [When(@"I click Submit button")]
        public void WhenIClickSubmitButton()
        {
            Pages.RegistrationPage.ClickSubmitButton();
        }
        
        [Then(@"I should be registered")]
        public void ThenIShouldBeRegistered()
        {
            Assert.IsTrue(Pages.RegistrationPage.IsRegistered(), "Could not be registered due to errors on the form");
        }

        [When(@"I click Cancel button")]
        public void WhenIClickCancelButton()
        {
            PageNavigator.NavigatePage("Home");
        }

        [Then(@"I should be taken to the home page")]
        public void ThenIShouldBeTakenToTheHomePage()
        {
            Assert.IsTrue(Pages.DashboardPage.IsAt, "Unable to navigate to the home page");
        }


        [Then(@"the form should be validated")]
        public void ThenTheFormShouldBeValidated()
        {
            Pages.RegistrationPage.Sleep();
        }


        #endregion

        #region T&C

        [Then(@"the T&C selection should be validated if checked")]
        public void ThenTheTCSelectionShouldBeValidatedIfChecked()
        {
            Thread.Sleep(3000);
            Assert.IsTrue(RegistrationPage.IfUserAgreementAccepted(), "User agreement acceptance is required");
        }


        #endregion
    }
}
