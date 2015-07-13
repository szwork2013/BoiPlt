using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class TestDriverHelperFrameworkSteps
    {
        [Then(@"I should be able to call driver helper methods")]
        public void ThenIShouldBeAbleToCallDriverHelperMethods()
        {
            Type type = Type.GetType("Protiviti.Boilerplate.Test.Helper.DriverHelper", true);
            object newInstance = Activator.CreateInstance(type);
            Assert.IsTrue(newInstance != null, "Driver helper is not available");
        }

        [Then(@"I should be able to call ""(.*)""")]
        public void ThenIShouldBeAbleToCall(string p0)
        {
            Type type = Type.GetType("Protiviti.Boilerplate.Test.Helper.DriverHelper", true);
            var method = type.GetMember(p0);
            Assert.IsTrue(method != null);
        }
    }
}
