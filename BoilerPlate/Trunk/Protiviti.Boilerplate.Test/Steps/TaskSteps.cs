using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Text;
using Protiviti.Boilerplate.Test.Support;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Linq.Expressions;

namespace Protiviti.Boilerplate.Test.Steps
{
  [Binding]
  public class TaskSteps
  {
    [Then(@"^(.*)--TASK$")]
    public void VerifyTask(string taskName)
    {
      var result = "Not found";

      // read JSON directly from a file
      using (StreamReader file = File.OpenText(@"Features\tasks.json"))
      using (JsonTextReader reader = new JsonTextReader(file))
      {
        JArray taskList = (JArray)JToken.ReadFrom(reader);
        foreach (var task in taskList.Children())
        {
          if (taskName.Trim().ToLower() == task["name"].Value<String>().Trim().ToLower())
            if(task["status"] != null)
              result = task["status"].Value<String>();
        }
      }

      if (result.ToLower() == "complete")
        return;
      else if (result.ToLower() == "in progress")
        throw new Exception("The '" + taskName + "' has started and is not complete.");
      else
        ScenarioContext.Current.Pending();

    }
    [Then(@"^(.*)--TASK$")]
    public void VerifyTaskWithTable(string taskName, Table tableArgs)
    {
      using (StreamReader file = File.OpenText(@"Features\tasks.json"))
      using (JsonTextReader reader = new JsonTextReader(file))
      {
        JArray taskList = (JArray)JToken.ReadFrom(reader);
        foreach (var tableRow in tableArgs.Rows)
        {
          var result = "Not found";

          // read JSON directly from a file
          foreach (var task in taskList.Children())
          {
            if (taskName.Trim().ToLower() == task["name"].Value<String>().Trim().ToLower())
            {
              var statusTableObject = task["table"];
              if (statusTableObject != null)
              {
                var statusTable = statusTableObject.Value<JArray>();
                foreach (var statusTableRow in statusTable)
                {
                  if (statusTableRow["arguments"].Value<JArray>().ToObject<string[]>().IsEqualTo(tableRow.Values.ToArray<string>()))
                  {
                    result = statusTableRow["status"].Value<String>();
                  }
                }
              }
            }
          }
          if (result.ToLower() == "in progress")
            throw new Exception("The '" + taskName + "' has started and is not complete.");
          else if(result.ToLower() != "complete")
            ScenarioContext.Current.Pending();
        }
      }

    }
  }
}
