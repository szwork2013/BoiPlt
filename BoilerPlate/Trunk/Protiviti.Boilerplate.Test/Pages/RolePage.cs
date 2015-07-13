using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Protiviti.Boilerplate.Test.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.PhantomJS;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data.SqlClient;

namespace Protiviti.Boilerplate.Test.Pages
{
    class RolePage
    {

        //static RolePage()
        //{
        //    SeleniumController.Instance.Driver = new PhantomJSDriver();
        //    SeleniumController.Instance.Driver.Manage().Window.Size = new Size(1920, 1080);
        //}

        private static int browerWaitTime = 1;
        private static int waitTime = 4000;
        private static bool roleExists = false;
        private static bool isAdminSectionVisible = false;

        public static void LoginAsAdmin()
        {
            if (!isAdminSectionVisible)
            {
                LoginPage.GoTo();
                LoginPage.AdminLoginUsername();
                LoginPage.AdminLoginPassword();
                LoginPage.ClickLoginButton();
                //this is after you clean,rebuild and reset iis
                //this will wait for the page to load after user loggs in
                WebDriverWait wait = new WebDriverWait(SeleniumController.Instance.Driver, TimeSpan.FromMinutes(2));
                IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.Id("Technology Overview")));
                isAdminSectionVisible = true;

            }

        }

        /// <summary>
        /// This function navigates the user to the Roles section 
        /// </summary>
        static int flag = 0;
        public static void NavigateToRoles()
        {
            if (flag == 0)
            {
                WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("adminsection"), 30);
                IWebElement Manage = SeleniumController.Instance.Driver.FindElement(By.Id("adminsection"));
                Manage.Click();
                WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("mnuRoles"), 30);
                IWebElement Roles = SeleniumController.Instance.Driver.FindElement(By.Id("mnuRoles"));
                Roles.Click();
                flag++;
               try
                   {
                   string method = WebDriverExtensions.GetCurrentMethod();
                string scenario= WebDriverExtensions.GetCurrentScenario();
                string imagename = method+"_"+scenario;
                WebDriverExtensions.TakeScreenshot(SeleniumController.Instance.Driver, imagename);
                   }
                   catch
               {
                   throw new Exception("Unable to take a sceenshot");
                   }
                
            }
            else if (SeleniumController.Instance.Driver.Url.Contains("roles/roleId"))
            {
                WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("backtolist"), 30);
                IWebElement backToLoist = SeleniumController.Instance.Driver.FindElement(By.Id("backtolist"));
                backToLoist.Click();
                Thread.Sleep(waitTime);
            }

        }

        /// <summary>
        /// This function verifies that the header name is correct in Roles section 
        /// </summary>
        /// <param name="text"></param>
        public static void HasHeaderAsRoles(string text)
        {
            Thread.Sleep(waitTime);
            IWebElement HeaderTitle = SeleniumController.Instance.Driver.FindElement(By.Id("Roles-Header"));
            string title = HeaderTitle.Text;
            Assert.AreEqual(text, title);
        }

        /// <summary>
        /// This function verifies the header of the Add Roles page
        /// </summary>
        public static void HasHeaderAsAddRoles()
        {
            Thread.Sleep(waitTime);
            IWebElement AddRolesHeader = SeleniumController.Instance.Driver.FindElement(By.TagName("h1"));
            string title = AddRolesHeader.Text;
            Assert.AreEqual("Add Role :", title);
        }

        /// <summary>
        /// This function checks for the presence of "Back To List" link 
        /// </summary>
        /// <param name = "text"></param>
        public static void HasBackToListLink(string text)
        {
            Thread.Sleep(waitTime);
            IWebElement BackToList = SeleniumController.Instance.Driver.FindElement(By.Id("backtolist"));
            string title = BackToList.Text;
            Assert.AreEqual(text, title);
        }

        /// <summary>
        /// This function check for the presence of Add Roles label followed by a textbox  
        /// </summary>
        /// <param name="text"></param>
        public static void HasLabelAsAddRole(string text)
        {
            Thread.Sleep(waitTime);
            IWebElement AddRoleLabel = SeleniumController.Instance.Driver.FindElement(By.Id("rolenamelabel"));
            string title = AddRoleLabel.Text;
            Assert.AreEqual(text, title);
        }

        /// <summary>
        /// This function checks for the header of the grid in the Roles section 
        /// </summary>
        public static void HasRoleAsTableHeader(string text)
        {
            Thread.Sleep(waitTime);
            IWebElement RoleHeader = SeleniumController.Instance.Driver.FindElement(By.Id("Roles-Results-Header-Name"));
            string Title = RoleHeader.Text;
            Assert.AreEqual(text, Title);
        }

        public static void CheckForRolesTable()
        {
            Thread.Sleep(waitTime);
            IWebElement HeaderTitle = SeleniumController.Instance.Driver.FindElement(By.CssSelector("h4#Roles-Header"));
            string title = HeaderTitle.Text;
            Assert.AreEqual("Roles", title);
        }

        #region Expand/Collapse
        /// <summary>
        /// This function click on the expand/collapse arrow 
        /// </summary>
        public static void ClickOnArrow()
        {
            Thread.Sleep(waitTime);
            IWebElement arrow = SeleniumController.Instance.Driver.FindElement(By.ClassName("pull-right"));
            arrow.Click();
            Thread.Sleep(waitTime);
        }

        /// <summary>
        /// This function checks for the collapse functionality of the grid 
        /// </summary>
        public static void CheckCollapse()
        {
            Thread.Sleep(waitTime);
            IWebElement Collapse = SeleniumController.Instance.Driver.FindElement(By.Id("Roles-Body"));
            string value = Collapse.GetAttribute("style").Trim();
            Assert.AreEqual("display: none;", value);
        }

        /// <summary>
        /// This function checks for the expand functionality of the grid 
        /// </summary>
        public static void CheckExpand()
        {
            Thread.Sleep(waitTime);
            IWebElement Expand = SeleniumController.Instance.Driver.FindElement(By.Id("searchtextbox"));
            if (Expand.Displayed == true)
                Assert.AreEqual("input", Expand.TagName);
        }

        #endregion

        #region pop-up
        /// <summary>
        /// This function verifies the title of the pop-up
        /// </summary>
        /// <param name="text"></param>
        public static void CheckPopUpTitle(string text)
        {
            WebDriverWait wait = new WebDriverWait(SeleniumController.Instance.Driver, TimeSpan.FromSeconds(browerWaitTime));
            try
            {
                Thread.Sleep(3000);
                wait.Until(x => x.FindElement(By.ClassName("modal-content")));
                IWebElement Header = SeleniumController.Instance.Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[1]/h3"));
                Assert.AreEqual(text, Header.Text.Trim());
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// This function verifies the message of the pop-up
        /// </summary>
        /// <param name="text"></param>
        public static void CheckPopUpMessage(string text)
        {
            WebDriverWait wait = new WebDriverWait(SeleniumController.Instance.Driver, TimeSpan.FromSeconds(browerWaitTime));
            try
            {
                wait.Until(ExpectedConditions.ElementExists(By.ClassName("modal-content")));
                IWebElement message = SeleniumController.Instance.Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/p"));
                Assert.AreEqual(text, message.Text);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Get Metadata
        public static void GetRolesMetadata()
        {
            SeleniumController.Instance.Driver.Navigate().GoToUrl(TestSettings.Instance.ServerUrl + "/api/rolemanager/metadata");
        }
        #endregion

        #region Add Role
        /// <summary>
        /// This function checks for the presence of Add button 
        /// </summary>
        public static bool HasAddBtn()
        {
            IWebElement Addbtn = SeleniumController.Instance.Driver.FindElement(By.Id("btnSubmit"));
            return Addbtn != null;
        }

        /// <summary>
        /// This function click on the AddRoles  
        /// </summary>

        public static void ClickOnAddRoles()
        {
            WebDriverWait wait = new WebDriverWait(SeleniumController.Instance.Driver, TimeSpan.FromSeconds(browerWaitTime));
            IWebElement Add = SeleniumController.Instance.Driver.FindElement(By.Id("addrole"));
            Add.Click();
            string abc = SeleniumController.Instance.Driver.WindowHandles.ToString();
            Thread.Sleep(2000);
        }

        /// <summary>
        /// This function enters text in the Role Name 
        /// </summary>
        /// <param name="text"></param>
        public static void EnterRoleName(string text)
        {
            Thread.Sleep(waitTime);
            WebDriverWait wait = new WebDriverWait(SeleniumController.Instance.Driver, TimeSpan.FromSeconds(browerWaitTime));

            try
            {
                wait.Until(ExpectedConditions.ElementExists(By.Name("roleName")));
                IWebElement roleName = SeleniumController.Instance.Driver.FindElement(By.Name("roleName"));
                if (roleName != null)
                    roleName.SendKeys(text);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This function clicks on Add button 
        /// </summary>
        public static void ClickAdd()
        {
            Thread.Sleep(2000);
            SeleniumController.Instance.Driver.FindElement(By.Id("btnSubmit")).Click();

        }

        public static void CheckMessage(string text)
        {
            Thread.Sleep(waitTime);
            IWebElement messageElement = SeleniumController.Instance.Driver.FindElement(By.Id("message"));
            string message = messageElement.Text;
            Assert.AreEqual(text, message);
        }

        public static void CheckAddNewRoleMessage(string newRoleMessage, string roleExistsMessage)
        {
            WebDriverWait wait = new WebDriverWait(SeleniumController.Instance.Driver, TimeSpan.FromSeconds(browerWaitTime));
            IWebElement messageElement = SeleniumController.Instance.Driver.FindElement(By.Id("message"));
            Thread.Sleep(1000);
            string message = messageElement.Text.Trim();
            Console.WriteLine(message + "before if");
            if (message.Contains(newRoleMessage.Trim()) || message.Contains(roleExistsMessage.Trim()))
            {
                Console.WriteLine(message + "if");
                Assert.AreEqual("true", "true");
            }
            else
            {
                Console.WriteLine(message + "else");
                Assert.AreEqual("true", "false");
            }


        }

        /// <summary>
        /// This function verifies the message on adding Roles with same name
        /// </summary>
        /// <param name="text"></param>
        public static void CheckDuplicateNameMessage(string text)
        {
            Thread.Sleep(waitTime);
            IWebElement ErrorMessage = SeleniumController.Instance.Driver.FindElement(By.Id("message"));
            string message = ErrorMessage.Text;
            Assert.AreEqual(text, message);
        }

        public static void AddBtnShouldBeDisabled()
        {
            Thread.Sleep(200);
            IWebElement Addbtn = SeleniumController.Instance.Driver.FindElement(By.Id("btnSubmit"));
            string value = Addbtn.GetAttribute("disabled");
            Assert.AreEqual("true", value);
        }
        #endregion

        #region Search
        /// <summary>
        /// This function checks for the placeholder text in Search 
        /// </summary>
        /// <param name="text"></param>
        public static void CheckForSearchtext(string text)
        {
            Thread.Sleep(waitTime);
            IWebElement search = SeleniumController.Instance.Driver.FindElement(By.Id("searchtextbox"));
            string placeholder = search.GetAttribute("placeholder");

            Assert.AreEqual(text, placeholder);
        }

        /// <summary>
        /// This function checks for the presence of Search button 
        /// </summary>
        public static bool HasSearchBtn()
        {
            IWebElement Searchbtn = SeleniumController.Instance.Driver.FindElement(By.Id("searchbtn"));
            return Searchbtn != null;
        }

        /// <summary>
        /// This function enters text in the Search section 
        /// </summary>
        /// <param name="text"></param>
        public static void EnterValueInSearch(string text)
        {
            IWebElement Search = SeleniumController.Instance.Driver.FindElement(By.Id("searchtextbox"));
            Search.SendKeys(text);
        }

        /// <summary>
        /// This function clicks on Search button
        /// </summary>
        public static void ClickSearch()
        {
            IWebElement Search = SeleniumController.Instance.Driver.FindElement(By.Id("searchbtn"));
            Search.Click();
            Thread.Sleep(waitTime);
        }

        /// <summary>
        /// This function verifies that the correct results are displayed on searching an element
        /// </summary>
        /// <param name="text"></param>
        public static void VerifySearchResult(string text)
        {
            Thread.Sleep(waitTime);
            IWebElement SearchResult = SeleniumController.Instance.Driver.FindElement(By.Id("RoleName"));
            string RoleName = SearchResult.Text;
            Assert.AreEqual(text, RoleName);
        }

        #endregion

        #region Edit Role

        /// <summary>
        /// This function clicks on Edit Role
        /// </summary>
        /// <param name="text"></param>
        public static void ClickOnEditRole(string text)
        {
            roleExists = false;
            try
            {
                IWebElement Edit = SeleniumController.Instance.Driver.FindElement(By.Id("edit-" + text.Trim()));
                if (Edit != null)
                {
                    roleExists = true;
                    Edit.Click();
                    Thread.Sleep(waitTime);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            if (!roleExists)
            {
                AddNewRole(text);
                IWebElement Edit = SeleniumController.Instance.Driver.FindElement(By.Id("edit-" + text.Trim()));
                Edit.Click();
                //Console.WriteLine("Role" + text + " does not exists");
            }
        }

        /// <summary>
        /// This function verifies the header of the edit role section
        /// </summary>
        public static void UpdateRolesHeader(string p0)
        {
            Thread.Sleep(40);
            Thread.Sleep(waitTime);
            Console.WriteLine(SeleniumController.Instance.Driver.PageSource);
            IWebElement UpdateRolesHeader = SeleniumController.Instance.Driver.FindElement(By.CssSelector("h1.ng-binding"));
            string actualpageheader = UpdateRolesHeader.Text;
            string expectedpageheader = "Edit Role : " + p0;
            Assert.AreEqual(expectedpageheader , actualpageheader);
        }

        /// <summary>
        /// This function checks for the presence of Update button
        /// </summary>
        public static bool HasUpdateBtn()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("btnSubmit"), 30);
            IWebElement Updatebtn = SeleniumController.Instance.Driver.FindElement(By.Id("btnSubmit"));
            return Updatebtn != null;
        }

        /// <summary>
        /// This function changes the name of role from Role1 to Role2
        /// </summary>
        /// <param name="role1"></param>
        /// <param name="role2"></param>
        public static void UpdateRoleName(string role1, string role2)
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("txtRoleName"), 30);
            IWebElement RoleName = SeleniumController.Instance.Driver.FindElement(By.Id("txtRoleName"));
            //Assert.AreEqual(role1, RoleName.Text);
            RoleName.Clear();
            RoleName.SendKeys(role2);
        }

        /// <summary>
        /// This function clicks on Update button
        /// </summary>
        public static void ClickOnUpdate()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("btnSubmit"), 30);
            IWebElement Update = SeleniumController.Instance.Driver.FindElement(By.Id("btnSubmit"));
            Update.Click();
            Thread.Sleep(waitTime);
        }

        #endregion

        #region Deletion of role
        /// <summary>
        /// This function clicks on Delete role 
        /// </summary>
        /// <param name="text"></param>
        public static void ClickOnDeleteRole(string text)
        {
            roleExists = false;

            //First check whether role exists or not
            EnterValueInSearch(text);
            ClickSearch();

            if (text != null)
            {
                IWebElement Delete = SeleniumController.Instance.Driver.FindElement(By.Id("delete-" + text));

                IList<IWebElement> RoleNames = SeleniumController.Instance.Driver.FindElements(By.Id("RoleName")).ToList();
                foreach (var RoleName in RoleNames)
                {
                    if (RoleName.Text.ToLower() == text.Trim().ToLower())
                    {
                        roleExists = true;
                        Delete.Click();
                    }
                }
            }
            if (!roleExists)
            {
                Console.WriteLine("Role" + text + " does not exists");
            }
        }

        ///Deletes a selected role
        public static void DeleteRole(String text)
        {
            roleExists = false;

            //First check whether role exists or not
            EnterValueInSearch(text);
            ClickSearch();

            if (text != null)
            {
                Thread.Sleep(waitTime);
                IList<IWebElement> RoleNames = SeleniumController.Instance.Driver.FindElements(By.Id("RoleName")).ToList();

                foreach (var RoleName in RoleNames)
                {
                    string value;

                    if (RoleNames.Count > 0 && RoleName.Text == text)
                    {
                        IWebElement Delete = SeleniumController.Instance.Driver.FindElement(By.Id("delete-" + text));
                        if (Delete != null)
                        {
                            roleExists = true;
                            Delete.Click();
                        }
                    }
                }
            }

            if (!roleExists)
            {
                AddNewRole(text);
            }

        }

        public static void AddNewRole(String text)
        {
            ClickOnAddRoles();
            EnterRoleName(text);
            ClickAdd();
            NavigatetoRolePage();
            DeleteRole(text);
        }
        /// <summary>
        /// This function clicks on Confirm Delete button
        /// </summary>
        public static void ClickOnConfirmDelete()
        {
            if (roleExists)
            {
                Thread.Sleep(waitTime);
                IWebElement ConfirmDeletebtn = SeleniumController.Instance.Driver.FindElement(By.Id("deletebtn"));
                ConfirmDeletebtn.Click();
                Thread.Sleep(2000);
            }


        }

        /// <summary>
        /// This function verifies that the deleted element is no longer displayed
        /// </summary>
        /// <param name="text"></param>
        public static void CheckElementIsDeleted(string text)
        {
            if (roleExists)
            {
                string name;
                IList<IWebElement> RoleNames = SeleniumController.Instance.Driver.FindElements(By.Id("RoleName")).ToList();
                foreach (var RoleName in RoleNames)
                {
                    name = RoleName.Text;
                    if (name == text)
                    {
                        Console.Write("Element is not deleted");
                        break;
                    }
                    else if (name == null)
                    {
                        Console.Write("Element is deleted");
                    }
                    else
                    {
                        Console.Write("Element doen not exist");
                    }
                }
            }
        }


        /// <summary>
        /// This function checks for the presence of Cancel button
        /// </summary>
        public static bool HasCancelbtn()
        {
            IWebElement Cancelbtn = SeleniumController.Instance.Driver.FindElement(By.Id("cancelbtn"));
            return Cancelbtn != null;
        }

        /// <summary>
        /// This function checks for the presence if delete button
        /// </summary>
        /// <returns></returns>
        static int count = 0;
        public static int HasDeletebtn()
        {
            IWebElement Deletebtn = SeleniumController.Instance.Driver.FindElement(By.Id("deletebtn"));
            if (Deletebtn != null)
            {
                IWebElement Cancelbtn = SeleniumController.Instance.Driver.FindElement(By.Id("cancelbtn"));
                Cancelbtn.Click();
            }
            count++;
            return (count);
        }


        public static void NavigatetoRolePage()
        {
            SeleniumController.Instance.Driver.FindElement(By.Id("backtolist")).Click();
        }


        public static void ClearSearchBox()
        {
            SeleniumController.Instance.Driver.FindElement(By.Id("searchtextbox")).Clear();
            SeleniumController.Instance.Driver.FindElement(By.Id("searchbtn")).Click();
            count--;
        }
        #endregion

        #region Pagination
        /// <summary>
        /// This function checks for the presence of First Page button
        /// </summary>
        public static bool HasFirstPagebtn()
        {
            IWebElement FirstPagebtn = SeleniumController.Instance.Driver.FindElement(By.Id("First-Page"));
            return FirstPagebtn != null;
        }

        /// <summary>
        /// This function checks for the presence of Previous Page button
        /// </summary>
        public static bool HasPreviousPagebtn()
        {
            IWebElement PreviousPagebtn = SeleniumController.Instance.Driver.FindElement(By.Id("Prev-Page"));
            return PreviousPagebtn != null;
        }

        /// <summary>
        /// This function checks for the presence of Next Page button
        /// </summary>
        public static bool HasNextPagebtn()
        {
            IWebElement NextPagebtn = SeleniumController.Instance.Driver.FindElement(By.Id("Next-Page"));
            return NextPagebtn != null;
        }

        /// <summary>
        /// This function checks for the current page 
        /// </summary>
        /// <param name="text"></param>
        public static void CheckForCurrentPage(string text)
        {
            IWebElement CurrentPage = SeleniumController.Instance.Driver.FindElement(By.Id("pagenumber"));
            string CurrentPageInfo = CurrentPage.Text;
            Assert.AreEqual(text, CurrentPageInfo);
        }
        /// <summary>
        /// This function clicks on the button depending on the test data
        /// </summary>
        /// <param name="text"></param>
        public static void ClickOnPaginationBtn(string text)
        {
            IWebElement NextPage = SeleniumController.Instance.Driver.FindElement(By.Id("Next-Page"));
            IWebElement PreviousPage = SeleniumController.Instance.Driver.FindElement(By.Id("Prev-Page"));
            IWebElement FirstPage = SeleniumController.Instance.Driver.FindElement(By.Id("First-Page"));

            if (text == "Next Page")
            {
                NextPage.Click();
            }
            else if (text == "Previous Page")
            {
                NextPage.Click();
                PreviousPage.Click();
            }
            else if (text == "First Page")
            {
                PreviousPage.Click();
                FirstPage.Click();
            }
        }
        /// <summary>
        /// This function verifies the page number 
        /// </summary>
        /// <param name="text"></param>
        public static void CheckPageNumber(string text)
        {
            IWebElement PageNumber = SeleniumController.Instance.Driver.FindElement(By.Id("pagenumber"));
            string value = PageNumber.Text.Trim();
            Assert.AreEqual(text, value);
        }


        public static void TakeScreenshot(IWebDriver driver, string saveLocation)
        {

            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
            Screenshot screenshot = ssdriver.GetScreenshot();
            screenshot.SaveAsFile("Test.png", ImageFormat.Png);
        }

        #endregion

        #region db

        public static void DeletedRoleAndValidateDb(string Role)
        {
            string connectionstring = "Data Source=localhost; Initial Catalog= ProtivitiPOC1; Integrated Security = True";
            SqlConnection Con = new SqlConnection(connectionstring);
            Con.Open();

            string sqlQuery = "select Name from AspNetRoles";
            SqlCommand Com = new SqlCommand(sqlQuery, Con);
            var names = Com.ExecuteReader();

            while(names.Read())
            {
                var name = (string)names["Name"];
                if(name == Role)
                {
                    Console.WriteLine("Role" + names["Name"] + "is not deleted successfully");
                }
            }

            Con.Close();
        }
        #endregion
    }
}

