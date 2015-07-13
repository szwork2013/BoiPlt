using Microsoft.VisualStudio.TestTools.UnitTesting;
using Protiviti.Boilerplate.Test.Pages;
using System;
using TechTalk.SpecFlow;

namespace Protiviti.Boilerplate.Test
{
    [Binding]
    public class ChangePasswordSteps
    {
        [Given(@"I click on Change password in profile drop down menu item")]
        public void GivenIClickOnChangePasswordInProfileDropDownMenuItem()
        {
            UserProfilePage.ClickChangePasswordItem();
        }

        [When(@"I add a new password")]
        public void WhenIAddANewPassword()
        {
            UserProfilePage.AddANewPassword();
        }

        [When(@"I add same text as old password")]
        public void WhenIAddSameTextAsOldPassword()
        {
            UserProfilePage.AddSameOldPassword();
        }

        [When(@"I click on Change password in profile drop down menu item")]
        public void WhenIClickOnChangePasswordInProfileDropDownMenuItem()
        {
            UserProfilePage.ClickChangePasswordItem();
        }

        [When(@"I clear the old password field")]
        public void WhenIClearTheOldPasswordField()
        {
            UserProfilePage.EmptyOldPassword();
        }

        [Then(@"I should see a old password field in the Change Password section")]
        public void ThenIShouldSeeAOldPasswordFieldInTheChangePasswordSection()
        {
            Assert.IsTrue(UserProfilePage.IsOldPasswordPresent(), "Old Password not present!");
        }

        [Then(@"I should see a new password field in the Change Password section")]
        public void ThenIShouldSeeANewPasswordFieldInTheChangePasswordSection()
        {
            Assert.IsTrue(UserProfilePage.IsNewPasswordPresent(), "New Password not present!");
        }

        [Then(@"I should see a confirm password field in the Change Password section")]
        public void ThenIShouldSeeAConfirmPasswordFieldInTheChangePasswordSection()
        {
            Assert.IsTrue(UserProfilePage.IsConfirmPasswordPresent(), "Confirm Password not present!");
        }

        [Then(@"I should see a validation message for old password")]
        public void ThenIShouldSeeAValidationMessageForOldPassword()
        {
            Assert.IsTrue(UserProfilePage.IsOldPasswordErrorVisible(), "Required old password not present!");
        }


        [Then(@"I should see a validation message for same passwords")]
        public void ThenIShouldSeeAValidationMessageForSamePasswords()
        {
            Assert.IsTrue(UserProfilePage.IsSamePwdValidationPresent(), "Same old and new passwordvalidation not working");
        }

    }
}
