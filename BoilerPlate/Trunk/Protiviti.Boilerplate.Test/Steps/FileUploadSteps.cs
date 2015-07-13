using System;
using TechTalk.SpecFlow;
using Protiviti.Boilerplate.Test.Support;
using Protiviti.Boilerplate.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class FileUploadSteps
    {        
        [Given(@"I am on Grid Demo Page")]
        public void GivenIAmOnGridDemoPage()
        {
           GridDemoPage.GoTo();
        }

        [Given(@"I see a data grid with the ""(.*)"" column names")]
        public void GivenISeeADataGridWithTheColumnNames(string columnName)
        {
            string name;
            GridDemoPage.GoTo();
            //SeleniumController.SleepWaitTime(2000);
            switch (columnName)
            {
                case "File Name": 
                    name = GridDemoPage.FindGridElement(".//*[@id='PRO_fileUploadGrid']/div[1]/div/table/thead/tr/th[1]");
                    Assert.AreEqual(columnName, name);
                    break;

                case "File Size": 
                    name = GridDemoPage.FindGridElement(".//*[@id='PRO_fileUploadGrid']/div[1]/div/table/thead/tr/th[2]");
                    Assert.AreEqual(columnName, name);
                    break;

                case "File Type": 
                    name = GridDemoPage.FindGridElement(".//*[@id='PRO_fileUploadGrid']/div[1]/div/table/thead/tr/th[3]");
                    Assert.AreEqual(columnName, name);
                    break;

                case "Upload Date Time": 
                    name = GridDemoPage.FindGridElement(".//*[@id='PRO_fileUploadGrid']/div[1]/div/table/thead/tr/th[4]");
                    Assert.AreEqual(columnName, name);
                    break;   
            }
        }


        [Given(@"I have selected one file")]
        public void GivenIHaveSelectedOneFile()
        {
            GridDemoPage.GoTo();
            SeleniumController.Instance.Driver.Navigate().Refresh();
            SeleniumController.SleepWaitTime(2000);
            GridDemoPage.SelectButton();
        }
       
        [Given(@"I view Kendo File Upload section")]
        public void GivenIViewKendoFileUploadSection()
        {
            
            SeleniumController.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(1));
        }


        [When(@"I view Kendo File Upload section")]
        public void WhenIViewKendoFileUploadSection()
        {
            GridDemoPage.CheckURL();
            Thread.Sleep(3000);
        }

        [When(@"I select a file")]
        public void WhenISelectAFile()
        {
            GridDemoPage.SelectButton();
        }

        [When(@"I click on Upload button")]
        public void WhenIClickOnUploadButton()
        {
            GridDemoPage.ClickUploadButton();            
        }

        [When(@"I click on Remove icon")]
        public void WhenIClickOnRemoveIcon()
        {
            GridDemoPage.ClickRemoveIcon();
        }

               
        [Then(@"I should see an empty Grid")]
        public void ThenIShouldSeeAnEmptyGrid()
        {
            GridDemoPage.FileUploadGridPresent();   
        }

        [Then(@"Grid has following column names:")]
        public void ThenGridHasFollowingColumnNames(Table table)
        {
            GridDemoPage.FileUploadGridColumns();            
        }

        [Then(@"I should see a Select File button")]
        public void ThenIShouldSeeASelectFileButton()
        {
            GridDemoPage.SelectFileButtonPresent();          

       }

        [Then(@"I should see the Upload button")]
        public void ThenIShouldSeeTheUploadButton()
        {
           Assert.IsTrue(GridDemoPage.UploadButtonPresent(),"Upload button not present !");            
                     
        }

        [Then(@"I should see a remove icon for removing the selected file")]
        public void ThenIShouldSeeARemoveIconForRemovingTheSelectedFile()
        {
            GridDemoPage.RemoveIconPresent();            
        }

        [Then(@"I should see the selected file in the textfield below")]
        public void ThenIShouldSeeTheSelectedFileInTheTextfieldBelow()
        {
            GridDemoPage.SelectedFilePresent();
        }

        [Then(@"I should see a progress bar")]
        public void ThenIShouldSeeAProgressBar()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Selected file should be removed")]
        public void ThenSelectedFileShouldBeRemoved()
        {
            Assert.IsFalse(GridDemoPage.SelectedFileRemoved(), "File not removed !");
        }

        [Then(@"File should not be uploaded")]
        public void ThenFileShouldNotBeUploaded()
        {
            Assert.IsFalse(GridDemoPage.SelectedFileRemoved(), "File uploaded even after removal !");
        }

        [When(@"I select ""(.*)"" from file dialog window")]
        public void WhenISelectFromFileDialogWindow(string file)
        {
            Assert.IsTrue(GridDemoPage.FileSelected(file)," Appropriate File Not selected ! ");
        }

        [When(@"I select a file ""(.*)""")]
        public void WhenISelectAFile(string fileName)
        {
            GridDemoPage.SelectFile(fileName);
        }


        [Then(@"Grid should display File Name")]
        public void ThenGridShouldDisplayFileName()
        {
            Assert.IsTrue(GridDemoPage.GridFileName(), " Grid not displaying File Name");
        }

        [Then(@"Grid should display File Size")]
        public void ThenGridShouldDisplayFileSize()
        {
            Assert.IsTrue(GridDemoPage.GridFileSize(), " Grid not displaying File Size");
        }

        [Then(@"Grid should display File Type")]
        public void ThenGridShouldDisplayFileType()
        {
            Assert.IsTrue(GridDemoPage.GridFileType(), " Grid not displaying File Type");
        }

        [Then(@"Grid should display Upload Date Time")]
        public void ThenGridShouldDisplayUploadDateTime()
        {
            Assert.IsTrue(GridDemoPage.GridUploadDateTime(), " Grid not displaying File Upload Date Time");
        }



    }
}

