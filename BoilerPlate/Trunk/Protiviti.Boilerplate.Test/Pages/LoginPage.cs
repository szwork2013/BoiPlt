using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Protiviti.Boilerplate.Test.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using System.Threading;
using System.Diagnostics;

namespace Protiviti.Boilerplate.Test.Pages
{
    class LoginPage
    {

        public static void Initialize()
        {
            //SeleniumController.Instance.Driver.Navigate().GoToUrl(TestSettings.Instance.ServerUrl + "/breeze/UserManager/Metadata");
        }

        /// <summary>
        /// This function navigates the user to the login section of the project
        /// </summary>
        public static void GoTo()
        {
            Initialize();
            SeleniumController.Instance.Driver.Navigate().GoToUrl("http://localhost/Protiviti.Boilerplate.Client/#/login/");
            Thread.Sleep(2000);
        }

        /// <summary>
        /// This function checks if the alert window is present and throws an exception if alert window is not present
        /// </summary>
        public static bool isAlertPresent()
        {
            var abc = SeleniumController.Instance.Driver.SwitchTo().Alert();
            if (abc != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// This function provides admin login by entering admin username in the respective field
        /// </summary>
        public static void AdminLoginUsername()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("Email"), 10);
            IWebElement username = SeleniumController.Instance.Driver.FindElement(By.Id("Email"));
            username.SendKeys("admin@protiviti.com");
        }

        /// <summary>
        /// This function provides admin login by entering admin password in the respective field
        /// </summary>
        public static void AdminLoginPassword()
        {
            IWebElement password = SeleniumController.Instance.Driver.FindElement(By.Id("Password"));
            password.SendKeys("Admin@123");
        }

        /// <summary>
        /// This function provides user login by entering username in the respective field
        /// </summary>
        public static void UserLoginUsername(string username)
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("Email"), 10);
            IWebElement usernameFld = SeleniumController.Instance.Driver.FindElement(By.Id("Email"));
            usernameFld.SendKeys(username);
        }


        /// <summary>
        /// This function provides user login by entering username in the respective field
        /// </summary>
        public static void UserLoginPassword(string password)
        {
            IWebElement passwordFld = SeleniumController.Instance.Driver.FindElement(By.Id("Password"));
            passwordFld.SendKeys(password);
        }



        /// <summary>
        /// This function clicks login button on the menu bar at the top-right corner
        /// </summary>
        public static void ClickLoginButtonMenuBar()
        {
            bool loggedIn = UserLoggedIn();
            if(loggedIn == true)
            {
                SeleniumController.SleepWaitTime(1000);
            }
            //SeleniumController.SleepWaitTime(2000);
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.ClassName("brand-title"), 30);
            IWebElement login_button = SeleniumController.Instance.Driver.FindElement(By.ClassName("brand-title"));
            login_button.Click();
        }

        /// <summary>
        /// This function clicks login button on the login section
        /// </summary>
        public static void ClickLoginButton()
        {
            IWebElement btnLogin = SeleniumController.Instance.Driver.FindElement(By.Id("btnLogin"));
            btnLogin.Click();
        }

        /// <summary>
        /// This function clicks reset button on the login section
        /// </summary>
        public static void ClickResetButton()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("btnReset"), 10);
            IWebElement btnReset = SeleniumController.Instance.Driver.FindElement(By.Id("btnReset"));
            btnReset.Click();
        }

        /// <summary>
        /// This function checks the presence of the Username field on the login sectiom
        /// </summary>
        /// <returns></returns>
        public static bool UsernameFieldLoginSection()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("Email"));
            IWebElement username = SeleniumController.Instance.Driver.FindElement(By.Id("Email"));
            if (username != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// This function checks the presence of the Password field on the login sectiom
        /// </summary>
        /// <returns></returns>
        public static bool PasswordFieldLoginSection()
        {
            IWebElement password = SeleniumController.Instance.Driver.FindElement(By.Id("Password"));
            if (password != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// This function checks the presence of the Login button on the login sectiom
        /// </summary>
        /// <returns></returns>
        public static bool LoginButtonLoginSection()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("btnLogin"));
            IWebElement btnLogin = SeleniumController.Instance.Driver.FindElement(By.Id("btnLogin"));
            if (btnLogin != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// This function checks the presence of the Reset button on the login sectiom
        /// </summary>
        /// <returns></returns>
        public static bool ResetButtonLoginSection()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("btnReset"));
            IWebElement btnReset = SeleniumController.Instance.Driver.FindElement(By.Id("btnReset"));
            if (btnReset != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// This function checks that appropriate placeholder is there on Username field,
        /// and returns an exception if appropriate placeholder not there
        /// </summary>
        /// <param name="text"></param>
        public static void PlaceholderUsernameField(string text)
        {
            SeleniumController.SleepWaitTime(2000);
            IWebElement username = SeleniumController.Instance.Driver.FindElement(By.Id("Email"));
            string placeholderUsername = username.GetAttribute("placeholder");
            Assert.AreEqual(text, placeholderUsername);

        }

        /// <summary>
        /// This function checks that appropriate placeholder is there on Password field,
        /// and returns an exception if appropriate placeholder not there
        /// </summary>
        /// <param name="text"></param>
        public static void PlaceholderPasswordField(string text)
        {
            IWebElement password = SeleniumController.Instance.Driver.FindElement(By.Id("Password"));
            string placeholderPassword = password.GetAttribute("placeholder");
            Assert.AreEqual(text, placeholderPassword);

        }

        /// <summary>
        /// This function logs out the user that is signed in and return true,
        /// and returns false if the user is not logged in
        /// </summary>
        public static bool UserLoggedIn()
        {
            try
            {
                WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("currentuser"), 30);
                IWebElement headertext = SeleniumController.Instance.Driver.FindElement(By.Id("currentuser"));
                headertext.Click();
                WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("signout"), 30);
                IWebElement logoutBtn = SeleniumController.Instance.Driver.FindElement(By.Id("signout"));
                logoutBtn.Click();
                return true;

            }
            catch(Exception e)
            {
                return false;
            }
        }

        public static void LogOutUser()
        {
            if (SeleniumController.Instance.Driver.FindElement(By.Id("login")).Displayed == true)
            {
                throw new Exception("User is not logged in");
            }

            else
            {
                WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("currentuser"), 30);
                IWebElement headertext = SeleniumController.Instance.Driver.FindElement(By.Id("currentuser"));
                headertext.Click();
                WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("signout"), 30);
                IWebElement logoutBtn = SeleniumController.Instance.Driver.FindElement(By.Id("signout"));
                logoutBtn.Click();

            }
        }

        /// <summary>
        /// This function enters values in username and password fields
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static void UserEnterUsernamePassword(string username, string password)
        {
            LoginPage.ClickResetButton();
            IWebElement usernameFld = SeleniumController.Instance.Driver.FindElement(By.Id("Email"));
            usernameFld.SendKeys(username);
            IWebElement passwordFld = SeleniumController.Instance.Driver.FindElement(By.Id("Password"));
            passwordFld.SendKeys(password);
        }

        /// <summary>
        /// This function checks if the username and password fields are reset on reset functionality
        /// </summary>
        /// <returns></returns>
        public static bool UsernamePasswordFieldsReset()
        {
            IWebElement username = SeleniumController.Instance.Driver.FindElement(By.Id("Email"));
            string txtUsername = username.Text;
            IWebElement password = SeleniumController.Instance.Driver.FindElement(By.Id("Password"));
            string txtPass = password.Text;
            if ((txtPass == "") && (txtUsername == ""))
                return true;
            else
                return false;
        }

        /// <summary>
        /// This function checks if the user is not logged in, and throws an exception if user is logged in
        /// </summary>
        public static void UserNotLoggedIn()
        {
            IWebElement loginBtn = SeleniumController.Instance.Driver.FindElement(By.ClassName("brand-title"));
            string btnText = loginBtn.Text;
            Assert.AreEqual("  Login", btnText);
        }

        /// <summary>
        /// This function checks the presence of menu navigation bar
        /// </summary>
        /// <returns></returns>
        public static bool MenuNavigationBar()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.ClassName("navbar"), 10);
            var navMenu = SeleniumController.Instance.Driver.FindElement(By.ClassName("navbar"));
            if (navMenu == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// This function checks if the Employees menu item is not present on top menu navigation bar
        /// </summary>
        /// <param name="menuItem"></param>
        /// <returns></returns>
        public static bool EmployeesMenuItemNotPresent(string menuItem)
        {
            IWebElement navMenu = SeleniumController.Instance.Driver.FindElement(By.ClassName("navbar"));
            IWebElement employeesItem = navMenu.FindElement(By.Id("employees"));
            if (employeesItem.Text == menuItem)
                return false;
            else
            {
                //LoginPage.LogOutUser();
                return true;
            }
        }

        /// <summary>
        /// This function checks if the Employees menu item is present on top menu navigation bar 
        /// </summary>
        /// <param name="menuItem"></param>
        /// <returns></returns>
        public static bool EmployeesMenuItemPresent(string menuItem)
        {
            SeleniumController.SleepWaitTime(2000);
            IWebElement navMenu = SeleniumController.Instance.Driver.FindElement(By.ClassName("navbar"));
            IWebElement employeesItem = navMenu.FindElement(By.Id("employees"));
            if (employeesItem.Text == menuItem)
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// This functin checks if the Manage menu item is present on top menu navigation bar
        /// </summary>
        /// <param name="menuItem"></param>
        /// <returns></returns>
        public static bool ManageAdminMenuItemPresent(string menuItem)
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("adminsection"), 30);
            IWebElement navMenuItem = SeleniumController.Instance.Driver.FindElement(By.Id("adminsection"));
            if (navMenuItem.Text == menuItem)
            {
                navMenuItem.Click();
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// This function checks if appropriate menu items are present in Manage menu item dropdown
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <returns></returns>
        public static bool ManageDropdownItems(string item1, string item2)
        {
            IWebElement manageItem1 = SeleniumController.Instance.Driver.FindElement(By.Id("allusers"));
            IWebElement manageItem2 = SeleniumController.Instance.Driver.FindElement(By.Id("mnuRoles"));
            if ((manageItem1.Text == item1) && (manageItem2.Text == item2))
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// This function checks if the Manage menu item is not present on top menu navigation bar
        /// </summary>
        /// <param name="menuItem"></param>
        /// <returns></returns>
        public static bool ManageAdminMenuItemNotPresent(string menuItem)
        {
            SeleniumController.SleepWaitTime(3000);
            IWebElement item = SeleniumController.Instance.Driver.FindElement(By.Id("adminsection"));
            if (item.Text == menuItem)
                return false;
            else
            {
                return true;
            }
        }

        /// <summary>
        /// This function check the presence of 'Conect with Google+' button
        /// This function also helps to click on the same button
        /// Flag =0 --> Presence of Button
        /// Flag =1  --> Clicking on Button
        /// </summary>
        /// <returns></returns>
        static int count = 0;   // to check which button is clicked
        public static void GoogleLoginButtonPresent(int flag)
        {
            SeleniumController.SleepWaitTime(4000); 
            var googlebutton = SeleniumController.Instance.Driver.FindElements(By.TagName("button"));
            try
            {
                if (flag == 1)
                {
                    IWebElement SignInWithGoogle = googlebutton[4];
                    SignInWithGoogle.Click();
                    count++;
                    SeleniumController.SleepWaitTime(4000);
                }
                else
                {
                    SeleniumController.SleepWaitTime(3000);
                    String GoogleButtonText = googlebutton[4].Text;
                    Assert.AreEqual("| Connect with Google+", GoogleButtonText);
                }
            }
            catch
            {
                throw new Exception("Google button not present/clicked.");
            }
        }

        /// <summary>
        /// This function check the presence of 'Conect with Google+' button
        /// This function also helps to click on the same button
        /// Flag =0 --> Verifying Presence of Button
        /// Flag =1  --> Clicking on Button
        /// </summary>

        public static void FacebookLoginButtonPresent(int flag)
        {
            SeleniumController.SleepWaitTime(20000);
            var facebookbutton = SeleniumController.Instance.Driver.FindElements(By.TagName("button"));
            try
            {
                if (flag == 1)
                {
                    SeleniumController.SleepWaitTime(2000);
                    IWebElement SignInWithFacebook = facebookbutton[3];
                    SignInWithFacebook.Click();
                    SeleniumController.SleepWaitTime(3000);
                }
                else
                {
                    SeleniumController.SleepWaitTime(2000);
                    String FacebookButtonText = facebookbutton[3].Text;
                    Assert.AreEqual("| Connect with Facebook", FacebookButtonText);
                }
            }
            catch
            {
                throw new Exception("Facebook button not present/clicked.");
            }
        }

        /// <summary>
        /// This function allows user to login with Facebook or Google account
        /// Count=1 -->  External Login via Google+, Count =0--> External Login via Facebook
        /// </summary>
        public static void PopUpLoginWindow()
        {
            SeleniumController.SleepWaitTime(4000);

            if (count == 1)
            {
                IList<String> allWindows = SeleniumController.Instance.Driver.WindowHandles;
                
                int wincount = allWindows.Count();
                for (int i = 0; i < wincount; i++)
                {
                    try
                    {

                        if (SeleniumController.Instance.Driver.SwitchTo().Window(allWindows[i]).Title.Equals("Sign in - Google Accounts"))
                        {
                            SeleniumController.WaitTime("input#Email");

                            IWebElement Username = SeleniumController.Instance.Driver.FindElement(By.Id("Email"));
                            Username.SendKeys("boipla02@gmail.com");

                            IWebElement Password = SeleniumController.Instance.Driver.FindElement(By.Id("Passwd"));
                            Password.SendKeys("password3!");

                            IWebElement SignIn = SeleniumController.Instance.Driver.FindElement(By.Id("signIn"));
                            SignIn.Click();

                            SeleniumController.WaitTime("button#submit_approve_access");

                            try
                            {
                                if (SeleniumController.Instance.Driver.Title.Contains("Request for Permission"))
                                {
                                    SeleniumController.WaitTime("button#submit_approve_access");
                                    IWebElement Approve = SeleniumController.Instance.Driver.FindElement(By.Id("submit_approve_access"));
                                    for (int j = 0; j < 10; j++)
                                    {
                                        if (Approve.Enabled == true)
                                        {
                                            Approve.Click();
                                            break;
                                        }
                                        else
                                        {
                                            SeleniumController.SleepWaitTime(4000);
                                            continue;
                                        }
                                    }
                                }
                            }
                            catch
                            {
                                throw new Exception("Google page not loaded within 10 minutes. Please Execute the test again.");
                            }
                        }
                    }
                    catch (NoSuchWindowException e)
                    {
                        Debug.WriteLine("No such window found");
                    }
                }
            }
            else
            {
                IList<String> allWindows = SeleniumController.Instance.Driver.WindowHandles;
                int wincount = allWindows.Count();
                for (int i = 0; i < wincount; i++)
                {
                    try
                    {
                        if (SeleniumController.Instance.Driver.SwitchTo().Window(allWindows[i]).Title.Equals("Facebook"))
                        {
                            SeleniumController.Instance.Driver.Close();
                            //  SeleniumController.WaitTime(" ");

                        //    IWebElement Username = SeleniumController.Instance.Driver.FindElement(By.Id("email"));
                        //    Username.SendKeys("faspro01@gmail.com");

                        //    IWebElement Password = SeleniumController.Instance.Driver.FindElement(By.Id("pass"));
                        //    Password.SendKeys("password2!");

                        //    IWebElement CheckBox = SeleniumController.Instance.Driver.FindElement(By.Id("persist_box"));
                        //    CheckBox.Click();

                        //    IWebElement SignIn = SeleniumController.Instance.Driver.FindElement(By.Id("u_0_1"));
                        //    SignIn.Click();

                        //    // SeleniumController.WaitTime(" ");

                        //    SeleniumController.SleepWaitTime(30000);
                        //    try
                        //    {
                        //        if (SeleniumController.Instance.Driver.Title.Contains("Request for Permission"))
                        //        {
                        //            // SeleniumController.WaitTime("input#Email");
                        //            SeleniumController.SleepWaitTime(1000);
                        //            IWebElement Approve = SeleniumController.Instance.Driver.FindElement(By.Id("submit_approve_access"));
                        //            for (int j = 0; j < 10; j++)
                        //            {
                        //                if (Approve.Enabled == true)
                        //                {
                        //                    Approve.Click();
                        //                    break;
                        //                }
                        //                else
                        //                {
                        //                    SeleniumController.SleepWaitTime(4000);
                        //                    continue;
                        //                }
                        //            }
                        //        }
                        //    }
                        //    catch
                        //    {
                        //        throw new Exception("Facebook page not loaded within 10 minutes. Please Execute the test again.");
                        //    }
                        }
                    }
                    catch (NoSuchWindowException e)
                    {
                        Debug.WriteLine("No such window found");
                    }
                }


            }
        }



        /// <summary>
        /// This function allows user to associate their google/facebook account with the portal
        ///  /// Count=1 -->  External Login via Google+, Count =0--> External Login via Facebook
        /// </summary>
        public static void RegisterYourAccount()
        {
            SeleniumController.SleepWaitTime(1000);
            IWebDriver portal = SeleniumController.Instance.Driver;
            IList<String> allWindows = SeleniumController.Instance.Driver.WindowHandles;
            int wincount = allWindows.Count();
            for (int i = 0; i < wincount; i++)
            {
                try
                {
                    SeleniumController.Instance.Driver.SwitchTo().Window(allWindows[0]);
                    {
                        if (count == 1)
                        {
                            SeleniumController.SleepWaitTime(2000);
                            var Username = portal.FindElements(By.TagName("input"));
                            if (Username.Count!= 0)
                            {
                                //  SeleniumController.WaitTime("input.form-control ng-pristine ng-untouched ng-valid ng-valid-required");
                                IWebElement UsernameTextbox = Username[0];
                                UsernameTextbox.Clear();
                                UsernameTextbox.SendKeys("GoogleAccountRegistered");

                                portal.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
                                var RegisterButton = portal.FindElements(By.TagName("button"));
                                IWebElement RegisterButtonClick = RegisterButton[1];
                                RegisterButtonClick.Click();
                                SeleniumController.SleepWaitTime(4000);
                                String url = SeleniumController.Instance.Driver.Url;
                                if(SeleniumController.Instance.Driver.Url.Contains("http://localhost/Protiviti.Boilerplate.Client/#/"))
                                {
                                   continue;
                                }
                                else
                                {
                                    //SeleniumController.Instance.Driver.FindElement(By.XPath("html/body/div[1]/div/section/div/section/section/div/div/div[2]/div/div[2]/div[2]"));
                                     UsernameTextbox.Clear();
                                    UsernameTextbox.SendKeys("NewUser01");
                                    RegisterButtonClick.Click();
                                    
                                }

                            }
                            else
                            {
                                Console.WriteLine("This Google user is already registered with the portal");
                            }
                        }

                        else
                        {
                            var Username = portal.FindElements(By.TagName("a"));
                                                
                            if (Username.Count != 0)
                            {
                                //SeleniumController.WaitTime("form-control ng-pristine ng-untouched ng-valid ng-valid-required");
                                IWebElement UsernameTextbox = Username[0];
                                UsernameTextbox.Clear();
                                UsernameTextbox.SendKeys("FBAccountRegistered");


                                portal.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                                var RegisterButton = portal.FindElements(By.TagName("button"));
                                IWebElement RegisterButtonClick = RegisterButton[1];
                                RegisterButtonClick.Click();
                                //SeleniumController.WaitTime("h4#Technology Overview");
                            }
                            else
                            {
                                Console.WriteLine("This Facebook user is already registered with the portal.");
                            }

                        }
                    }
                }
                catch
                {
                    throw new Exception(" Window not found. Please try again.");
                }
            }

        }


        /// <summary>
        /// This function allows user to associate their google/facebook account with the portal after registering a name and clicking on Register button
        ////// Count=1 -->  External Login via Google+, Count =0--> External Login via Facebook 
        /// </summary>
        public static void VerifyExternalUserLogin()
        {
            SeleniumController.SleepWaitTime(2000);
            IList<String> allWindows = SeleniumController.Instance.Driver.WindowHandles;
            int wincount = allWindows.Count();
            for (int i = 0; i < wincount; i++)
            {
                SeleniumController.Instance.Driver.SwitchTo().Window(allWindows[0]);
                SeleniumController.WaitTime("a#currentuser");
                String headertext = SeleniumController.Instance.Driver.FindElement(By.Id("currentuser")).Text;
                SeleniumController.Instance.Driver.FindElement(By.Id("currentuser")).Click();
                if (count != 0)
                {
                    if (headertext == "GoogleAccountRegistered")
                        Assert.AreEqual("GoogleAccountRegistered", headertext);
                    else if (headertext == "NewUser01")
                        Assert.AreEqual("NewUser01", headertext);
                    else
                        Console.WriteLine("Invalid Name");
                    Signout();
                }

                else
                {
                    Assert.AreEqual("FBAccountRegistered", headertext);
                    Signout();
                }

            }
        }


        /// <summary>
        /// This function allows user to click on UserName displayed on the header
        /// </summary>
        public static void ClickExternalUserName()
        {
            SeleniumController.SleepWaitTime(3000);
            IList<String> allWindows = SeleniumController.Instance.Driver.WindowHandles;
            int wincount = allWindows.Count();
            for (int i = 0; i < wincount; i++)
            {
                try
                {
                    SeleniumController.Instance.Driver.SwitchTo().Window(allWindows[0]);
                    IWebElement headertext = SeleniumController.Instance.Driver.FindElement(By.Id("currentuser"));
                    headertext.Click();


                }
                catch
                {
                    throw new Exception("Missing Name/ Unable to find the element");
                    
                }
            }
        }


        /// <summary>
        /// This function check the dropdown items when external user is logged in
        /// By Default: Only 'Sign Out' is displayed to the external user
        /// </summary>
        public static void ExternalDropDownItems()
        {
            Thread.Sleep(3000);
            String[] listitems = new String[] { "changepassword", "changeprofile" };
            int count = listitems.Count();

            for (int i = 0; i < count; i++)
            {
                IWebElement hiddenitem1 = SeleniumController.Instance.Driver.FindElement(By.Id(listitems[i]));
                bool hidden1 = hiddenitem1.Displayed;
                if (hidden1 == true)
                {
                    throw new Exception("Please valaidate all the list items and hidden items");
                }

            }
           Signout();
        }

        public static void Signout()
        {
            SeleniumController.Instance.Driver.FindElement(By.Id("signout")).Click();
        }
            
        
    }
}