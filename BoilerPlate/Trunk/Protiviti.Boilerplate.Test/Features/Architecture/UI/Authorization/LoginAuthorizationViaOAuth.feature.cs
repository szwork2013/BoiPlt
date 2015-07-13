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
namespace Protiviti.Boilerplate.Test.Features.Architecture.UI.Authorization
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class LoginFunctionalityAuthorizationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "LoginAuthorizationViaOAuth.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Login Functionality Authorization", "In order to login\r\nAs a registered user\r\nI want to enter my username and password" +
                    "", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Login Functionality Authorization")))
            {
                Protiviti.Boilerplate.Test.Features.Architecture.UI.Authorization.LoginFunctionalityAuthorizationFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Employees Menu Item Inaccessible without login")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Login Functionality Authorization")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Rohan_LoginAuthorization")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AjaySingh")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        public virtual void EmployeesMenuItemInaccessibleWithoutLogin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Employees Menu Item Inaccessible without login", new string[] {
                        "Rohan_LoginAuthorization",
                        "AjaySingh",
                        "Must"});
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
 testRunner.Given("I am not logged in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 testRunner.When("I view the top menu navigation bar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.Then("I should not see the \'Employees\' menu item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Presence of Employees Menu Item on Admin Login")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Login Functionality Authorization")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Rohan_LoginAuthorization")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AjaySingh")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        public virtual void PresenceOfEmployeesMenuItemOnAdminLogin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Presence of Employees Menu Item on Admin Login", new string[] {
                        "Rohan_LoginAuthorization",
                        "AjaySingh",
                        "Must"});
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
 testRunner.Given("I login as admin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
 testRunner.When("I view the top menu navigation bar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
 testRunner.Then("I should see the \'Employees\' menu item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
 testRunner.And("User logs out", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void PresenceOfEmployeesMenuItemOnMemberLogin(string username, string password, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Rohan_LoginAuthorization",
                    "AjaySingh",
                    "Must"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Presence of Employees Menu Item on Member Login", @__tags);
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
 testRunner.Given(string.Format("I login as a member with username \"{0}\" and password \"{1}\"", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
 testRunner.When("I view the top menu navigation bar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
 testRunner.Then("I should see the \'Employees\' menu item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
 testRunner.And("User logs out", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Presence of Employees Menu Item on Member Login")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Login Functionality Authorization")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Rohan_LoginAuthorization")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AjaySingh")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Test3@protiviti.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "Test3@protiviti.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Test@123")]
        public virtual void PresenceOfEmployeesMenuItemOnMemberLogin_Test3Protiviti_Com()
        {
            this.PresenceOfEmployeesMenuItemOnMemberLogin("Test3@protiviti.com", "Test@123", ((string[])(null)));
        }
        
        public virtual void EmployeesMenuItemInaccessibleToNon_AdminNon_MemberUsers(string username, string password, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Rohan_LoginAuthorization",
                    "AjaySingh",
                    "Must"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Employees Menu Item Inaccessible to Non-Admin Non-Member Users", @__tags);
#line 38
this.ScenarioSetup(scenarioInfo);
#line 39
 testRunner.Given(string.Format("I login as non-admin non-member user with username \"{0}\" and password \"{1}\"", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
 testRunner.When("I view the top menu navigation bar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
 testRunner.Then("I should not see the \'Employees\' menu item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
 testRunner.And("User logs out", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Employees Menu Item Inaccessible to Non-Admin Non-Member Users")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Login Functionality Authorization")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Rohan_LoginAuthorization")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AjaySingh")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Test4@protiviti.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "Test4@protiviti.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Test@123")]
        public virtual void EmployeesMenuItemInaccessibleToNon_AdminNon_MemberUsers_Test4Protiviti_Com()
        {
            this.EmployeesMenuItemInaccessibleToNon_AdminNon_MemberUsers("Test4@protiviti.com", "Test@123", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Presence of Manage Menu Item on Admin Login")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Login Functionality Authorization")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Rohan_LoginAuthorization")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AjaySingh")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        public virtual void PresenceOfManageMenuItemOnAdminLogin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Presence of Manage Menu Item on Admin Login", new string[] {
                        "Rohan_LoginAuthorization",
                        "AjaySingh",
                        "Must"});
#line 50
this.ScenarioSetup(scenarioInfo);
#line 51
 testRunner.Given("I login as admin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 52
 testRunner.When("I view the top menu navigation bar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 53
 testRunner.Then("I should see the \'Manage\' menu item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 54
 testRunner.And("I should see the \'All Users\' and \'Roles\' in the dropdown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And("User logs out", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Manage Menu Item Inaccessible without login")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Login Functionality Authorization")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Rohan_LoginAuthorization")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AjaySingh")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        public virtual void ManageMenuItemInaccessibleWithoutLogin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Manage Menu Item Inaccessible without login", new string[] {
                        "Rohan_LoginAuthorization",
                        "AjaySingh",
                        "Must"});
#line 60
this.ScenarioSetup(scenarioInfo);
#line 61
 testRunner.Given("I am not logged in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 62
 testRunner.When("I view the top menu navigation bar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
 testRunner.Then("I should not see the \'Manage\' menu item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void ManageMenuItemInaccessibleOnMemberLogin(string username, string password, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Rohan_LoginAuthorization",
                    "AjaySingh",
                    "Must"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Manage Menu Item Inaccessible on Member Login", @__tags);
#line 68
this.ScenarioSetup(scenarioInfo);
#line 69
 testRunner.Given(string.Format("I login as a member with username \"{0}\" and password \"{1}\"", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 70
 testRunner.When("I view the top menu navigation bar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 71
 testRunner.Then("I should not see the \'Manage\' menu item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 72
 testRunner.And("User logs out", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Manage Menu Item Inaccessible on Member Login")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Login Functionality Authorization")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Rohan_LoginAuthorization")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AjaySingh")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Test3@protiviti.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "Test3@protiviti.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Test@123")]
        public virtual void ManageMenuItemInaccessibleOnMemberLogin_Test3Protiviti_Com()
        {
            this.ManageMenuItemInaccessibleOnMemberLogin("Test3@protiviti.com", "Test@123", ((string[])(null)));
        }
        
        public virtual void ManageMenuItemInaccessibleToNon_AdminNon_MemberUsers(string username, string password, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Rohan_LoginAuthorization",
                    "AjaySingh",
                    "Must"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Manage Menu Item Inaccessible to Non-Admin Non-Member Users", @__tags);
#line 80
this.ScenarioSetup(scenarioInfo);
#line 81
 testRunner.Given(string.Format("I login as non-admin non-member user with username \"{0}\" and password \"{1}\"", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 82
 testRunner.When("I view the top menu navigation bar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 83
 testRunner.Then("I should not see the \'Manage\' menu item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 84
 testRunner.And("User logs out", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Manage Menu Item Inaccessible to Non-Admin Non-Member Users")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Login Functionality Authorization")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Rohan_LoginAuthorization")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AjaySingh")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Must")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Test4@protiviti.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "Test4@protiviti.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Test@123")]
        public virtual void ManageMenuItemInaccessibleToNon_AdminNon_MemberUsers_Test4Protiviti_Com()
        {
            this.ManageMenuItemInaccessibleToNon_AdminNon_MemberUsers("Test4@protiviti.com", "Test@123", ((string[])(null)));
        }
    }
}
#pragma warning restore
#endregion