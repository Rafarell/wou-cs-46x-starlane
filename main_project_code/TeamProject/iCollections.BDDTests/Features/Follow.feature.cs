﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.7.0.0
//      SpecFlow Generator Version:3.7.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace iCollections.BDDTests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.7.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Follow")]
    public partial class FollowFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "Follow.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Follow", @"**As a registered user I would like to be able to follow and unfollow other users.**

This feature ensures that registered users can follow other users they do not follow and can unfollow users that
they do follow. Users cannot follow themselves. Users cannot follow or unfollow users that do not exist. It also 
*defines* a set of seeded users for future software test engineers to use when performing other kinds of tests.

To generate living documentation, create a Documentation folder and then run one of these from the project dir: 
    `livingdoc test-assembly -t bin\Debug\net5.0\TestExecution.json -o Documentation bin\Debug\net5.0\Fuji.BDDNunitTests.dll`
    `livingdoc feature-folder -t bin\Debug\net5.0\TestExecution.json -o Documentation .`", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
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
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 12
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "UserName",
                        "Email",
                        "FirstName",
                        "LastName",
                        "Password"});
            table10.AddRow(new string[] {
                        "TaliaK",
                        "knott@example.com",
                        "Talia",
                        "Knott",
                        "Hello123#"});
            table10.AddRow(new string[] {
                        "ZaydenC",
                        "clark@example.com",
                        "Zayden",
                        "Clark",
                        "Hello123#"});
            table10.AddRow(new string[] {
                        "DavilaH",
                        "hareem@example.com",
                        "Hareem",
                        "Davila",
                        "Hello123#"});
            table10.AddRow(new string[] {
                        "KrzysztofP",
                        "krzysztof@example.com",
                        "Krzysztof",
                        "Ponce",
                        "Hello123#"});
#line 13
 testRunner.Given("the following users exist", ((string)(null)), table10, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "UserName",
                        "Email",
                        "FirstName",
                        "LastName",
                        "Password"});
            table11.AddRow(new string[] {
                        "AndreC",
                        "colea@example.com",
                        "Andre",
                        "Cole",
                        "0a9dfi3.a"});
            table11.AddRow(new string[] {
                        "JoannaV",
                        "valdezJ@example.com",
                        "Joanna",
                        "Valdez",
                        "d9u(*dsF4"});
#line 19
 testRunner.And("the following users do not exist", ((string)(null)), table11, "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Logged-in user can follow a user they do not follow.")]
        [NUnit.Framework.TestCaseAttribute("TaliaK", "ZaydenC", null)]
        [NUnit.Framework.TestCaseAttribute("ZaydenC", "DavilaH", null)]
        [NUnit.Framework.TestCaseAttribute("DavilaH", "TaliaK", null)]
        public virtual void Logged_InUserCanFollowAUserTheyDoNotFollow_(string userName1, string userName2, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("UserName1", userName1);
            argumentsOfScenario.Add("UserName2", userName2);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Logged-in user can follow a user they do not follow.", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 24
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 12
this.FeatureBackground();
#line hidden
#line 25
 testRunner.Given(string.Format("I am a user with username \'{0}\'", userName1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 26
  testRunner.And(string.Format("there is another user with username \'{0}\' who I do not follow", userName2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 27
 testRunner.When("I follow that user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 28
 testRunner.Then("I now follow that user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Logged-in user can unfollow a user they follow.")]
        [NUnit.Framework.TestCaseAttribute("TaliaK", "ZaydenC", null)]
        [NUnit.Framework.TestCaseAttribute("ZaydenC", "DavilaH", null)]
        [NUnit.Framework.TestCaseAttribute("DavilaH", "TaliaK", null)]
        public virtual void Logged_InUserCanUnfollowAUserTheyFollow_(string userName1, string userName2, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("UserName1", userName1);
            argumentsOfScenario.Add("UserName2", userName2);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Logged-in user can unfollow a user they follow.", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 36
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 12
this.FeatureBackground();
#line hidden
#line 37
 testRunner.Given(string.Format("I am a user with username \'{0}\'", userName1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 38
  testRunner.And(string.Format("there is another user with username \'{0}\' who I follow", userName2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 39
 testRunner.When("I unfollow that user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 40
 testRunner.Then("I no longer follow that user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Logged-in user cannot follow themself.")]
        [NUnit.Framework.TestCaseAttribute("TaliaK", null)]
        [NUnit.Framework.TestCaseAttribute("ZaydenC", null)]
        public virtual void Logged_InUserCannotFollowThemself_(string userName, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("UserName", userName);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Logged-in user cannot follow themself.", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 48
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 12
this.FeatureBackground();
#line hidden
#line 49
 testRunner.Given(string.Format("I am a user with username \'{0}\'", userName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 50
 testRunner.When("I follow myself", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 51
 testRunner.Then("that follow attempt fails", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 52
  testRunner.And("it returns a JSON message describing the failure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Logged-in user cannot follow a user that does not exist.")]
        [NUnit.Framework.TestCaseAttribute("TaliaK", "AndreC", null)]
        [NUnit.Framework.TestCaseAttribute("ZaydenC", "JoannaV", null)]
        public virtual void Logged_InUserCannotFollowAUserThatDoesNotExist_(string userName1, string userName2, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("UserName1", userName1);
            argumentsOfScenario.Add("UserName2", userName2);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Logged-in user cannot follow a user that does not exist.", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 59
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 12
this.FeatureBackground();
#line hidden
#line 60
 testRunner.Given(string.Format("I am a user with username \'{0}\'", userName1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 61
  testRunner.And(string.Format("there is not a user with ussername \'{0}\'", userName2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 62
 testRunner.When("I follow that user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 63
 testRunner.Then("that follow attempt fails", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 64
  testRunner.And("it returns a JSON message describing the failure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
