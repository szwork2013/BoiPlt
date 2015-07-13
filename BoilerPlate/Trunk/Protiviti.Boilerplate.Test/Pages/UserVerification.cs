using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protiviti.Boilerplate.Test.Support;
using Protiviti.Boilerplate.Test.Steps;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using Coypu;
using Coypu.Drivers;
using Coypu.Drivers.Selenium;
using System.Data;
using TechTalk.SpecFlow;
using OpenQA.Selenium;



namespace Protiviti.Boilerplate.Test.Pages
{
    class UserVerification
    {
        public static string Postfix(int charectersCount)
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

        /// <summary>
        /// This function redirects user to the home page of our site
        /// </summary>
        public static void HomePage()
        {
            SeleniumController.Instance.Driver.Navigate().GoToUrl(TestSettings.Instance.ClientUrl + "/#");

        }

        /// <summary>
        /// This function clicks on the Sign Up button on the home page
        /// </summary>
        public static void SignUpbutton()
        {
            SeleniumController.SleepWaitTime(2000);
            SeleniumController.Instance.Driver.FindElement(By.Id("signin")).Click();
        }

        /// <summary>
        /// This function fills at the required fields on the registration page.
        /// </summary>
        static int count = 0;

        public static void FillAllRequiredFields()
        {
            try
            {
                //String[] UserId = new String[] { "fast11@protiviti.com", "fast21@protiviti.com", "fast31@protiviti.com", "fast41@protiviti.com", "fast51@protiviti.com" };
                string userEmail = "fast";
                userEmail = userEmail + Postfix(3) + "@boilerplate.in";
                for (int i = count; i <= count; i++)
                {
                    SeleniumController.WaitTime("input#email");
                    SeleniumController.Instance.Driver.FindElement(By.Id("email")).SendKeys(userEmail);// button = SeleniumController.Instance.Driver.FindElement(By.Id("submit"));
                    SeleniumController.WaitTime("input#confirmEmail");
                    SeleniumController.Instance.Driver.FindElement(By.Id("confirmEmail")).SendKeys(userEmail);
                    SeleniumController.WaitTime("input#password");
                    SeleniumController.Instance.Driver.FindElement(By.Id("password")).SendKeys("Password1!");
                    SeleniumController.WaitTime("input#confirmPassword");
                    SeleniumController.Instance.Driver.FindElement(By.Id("confirmPassword")).SendKeys("Password1!");
                    SeleniumController.WaitTime("input#firstName");
                    SeleniumController.Instance.Driver.FindElement(By.Id("firstName")).SendKeys("Tester");
                    SeleniumController.WaitTime("input#lastName");
                    SeleniumController.Instance.Driver.FindElement(By.Id("lastName")).SendKeys("Coypu");
                    SeleniumController.WaitTime("input#phone");
                    SeleniumController.Instance.Driver.FindElement(By.Id("phone")).SendKeys("9891188849");
                    SeleniumController.WaitTime("input#addressLine1");
                    SeleniumController.Instance.Driver.FindElement(By.Id("addressLine1")).SendKeys("abcd");
                    SeleniumController.WaitTime("input#city ");
                    SeleniumController.Instance.Driver.FindElement(By.Id("city")).SendKeys("delhi");
                    SeleniumController.WaitTime("select#country");
                    Country();
                    SeleniumController.WaitTime("select#stateProvince");
                    State();
                    SeleniumController.WaitTime("input#postalCode");
                    Zip();
                    SeleniumController.WaitTime("input#userAgreement");
                    var checkBox = SeleniumController.Instance.Driver.FindElement(By.Id("userAgreement"));
                    if (!checkBox.Selected)
                    {
                        checkBox.Click();
                    }

                    //((IJavaScriptExecutor)SeleniumController.Instance.Driver).ExecuteScript("window.scrollTo(0,100)");
                }
                count++;
            }
            catch
            {
                throw new Exception("Please enter valid User Id in the array above.");
            }
        }

        public static void State()
        {
            string state = "New Delhi";
            var inputBox = SeleniumController.Instance.Driver.FindElement(By.Id("stateProvince"));
            inputBox.SendKeys(state);
        }

        public static void Country()
        {
            string country = "India";
            var inputBox = SeleniumController.Instance.Driver.FindElement(By.Id("country"));
            inputBox.SendKeys(country);
        }

        public static void Zip()
        {
            string PostalCode = "110085";
            var inputBox = SeleniumController.Instance.Driver.FindElement(By.Id("postalCode"));
            inputBox.Clear();
            inputBox.SendKeys(PostalCode);
        }


        /// <summary>
        /// This function clicks on the Submit button on registration page
        /// </summary>
        public static void SubmitButton()
        {
            var registerButton = SeleniumController.Instance.Driver.FindElement(By.Id("submit"));
            registerButton.Click();
            for (int i = 0; i < 10; i++)
            {
                if (SeleniumController.Instance.Driver.Url == "http://localhost/Protiviti.Boilerplate.Client/#/registration")
                {
                    SeleniumController.SleepWaitTime(2000);
                    continue;

                }
                else
                {
                    SeleniumController.WaitTime("div.col-md-3 button");
                    break;
                }
            }
        }


        /// <summary>
        /// This function verifies that the user is navigated to Verification Page
        /// </summary>
        public static void VerificationPage()
        {
            SeleniumController.SleepWaitTime(2000);

            if (SeleniumController.Instance.Driver.Url == "http://localhost/Protiviti.Boilerplate.Client/#/registration")
            {
                String errormessage = SeleniumController.Instance.Driver.FindElement(By.CssSelector("div.panel-body ng-scope span")).Text;
                if (errormessage.Contains("Failed to register"))
                {
                    Console.WriteLine("User already exists!");
                    throw new Exception(" Please try with a new user");
                }

            }
            else
            {
                try
                {
                    SeleniumController.WaitTime("div.col-md-3 button");
                    String VerificatonCode = SeleniumController.Instance.Driver.FindElement(By.CssSelector("div.col-md-3 button")).Text;
                    Assert.AreEqual("Send Verification Code", VerificatonCode);

                    IWebElement code = SeleniumController.Instance.Driver.FindElement(By.CssSelector("div.form-group input"));
                    code.Click();
                    code.SendKeys("11");

                    SeleniumController.WaitTime("div.form-group button");
                    IWebElement button = SeleniumController.Instance.Driver.FindElement(By.CssSelector("div.form-group button"));
                    string btext = button.Text;
                    Assert.AreEqual("Verify Code", btext);


                }

                catch
                {
                    throw new Exception("Page is not present.");

                }
            }
        }

        /// <summary>
        /// This function checks presence of both the authentication methods available in the dropdown menu
        /// </summary>
        public static void AuthenticationModes(String val)
        {
            SeleniumController.SleepWaitTime(2000);

            if (val == "SMS")
            {
                SeleniumController.WaitTime("div.row option");
                string a1 = SeleniumController.Instance.Driver.FindElement(By.CssSelector("div.row option:nth-of-type(3)")).Text;
                Assert.AreEqual("SMS", a1);
                Console.WriteLine("Hello");

            }
            else
            {
                SeleniumController.WaitTime("div.row option");
                string a2 = SeleniumController.Instance.Driver.FindElement(By.CssSelector("div.row option:nth-of-type(2)")).Text;
                Assert.AreEqual("Email", a2);
                Console.WriteLine("aa");

            }
        }

        /// <summary>
        /// This function selects an authentication method and eneters valid/invalid code in the textbox
        /// Flag =0 -> Invalid Code, Flag =1 -> Valid Code
        /// </summary>
        public static void VerificationCode(int flag)
        {
            SeleniumController.SleepWaitTime(3000);
            try
            {

                if (flag == 0)
                {
                    SeleniumController.WaitTime("div.row option");
                    SeleniumController.Instance.Driver.FindElement(By.CssSelector("div.row option:nth-of-type(3)")).Click();
                    IWebElement code = SeleniumController.Instance.Driver.FindElement(By.CssSelector("div.form-group input"));
                    code.Click();
                    code.SendKeys("1121");
                }
                else
                {
                    SeleniumController.WaitTime("div.row option");
                    SeleniumController.Instance.Driver.FindElement(By.CssSelector("div.row option:nth-of-type(2)")).Click();
                    IWebElement code = SeleniumController.Instance.Driver.FindElement(By.CssSelector("div.form-group input"));
                    code.Click();
                    code.SendKeys("1122");
                }
            }
            catch
            {
                throw new Exception("Button is not clicked.");
            }
        }

        /// <summary>
        /// This function checks for the error message that appears when invalid verification code is enetered.
        /// </summary>
        public static void ErrorMessage()
        {
            SeleniumController.SleepWaitTime(2000);
            try
            {
                SeleniumController.WaitTime("div.form-group button");
                SeleniumController.Instance.Driver.FindElement(By.CssSelector("div.form-group button")).Click();

                SeleniumController.WaitTime("div.toast-message");
                IWebElement mes = SeleniumController.Instance.Driver.FindElement(By.CssSelector("div.toast-message"));
                String message = mes.Text;
                Assert.AreEqual("[Boilerplate Error] $rootScope.requiresverification.data is undefined", message);

            }

            catch
            {
                throw new Exception("No error message is present on the screen.");
            }
        }


    }
}
