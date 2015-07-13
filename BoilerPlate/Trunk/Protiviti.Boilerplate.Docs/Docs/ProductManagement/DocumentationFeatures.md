Documentation Features
========================

Overview
-----------------
Documentation features are used to spec out the documentation
that should be created or updated as part of a sprint.
They typically start with the key word "Review" and are named
after an action of reviewing some soft of information that
should be available to the person performing the operation.
Documentation features work in conjunction with the 
documentation web project that is part of the solution.
To understand more about actually creating documentation 
please click [here](../Architecture/Docs/Overview).

Step Types
-----------------
There are a small set of generic steps that can be used to
outline the structure and content that should be included
in the documentation.  They are:

* __When I view the "[URL]" markdown file__
    
  Navigates to a specific documentation page for the 
  URL specified. [URL] should be the URL to a documentation 
  page (markdown) that can be accessed via the documentation 
  project web site. 
  Usually you start with the README file and then follow links
  in the documentation file using the next step.

* __And I click the "[LINK TEXT]" link__

  Follows a link on the current page.
  [LINK TEXT] should be the display text of the link to click.

* __And I click the "[LINK TEXT]" link in the "[SECTION TITLE]" section__

  Follows a link on in the specified section 
  \(element between the h2 with matching text and the following h2\).
  [LINK TEXT] should be the display text of the link to click.

* __And the "[SECTION TITLE]" section should include a list item with the text "[LIST ITEM TEXT]"__

  Verifies that a list item exists in the specified section with matching text.
  If the list item contains a double quote you can specify two single quotes
  and they will match a double quote.  For example this step will match the
  above list item.

        And the "Step Types" section should include a list item with the text "And the ''[SECTION TITLE]'' section should include a list item with the text ''[LIST ITEM TEXT]''"

* __Then I should see the "[HEADING TEXT]" page__

  Validates there is an H1 on the page with the specified 
  heading text.  [HEADING TEXT] should the be text inside
  the h1 that is the heading of the page.

* __Then I should see a "[SECTION TITLE]" section__

  Validates that there is a section on the page title
  with the text specified.  This looks for an h2 with the 
  text in the [SECTION TITLE] parameter.

* __And the "[SECTION TITLE]" section should contain the following links__

        | LinkText                          | 
        | Installing the Prerequisites      | 
        | Getting Access to the Source Code | 
        | Running the Application           | 

  Validates that section with a title whose text matches 
  the [SECTION TITLE] paramter has links whose text
  matches all the links specified in the table parameter.

* __And the "[TITLE]" section should "[EXPLANATION]"__

  Gives an explanation of what information a section is 
  supposed to provide.  Validates that there is a paragraph
  directly after the section title.



Examples
-----------------
To see examples of documentation features go to: 

      Protiviti.Boilerplate.Test
        Features
          ProductManagement
            BacklogManagement
              DefineDocumentationFeatures.feature


<p class="updated">Updated on 9/24/2014 by Stewart Armbrecht</p>
<p class="reviewed">Reviewed on 9/24/2014 by Stewart Armbrecht</p>
