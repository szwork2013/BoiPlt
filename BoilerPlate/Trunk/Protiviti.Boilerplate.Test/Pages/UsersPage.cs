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
using System.Data.SqlClient;
using System.Threading;

namespace Protiviti.Boilerplate.Test.Pages
{
    class UsersPage
    {
        public static string _email;

        /// <summary>
        /// This function navigates the admin to the Users section
        /// </summary>
        public static void GoTo()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("adminsection"), 10);
            IWebElement manage = SeleniumController.Instance.Driver.FindElement(By.Id("adminsection"));
            manage.Click();
            SeleniumController.Instance.Driver.FindElement(By.Id("allusers")).Click();
        }
        /// <summary>
        /// This function provides admin login for the system
        /// </summary>
        public static void LoginAsAdmin()
        {
            LoginPage.GoTo();
            LoginPage.ClickResetButton();
            LoginPage.AdminLoginUsername();
            LoginPage.AdminLoginPassword();
            LoginPage.ClickLoginButton();
        }

        /// <summary>
        /// This function navigates to the users section
        /// </summary>
        public static void UserSection()
        {
            SeleniumController.SleepWaitTime(3000);
            LoginPage.GoTo();
            LoginPage.AdminLoginUsername();
            LoginPage.AdminLoginPassword();
            LoginPage.ClickLoginButton();
            UsersPage.GoTo();
        }

        /// <summary>
        /// This function checks if panel heading of the Users panel and throws an exception if it doesn't match
        /// </summary>
        /// <param name="headerText"></param>
        public static void PanelHeader(string headerText)
        {
            SeleniumController.SleepWaitTime(2000);
            IWebElement header = SeleniumController.Instance.Driver.FindElement(By.Id("Users"));
            Assert.AreEqual(header.Text, headerText);
        }

        /// <summary>
        /// This function checks if appropriate table column names are there in the Users panel section,
        /// and throws an exception if they don't match
        /// </summary>
        /// <param name="header1"></param>
        /// <param name="header2"></param>
        /// <param name="header3"></param>
        /// <param name="header4"></param>
        /// <param name="header5"></param>
        public static void PanelTableHeaders(string header1, string header2, string header3, string header4, string header5, string header6)
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("Users-Results-Header-Id"), 10);
            string header1Txt = SeleniumController.Instance.Driver.FindElement(By.Id("Users-Results-Header-Id")).Text;
            Assert.AreEqual(header1, header1Txt);
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("Users-Results-Header-Email"), 10);
            string header2Txt = SeleniumController.Instance.Driver.FindElement(By.Id("Users-Results-Header-Email")).Text;
            Assert.AreEqual(header2, header2Txt);
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("Users-Results-Header-FullName"), 10);
            string header3Txt = SeleniumController.Instance.Driver.FindElement(By.Id("Users-Results-Header-FullName")).Text;
            Assert.AreEqual(header3, header3Txt);
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("Users-Results-Header-Phone"), 10);
            string header4Txt = SeleniumController.Instance.Driver.FindElement(By.Id("Users-Results-Header-Phone")).Text;
            Assert.AreEqual(header4, header4Txt);
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("Users-Results-Header-Address"), 10);
            string header5Txt = SeleniumController.Instance.Driver.FindElement(By.Id("Users-Results-Header-Address")).Text;
            Assert.AreEqual(header5, header5Txt);
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("Users-Results-Header-IsActive"), 10);
            string header6Txt = SeleniumController.Instance.Driver.FindElement(By.Id("Users-Results-Header-IsActive")).Text;
            Assert.AreEqual(header6, header6Txt);
        }

        /// <summary>
        /// This function checks if Users panel is present and returns true or false depending on criteria
        /// </summary>
        /// <returns></returns>
        public static bool PanelPresent()
        {
            IWebElement panelHeading = SeleniumController.Instance.Driver.FindElement(By.ClassName("panel-heading"));
            IWebElement panelBody = SeleniumController.Instance.Driver.FindElement(By.ClassName("panel-body"));
            if ((panelHeading != null) && (panelBody != null))
                return true;
            else
                return false;
        }

        /// <summary>
        /// This function checks if search box is present on Users section and returns true or false depending on criteria
        /// </summary>
        /// <returns></returns>
        public static bool SearchBoxPresent()
        {
            IWebElement searchBox = SeleniumController.Instance.Driver.FindElement(By.Id("searchBox"));
            if (searchBox != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// This function checks if appropriate placeholder is present on search box and throws an exception if it doesn't match
        /// </summary>
        /// <param name="text"></param>
        public static void PlaceholderSearchBox(string text)
        {
            IWebElement searchBox = SeleniumController.Instance.Driver.FindElement(By.Id("searchBox"));
            string placeholdersearchBox = searchBox.GetAttribute("placeholder");
            Assert.AreEqual(text, placeholdersearchBox);
        }

        /// <summary>
        /// This function checks if Search button is present on Users panel,
        /// and throws an exception if it is not present
        /// </summary>
        /// <param name="buttonTxt"></param>
        public static void SearchButtonPresent(string buttonTxt)
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("searchBtn"), 10);
            IWebElement searchBtn = SeleniumController.Instance.Driver.FindElement(By.Id("searchBtn"));
            Assert.AreEqual(buttonTxt, searchBtn.Text);
        }

        /// <summary>
        /// This function checks if Register button is present on Users panel,
        /// and throws an exception if it is not present
        /// </summary>
        /// <param name="buttonTxt"></param>
        public static void RegisterButtonPresent(string buttonTxt)
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("registerBtn"), 10);
            IWebElement registerBtn = SeleniumController.Instance.Driver.FindElement(By.Id("registerBtn"));
            Assert.AreEqual(buttonTxt, registerBtn.Text);
        }

        /// <summary>
        /// This function compares the text on Register button, clicks the button if it is appropriate,
        /// and throws an exception if the text is not appropriate
        /// </summary>
        /// <param name="button"></param>
        public static void ClickRegisterButton(string button)
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("registerBtn"), 10);
            IWebElement registerBtn = SeleniumController.Instance.Driver.FindElement(By.Id("registerBtn"));
            if (registerBtn.Text == button)
                registerBtn.Click();
            else
                throw new Exception("Register button not present ");

        }

        /// <summary>
        /// This function checks the functionality of the Register button that it navigates tto the Registration form
        /// </summary>
        public static void NavigationRegistrationForm()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.ClassName("panel-title"), 10);
            IWebElement title = SeleniumController.Instance.Driver.FindElement(By.ClassName("panel-title"));
            string titleTxt = title.Text;
            Assert.AreEqual("Registration Form", titleTxt);
        }

        /// <summary>
        /// This function clicks the Expand/Collapse arrow present at the top right corner of Users panel
        /// </summary>
        public static void ClickExpandCollapseArrow()
        {
            SeleniumController.SleepWaitTime(2000);
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.XPath(".//*[@id='Users']/a/i"), 10);
            IWebElement arrow = SeleniumController.Instance.Driver.FindElement(By.XPath(".//*[@id='Users']/a/i"));
            arrow.Click();
        }

        public static void IsPanelCollapsed()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("Users-Header"), 10);
            IWebElement panelHeader = SeleniumController.Instance.Driver.FindElement(By.Id("Users-Header"));
            string attribute = panelHeader.GetAttribute("style");
            if (attribute == "display: none;")
            {
                SeleniumController.Instance.Driver.WaitUntilElementIsPresent(By.XPath(".//*[@id='Users']/a/i"), 30);
            }
            else
            {
                IWebElement arrow = SeleniumController.Instance.Driver.FindElement(By.XPath(".//*[@id='Users']/a/i"));
                arrow.Click();
            }
        }

        /// <summary>
        /// This function checks if Users panel collapse on clicking the Collapse/Expand arrow and throws an exception if it doesn't collapse
        /// </summary>
        public static void UsersPanelCollapse()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("Users-Header"), 10);
            IWebElement panelHeader = SeleniumController.Instance.Driver.FindElement(By.Id("Users-Header"));
            string attribute = panelHeader.GetAttribute("style");
            //Assert.AreEqual("display: none;", attribute);
            if (attribute.Contains("display: none") || attribute.Contains("overflow: hidden"))
            {
                Console.WriteLine("panel collapsed");
            }
            else
                throw new Exception("Panel not collapsed !");
        }

        /// <summary>
        /// This function checks if Users panel expand on clicking the Collapse/Expand arrow and throws an exception if it doesn't expand
        /// </summary>
        public static bool UsersPanelExpand()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("Users-Header"), 30);
            IWebElement panelHeader = SeleniumController.Instance.Driver.FindElement(By.Id("Users-Header"));
            string attribute = panelHeader.GetAttribute("style");
            if (attribute.Contains("display: block"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// This function checks if First Page button is present on the Users section and it's text is appropriate,
        /// and returns true or false depending on criteria
        /// </summary>
        /// <param name="buttontext"></param>
        /// <returns></returns>
        public static bool PagingFirstPage(string buttontext)
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("First-Page"), 10);
            IWebElement frstPageBtn = SeleniumController.Instance.Driver.FindElement(By.Id("First-Page"));
            string frstPageBtnTxt = frstPageBtn.Text;
            if (buttontext == frstPageBtnTxt)
                return true;
            else
                return false;
        }

        /// <summary>
        /// This function checks if Previous Page button is present on the Users section and it's text is appropriate,
        /// and returns true or false depending on criteria
        /// </summary>
        /// <param name="buttontext"></param>
        /// <returns></returns>
        public static bool PagingPreviousPage(string buttontext)
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("Prev-Page"), 10);
            IWebElement PrevPageBtn = SeleniumController.Instance.Driver.FindElement(By.Id("Prev-Page"));
            string PrevPageBtnTxt = PrevPageBtn.Text;
            if (buttontext == PrevPageBtnTxt)
                return true;
            else
                return false;
        }

        /// <summary>
        /// This function checks if Next Page button is present on the Users section and it's text is appropriate,
        /// and returns true or false depending on criteria
        /// </summary>
        /// <param name="buttontext"></param>
        /// <returns></returns>
        public static bool PagingNextPage(string buttontext)
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("Next-Page"), 10);
            IWebElement NextPageBtn = SeleniumController.Instance.Driver.FindElement(By.Id("Next-Page"));
            string NextPageBtnTxt = NextPageBtn.Text;
            if (buttontext == NextPageBtnTxt)
                return true;
            else
                return false;
        }

        /// <summary>
        /// This function checks that page no. is displayed on the panel,
        /// and returns true or false depending on criteria
        /// </summary>
        /// <returns></returns>
        public static bool PagingPageNumber()
        {
            var element = SeleniumController.Instance.Driver.FindElements(By.TagName("span"));
            foreach (var elmt in element)
            {
                if (elmt.Text.Contains("Page:"))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// This function checks if remove icon is present and returns true or false depending on criteria
        /// </summary>
        /// <returns></returns>
        public static bool RemoveIconPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.ClassName("fa-trash-o"), 10);
            var removeIcon = SeleniumController.Instance.Driver.FindElements(By.ClassName("fa-trash-o"));
            foreach (var icon in removeIcon)
            {
                if (icon == null)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// This function checks if edit icon is present and returns true or false depending on criteria
        /// </summary>
        /// <returns></returns>
        public static bool EditIconPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.ClassName("fa-pencil"), 10);
            var editIcon = SeleniumController.Instance.Driver.FindElements(By.ClassName("fa-pencil"));
            foreach (var icon in editIcon)
            {
                if (icon == null)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// This function clicks on the Remove icon present on the Users panel
        /// </summary>
        public static void ClickRemoveIcon()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.ClassName("fa-trash-o"), 10);
            IWebElement removeIcon = SeleniumController.Instance.Driver.FindElement(By.ClassName("fa-trash-o"));
            removeIcon.Click();
        }

        /// <summary>
        /// This function checks if Remove alert is present on clicking Remove icon,
        /// and returns true or false depending on criteria
        /// </summary>
        /// <returns></returns>
        public static bool isRemoveAlertPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.XPath("html/body/div[3]/div/div/div/div[1]/h3"), 10);
            IWebElement alertTitle = SeleniumController.Instance.Driver.FindElement(By.XPath("html/body/div[3]/div/div/div/div[1]/h3"));
            if (alertTitle.Text.Contains("Delete user"))
                return true;
            else
                return false;
        }

        public static bool IsActivateAlertPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.XPath("html/body/div[3]/div/div/div/div[1]/h3"), 10);
            IWebElement alertTitle = SeleniumController.Instance.Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[1]/h3"));
            if (alertTitle.Text.Contains("Activate user"))
                return true;
            else
                return false;
        }


        /// <summary>
        /// This function clicks on the Delete User button present on the Remove user alert
        /// </summary>
        /// <param name="button"></param>

        public static void ClickDeleteUserButton()
        {
            //WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.XPath("html/body/div[3]/div/div/div/div[3]/button[2]"), 10);
            //IWebElement dltButton = SeleniumController.Instance.Driver.FindElement(By.XPath("html/body/div[3]/div/div/div/div[3]/button[2]"));
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("deletebtn"), 30);
            IWebElement dltButton = SeleniumController.Instance.Driver.FindElement(By.Id("deletebtn"));
            //Assert.AreEqual(button, dltButton.Text);
            dltButton.Click();

        }

        /// <summary>
        /// This function count the no. of the users present in the users panel, and returns it's count
        /// </summary>
        /// <returns></returns>
        public static int CountUsers()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("Email"), 10);
            var user = SeleniumController.Instance.Driver.FindElements(By.Id("Email"));
            int userCount = user.Count;
            return userCount;
        }

        /// <summary>
        /// This function checks if the users count is same or not after the user has been removed,
        /// and returns true or false depending on criteria
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool UserRemoved(int count)
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("Email"), 10);
            var user = SeleniumController.Instance.Driver.FindElements(By.Id("Email"));
            int userCountDelete = user.Count;
            if (userCountDelete == count)
                return false;
            else
                return true;
        }

        /// <summary>
        /// This function clicks the Edit icon present on the Users panel
        /// </summary>
        public static void ClickEditIcon(string email)
        {
            if (IsActivateButtonPresent(email))
            {
                SeleniumController.SleepWaitTime(3000);
                ClickActivateButtonForUser(email);
                ClickActivateUserButton();
                WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("edit" + email), 10);
                IWebElement icon = SeleniumController.Instance.Driver.FindElement(By.Id("edit" + email));
                icon.Click();
            }
            else
            {
                //SearchEmail(email);
                WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("edit" + email), 10);
                IWebElement icon = SeleniumController.Instance.Driver.FindElement(By.Id("edit" + email));
                icon.Click();
            }
        }

        /// <summary>
        /// This function checks that admin is navigated to Assign Roles screen
        /// </summary>
        /// <returns></returns>
        public static bool AssignRolesSection()
        {
            SeleniumController.SleepWaitTime(2000);
            IWebElement header = SeleniumController.Instance.Driver.FindElement(By.Id("assignRoleUser"));
            string headerTxt = header.Text;
            if (headerTxt.Contains("Assign roles to user"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// This function checks for the presence of button 'Back to list' on the Assign Roles screen
        /// </summary>
        /// <param name="text"></param>
        public static void BacktolistButton(string text)
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("backtolist"), 10);
            IWebElement hyperText = SeleniumController.Instance.Driver.FindElement(By.Id("backtolist"));
            Assert.AreEqual(text, hyperText.Text);
        }

        /// <summary>
        /// This function checks a particular role checkbox in the Assign Roles screen
        /// </summary>
        public static void ClickRoleCheckbox()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.XPath("/html/body/div/div/section/div/section/section/div/div/div/div[1]/div/div[2]/section/section/div/div[3]/label/input"), 10);
            IWebElement role = SeleniumController.Instance.Driver.FindElement(By.XPath("/html/body/div/div/section/div/section/section/div/div/div/div[1]/div/div[2]/section/section/div/div[3]/label/input"));
            role.Click();
            SeleniumController.SleepWaitTime(2000);
        }

        /// <summary>
        /// This function verifies if the role that is to be added is checked or not, if the role is checked, then it is unchecked again
        /// </summary>
        public static void RoleCheckboxValueAdded()
        {
            ClickRoleCheckbox();
            bool val = RoleAdded();
            if (val == true)
            {
                ClickRoleCheckbox();
            }
            else
            {
                SeleniumController.SleepWaitTime(2000);
            }

        }

        /// <summary>
        /// This function verifies if the role that is to be removed is checked or not, if the role is not checked, then it is checked again
        /// </summary>
        public static void RoleCheckboxValueRemoved()
        {
            ClickRoleCheckbox();
            bool val = RoleRemoved();
            if (val == true)
            {
                ClickRoleCheckbox();
            }
            else
            {
                SeleniumController.SleepWaitTime(2000);
            }

        }

        /// <summary>
        /// This function checks if message is displayed on assign a particular role to a user
        /// </summary>
        /// <returns></returns>
        public static bool RoleAdded()
        {
            SeleniumController.SleepWaitTime(3000);
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.XPath("/html/body/div/div/section/div/section/section/div/div/div/div[1]/div/div[2]/section/section/div/div[1]/strong"), 10);
            IWebElement message = SeleniumController.Instance.Driver.FindElement(By.XPath("/html/body/div/div/section/div/section/section/div/div/div/div[1]/div/div[2]/section/section/div/div[1]/strong"));
            string msgText = message.Text;
            if (msgText.Contains("added successfully"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// This function checks if message is displayed on removing a particular role from a user
        /// </summary>
        /// <returns></returns>
        public static bool RoleRemoved()
        {
            SeleniumController.SleepWaitTime(3000);
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.XPath("/html/body/div/div/section/div/section/section/div/div/div/div[1]/div/div[2]/section/section/div/div[1]/strong"), 10);
            IWebElement message = SeleniumController.Instance.Driver.FindElement(By.XPath("/html/body/div/div/section/div/section/section/div/div/div/div[1]/div/div[2]/section/section/div/div[1]/strong"));
            string msgText = message.Text;
            if (msgText.Contains("removed successfully"))
                return true;
            else
                return false;
        }

        public static bool IsActivateButtonPresent(string email)
        {
            IWebElement activateIcon;
            SeleniumController.SleepWaitTime(3000);
            //WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("activateUser" + email), 10);
            try
            {
                SearchEmail(email);
                activateIcon = SeleniumController.Instance.Driver.FindElement(By.Id("activateUser" + email));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static void DeleteParticularUser(string email)
        {
            _email = email;
            SearchEmail(email);
            SeleniumController.SleepWaitTime(3000);
            if (IsActivateButtonPresent(email))
            {
                InCasePresenceOfActivateButton(email);
                //ClickActivateButtonForUser(email);
                ClickActivateUserButton();
                InCaseOfAbsenceOfActivateButton(email);
            }
            else
            {
                InCaseOfAbsenceOfActivateButton(email);
                //WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("deleteUser" + email), 30);
                //var button = SeleniumController.Instance.Driver.FindElement(By.Id("deleteUser" + email));
                //button.Click();
            }
        }

        // if activate button is present then activate the user
        public static void InCasePresenceOfActivateButton(string email)
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("activateUser" + email), 30);
            var button = SeleniumController.Instance.Driver.FindElement(By.Id("activateUser" + email));
            button.Click();
        }

        // if activate button is not present then remove the user
        public static void InCaseOfAbsenceOfActivateButton(string email)
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("deleteUser" + email), 30);
            var button = SeleniumController.Instance.Driver.FindElement(By.Id("deleteUser" + email));
            button.Click();
        }

        public static void ClickActivateButtonForUser(string email)
        {
            if (IsActivateButtonPresent(email))
            {
                InCasePresenceOfActivateButton(email);
            }
            else
            {
                InCaseOfAbsenceOfActivateButton(email);
                ClickDeleteUserButton();
                WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("activateUser" + email), 30);
                var button = SeleniumController.Instance.Driver.FindElement(By.Id("activateUser" + email));
                button.Click();
            }
        }

        public static void ClickActivateUserButton()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.XPath("html/body/div[3]/div/div/div/div[3]/button[2]"), 10);
            IWebElement actButton = SeleniumController.Instance.Driver.FindElement(By.XPath("html/body/div[3]/div/div/div/div[3]/button[2]"));
            Assert.AreEqual("Activate User", actButton.Text);
            actButton.Click();
        }

        public static bool IsDeleteButtonPresent(string email)
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("deleteUser" + email), 10);
            var deleteIcon = SeleniumController.Instance.Driver.FindElement(By.Id("deleteUser" + email));

            if (deleteIcon != null)
                return true;
            else
                return false;
        }

        public static void ClickCancelActivateUserButton()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.XPath("html/body/div[3]/div/div/div/div[3]/button[1]"), 10);
            IWebElement cancelButton = SeleniumController.Instance.Driver.FindElement(By.XPath("html/body/div[3]/div/div/div/div[3]/button[1]"));
            Assert.AreEqual("Cancel", cancelButton.Text);
            cancelButton.Click();
        }

        public static void SearchEmail(string email)
        {
            //SeleniumController.SleepWaitTime(2000);
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("Email"), 20);
            IWebElement searchBox = SeleniumController.Instance.Driver.FindElement(By.Id("searchBox"));
            searchBox.Clear();
            searchBox.SendKeys(email);

            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("searchBtn"), 20);
            IWebElement searchBtn = SeleniumController.Instance.Driver.FindElement(By.Id("searchBtn"));
            searchBtn.Click();
        }

        /// <summary>
        /// This function checks the active status of the registered user,
        /// and returns true or false depending on criteria
        /// </summary>
        /// <returns></returns>
        public static bool IsUserActive()
        {
            SeleniumController.SleepWaitTime(2000);
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("isActive"), 30);
            IWebElement userActive = SeleniumController.Instance.Driver.FindElement(By.Id("isActive"));
            if (userActive.Text == "No")
                return true;
            else
                return false;
        }

        /// <summary>
        /// This function activates the  particular user again that was deleted earlier
        /// </summary>
        /// <param name="email"></param>
        public static void ActivateUserAgain(string email)
        {
            SeleniumController.SleepWaitTime(3000);
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("activateUser" + email), 10);
            IWebElement activateUser = SeleniumController.Instance.Driver.FindElement(By.Id("activateUser" + email));
            activateUser.Click();
            SeleniumController.SleepWaitTime(2000);
            SeleniumController.Instance.Driver.FindElement(By.Id("deletebtn")).Click();
        }

        public static bool IsEditPwdSectionPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("EditPwdForUsers"), 30);
            IWebElement editPwdSection = SeleniumController.Instance.Driver.FindElement(By.Id("EditPwdForUsers"));
            if (editPwdSection != null)
                return true;
            else
                return false;
        }

        public static void EmptyNewPasswordField()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("newPassword"), 30);
            IWebElement newPwd = SeleniumController.Instance.Driver.FindElement(By.Id("newPassword"));
            newPwd.Clear();
            newPwd.SendKeys("");
        }

        public static bool IsRequiredPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("reqNewPwd"), 30);
            IWebElement reqValidationMsg = SeleniumController.Instance.Driver.FindElement(By.Id("reqNewPwd"));
            if (reqValidationMsg != null)
                return true;
            else
                return false;
        }

        public static void DifferentConfirmPassword()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("newPassword"), 30);
            IWebElement newPwd = SeleniumController.Instance.Driver.FindElement(By.Id("newPassword"));
            newPwd.Clear();
            newPwd.SendKeys("Password1!");

            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("confirmPassword"), 30);
            IWebElement confirmPwd = SeleniumController.Instance.Driver.FindElement(By.Id("confirmPassword"));
            confirmPwd.Clear();
            confirmPwd.SendKeys("DifferentPassword1!");
        }

        public static void IsDifferenConfirmPwdValidationPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("statusMessage"), 30);
            IWebElement validationMsg = SeleniumController.Instance.Driver.FindElement(By.Id("statusMessage"));
            Assert.AreEqual("Failed to register user: The new password and confirmation password do not match.", validationMsg.Text);
        }

        public static void ClickSubmitButton()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("changePwdBtn"), 30);
            IWebElement submitBtn = SeleniumController.Instance.Driver.FindElement(By.Id("changePwdBtn"));
            submitBtn.Click();
        }

        public static void InvalidNewPassword()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("newPassword"), 30);
            IWebElement newPwd = SeleniumController.Instance.Driver.FindElement(By.Id("newPassword"));
            newPwd.Clear();
            newPwd.SendKeys("IAMINVALID");
        }

        public static void PopulateSameConfirmPwd()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("confirmPassword"), 30);
            IWebElement confirmPwd = SeleniumController.Instance.Driver.FindElement(By.Id("confirmPassword"));
            confirmPwd.Clear();
            confirmPwd.SendKeys("IAMINVALID");
        }

        public static void IsInvalidPwdValidationPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("statusMessage"), 30);
            IWebElement validationMsg = SeleniumController.Instance.Driver.FindElement(By.Id("statusMessage"));
            Assert.AreEqual("Failed to register user: Passwords must have at least one non letter or digit character. Passwords must have at least one digit ('0'-'9'). Passwords must have at least one lowercase ('a'-'z').", validationMsg.Text);
        }

        public static void ValidNewPassword()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("newPassword"), 30);
            IWebElement newPwd = SeleniumController.Instance.Driver.FindElement(By.Id("newPassword"));
            newPwd.Clear();
            newPwd.SendKeys("Password1!");
        }

        public static void PopulateSameValidConfirmPwd()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("confirmPassword"), 30);
            IWebElement confirmPwd = SeleniumController.Instance.Driver.FindElement(By.Id("confirmPassword"));
            confirmPwd.Clear();
            confirmPwd.SendKeys("Password1!");
        }

        public static void IsSuccessMsgPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("statusMessage"), 30);
            IWebElement validationMsg = SeleniumController.Instance.Driver.FindElement(By.Id("statusMessage"));
            Assert.AreEqual("User Password Changed Successfully!", validationMsg.Text);
        }

        #region db
        public static void IsActiveDB()
        {
            int value;
            string connectionstring = "Data Source=localhost; Initial Catalog= ProtivitiPOC1; Integrated Security = True";
            SqlConnection Con = new SqlConnection(connectionstring);
            Con.Open();

            string sqlQuery = "select IsActive from Registration.People where UserName = '" + _email + "'";
            SqlCommand Com = new SqlCommand(sqlQuery, Con);
            value = Convert.ToInt16(Com.ExecuteScalar());
            try
            {
                if (value == 0)
                {
                    Console.Write("User is at inactive state");
                }
            }
            catch (Exception)
            {
                throw;
            }

            Con.Close();
        }
        #endregion
    }
}
