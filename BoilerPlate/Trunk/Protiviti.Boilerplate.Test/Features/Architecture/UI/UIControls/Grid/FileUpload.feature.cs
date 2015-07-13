﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18444
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Protiviti.Boilerplate.Test.Features.Architecture.UI.UIControls.Grid
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class FileUploadFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "FileUpload.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "FileUpload", "In order to upload a file \nAs a user\nI want to select a file from my local machin" +
                    "e", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "FileUpload")))
            {
                Protiviti.Boilerplate.Test.Features.Architecture.UI.UIControls.Grid.FileUploadFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Presence of File Upload Grid")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "FileUpload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Rohan_FileUpload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Shruti")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Current")]
        public virtual void PresenceOfFileUploadGrid()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Presence of File Upload Grid", new string[] {
                        "Rohan_FileUpload",
                        "Shruti",
                        "Must",
                        "Current"});
#line 10
this.ScenarioSetup(scenarioInfo);
#line 11
 testRunner.Given("I am on Grid Demo Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 12
 testRunner.When("I view Kendo File Upload section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.Then("I should see an empty Grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "File Name",
                        "File Size",
                        "File Type",
                        "Upload Date Time"});
#line 14
 testRunner.And("Grid has following column names:", ((string)(null)), table1, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Presence of Select Files button")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "FileUpload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Rohan_FileUpload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Shruti")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Current")]
        public virtual void PresenceOfSelectFilesButton()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Presence of Select Files button", new string[] {
                        "Rohan_FileUpload",
                        "Shruti",
                        "Must",
                        "Current"});
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
 testRunner.Given("I am on Grid Demo Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
 testRunner.When("I view Kendo File Upload section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
 testRunner.Then("I should see a Select File button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Upload button is displayed on file selection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "FileUpload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Rohan_FileUpload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Shruti")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Current")]
        public virtual void UploadButtonIsDisplayedOnFileSelection()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Upload button is displayed on file selection", new string[] {
                        "Rohan_FileUpload",
                        "Shruti",
                        "Must",
                        "Current"});
#line 30
this.ScenarioSetup(scenarioInfo);
#line 31
 testRunner.Given("I am on Grid Demo Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 32
 testRunner.When("I select a file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
 testRunner.Then("I should see the Upload button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Remove icon is displayed on file selection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "FileUpload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Rohan_FileUpload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Shruti")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Current")]
        public virtual void RemoveIconIsDisplayedOnFileSelection()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Remove icon is displayed on file selection", new string[] {
                        "Rohan_FileUpload",
                        "Shruti",
                        "Must",
                        "Current"});
#line 39
this.ScenarioSetup(scenarioInfo);
#line 40
 testRunner.Given("I am on Grid Demo Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
 testRunner.When("I select a file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
 testRunner.Then("I should see a remove icon for removing the selected file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void SelectingAFileFromLocalMachine(string columnName, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Rohan_FileUpload",
                    "Shruti",
                    "Must",
                    "Current"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Selecting a file from local machine", @__tags);
#line 48
this.ScenarioSetup(scenarioInfo);
#line 49
 testRunner.Given(string.Format("I see a data grid with the \"{0}\" column names", columnName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 50
 testRunner.When("I select a file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
 testRunner.Then("I should see the selected file in the textfield below", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Selecting a file from local machine")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "FileUpload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Rohan_FileUpload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Shruti")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Current")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "File Name")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Column Name", "File Name")]
        public virtual void SelectingAFileFromLocalMachine_FileName()
        {
            this.SelectingAFileFromLocalMachine("File Name", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Selecting a file from local machine")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "FileUpload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Rohan_FileUpload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Shruti")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Current")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "File Size")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Column Name", "File Size")]
        public virtual void SelectingAFileFromLocalMachine_FileSize()
        {
            this.SelectingAFileFromLocalMachine("File Size", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Selecting a file from local machine")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "FileUpload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Rohan_FileUpload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Shruti")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Current")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "File Type")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Column Name", "File Type")]
        public virtual void SelectingAFileFromLocalMachine_FileType()
        {
            this.SelectingAFileFromLocalMachine("File Type", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Selecting a file from local machine")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "FileUpload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Rohan_FileUpload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Shruti")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Current")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Upload Date Time")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Column Name", "Upload Date Time")]
        public virtual void SelectingAFileFromLocalMachine_UploadDateTime()
        {
            this.SelectingAFileFromLocalMachine("Upload Date Time", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Removing the selected item")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "FileUpload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Rohan_FileUpload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Shruti")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Current")]
        public virtual void RemovingTheSelectedItem()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Removing the selected item", new string[] {
                        "Rohan_FileUpload",
                        "Shruti",
                        "Must",
                        "Current"});
#line 63
this.ScenarioSetup(scenarioInfo);
#line 64
 testRunner.Given("I have selected one file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 65
 testRunner.When("I click on Remove icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 66
 testRunner.Then("Selected file should be removed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("File Upload after removing the selected file")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "FileUpload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Rohan_FileUpload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Shruti")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Current")]
        public virtual void FileUploadAfterRemovingTheSelectedFile()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("File Upload after removing the selected file", new string[] {
                        "Rohan_FileUpload",
                        "Shruti",
                        "Must",
                        "Current"});
#line 72
this.ScenarioSetup(scenarioInfo);
#line 73
 testRunner.Given("I have selected one file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 74
 testRunner.When("I click on Remove icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 75
 testRunner.And("I click on Upload button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.Then("File should not be uploaded", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void RelevantFileDetailsInFileUploadGrid(string fileName, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Rohan_FileUpload",
                    "Shruti",
                    "Must",
                    "Current"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Relevant file details in file upload grid", @__tags);
#line 82
this.ScenarioSetup(scenarioInfo);
#line 83
 testRunner.Given("I am on Grid Demo Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 84
 testRunner.When(string.Format("I select a file \"{0}\"", fileName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 85
 testRunner.And("I click on Upload button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.Then("Grid should display File Name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 87
 testRunner.And("Grid should display File Size", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
 testRunner.And("Grid should display File Type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.And("Grid should display Upload Date Time", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Relevant file details in file upload grid")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "FileUpload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Rohan_FileUpload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Shruti")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Current")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Lighthouse")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:File Name", "Lighthouse")]
        public virtual void RelevantFileDetailsInFileUploadGrid_Lighthouse()
        {
            this.RelevantFileDetailsInFileUploadGrid("Lighthouse", ((string[])(null)));
        }
    }
}
#pragma warning restore
#endregion