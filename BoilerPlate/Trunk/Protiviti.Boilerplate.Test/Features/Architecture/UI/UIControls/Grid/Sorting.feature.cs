﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34014
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
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Sorting")]
    public partial class SortingFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Sorting.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Sorting", "In order to allow the user to order results in a grid\nAs a user\nI want to sort gr" +
                    "id data by the columns that the user selects", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
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
        
        public virtual void FeatureBackground()
        {
#line 6
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "MyString",
                        "MyInt",
                        "MyDecimal",
                        "MyFloat",
                        "FirstName",
                        "LastName"});
            table1.AddRow(new string[] {
                        "abc",
                        "5",
                        "1.463",
                        "1.463",
                        "Jane",
                        "Doe"});
            table1.AddRow(new string[] {
                        "def",
                        "1",
                        "1.464",
                        "1.464",
                        "Julie",
                        "Doe"});
            table1.AddRow(new string[] {
                        "aaa",
                        "3",
                        "74.34",
                        "12.12",
                        "Stanley",
                        "Brady"});
            table1.AddRow(new string[] {
                        "baa",
                        "5",
                        "-12.0",
                        "345.2",
                        "Horace",
                        "Franklin"});
#line 7
 testRunner.Given("a database table having the following rows:", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Column",
                        "Type"});
            table2.AddRow(new string[] {
                        "MyString",
                        "string"});
            table2.AddRow(new string[] {
                        "MyInt",
                        "integer"});
            table2.AddRow(new string[] {
                        "MyDecimal",
                        "decimal"});
            table2.AddRow(new string[] {
                        "MyFloat",
                        "float"});
            table2.AddRow(new string[] {
                        "FullName",
                        "string"});
#line 14
 testRunner.And("a grid having the following columns and column types:", ((string)(null)), table2, "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Sorting a grid")]
        [NUnit.Framework.TestCaseAttribute("ascending", "MyString", "alphabetically", null)]
        [NUnit.Framework.TestCaseAttribute("descending", "MyString", "reverse-alphabetically", null)]
        [NUnit.Framework.TestCaseAttribute("ascending", "MyInteger", "in numerical order", null)]
        [NUnit.Framework.TestCaseAttribute("descending", "MyInteger", "in reverse-numerical order", null)]
        [NUnit.Framework.TestCaseAttribute("ascending", "MyDecimal", "in numerical order", null)]
        [NUnit.Framework.TestCaseAttribute("descending", "MyDecimal", "in reverse-numerical order", null)]
        [NUnit.Framework.TestCaseAttribute("ascending", "MyFloat", "in numerical order", null)]
        [NUnit.Framework.TestCaseAttribute("descending", "MyFloat", "in reverse-numerical order", null)]
        [NUnit.Framework.TestCaseAttribute("ascending", "FullName", "alphabetically", null)]
        [NUnit.Framework.TestCaseAttribute("descending", "FullName", "reverse-alphabetically", null)]
        public virtual void SortingAGrid(string sortDirection, string dataType, string sortMethod, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sorting a grid", exampleTags);
#line 22
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 23
 testRunner.Given("I am viewing a grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
 testRunner.When(string.Format("I click sort {0} on column <column name>", sortDirection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
 testRunner.Then(string.Format("the grid results should be sorted {0}", sortMethod), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Sorting a grid by multiple columns")]
        public virtual void SortingAGridByMultipleColumns()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sorting a grid by multiple columns", ((string[])(null)));
#line 39
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 40
 testRunner.Given("I am viewing a grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
 testRunner.When("I sort by MyString, then by MyInteger, then by MyDecimal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
 testRunner.Then("the grid should sort by all of those columns, in the order in which the sorts wer" +
                    "e applied", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion