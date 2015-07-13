using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Protiviti.Boilerplate.Test.Support;
using System.Threading;
using OpenQA.Selenium.Firefox;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace Protiviti.Boilerplate.Test.Pages
{
    public class RegistrationPage
    {
        public static string randomGen(int charectersCount)
        {
            var chars = "0123456789";
            var stringChars = new char[charectersCount];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            return finalString;
        }

        public static bool IsAt()
        {
            var registrationPageElement = SeleniumController.Instance.Driver.FindElement(By.Id("registrationForm"));
            if (registrationPageElement.Text == "Register")
                return true;
            else
                return false;
        }

        public static bool IsRegistered()
        {
            //var readOnlyPage = SeleniumController.Instance.Driver.FindElements(By.Id("readOnlyForm"));
            //return readOnlyPage.Count > 0;
            Thread.Sleep(8000);
            var verificationText = SeleniumController.Instance.Driver.FindElement(By.TagName("h3"));
            if (verificationText.Text == "Verify your Account")
                return true;
            else
                return false; 
        }

        public static void FillRandomEmail()
        {
            string userEmail = "CKemailselenium+";
            userEmail = userEmail + randomGen(4) + "@gmail.com";
            Assert.AreEqual(true, WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("email"), 30));
            var inputBox = SeleniumController.Instance.Driver.FindElement(By.Id("email"));
            inputBox.Clear();
            inputBox.SendKeys(userEmail);
            SeleniumController.WaitTime("input#confirmEmail");
            var confirmEmailBox = SeleniumController.Instance.Driver.FindElement(By.Id("confirmEmail"));
            confirmEmailBox.Clear();
            confirmEmailBox.SendKeys(userEmail);

        }

        public static void FillEmailIncorrectFormat()
        {
            string userEmail = "CKemailselenium+";
            userEmail = userEmail + randomGen(4);
            SeleniumController.WaitTime("input#email");
            var inputBox = SeleniumController.Instance.Driver.FindElement(By.Id("email"));
            inputBox.SendKeys(userEmail);
            SeleniumController.WaitTime("input#confirmEmail");
            var confirmEmailBox = SeleniumController.Instance.Driver.FindElement(By.Id("confirmEmail"));
            confirmEmailBox.Clear();
            confirmEmailBox.SendKeys(userEmail);
        }

        public static void FillEmailsThatDontMatch()
        {
            string userEmail = "CKemailselenium+";
            userEmail = userEmail + randomGen(4) + "@gmail.com";
            SeleniumController.WaitTime("input#email");
            var inputBox = SeleniumController.Instance.Driver.FindElement(By.Id("email"));
            inputBox.SendKeys(userEmail);
            SeleniumController.WaitTime("input#confirmEmail");
            var confirmEmailBox = SeleniumController.Instance.Driver.FindElement(By.Id("confirmEmail"));
            confirmEmailBox.Clear();
            confirmEmailBox.SendKeys(userEmail + randomGen(4));
        }

        public static void FillPassword()
        {
            string password = "Password1!";
            SeleniumController.WaitTime("input#password"); 
            var inputBox = SeleniumController.Instance.Driver.FindElement(By.Id("password"));
            inputBox.Clear();
            inputBox.SendKeys(password);
            SeleniumController.WaitTime("input#confirmPassword");
            var confirmPasswordBox = SeleniumController.Instance.Driver.FindElement(By.Id("confirmPassword"));
            confirmPasswordBox.Clear();
            confirmPasswordBox.SendKeys(password);
        }

        internal static void FillPasswordsThatDontMatch()
        {
            string password = "password1!";
            SeleniumController.WaitTime("input#password"); 
            var inputBox = SeleniumController.Instance.Driver.FindElement(By.Id("password"));
            inputBox.Clear();
            inputBox.SendKeys(password);
            SeleniumController.WaitTime("input#confirmPassword");
            var confirmPasswordBox = SeleniumController.Instance.Driver.FindElement(By.Id("confirmPassword"));
            confirmPasswordBox.Clear();
            confirmPasswordBox.SendKeys("password");
        }

        public static void FillSalutation()
        {
            string salutation = "Miss";
            var inputBox = SeleniumController.Instance.Driver.FindElement(By.Id("salutation"));
            inputBox.SendKeys(salutation);
        }

        public static void FillSuffix()
        {
            string suffix = "Senior";
            var inputBox = SeleniumController.Instance.Driver.FindElement(By.Id("suffix"));
            inputBox.Clear();
            inputBox.SendKeys(suffix);
        }

        public static void FillFirstName()
        {
            string firstName = "CK";
            firstName = firstName + randomGen(2);
            var inputBox = SeleniumController.Instance.Driver.FindElement(By.Id("firstName"));
            inputBox.Clear();
            inputBox.SendKeys(firstName);
        }

        public static void FillLastName()
        {
            string lastName = "Koti";
            lastName = lastName + randomGen(2);
            var inputBox = SeleniumController.Instance.Driver.FindElement(By.Id("lastName"));
            inputBox.Clear();
            inputBox.SendKeys(lastName);
        }

        public static void FillPhoneNumber()
        {
            string phoneNumber = "224-654-9876";
            var inputBox = SeleniumController.Instance.Driver.FindElement(By.Id("phone"));
            inputBox.Clear();
            inputBox.SendKeys(phoneNumber);
        }

        public static void FillInvalidPhoneNumber()
        {
            string phoneNumber = "224Phone";
            var inputBox = SeleniumController.Instance.Driver.FindElement(By.Id("phone"));
            inputBox.Clear();
            inputBox.SendKeys(phoneNumber);
        }

        public static void FillCountry()
        {
            string country = "United States";
            SeleniumController.WaitTime("select#country");
            var inputBox = SeleniumController.Instance.Driver.FindElement(By.Id("country"));
            inputBox.SendKeys(country);
        }

        public static void FillAddressLine1()
        {
            string addressLine1 = "101 N Wacker Dr";
            var inputBox = SeleniumController.Instance.Driver.FindElement(By.Id("addressLine1"));
            inputBox.Clear();
            inputBox.SendKeys(addressLine1);
        }

        public static void FillCity()
        {
            string city = "Chicago";
            var inputBox = SeleniumController.Instance.Driver.FindElement(By.Id("city"));
            inputBox.Clear();
            inputBox.SendKeys(city);
        }

        public static void FillState()
        {
            string state = "IL";
            SeleniumController.WaitTime("select#stateProvince");
            var inputBox = SeleniumController.Instance.Driver.FindElement(By.Id("stateProvince"));
            inputBox.SendKeys(state);
        }

        public static void FillZipCode()
        {
            string zipPostalCode = "60601";
            SeleniumController.WaitTime("input#postalCode");
            var inputBox = SeleniumController.Instance.Driver.FindElement(By.Id("postalCode"));
            inputBox.Clear();
            inputBox.SendKeys(zipPostalCode);
        }

        public static void AcceptUserAgreement()
        {
            SeleniumController.WaitTime("input#userAgreement");
            var checkBox = SeleniumController.Instance.Driver.FindElement(By.Id("userAgreement"));
            if (!checkBox.Selected)
            {
                checkBox.Click();
            }
        }

        public static void FillAllRequiredFields()
        {
            FillRandomEmail();
            FillPassword();
            FillFirstName();
            FillLastName();
            FillPhoneNumber();
            FillCountry();
            FillAddressLine1();
            FillCity();
            FillState();
            FillZipCode();
            AcceptUserAgreement();
        }

        public static void FillRequiredFieldsPartially()
        {
            FillRandomEmail();
            FillPassword();
            FillPhoneNumber();
            FillCountry();
            FillAddressLine1();
            FillCity();
            FillState();
        }

        public static void FillAllRequiredFieldsExceptTAndC()
        {
            FillRandomEmail();
            FillPassword();
            FillFirstName();
            FillLastName();
            FillPhoneNumber();
            FillCountry();
            FillAddressLine1();
            FillCity();
            FillState();
            FillZipCode();
        }

        public static void FillRequiredAndNonRequiredFields()
        {
            FillRandomEmail();
            FillPassword();
            FillFirstName();
            FillLastName();
            FillPhoneNumber();
            FillCountry();
            FillAddressLine1();
            FillCity();
            FillState();
            FillSalutation();
            AcceptUserAgreement();
        }

        public static bool HasEmailField()
        {
            var inputField = SeleniumController.Instance.Driver.FindElement(By.Id("email"));
            return inputField != null;
        }

        public static bool HasConfirmEmailField()
        {
            var inputField = SeleniumController.Instance.Driver.FindElement(By.Id("confirmEmail"));
            return inputField != null;
        }

        public static bool HasPasswordField()
        {
            var inputField = SeleniumController.Instance.Driver.FindElement(By.Id("password"));
            return inputField != null;
        }

        public static bool HasConfirmPasswordField()
        {
            var inputField = SeleniumController.Instance.Driver.FindElement(By.Id("confirmPassword"));
            return inputField != null;
        }

        public static bool HasSalutationField()
        {
            var inputField = SeleniumController.Instance.Driver.FindElement(By.Id("salutation"));
            return inputField != null;
        }

        public static bool HasFirstNameField()
        {
            var inputField = SeleniumController.Instance.Driver.FindElement(By.Id("firstName"));
            return inputField != null;
        }

        public static bool HasLastNameField()
        {
            var inputField = SeleniumController.Instance.Driver.FindElement(By.Id("lastName"));
            return inputField != null;
        }

        public static bool HasTitleField()
        {
            var inputField = SeleniumController.Instance.Driver.FindElement(By.Id("title"));
            return inputField != null;
        }

        public static bool HasSuffixField()
        {
            var inputField = SeleniumController.Instance.Driver.FindElement(By.Id("suffix"));
            return inputField != null;
        }

        public static bool HasPhoneField()
        {
            var inputField = SeleniumController.Instance.Driver.FindElement(By.Id("phone"));
            return inputField != null;
        }

        public static bool HasFaxField()
        {
            var inputField = SeleniumController.Instance.Driver.FindElement(By.Id("fax"));
            return inputField != null;
        }

        public static bool HasCellField()
        {
            var inputField = SeleniumController.Instance.Driver.FindElement(By.Id("cell"));
            return inputField != null;
        }

        public static bool HasCountryField()
        {
            var inputField = SeleniumController.Instance.Driver.FindElement(By.Id("country"));
            return inputField != null;
        }

        public static bool HasAddressLine1Field()
        {
            var inputField = SeleniumController.Instance.Driver.FindElement(By.Id("addressLine1"));
            return inputField != null;
        }

        public static bool HasAddressLine2Field()
        {
            var inputField = SeleniumController.Instance.Driver.FindElement(By.Id("addressLine2"));
            return inputField != null;
        }

        public static bool HasCityField()
        {
            var inputField = SeleniumController.Instance.Driver.FindElement(By.Id("city"));
            return inputField != null;
        }

        public static bool HasStateField()
        {
            var inputField = SeleniumController.Instance.Driver.FindElement(By.Id("stateProvince"));
            return inputField != null;
        }
        
        public static bool HasPostalCodeField()
        {
            var inputField = SeleniumController.Instance.Driver.FindElement(By.Id("postalCode"));
            return inputField != null;
        }

        public static bool HasSubmitButton()
        {
            var registerButton = SeleniumController.Instance.Driver.FindElement(By.Id("submit"));
            return registerButton != null;
        }

        public static void ClickSubmitButton()
        {
         
            var registerButton = SeleniumController.Instance.Driver.FindElement(By.Id("submit"));
            registerButton.Click();
            Thread.Sleep(10000);
        }

        /// <summary>
        /// Happy path: Submit in all required fields
        /// </summary>
        public static void SubmitAllRequiredFields()
        {
            FillAllRequiredFields();
            ClickSubmitButton();
        }

        /// <summary>
        /// Submit partially required fields 
        /// </summary>
        public static void SubmitPartiallyFilledRequiredFields()
        {
            FillRequiredFieldsPartially();
            ClickSubmitButton();
        }

        /// <summary>
        /// Fill in required and non required fields
        /// </summary>
        public static void SubmitRequiredAndNonRequiredFields()
        {
            FillRequiredFieldsPartially();
            ClickSubmitButton();
        }

        public static void GoTo()
        {
            SeleniumController.Instance.Driver.Navigate().GoToUrl("http://localhost/Protiviti.Boilerplate.Client/#/registration");
           // Sleep();
        }

        public static void Sleep()
        {
            Thread.Sleep(4000);
        }

        #region Emails

        public static bool IfEmailsMatch()
        {
            Assert.AreEqual(true, WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("email"), 30));
            var inputBoxValue = SeleniumController.Instance.Driver.FindElement(By.Id("email")).GetAttribute("value");
            var confirmInputBoxValue = SeleniumController.Instance.Driver.FindElement(By.Id("confirmEmail")).GetAttribute("value");
            return (inputBoxValue == confirmInputBoxValue);
        }

        public static bool IfEmailsDontMatch()
        {
            Assert.AreEqual(true, WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("email"), 30));
            var inputBoxValue = SeleniumController.Instance.Driver.FindElement(By.Id("email")).GetAttribute("value");
            var confirmInputBoxValue = SeleniumController.Instance.Driver.FindElement(By.Id("confirmEmail")).GetAttribute("value");
            return (inputBoxValue != confirmInputBoxValue);
        }

        public static bool IfEmailsFormatIsIncorrect()
        {
            Assert.AreEqual(true, WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("email"), 30));
            var inputBoxValue = SeleniumController.Instance.Driver.FindElement(By.Id("email")).GetAttribute("value"); ;
            var confirmInputBoxValue = SeleniumController.Instance.Driver.FindElement(By.Id("confirmEmail")).GetAttribute("value"); ;
            return (!EmailIsValid(inputBoxValue) || !EmailIsValid(confirmInputBoxValue));
        }

        public static bool IfEmailsFormatIsCorrect()
        {
            Assert.AreEqual(true, WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("email"), 30));
            var inputBoxValue = SeleniumController.Instance.Driver.FindElement(By.Id("email")).GetAttribute("value"); ;
            var confirmInputBoxValue = SeleniumController.Instance.Driver.FindElement(By.Id("confirmEmail")).GetAttribute("value"); ;
            return (EmailIsValid(inputBoxValue) && EmailIsValid(confirmInputBoxValue));
        }

        static Regex ValidEmailRegex = CreateValidEmailRegex();

        /// <summary>
        /// Taken from http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx
        /// </summary>
        /// <returns></returns>
        private static Regex CreateValidEmailRegex()
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }

        internal static bool EmailIsValid(string emailAddress)
        {
            bool isValid = ValidEmailRegex.IsMatch(emailAddress);

            return isValid;
        }


        #endregion

        #region Passwords

        public static bool IfPasswordsMatch()
        {
            var inputBoxValue = SeleniumController.Instance.Driver.FindElement(By.Id("password")).GetAttribute("value");
            var confirmInputBoxValue = SeleniumController.Instance.Driver.FindElement(By.Id("confirmPassword")).GetAttribute("value");
            return (inputBoxValue == confirmInputBoxValue);
        }

        public static bool IfPasswordsDontMatch()
        {
            var inputBoxValue = SeleniumController.Instance.Driver.FindElement(By.Id("password")).GetAttribute("value");
            var confirmInputBoxValue = SeleniumController.Instance.Driver.FindElement(By.Id("confirmPassword")).GetAttribute("value");
            return (inputBoxValue != confirmInputBoxValue);
        }

        #endregion

        #region Phone number
        
        static Regex ValidPhoneRegex = CreateValidPhoneRegex();

        private static Regex CreateValidPhoneRegex()
        {
            string validPhonePattern = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
            return new Regex(validPhonePattern);
        }

        public static bool IsValidPhone()
        {
            Assert.AreEqual(true, WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("phone"), 30));
            var inputBoxValue = SeleniumController.Instance.Driver.FindElement(By.Id("phone")).GetAttribute("value");
            return ValidPhoneRegex.IsMatch(inputBoxValue);
        }

        public static bool IsInvalidPhone()
        {
            Assert.AreEqual(true, WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("phone"), 30));
            var inputBoxValue = SeleniumController.Instance.Driver.FindElement(By.Id("phone")).GetAttribute("value");
            return !ValidPhoneRegex.IsMatch(inputBoxValue);
        }

        #endregion

        #region User agreement
        
        internal static bool IfUserAgreementAccepted()
        {
            SeleniumController.WaitTime("input#userAgreement");
            Assert.AreEqual(true, WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("userAgreement"), 30));
            SeleniumController.SleepWaitTime(3000);
            var checkBox = SeleniumController.Instance.Driver.FindElement(By.Id("userAgreement"));
                        return checkBox.Selected;
        }


        #endregion
    }
}

