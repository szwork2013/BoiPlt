using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Firefox;

namespace Protiviti.Boilerplate.Test.Support
{
    public class TestSettings
    {
        public static TestSettings Instance = new TestSettings();

        public string CurrentSprint { get; set; }
        public string DefaultDocumentationReviewer { get; set; }
        public string DefaultDocumentationOwner { get; set; }
        public string ServerUrl { get; set; }
        public string TokenAccessRelativeUrl { get; set; }
        public string ClientUrl { get; set; }
        public string DocsUrl { get; set; }
        public int ValidReviewAgeInMonths { get; set; }
        public Dictionary<string, string> ErrorResolutionPriorities = new Dictionary<string, string>();

        public TestSettings()
        {
            this.ServerUrl = ConfigurationManager.AppSettings["ServerUrl"];
            this.TokenAccessRelativeUrl = ConfigurationManager.AppSettings["TokenAccessRelativeUrl"];
            this.ClientUrl = ConfigurationManager.AppSettings["ClientUrl"];
            this.DocsUrl = ConfigurationManager.AppSettings["DocsUrl"];
            this.CurrentSprint = ConfigurationManager.AppSettings["CurrentSprint"];
            this.ValidReviewAgeInMonths = Int32.Parse(ConfigurationManager.AppSettings["ValidReviewAgeInMonths"]);
            this.DefaultDocumentationReviewer = ConfigurationManager.AppSettings["DefaultDocumentationReviewer"];
            this.DefaultDocumentationOwner = ConfigurationManager.AppSettings["DefaultDocumentationOwner"];
            var errorResolutionPrioritiesString = ConfigurationManager.AppSettings["ErrorResolutionPriorities"];
            var errorResolutionPrioritiesSplit = errorResolutionPrioritiesString.Split(';');
            foreach (var typeAndPriorityString in errorResolutionPrioritiesSplit)
            {
                var typeAndPrioritySplit = typeAndPriorityString.Split('=');
                var errorType = typeAndPrioritySplit[0];
                var resolutionPriority = typeAndPrioritySplit[1];
                this.ErrorResolutionPriorities.Add(errorType, resolutionPriority);
            }
        }
    }
}
