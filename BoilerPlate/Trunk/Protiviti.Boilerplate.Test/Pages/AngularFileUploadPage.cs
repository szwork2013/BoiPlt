using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Protiviti.Boilerplate.Test.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using System.Data.SqlClient;
using System.Threading;
using System.Xml.Linq;

namespace Protiviti.Boilerplate.Test.Pages
{
    class AngularFileUploadPage
    {
        public static string _FileTitle;
        public static string _FileName;

        /// <summary>
        /// This function navigates the user to AngularFileUpload Page directly 
        /// </summary>
        public static void GoTo()
        {
            SeleniumController.Instance.Driver.Navigate().GoToUrl("http://localhost/Protiviti.Boilerplate.Client/#/angularFileUpload");
            SeleniumController.SleepWaitTime(3000);
        }

        /// <summary>
        /// This function navigates the user to the AngularFileUpload Page from the 'View' item in the top menu bar
        /// </summary>
        public static void NavigateTo()
        {
            IWebElement viewItem = SeleniumController.Instance.Driver.FindElement(By.Id("viewmenu"));
            viewItem.Click();
            IWebElement angularFileUpload = SeleniumController.Instance.Driver.FindElement(By.Id("angularFileUpload"));
            angularFileUpload.Click();
        }

        /// <summary>
        /// This function checks for the presence of File Title field on the File Upload section of Angular File Upload
        /// </summary>
        /// <returns></returns>
        public static bool FileTitleFieldPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("fileTitle"), 30);
            IWebElement titleField = SeleniumController.Instance.Driver.FindElement(By.Id("fileTitle"));
            if (titleField != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// This function checks for the presence of File title label on the Upload section of Angular File Upload
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public static bool FileTitleLabelPresent(string label)
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("fileTitleLabel"), 30);
            IWebElement titleLabel = SeleniumController.Instance.Driver.FindElement(By.Id("fileTitleLabel"));
            if (titleLabel.Text.Contains("File Title"))
                return true;
            else
                return false;

        }

        /// <summary>
        /// This function checks for the presence of File Name label on the Upload section of Angular File Upload
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public static bool FileNameLabelPresent(string label)
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("fileName"), 30);
            IWebElement nameLabel = SeleniumController.Instance.Driver.FindElement(By.Id("fileName"));
            if (nameLabel.Text.Contains("File Name"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// This function checks for the presence of Submit button on the Upload section of Angular File Upload
        /// </summary>
        /// <param name="button"></param>
        public static void SubmitButtonPresent(string button)
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("submit"), 30);
            IWebElement btnSubmit = SeleniumController.Instance.Driver.FindElement(By.Id("submit"));
            Assert.AreEqual(button, btnSubmit.Text);
        }

        /// <summary>
        /// This functions enters the File title of the file to be uploaded in the FileTitle text field
        /// </summary>
        /// <param name="title"></param>
        public static void FileTitle(string title)
        {
            _FileTitle = title;
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("fileTitle"), 30);
            IWebElement fileTitle = SeleniumController.Instance.Driver.FindElement(By.Id("fileTitle"));
            fileTitle.Clear();
            fileTitle.SendKeys(title);
        }

        /// <summary>
        /// This function selects the file in the FileUpload placeholder by entering the path of the file from the local machine
        /// </summary>
        /// <param name="name"></param>
        public static void FileName(string name)
        {
            _FileName = name + ".jpg";
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("picFile"), 30);
            IWebElement fileName = SeleniumController.Instance.Driver.FindElement(By.Id("picFile"));
            fileName.SendKeys("C:\\Users\\Public\\Pictures\\Sample Pictures\\Desert.jpg");
        }

        /// <summary>
        /// This function clicks the Submit button on the upload section of the AngularFileUpload
        /// </summary>
        /// <param name="button"></param>
        public static void ClickSubmitButton(string button)
        {
            IWebElement btnSubmit = SeleniumController.Instance.Driver.FindElement(By.Id("submit"));
            Assert.AreEqual(button, btnSubmit.Text);
            btnSubmit.Click();
        }

        /// <summary>
        /// This function checks if the Submit button is disabled when no file is selected
        /// </summary>
        /// <returns></returns>
        public static bool SubmitButtonDisabled()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("submit"), 30);
            IWebElement btnSubmit = SeleniumController.Instance.Driver.FindElement(By.Id("submit"));
            string enable = btnSubmit.GetAttribute("disabled");
            if (enable == "true")
                return true;
            else
                return false;
        }

        /// <summary>
        /// This function checks for the presence of the progress bar in the file upload section 
        /// </summary>
        /// <returns></returns>
        //public static bool ProgressBarpresent()
        //{
        //    WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("progressbar"), 240);
        //    IWebElement uploadPercentage = SeleniumController.Instance.Driver.FindElement(By.Id("progressbar"));
        //    if (string.IsNullOrEmpty(uploadPercentage.Text))
        //        return false;
        //    else
        //        return true;
        //}

        /// <summary>
        /// This function checks if progress bar displays upload percentage on uploading selected file
        /// </summary>
        /// <param name="percent"></param>
        /// <returns></returns>
        //public static bool ProgressBarPercentage(string percent)
        //{
        //    WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("progressbar"), 240);
        //    IWebElement uploadPercentage = SeleniumController.Instance.Driver.FindElement(By.Id("progressbar"));
        //    if (uploadPercentage.Text.Contains("%"))
        //        return true;
        //    else
        //        return false;

        //}

        /// <summary>
        /// This function checks if 'Upload Successful' message is displayed on upload completion of the selected file
        /// </summary>
        /// <param name="message"></param>
        //public static void UploadSuccessfulMessage(string message)
        //{
        //    WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("msgUpload"), 240);
        //    IWebElement msgUpload = SeleniumController.Instance.Driver.FindElement(By.Id("msgUpload"));
        //    Assert.AreEqual(message, msgUpload.Text);
        //}

        /// <summary>
        /// This function checks if the progress bar shows complete upload percentage i.e. 100% for the selected file
        /// </summary>
        /// <param name="percentage"></param>
        /// <returns></returns>
        //public static bool CompleteUploadPercentage(int percentage)
        //{
        //    WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("progressbar"), 240);
        //    IWebElement uploadPercentage = SeleniumController.Instance.Driver.FindElement(By.Id("progressbar"));
        //    if (uploadPercentage.Text.Contains("100"))
        //        return true;
        //    else
        //        return false;
        //}


        public static void UploadedFilesGridColumns(ICollection<string> headers)
        {
            Thread.Sleep(2000);
            foreach (var h in headers)
            {
                var columnId = "file" + h + "-Header";
                IWebElement column = SeleniumController.Instance.Driver.FindElement(By.Id(columnId));
                Assert.AreEqual(column.Text, h);
            }
        }

        public static bool UploadedFilesGrid(string text)
        {
            Thread.Sleep(2000);
            IWebElement table = SeleniumController.Instance.Driver.FindElement(By.XPath("/html/body/div/div/section/div/section/section/div/div/div/fieldset"));
            string tableHeader = table.Text;
            if (tableHeader.Contains(text))
                return true;
            else
                return false;
        }

        /// <summary>
        /// This function counts the remove icons in the grid and compares it with the number of uploaded files present in the grid,
        /// and returns true or false depending on the criteria
        /// </summary>
        /// <returns></returns>
        public static bool RemoveIconPresent()
        {
            IList<IWebElement> icons = SeleniumController.Instance.Driver.FindElements(By.CssSelector("i[id^='deleteFile']"));
            int removeCount = icons.Count;
            var files = SeleniumController.Instance.Driver.FindElement(By.Id("Programs-Results-Table")).FindElements(By.Id("fileName"));
            int fileCount = files.Count;
            if (removeCount == fileCount)
                return true;
            else
                return false;

        }

        public static void PaginationofGrid(string button)
        {
            if (button == "First Page")
            {
                WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("First-Page"));
                IWebElement firstPage = SeleniumController.Instance.Driver.FindElement(By.Id("First-Page"));
                Assert.AreEqual(firstPage.Text, button);
            }
            else if (button == "Previous Page")
            {
                WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("Prev-Page"));
                IWebElement prevPage = SeleniumController.Instance.Driver.FindElement(By.Id("Prev-Page"));
                Assert.AreEqual(prevPage.Text, button);
            }
            else if (button == "Next Page")
            {
                WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("Next-Page"));
                IWebElement nextPage = SeleniumController.Instance.Driver.FindElement(By.Id("Next-Page"));
                Assert.AreEqual(nextPage.Text, button);
            }
        }

        public static bool SearchBoxPresent()
        {
            IWebElement searchBox = SeleniumController.Instance.Driver.FindElement(By.Id("searchBox"));
            if (searchBox != null)
                return true;
            else
                return false;
        }

        public static void PlaceholderSearchBox(string text)
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("searchBox"), 30);
            IWebElement searchBox = SeleniumController.Instance.Driver.FindElement(By.Id("searchBox"));
            string placeholder = searchBox.GetAttribute("placeholder");
            Assert.AreEqual(text, placeholder);
        }

        /// <summary>
        /// This function waits for the File Upload Grid's presence on the DOM
        /// </summary>
        public static void ViewFileUploadGrid()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("Programs-Results-Table"), 30);
        }

        /// <summary>
        /// This function uploads the selected file by entering it's title and path from the local machine
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="title"></param>
        public static void UploadSelectedFile(string filepath, string title)
        {
            SeleniumController.Instance.Driver.Navigate().Refresh();
            SeleniumController.SleepWaitTime(3000);
            IWebElement fileTitle = SeleniumController.Instance.Driver.FindElement(By.Id("fileTitle"));
            fileTitle.SendKeys(title);
            IWebElement file = SeleniumController.Instance.Driver.FindElement(By.Id("picFile"));
            file.SendKeys(filepath);
            Thread.Sleep(1000);
            IWebElement btnSubmit = SeleniumController.Instance.Driver.FindElement(By.Id("submit"));
            btnSubmit.Click();
            Thread.Sleep(2000);
        }

        /// <summary>
        /// This functions deletes the uploaded file that was uploaded in the Grid
        /// </summary>
        /// <param name="file"></param>
        /// <param name="title"></param>
        public static void DeleteSelectedFile(string file, string title)
        {
            SeleniumController.Instance.Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Name(file + "-" + title), 30);
            IWebElement deleteIcon = SeleniumController.Instance.Driver.FindElement(By.Name(file + "-" + title));
            deleteIcon.Click();
            SeleniumController.Instance.Driver.SwitchTo().Alert().Accept();
        }

        /// <summary>
        /// This function checks that the uploaded file is deleted on clicking the Delete icon by passing the 'Unable to locate element Exception'
        /// </summary>
        /// <param name="file"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        //public static string CheckDeletedFile(string file, string title)
        //{
        //    try
        //    {
        //        Thread.Sleep(2000);
        //        WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Name(file + "-" + title), 10);
        //        IWebElement deleteIcon = SeleniumController.Instance.Driver.FindElement(By.Name(file + "-" + title));
        //        string value = deleteIcon.Text;
        //        return value;
        //    }
        //    catch(Exception e)
        //    {
        //        SeleniumController.SleepWaitTime(2000);
        //        return (e.ToString());
        //    }

        //}

        /// <summary>
        /// This function checks if the uploaded file is deleted from the grid by comparing the attribute 'name' of the uploaded file from all the available files in the grid 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="title"></param>
        public static void CheckifFileDeleted(string file, string title)
        {
            SeleniumController.SleepWaitTime(3000);
            string name = file + "-" + title;
            var icons = SeleniumController.Instance.Driver.FindElements(By.CssSelector("table#Programs-Results-Table a"));
            for (int i = 0; i < 2; i++)
            {
                if (icons[i].GetAttribute("name") == name)
                {
                    throw new Exception("Item not deleted");
                }
            }
            Console.WriteLine("Item deleted");
        }


        #region db

        public static bool VerifyValuesWithDB()
        {
            string title = null;
            string name = null;
            string connectionstring = "Data Source=localhost; Initial Catalog=ProtivitiPOC1; Integrated Security =True";
            SqlConnection Connection = new SqlConnection(connectionstring);
            Connection.Open();

            string sqluserid = "select top 1 Title, FileName from [FileUpload].[File] order by CreatedDate desc";
            SqlCommand comm = new SqlCommand(sqluserid, Connection);
            SqlDataReader myreader = comm.ExecuteReader();
            while (myreader.Read())
            {
                title = myreader.GetString(0);
                name = myreader.GetString(1);
            }
            if (_FileTitle == title)
            {
                if (_FileName == name)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        #endregion
    }
}
