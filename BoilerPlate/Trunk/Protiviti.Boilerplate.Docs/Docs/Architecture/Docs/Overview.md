Documentation Architecture
========================

Overview
----------------
This system uses markdown for creating all documenation.  Markdown
is a simplified text based syntax for structuing a document.  It is
used by major components in the development community such as Stack Overflow
and GitHub.  It provides an easy way to create rich text documents that 
can be rendered on the web on multiple devices.

### Docs Project
This solution includes a Docs project \(Protiviti.Boilerplate.Docs\) that hosts all the markdown files.
The project is an asp.net MVC web project that includes a single controller
that will return an html representation of a markdown file. The controller 
uses a third party component to render the markdown file
as HTML:  MarkdownDeep (see link below).

To learn more about markdown and it's syntax see the links below.

If you are viewing this file off the file system and would like to view 
the documentation in a browser using the docs project simply navigate to 
[http://localhost/Protiviti.Boilerplate.Docs/](http://localhost/Protiviti.Boilerplate.Docs/) 

### Test Project
Documentation is considered a development activity just like any other.
As such prior to creating any documentation, the team should define a
feature and scenario\(s\) that outlines the structure of the documentation 
that should be created or updated.  These tests will actually inspect 
the documentation solution and fail if the criteria is not met.
See the links below to understand our __Test Architecture__, how it supports
documentation through __Documentation Features__, and how it all comes 
together in our process for __Feature and Scenario Completion__.

### Benefits of this Approach
By using the markdown, a web project and our testing infrastructure to drive
documentation we can have the following benefits:

* **Easy Delegation** We can delegate the activities of creating the documentation by 
  providing guidance through the documentation features and scenarios.
* **Automated Link Validation** We can use tests to browse all links in the 
  documentation and verify that none result in a dead end \(404\).
* **Automated Review** We can use special tags \(paragraph tags 
  with special classes\) to mark a page as needing a review from someone.
* **Automated Refresh** We can use special tests to scan all pages in the 
  documentation and fail if the review date on any page is older than a
  specified time.
* **Automated Project Start Tasks** We can use special tests that specify
  initial setup activities that should be performed on a new project that only
  fail when the project is no longer titled as the Boilerplate.  For instance
  when we start a new project off the boilerplate we can cause a test to fail
  if the string 'Protiviti' shows up anywhere in the documentation.
  

Creating Documentation
------------------------
In order to create documenation in this solution you will need to understand
markdown and have access to the Protiviti.Boilerplate.Docs project source code
with the ability to check-in and check-out filesas well as a markdown editor.

There are a multitude of markdown editors out there.  
[Here are 75](http://mashable.com/2013/06/24/markdown-tools/)

For this team the prefered way to edit Markdown is to use Visual Studio
with the Web Extensions installed.

### Prerequisites
* First setup a local environment following the steps in the 
[Getting Started](../../) section.
* Install Visual Studio Web Essentials
    * Go to Tools -> Extensions and Updateds
    * Click Online in the left hand side.
    * Search for Web Essentials
    * Click install.

### Defining Documentation
All activites performed as part of a project related to enhancing this
solution should be captured as a feature and scenario in the test project.
This includes documentation. _Prior to creating documentation_ you should
define a documentation feature and scenario that oulines the structure 
of the documentation you will create.  This will also run automated tests
to validate that what is created matches the specification.

To understand how our solution uses a behavior driven development process
with SpecFlow, Gherkin, Features and Scenarios review [this documenation](../Test/Overview)
on our test architecture and [this documentation](../../ProductManagement/DocumentationFeatures) 
on how to write features and scenarios that outline documentation 
that should be created.

### Creating Documenation
Creating documentation is no different than creating functionality
in the solution. As such it should follow the proper development process
for completing a feature or scenario.  Review the documentation 
[here](../../Development/FeatureOrScenarioCompletion/Overview) to 
understand how that should occur.  

Below is a high level overview of the steps that could vary from the actual
feature or scenario completion process.  In the case that it does use the 
feature or scenario completion process.

* **Run Failing Test** Run your documentation feature or scenario that outlines the documentation 
  you should create. The scenario should fail.
* **Update Documenation** Add or update the markdown files to pass the test
  in the Protiviti.Boilerplate.Docs/Docs folders in the solution.
* **Validate Your Changes** Check your edits by opening a browser and navigate to "http://localhost/Protiviti.Boilerplate.Docs/"
* **Verify Test Passes** Run the documenation feature or scenario to verify that it passes.
* **Other Activities** Perform all other activities as outlined by the feature and 
  scenario completion process.
* **Check-In** Check-in your changes
* **Other Activities** Continue to follow activities as outlined by the feature and 
  scenario completion process.

Resources
-----------------------------
* [Markdown](http://daringfireball.net/projects/markdown/)
* [Markdown Syntax](http://daringfireball.net/projects/markdown/syntax)
* [Markdown Deep Project](http://www.toptensoftware.com/markdowndeep/)
* [Test Architecture](../Test/Overview)
* [Documentation Features](../../ProductManagement/DocumentationFeatures)
* [Feature or Scenario Completion](../../Development/FeatureOrScenarioCompletion/Overview)

<p class="updated">Updated on 9/24/2014 by Stewart Armbrecht</p>
<p class="reviewed">Reviewed on 9/24/2014 by Stewart Armbrecht</p>
