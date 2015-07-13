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
using System.Windows.Forms;
using System.Threading;
namespace Protiviti.Boilerplate.Test.Pages
{
    public class GridDemoPage
    {
        /// <summary>
        /// This function navigated the user to the Grid Demo Page
        /// </summary>
        public static void GoTo()
        {
            SeleniumController.Instance.Driver.Navigate().GoToUrl("http://localhost/Protiviti.Boilerplate.Client/index.html#/gridDemo");
            SeleniumController.Instance.Driver.Navigate().Refresh();
        }
        public static GridObject GetGridObjectById(string gridId)
        {
            return new GridObject(gridId);
        }

        public static void CheckURL()
        {
            String url = SeleniumController.Instance.Driver.Url;

            if (url != "http://localhost/Protiviti.Boilerplate.Client/index.html#/gridDemo")
            {
                SeleniumController.Instance.Driver.NavigateTo("http://localhost/Protiviti.Boilerplate.Client/index.html#/gridDemo");

            }
                         
        }

        public static void EnterFilterValue(string filterValue)
        {
            var mainAnimationContainer = GetMainAnimationContainer();
            var filterValueField = mainAnimationContainer.FindElement(By.ClassName("k-textbox"));
            filterValueField.SendKeys(filterValue);

        }
        public static bool IsAt()
        {
                Assert.AreEqual(true, WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.TagName("h2"), 30));
                var found = false;
                var gredDemoPageProof = SeleniumController.Instance.Driver.FindElements(By.TagName("h2"));
                foreach (var subHeading in gredDemoPageProof)
                {
                    if (subHeading.Text == "Local Data Grid with Sort and Filter")
                    {
                        found = true;
                        return found;
                    }
                }
                return false;
          
        }

        

        public static void FileUploadGridPresent()
        {
            SeleniumController.SleepWaitTime(3000);
            SeleniumController.WaitTime("h2#PRO_headingUploadGrid");
            IWebElement grid_heading = SeleniumController.Instance.Driver.FindElement(By.CssSelector("h2#PRO_headingUploadGrid"));
            Assert.AreEqual("File Upload Grid", grid_heading.Text);

        }

        public static void FileUploadGridColumns()
        {
            SeleniumController.SleepWaitTime(2000);
            SeleniumController.WaitTime("div#PRO_fileUploadGrid");
            IWebElement columns = SeleniumController.Instance.Driver.FindElement(By.CssSelector("div#PRO_fileUploadGrid tr"));
            Assert.AreEqual("File Name File Size File Type Upload Date Time", columns.Text);
        }

        /// <summary>
        /// This function finds the 'Select File/s' button, clicks it and returns true else returns false
        /// </summary>
        public static void SelectButton()
        {
            SeleniumController.SleepWaitTime(2000);
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("uploadGrid"), 30);
            IWebElement selectFileBtn = SeleniumController.Instance.Driver.FindElement(By.Id("uploadGrid"));
            selectFileBtn.SendKeys("C:\\Users\\Public\\Pictures\\Sample Pictures\\Desert.jpg");            
        }

        /// <summary>
        /// This function selects the file as per the filename 
        /// </summary>
        /// <param name="file"></param>
        public static void SelectFile(string file)
        {
            SeleniumController.Instance.Driver.Navigate().Refresh();
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("uploadGrid"), 30);
            if(file =="Desert")
            {
                IWebElement selectFileBtn = SeleniumController.Instance.Driver.FindElement(By.Id("uploadGrid"));
                selectFileBtn.SendKeys("C:\\Users\\Public\\Pictures\\Sample Pictures\\Desert.jpg");
            }
            else if(file =="Jellyfish")
            {
                IWebElement selectFileBtn = SeleniumController.Instance.Driver.FindElement(By.Id("uploadGrid"));
                selectFileBtn.SendKeys("C:\\Users\\Public\\Pictures\\Sample Pictures\\Jellyfish.jpg");
            }
            else if(file =="Lighthouse")
            {
                IWebElement selectFileBtn = SeleniumController.Instance.Driver.FindElement(By.Id("uploadGrid"));
                selectFileBtn.SendKeys("C:\\Users\\Public\\Pictures\\Sample Pictures\\Lighthouse.jpg");
            }

        }

        /// <summary>
        /// This function checks the presence of the 'Select File/s' button and throws an exception
        /// if the button is not found
        /// </summary>
        public static void SelectFileButtonPresent()
        {
            SeleniumController.SleepWaitTime(2000);      
            IWebElement selectFile = SeleniumController.Instance.Driver.FindElement(By.ClassName("k-upload-button"));
            IWebElement selectButton = selectFile.FindElement(By.TagName("span"));
            Assert.AreEqual("Select File/s", selectButton.Text);

        }
        
        /// <summary>
        /// This function checks the presence of the 'Upload' button and returns true or false
        /// </summary>
        public static bool UploadButtonPresent()
        {
            SeleniumController.SleepWaitTime(2000);
            IWebElement abc = SeleniumController.Instance.Driver.FindElement(By.Id("uploadFiles"));
            if (abc != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// This function checks the presence of the 'Remove' icon and throws an exception
        /// if the icon is not found
        /// </summary>
        public static void RemoveIconPresent()
        {
            var found = false;
            SeleniumController.SleepWaitTime(2000);
            var icons = SeleniumController.Instance.Driver.FindElement(By.ClassName("k-upload-status"));
            var icon = icons.FindElements(By.TagName("button"));    
            if (icon.Count >= 1)
            {
                found = true;
            }

            if (!found)
                throw new Exception("Remove icon not present");

        }

        /// <summary>
        /// This function checks the presence of the file that is selected and throws an exception
        /// if the file is not found
        /// </summary>
        public static void SelectedFilePresent()
        {
            var found = false;
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.ClassName("k-filename"), 30);
            var file = SeleniumController.Instance.Driver.FindElement(By.ClassName("k-filename"));
            if (file != null)
            {
                found = true;
            }
            if (!found)
                throw new Exception("Selected file not present");
        }

        /// <summary>
        /// This function finds the grid column names and returns the value /name of the selected column
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public static string FindGridElement(string xpath)
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.XPath(xpath), 30);
            IWebElement column = SeleniumController.Instance.Driver.FindElement(By.XPath(xpath));
            string columnName = column.Text;
            return columnName;
        }

        /// <summary>
        /// This function clicks the remove icon after the file selection and uses a variable count to check the deletion of the selected item
        /// </summary>
        public static void ClickRemoveIcon()
        {
            //SeleniumController.SleepWaitTime(1000);
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.XPath("/html/body/div[1]/div/section/div/section/section/div/form/div[2]/ul/li/strong/button"), 30);
            //IWebElement removeIcon = SeleniumController.Instance.Driver.FindElement(By.CssSelector("html.k-ff.k-ff34.ng-scope body div.ng-scope div.ng-scope section#content.content div.shuffle-animation.ng-scope section#employee-view.mainbar.ng-scope section.matter div.container form.ng-pristine.ng-valid div.k-widget.k-upload.k-header.k-upload-sync ul.k-upload-files.k-reset li.k-file strong.k-upload-status button.k-button.k-button-bare.k-upload-action"));
            IWebElement removeIcon = SeleniumController.Instance.Driver.FindElement(By.XPath("/html/body/div[1]/div/section/div/section/section/div/form/div[2]/ul/li/strong/button"));
            removeIcon.Click();
        }

        /// <summary>
        /// This function clicks on the upload button present below the grid
        /// </summary>
        public static void ClickUploadButton()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("uploadFiles"), 30);
            IWebElement upload_button = SeleniumController.Instance.Driver.FindElement(By.Id("uploadFiles"));
            upload_button.Click();
        }

        /// <summary>
        /// This function checks if the file is selected in the text area below the grid column names,
        /// and returns true or false depending on criteria 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool FileSelected(string fileName)
        {
            SeleniumController.SleepWaitTime(2000);
            var filenames = SeleniumController.Instance.Driver.FindElements(By.ClassName("k-filename"));
            foreach (var name in filenames)
            {
                if (name.Text.Contains(fileName))
                    return true;
            }
            return false;           
        }

        
        /// <summary>
        /// This function checks if the selected file is removed in the grid and returns true or false depending on criteria
        /// </summary>
        /// <returns></returns>
        public static bool SelectedFileRemoved()
        {
            try
            {
                WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.ClassName("k-filename"), 30);
                IWebElement file = SeleniumController.Instance.Driver.FindElement(By.ClassName("k-filename"));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// This function checks if  file details are shown in File Name column after file is uploaded,
        /// and returns true or false depending on criteria
        /// </summary>
        /// <returns></returns>
        public static bool GridFileName()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.XPath(".//*[@id='PRO_fileUploadGrid']/div[2]/table/tbody/tr[1]/td[1]/span"), 30);
            IWebElement fileName = SeleniumController.Instance.Driver.FindElement(By.XPath(".//*[@id='PRO_fileUploadGrid']/div[2]/table/tbody/tr[1]/td[1]/span"));
            if (fileName == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// This function checks if  file details are shown in File Size column after file is uploaded,
        /// and returns true or false depending on criteria
        /// </summary>
        /// <returns></returns>
        public static bool GridFileSize()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.XPath(".//*[@id='PRO_fileUploadGrid']/div[2]/table/tbody/tr[1]/td[2]/span"), 30);
            IWebElement fileSize = SeleniumController.Instance.Driver.FindElement(By.XPath(".//*[@id='PRO_fileUploadGrid']/div[2]/table/tbody/tr[1]/td[2]/span"));
            if (fileSize == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// This function checks if  file details are shown in File Type column after file is uploaded,
        /// and returns true or false depending on criteria
        /// </summary>
        /// <returns></returns>
        public static bool GridFileType()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.XPath(".//*[@id='PRO_fileUploadGrid']/div[2]/table/tbody/tr[1]/td[3]/span"), 30);
            IWebElement fileType = SeleniumController.Instance.Driver.FindElement(By.XPath(".//*[@id='PRO_fileUploadGrid']/div[2]/table/tbody/tr[1]/td[3]/span"));
            if (fileType == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// This function checks if  file details are shown in Upload Date Time column after file is uploaded,
        /// and returns true or false depending on criteria
        /// </summary>
        /// <returns></returns>
        public static bool GridUploadDateTime()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.XPath(".//*[@id='PRO_fileUploadGrid']/div[2]/table/tbody/tr[1]/td[4]/span"), 30);
            IWebElement fileDateTime = SeleniumController.Instance.Driver.FindElement(By.XPath(".//*[@id='PRO_fileUploadGrid']/div[2]/table/tbody/tr[1]/td[4]/span"));
            if (fileDateTime == null)
                return false;
            else
                return true;
        }

        /// <summary>
        ///This function takes the name of table you would like to select and the number of rows that this table should
        ///be showing by default on the page then return true if the number of rows is correct.
        ///written by Sal
        /// </summary>
        /// <returns></returns>
        public static bool DataRowsCount(string gridToChose, int rowsAllowed)
        {


            string tableCssName;
            switch (gridToChose)
            {
                case "Local Data Grid with Sort and Filter":
                    tableCssName = "PRO_localGridWithSortFilter";
                    break;
                case "Local Editable Data Grid":
                    tableCssName = "PRO_localEditableGrid";
                    break;
                case "Remote Data Grid":
                    tableCssName = "PRO_remoteGrid";
                    break;
                case "Groupable Aggregated Data Grid":
                    tableCssName = "PRO_groupableGrid";
                    break;
                default:
                    return false;
                    break;
            }
            Assert.AreEqual(true, WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id(tableCssName), 30));
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id(tableCssName), 30);
            var gridContainer = SeleniumController.Instance.Driver.FindElement(By.CssSelector("div#PRO_localGridWithSortFilter"));
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.CssSelector("div#PRO_localGridWithSortFilter tr[class*='ng-scope'])"), 30);
            SeleniumController.SleepWaitTime(2000);
            if ( SeleniumController.Instance.Driver.FindElements(By.CssSelector("div#PRO_localGridWithSortFilter tr[class*='ng-scope']")).Count()== rowsAllowed)
                return true;
            else
                return false;          
        }

        public static bool CheckLocalDataGridIsPresent()
        {
            return SeleniumController.Instance.Driver.FindElement(By.Id("PRO_localGridWithSortFilter")).Displayed;
        }
        /// <summary>
        /// This element recieved the number of rows allowed to appear in each table page and checks to see that 
        /// the number of pages for each table is accurate based on the total number of items in the table.
        /// Add by Sal
        /// </summary>
        /// <returns></returns>
        public static bool ValidateTablePageCount(int rowsAllowed)
        {      
            var items = SeleniumController.Instance.Driver.FindElement(By.CssSelector("span[class='k-pager-info k-label']"));
            string itemsCountText = items.Text;
            int numberOfItems = Convert.ToInt32(Convert.ToString(itemsCountText[9]) + Convert.ToString(itemsCountText[10]));
            var gridContainer = SeleniumController.Instance.Driver.FindElement(By.CssSelector("div#PRO_localGridWithSortFilter"));
            var endPageButton = gridContainer.FindElement(By.CssSelector("span[class='k-icon k-i-seek-e']"));
            endPageButton.Click();
            var lastPageNumber = gridContainer.FindElement(By.CssSelector("span[class='k-state-selected']"));
            int pageNumbersOnBrowser= Convert.ToInt32(lastPageNumber.Text);
            SeleniumController.SleepWaitTime(2000);
            int correctPageNumbers=0;
            //-----------------------------trying to decide the number of pages based on the number of items. 
            int i = numberOfItems % rowsAllowed;
            if (i == 0 )
            correctPageNumbers = numberOfItems / rowsAllowed;
            else if (i != 0)
            correctPageNumbers = (numberOfItems / rowsAllowed) + 1 ;
            //-----------------------------
            if (correctPageNumbers == pageNumbersOnBrowser)
                return true;
            else
                return false;
        }
        /// <summary>
        /// This element has the dropdown element, input element and button in a kendo grid filter
        /// </summary>
        /// <returns></returns>
        public static IWebElement GetMainAnimationContainer()
        {
            SeleniumController.Instance.Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.ClassName("k-animation-container"), 30);
            IWebElement con = SeleniumController.Instance.Driver.FindElement(By.ClassName("k-animation-container")); 
            return con;
        }
        /// <summary>
        /// This element has dropdown options for filter types in a kendo grid filter
        /// </summary>
        /// <returns></returns>
        public static IWebElement GetSecondAnimationContainer()
        {
            return SeleniumController.Instance.Driver.FindElements(By.ClassName("k-animation-container"))[1];
        }

        /// <summary>
        /// This function selects and clicks the filter 
        /// </summary>
        public static void SelectFilterTypeInDropdown(string filterText)
        {
            GridObject obj = GridDemoPage.GetGridObjectById("PRO_localGridWithSortFilter");
            var dropdown = obj.GetFilterObjectForColumn("LastName");
            var filter = SeleniumController.Instance.Driver.FindElements(By.CssSelector("span.k-select"));
            filter[5].Click();
            var inputFields = SeleniumController.Instance.Driver.FindElements(By.CssSelector("li.k-item"));
            foreach(var field in inputFields)
            {
               
                if (field.Text.Count() > 2)
                {
                    if (field.Text == filterText)
                    {
                        field.Click();
                        break;
                    }
                }
                else
                    continue;
                }
         
        }

        /// <summary>
        /// This function enter the filter text
        /// </summary>
        /// <param name="mainAnimationContainer"></param>
        /// <param name="filterValue"></param>
        public static void FilterValue(string filterValue)
        {
            SeleniumController.WaitTime("input.k-input");
            var filterValueField = SeleniumController.Instance.Driver.FindElements(By.CssSelector("input.k-input"));
            filterValueField[5].Click();
            filterValueField[5].Clear();
            filterValueField[5].SendKeys(filterValue);
        
        }

        private static IWebElement GetFilterTypeOptionFromDropdown(IWebElement secondAnimationContainer, string filterText)
        {
            return secondAnimationContainer.FindElement(By.XPath(String.Format("//div/ul//li[contains(.,'{0}')]", filterText)));
        }
        private static IWebElement GetFilterTypeDropdown()
        {
            return SeleniumController.Instance.Driver.FindElement(By.ClassName("k-dropdown"));
        }
    }

    public class GridObject
    {
        private string gridId;
        public string GridId{
            get{
                return gridId;
            }
            private set{
                gridId = value;
            }
        }
        private IWebElement gridElement = null;
        public IWebElement GridElement
        {
            get
            {
                if(gridElement == null)
                {
                    gridElement = SeleniumController.Instance.Driver.FindElement(By.Id(gridId));
                }
                return gridElement;
            }
        }
        public GridObject(string gridId)
        {
            GridId = gridId;
        }
        public IWebElement GetRowCountElement()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.CssSelector(".k-pager-info.k-label"), 30);
            return GridElement.FindElement(By.CssSelector(".k-pager-info.k-label"));
        }
        private IWebElement SelectFilterForColumn(string dataFieldName)
        {
            var columnHeaderElement = SelectColumnHeader(dataFieldName);
            return columnHeaderElement.FindElement(By.ClassName("k-icon")).FindElement(By.ClassName("k-filter"));  
        }
        public void ClickFilterForColumn(string dataFieldName)
        {
            SeleniumController.WaitTime("span.k-select");         
            var filter = SeleniumController.Instance.Driver.FindElements(By.CssSelector("span.k-select"));
            filter[5].Click();
            
        }

        public IWebElement GetFilterObjectForColumn(string dataFieldName)
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.XPath("/html/body/div[1]/div/section/div/section/section/div/div[1]/table/thead/tr[2]/th[6]/span/span/span[2]/span/span[2]"), 50);
            var filter = SeleniumController.Instance.Driver.FindElements(By.CssSelector("span.k-select"));
            
            //taking the 5th element to fetch the last name
            return filter[5];
        }
        public IWebElement SelectColumnHeader(string dataFieldName)
        {
            return GridElement.FindElement(By.CssSelector(String.Format("th[data-field={0}]", dataFieldName)));
        }
        public System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> GetDisplayedResultRows()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.CssSelector("tbody > tr"), 30);
            return GridElement.FindElements(By.CssSelector("tbody > tr"));
        }
    }
}
