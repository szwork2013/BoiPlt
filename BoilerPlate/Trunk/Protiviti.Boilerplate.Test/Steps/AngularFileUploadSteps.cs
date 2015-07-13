using System;
using TechTalk.SpecFlow;
using Protiviti.Boilerplate.Test.Support;
using Protiviti.Boilerplate.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System.Collections;

namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class AngularFileUploadSteps
    {
        [Given(@"I am on File Upload page")]
        public void GivenIAmOnFileUploadPage()
        {
            AngularFileUploadPage.GoTo();   
        }

        [Given(@"I see Uploaded Files Grid")]
        public void GivenISeeUploadedFilesGrid()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I upload the file ""(.*)"" with title ""(.*)""")]
        public void GivenIUploadTheFileWithTitle(string file, string title)
        {
            if (file.Contains("Desert"))
                AngularFileUploadPage.UploadSelectedFile("C:\\Users\\Public\\Pictures\\Sample Pictures\\Desert.jpg",title);
            else if (file.Contains("Lighthouse"))
                AngularFileUploadPage.UploadSelectedFile("C:\\Users\\Public\\Pictures\\Sample Pictures\\Lighthouse.jpg", title);
            else if (file.Contains("Jellyfish"))
                AngularFileUploadPage.UploadSelectedFile("C:\\Users\\Public\\Pictures\\Sample Pictures\\Jellyfish.jpg", title);     
                        
        }



        [When(@"I navigate to File Upload page")]
        public void WhenINavigateToFileUploadPage()
        {
            AngularFileUploadPage.NavigateTo();
        }

        [When(@"I enter ""(.*)"" in FileTitle text-field")]
        public void WhenIEnterInFileTitleText_Field(string name)
        {
            AngularFileUploadPage.FileTitle(name);
        }

        [When(@"I click on '(.*)' button")]
        public void WhenIClickOnButton(string button)
        {
            AngularFileUploadPage.ClickSubmitButton(button);
        }

        [When(@"I don't select any file")]
        public void WhenIDonTSelectAnyFile()
        {
            SeleniumController.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(1));
        }

        [When(@"I select file ""(.*)""")]
        public void WhenISelectFile(string fileName)
        {
            AngularFileUploadPage.FileName(fileName);   
        }

        [When(@"I view the Uploaded Files Grid")]
        public void WhenIViewTheUploadedFilesGrid()
        {
            AngularFileUploadPage.ViewFileUploadGrid();
        }

        [When(@"I click sort ""(.*)"" on column ""(.*)""")]
        public void WhenIClickSortOnColumn(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I delete the file ""(.*)"" with title ""(.*)""")]
        public void WhenIDeleteTheFileWithTitle(string file, string title)
        {
            AngularFileUploadPage.DeleteSelectedFile(file, title);
        }

        [Then(@"The file ""(.*)"" with title ""(.*)"" should be deleted from the Uploaded Files Grid")]
        public void ThenTheFileWithTitleShouldBeDeletedFromTheUploadedFilesGrid(string file, string title)
        {
            AngularFileUploadPage.CheckifFileDeleted(file, title);            
        }
        
        [Then(@"The progress bar shows '(.*)' percentage")]
        public void ThenTheProgressBarShowsPercentage(int percentage)
        {
            ScenarioContext.Current.Pending();
           //Assert.IsTrue(AngularFileUploadPage.CompleteUploadPercentage(percentage)," Progress bar not showing appropriate percentage");
        }
        
        [Then(@"I should see a FileTitle text-field")]
        public void ThenIShouldSeeAFileNameText_Field()
        {
            Assert.IsTrue(AngularFileUploadPage.FileTitleFieldPresent(), "File Title field not present");
        }

        [Then(@"I should see a '(.*)' label")]
        public void ThenIShouldSeeALabel(string label)
        {
            if (label == "File Title")
                Assert.IsTrue(AngularFileUploadPage.FileTitleLabelPresent(label), "File Title label not present !");
            else if(label == "File Name")
                Assert.IsTrue(AngularFileUploadPage.FileNameLabelPresent(label), "File Name label not present !");            
        }

        [Then(@"I should see '(.*)' button")]
        public void ThenIShouldSeeButton(string button)
        {
            AngularFileUploadPage.SubmitButtonPresent(button);
        }

        [Then(@"Submit button should be disabled")]
        public void ThenSubmitButtonShouldBeDisabled()
        {
           Assert.IsTrue(AngularFileUploadPage.SubmitButtonDisabled(), "Submit button not disabled !");
        }

        [Then(@"Submit button should be enabled")]
        public void ThenSubmitButtonShouldBeEnabled()
        {
            Assert.IsFalse(AngularFileUploadPage.SubmitButtonDisabled(), "Submit button still disabled !");
        }

        [Then(@"I should see the progress bar")]
        public void ThenIShouldSeeTheProgressBar()
        {
            ScenarioContext.Current.Pending();
            //Assert.IsTrue(AngularFileUploadPage.ProgressBarpresent(), "Progress Bar not present !");
        }

        [Then(@"The progress bar should display upload percentage '(.*)'")]
        public void ThenTheProgressBarShouldDisplayUploadPercentage(string percent)
        {
            ScenarioContext.Current.Pending();
            //AngularFileUploadPage.ProgressBarPercentage(percent);
        }

        [Then(@"I should see a message '(.*)'")]
        public void ThenIShouldSeeAMessage(string message)
        {
            ScenarioContext.Current.Pending();
            //AngularFileUploadPage.UploadSuccessfulMessage(message);
        }

        [Then(@"I should see a '(.*)' Grid having following column names :")]
        public void ThenISeeAGridHavingFollowingColumnNames(string header, Table table)
        {
            var columns = table.Header;
             Assert.IsTrue(AngularFileUploadPage.UploadedFilesGrid(header), "Table header inappropriate");
            AngularFileUploadPage.UploadedFilesGridColumns(columns);
            
        }        

        [Then(@"I should see a button for ""(.*)""")]
        public void ThenIShouldSeeAButtonFor(string button)
        {
            AngularFileUploadPage.PaginationofGrid(button);            
        } 

        [Then(@"The grid results should be sorted ""(.*)""")]
        public void ThenTheGridResultsShouldBeSorted(string p0)
        {
            ScenarioContext.Current.Pending();
        }       

        
        [Then(@"I should see a Search field")]
        public void ThenIShouldSeeASearchField()
        {
            Assert.IsTrue(AngularFileUploadPage.SearchBoxPresent(), "Search Box not present !");
        }

        [Then(@"I should see a placeholder '(.*)' on Search field")]
        public void ThenIShouldSeeAPlaceholderOnSearchField(string placeholder)
        {
            AngularFileUploadPage.PlaceholderSearchBox(placeholder);            
        }

        [Then(@"I should see the remove icon for each uploaded file in the grid")]
        public void ThenIShouldSeeTheRemoveIconForEachUploadedFileInTheGrid()
        {
            Assert.IsTrue(AngularFileUploadPage.RemoveIconPresent(), "Remove icons for each uploaded file not present");
        }

       
        #region db

        [Then(@"The values should get added in the database")]
        public void ThenTheValuesShouldGetAddedInTheDatabase()
        {
            AngularFileUploadPage.VerifyValuesWithDB();
        }

        #endregion
    }
}
