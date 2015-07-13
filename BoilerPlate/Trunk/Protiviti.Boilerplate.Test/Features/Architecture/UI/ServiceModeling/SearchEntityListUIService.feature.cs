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
namespace Protiviti.Boilerplate.Test.Features.Architecture.UI.ServiceModeling
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class SearchEntityListUIServiceFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SearchEntityListUIService.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SearchEntityListUIService", "In order to retrieve all entities of a type from client code\nAs a developer\nI wan" +
                    "t to work with an example", ProgrammingLanguage.CSharp, new string[] {
                        "Sprint1",
                        "AlokGupta",
                        "Must"});
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "SearchEntityListUIService")))
            {
                Protiviti.Boilerplate.Test.Features.Architecture.UI.ServiceModeling.SearchEntityListUIServiceFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Retrieve all programs from client code")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SearchEntityListUIService")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AlokGupta")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        public virtual void RetrieveAllProgramsFromClientCode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve all programs from client code", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("I am a developer when I want to retrieve all programs from client code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.When("I make a call to \"#/programs\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then("I should see a list of programs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Validate Result Table When Retrieve all programs from client code")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SearchEntityListUIService")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AlokGupta")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        public virtual void ValidateResultTableWhenRetrieveAllProgramsFromClientCode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Result Table When Retrieve all programs from client code", ((string[])(null)));
#line 12
this.ScenarioSetup(scenarioInfo);
#line 13
 testRunner.Given("I am a developer when I want to retrieve all programs from client code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
 testRunner.When("I make a call to \"#/programs\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
 testRunner.Then("I should see results in a table \"Programs-Results-Table\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Validate Name Column When Retrieve all programs from client code")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SearchEntityListUIService")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AlokGupta")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        public virtual void ValidateNameColumnWhenRetrieveAllProgramsFromClientCode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Name Column When Retrieve all programs from client code", ((string[])(null)));
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
 testRunner.Given("I am a developer when I want to retrieve all programs from client code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
 testRunner.When("I make a call to \"#/programs\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
 testRunner.Then("I should see name column \"Programs-Results-Header-Name\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Validate Code Column When Retrieve all programs from client code")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SearchEntityListUIService")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AlokGupta")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        public virtual void ValidateCodeColumnWhenRetrieveAllProgramsFromClientCode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Code Column When Retrieve all programs from client code", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
 testRunner.Given("I am a developer when I want to retrieve all programs from client code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
 testRunner.When("I make a call to \"#/programs\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
 testRunner.Then("I should see code column \"Programs-Results-Header-Code\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Validate Cost Column When Retrieve all programs from client code")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SearchEntityListUIService")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AlokGupta")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        public virtual void ValidateCostColumnWhenRetrieveAllProgramsFromClientCode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Cost Column When Retrieve all programs from client code", ((string[])(null)));
#line 27
this.ScenarioSetup(scenarioInfo);
#line 28
 testRunner.Given("I am a developer when I want to retrieve all programs from client code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 29
 testRunner.When("I make a call to \"#/programs\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
 testRunner.Then("I should see cost column \"Programs-Results-Header-Cost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Validate Duration Column When Retrieve all programs from client code")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SearchEntityListUIService")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AlokGupta")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        public virtual void ValidateDurationColumnWhenRetrieveAllProgramsFromClientCode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Duration Column When Retrieve all programs from client code", ((string[])(null)));
#line 32
this.ScenarioSetup(scenarioInfo);
#line 33
 testRunner.Given("I am a developer when I want to retrieve all programs from client code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 34
 testRunner.When("I make a call to \"#/programs\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
 testRunner.Then("I should see duration column \"Programs-Results-Header-Duration\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Validate Location Column When Retrieve all programs from client code")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SearchEntityListUIService")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AlokGupta")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        public virtual void ValidateLocationColumnWhenRetrieveAllProgramsFromClientCode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Location Column When Retrieve all programs from client code", ((string[])(null)));
#line 37
this.ScenarioSetup(scenarioInfo);
#line 38
 testRunner.Given("I am a developer when I want to retrieve all programs from client code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
 testRunner.When("I make a call to \"#/programs\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
 testRunner.Then("I should see location column \"Programs-Results-Header-Location\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion