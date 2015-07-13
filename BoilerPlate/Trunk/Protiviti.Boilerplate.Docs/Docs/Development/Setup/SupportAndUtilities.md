Support and Utilities
========================

Waits
-------------------------------

*Implicit Wait:* During Implicit wait if the Web Driver cannot find it immediately because of its availability, the WebDriver will wait for mentioned time and it will not try to find the element again during the specified time period. Once the specified time is over, it will try to search the element once again the last time before throwing exception. The default setting is zero. Once we set a time, the Web Driver waits for the period of the WebDriver object instance.

*Explicit waits:* Intelligent waits that are confined to a particular web element. Using explicit waits you are basically telling  WebDriver to continue trying to find an element before a preset time limit for the search is reached. If the element is found, the WebDriver stops searching for the element and flag success on the search, if element is never present, the WebDriver keeps searching until the time limit is reached then it return a fail.


How to use it:
-------------------------------

For implicit wait, we already have this build in the Driver, so when using the standard selenium Findelement/Findelements functions, an implicit wait will be used with default wait time 0.5 second.


For explicit wait, as of now, you can explicit wait by calling the function "WaitUntilElementIsPresent" in the WebDriverExtensions class. The example below show triggering an explicit wait for the element Employee before selecting it.

Assert.AreEqual(true, WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.LinkText("Employees"), 30));

  var registrationLink = SeleniumController.Instance.Driver.FindElement(By.LinkText("Employees"));

In the example above, we are passing the Driver, the element we would like to explicitly wait for, and the amount of attempts to find the element before we stop looking.
<p class="updated">Updated on 9/30/2014 by Saleh Motan</p>
<p class="reviewed">Reviewed on 9/30/2014 by Saleh Motan</p>
