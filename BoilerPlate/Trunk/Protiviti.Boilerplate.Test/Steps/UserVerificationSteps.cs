using System;
using TechTalk.SpecFlow;
using Protiviti.Boilerplate.Test.Pages;
using Protiviti.Boilerplate.Test.Steps;
using Protiviti.Boilerplate.Test.Support;


namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class VerificationSteps
    {
        [Given(@"I am on the home page and click Sign Up")]
        public void GivenIAmOnTheHomePageAndClickSignUp()
        {
            PageNavigator.NavigatePage("Register");
            SeleniumController.SleepWaitTime(3000);
        }

        [Given(@"I fill all the required fields on the page")]
        public void GivenIFillAllTheRequiredFieldsOnThePage()
        {
            UserVerification.FillAllRequiredFields();
            SeleniumController.SleepWaitTime(3000);
        }

        [When(@"I click Submit button present on the page")]
        public void WhenIClickSubmitButtonPresentOnThePage()
        {
            UserVerification.SubmitButton();
            SeleniumController.SleepWaitTime(3000);
        }


        [Then(@"the form should be validated first")]
        public void ThenTheFormShouldBeValidatedFirst()
        {
            Console.WriteLine("User is registered successfully");
        }

        [Then(@"I should be redirected to the verification page")]
        public void ThenIShouldBeRedirectedToTheVerificationPage()
        {
            UserVerification.VerificationPage();
            SeleniumController.SleepWaitTime(3000);

        }


        [Given(@"I have eneterd valid credential in the registartion page")]
        public void GivenIHaveEneterdValidCredentialInTheRegistartionPage()
        {
            PageNavigator.NavigatePage("Register");
            SeleniumController.SleepWaitTime(3000);
            UserVerification.FillAllRequiredFields();
            SeleniumController.SleepWaitTime(3000);
        }

        [When(@"I am on Verification Page")]
        public void WhenIAmOnVerificationPage()
        {
            UserVerification.SubmitButton();
            SeleniumController.SleepWaitTime(3000);
        }

        [Then(@"I should see following buttons/fields on the page")]
        public void ThenIShouldSeeFollowingButtonsFieldsOnThePage()
        {
            UserVerification.VerificationPage();
            SeleniumController.SleepWaitTime(3000);

        }

        [Then(@"I should see following authentication methods on the page")]
        public void ThenIShouldSeeFollowingAuthenticationMethodsOnThePage(Table table)
        {
            foreach (TableRow tr in table.Rows)
            {
                string val = ((string[])tr.Values)[0].Trim();
                UserVerification.AuthenticationModes(val);
            }
            SeleniumController.SleepWaitTime(3000);

        }

        [Given(@"I am on Verification Page")]
        public void GivenIAmOnVerificationPage()
        {
            PageNavigator.NavigatePage("Register");
            SeleniumController.SleepWaitTime(3000);
            UserVerification.FillAllRequiredFields();
            UserVerification.SubmitButton();
            UserVerification.VerificationPage();
            SeleniumController.SleepWaitTime(3000);
        }

        static int code = 0;
        [When(@"I enter invalid verification code")]
        public void WhenIEnterInvalidVerificationCode()
        {
            UserVerification.VerificationCode(code);
            code++;
        }

        [Then(@"I should get an error message")]
        public void ThenIShouldGetAnErrorMessage()
        {
            UserVerification.ErrorMessage();

        }

        [When(@"I enter valid verification code")]
        public void WhenIEnterValidVerificationCode()
        {
            UserVerification.VerificationCode(code);
            SeleniumController.SleepWaitTime(3000);
        }

        [Then(@"I should be registered successfully")]
        public void ThenIShouldBeRegisteredSuccessfully()
        {
            Console.WriteLine("This Scenario is Pending for now");
        }

    }
}
