Feature: Validate Documentation
	In order to ensure that all documentation is up to date and relevant
	As a team member
	I want the testing infrastructure to automaically identify documentation problems

@StewartArmbrecht @Sprint0
Scenario: Validate All Documentation Pages
	Given I am a team member
	When I run the tests
    Then all links in the documentation should be to valid pages

@StewartArmbrecht @Sprint0
Scenario: Validate Documentation Page Missing Page
  Given I am a team member
  And I have a documentation page "that is missing" at "/Sample/MissingPage"
  When I validate the page
  Then the validators error messages should read
  """
  The root page of '{rootUrl}/Sample/MissingPage' can not be found.
  """
@StewartArmbrecht @Sprint0
Scenario: Validate Documentation Page Link Returns 404 Status Code
  Given I am a team member
  And I have a documentation page "with a link that gets a 404 status" at "/Sample/SiteValidator/My404LinkPage"
  And the page has "John Reviewer" tagged as the owner
  And the test settings have "Sprint9" set as the current sprint
  And the test settings have a "Could" priority for resolving "LinkRequestNonSuccessStatusCode" errors
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/My404LinkPage'
      LinkRequestNonSuccessStatusCode - The 'My 404 Link' link with an href of '/ThisPageDoesNotExist' returned a NotFound status

  """
  And the validators resolution scenarios should read
  """
  The following are recommended resolution scenarios:
    @Sprint9 @JohnReviewer @Could
    Scenario: Valid response from the 'My 404 Link' link on the page at '{rootUrl}/Sample/SiteValidator/My404LinkPage'
      Given I am a team member
      When I navigate to the "{rootUrl}/Sample/SiteValidator/My404LinkPage" page
      And I click the "My 404 Link" link
      Then I should get a valid response

  """
@StewartArmbrecht @Sprint0
Scenario: Validate Documentation Page Link Throws Exception
  Given I am a team member
  And I have a documentation page "with a link that causes an exception" at "/Sample/SiteValidator/MyExceptionLinkPage"
  And the page has "Sally Reviewer" tagged as the owner
  And the test settings have "Sprint12" set as the current sprint
  And the test settings have a "Must" priority for resolving "LinkRequestException" errors
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyExceptionLinkPage'
      LinkRequestException - The 'My Exception Link' link with an href of 'htDp://ww.noworky' caused an exception with a message of 'Only 'http' and 'https' schemes are allowed.
  Parameter name: requestUri'

  """
  And the validators resolution scenarios should read
  """
  The following are recommended resolution scenarios:
    @Sprint12 @SallyReviewer @Must
    Scenario: Valid response from the 'My Exception Link' link on the page at '{rootUrl}/Sample/SiteValidator/MyExceptionLinkPage'
      Given I am a team member
      When I navigate to the "{rootUrl}/Sample/SiteValidator/MyExceptionLinkPage" page
      And I click the "My Exception Link" link
      Then I should get a valid response

  """

@StewartArmbrecht @Sprint0
Scenario: Validate Documentation Page Missing Title
  Given I am a team member
  And I have a documentation page "with a missing title" at "/Sample/SiteValidator/MyMissingTitlePage"
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyMissingTitlePage'
      DocMissingTitle - The page does not have an h1 at the top to serve as a title.

  """
@StewartArmbrecht @Sprint0
Scenario: Validate Documentation Page Mulitple Titles
  Given I am a team member
  And I have a documentation page "with multiple titles" at "/Sample/SiteValidator/MyMultipleTitlePage"
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyMultipleTitlePage'
      DocMultipleTitles - The page has multiple 'h1' tags.  Please remove all but one and place it at the top of the page.

  """

@StewartArmbrecht @Sprint0
Scenario: Validate Documentation Page Empty Owner Tag
  Given I am a team member
  And I have a documentation page "with an empty owner tag" at "/Sample/SiteValidator/MyEmptyOwnerPage"
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyEmptyOwnerPage'
      DocImproperOwnerTag - Could not find a value in the owner tag.  The inner text format should match 'Page Owner: [NAME]'.

  """
@StewartArmbrecht @Sprint0
Scenario: Validate Documentation Page Multiple Owner Tag
  Given I am a team member
  And I have a documentation page "with multiple owner tags" at "/Sample/SiteValidator/MyMultipleOwnerPage"
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyMultipleOwnerPage'
      DocMultipleOwnerTags - There are multiple owner tags.  Please remove all but one.

  """
@StewartArmbrecht @Sprint0
Scenario: Validate Documentation Page Mislabeled Owner Tag
  Given I am a team member
  And I have a documentation page "with a mislabeled owner tag" at "/Sample/SiteValidator/MyMislabeledOwnerPage"
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyMislabeledOwnerPage'
      DocImproperOwnerTag - Could not find a value in the owner tag.  The inner text format should match 'Page Owner: [NAME]'.

  """
@StewartArmbrecht @Sprint0
Scenario: Validate Documentation Page Empty Reviewer Tag
  Given I am a team member
  And I have a documentation page "with an empty reviewer tag" at "/Sample/SiteValidator/MyEmptyReviewerPage"
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyEmptyReviewerPage'
      DocImproperReviewerTag - Could not find a value in the reviewer tag.  The inner text format should match 'Page Reviewer: [NAME]'.

  """
@StewartArmbrecht @Sprint0
Scenario: Validate Documentation Page Multiple Reviewer Tag
  Given I am a team member
  And I have a documentation page "with multiple reviewer tags" at "/Sample/SiteValidator/MyMultipleReviewerPage"
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyMultipleReviewerPage'
      DocMultipleReviewerTags - There are multiple reviewer tags.  Please remove all but one.

  """
@StewartArmbrecht @Sprint0
Scenario: Validate Documentation Page Mislabeled Reviewer Tag
  Given I am a team member
  And I have a documentation page "with a mislabeled reviewer tag" at "/Sample/SiteValidator/MyMislabeledReviewerPage"
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyMislabeledReviewerPage'
      DocImproperReviewerTag - Could not find a value in the reviewer tag.  The inner text format should match 'Page Reviewer: [NAME]'.

  """

@StewartArmbrecht @Sprint0
Scenario: Validate Documentation Page Missing Updated Tag
  Given I am a team member
  And I have a documentation page "with a missing updated tag" at "/Sample/SiteValidator/MyMissingUpdatedTagPage"
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyMissingUpdatedTagPage'
      DocMissingUpdatedTag - The page does not have an updated tag.  Please add '<p class="updated">Updated on [DATE] by [PERSON]</p> to the page.  Just copy it into the markdown file and then replace the [DATE] and [PERSON] fields with the actual date and the person that updated the page.

  """
@StewartArmbrecht @Sprint0
Scenario: Validate Documentation Page Updated Tag Invalid
  Given I am a team member
  And I have a documentation page "with a page that is has an invalide updated text" at "/Sample/SiteValidator/MyInvalidUpdatedTagPage"
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyInvalidUpdatedTagPage'
      DocInvalidUpdatedTag - The page does not have a properly formated updated tag.  Please make sure it conforms to 'Updated on [dd/mm/yy] by [NAME]'.

  """
@StewartArmbrecht @Sprint0
Scenario: Validate Documentation Page Updated Tag Invalid Date
  Given I am a team member
  And I have a documentation page "with a page that is has an invalid updated date" at "/Sample/SiteValidator/MyInvalidUpdatedDatePage"
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyInvalidUpdatedDatePage'
      DocInvalidUpdatedDate - The updated date is not a valid date.

  """
@StewartArmbrecht @Sprint0
Scenario: Validate Documentation Page Multiple Updated Tags
  Given I am a team member
  And I have a documentation page "with multiple updated tags" at "/Sample/SiteValidator/MyMultipleUpdatedTagPage"
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyMultipleUpdatedTagPage'
      DocMultipleUpdatedTags - There are multiple updated tags.  Please remove all but one.

  """
@StewartArmbrecht @Sprint0
Scenario: Validate Documentation Page Updated Tag Date Is In The Future
  Given I am a team member
  And I have a documentation page "with an updated date in the future" at "/Sample/SiteValidator/MyFutureUpdatedTagPage"
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyFutureUpdatedTagPage'
      DocFutureUpdatedDate - The updated date is in the future.

  """

@StewartArmbrecht @Sprint0
Scenario: Validate Documentation Page Missing Reviewed Tag
  Given I am a team member
  And I have a documentation page "with a missing reviewed tag" at "/Sample/SiteValidator/MyMissingReviewedTagPage"
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyMissingReviewedTagPage'
      DocMissingReviewedTag - The page does not have an reviewed tag.  Please add '<p class="reviewed">Reviewed on [DATE] by [PERSON]</p> to the page.  Just copy it into the markdown file and then replace the [DATE] and [PERSON] fields with the actual date and the person that reviewed the page.

  """
@StewartArmbrecht @Sprint0
Scenario: Validate Documentation Page Reviewed Tag Invalid
  Given I am a team member
  And I have a documentation page "with a page that is has an invalide reviewed text" at "/Sample/SiteValidator/MyInvalidReviewedTagPage"
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyInvalidReviewedTagPage'
      DocInvalidReviewedTag - The page does not have a properly formated reviewed tag.  Please make sure it conforms to 'Reviewed on [dd/mm/yy] by [NAME]'.

  """
@StewartArmbrecht @Sprint0
Scenario: Validate Documentation Page Reviewed Tag Invalid Date
  Given I am a team member
  And I have a documentation page "with a page that is has an invalid reviewed date" at "/Sample/SiteValidator/MyInvalidReviewedDatePage"
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyInvalidReviewedDatePage'
      DocInvalidReviewedDate - The reviewed date is not a valid date.

  """
@StewartArmbrecht @Sprint0
Scenario: Validate Documentation Page Multiple Reviewed Tags
  Given I am a team member
  And I have a documentation page "with multiple reviewed tags" at "/Sample/SiteValidator/MyMultipleReviewedTagPage"
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyMultipleReviewedTagPage'
      DocMultipleReviewedTags - There are multiple reviewed tags.  Please remove all but one.

  """
@StewartArmbrecht @Sprint0
Scenario: Validate Documentation Page Reviewed Tag Date Is In The Future
  Given I am a team member
  And I have a documentation page "with an reviewed date in the future" at "/Sample/SiteValidator/MyFutureReviewedTagPage"
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyFutureReviewedTagPage'
      DocFutureReviewedDate - The reviewed date is in the future.

  """
Scenario: Validate Documentation Page Reviewed Date is Older Than Updated Date With Valid Reviewer
  Given I am a team member
  And I have a documentation page "with a reviewed date earlier than the updated date and a valid reviewer" at "/Sample/SiteValidator/MyReviewedDateOlderThanUpdatedDatePage"
  And the page has "John Reviewer" tagged as the reviewer
  And the test settings have "Sprint4" set as the current sprint
  And the test settings have a "Must" priority for resolving "DocUnreviewedChange" errors
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyReviewedDateOlderThanUpdatedDatePage'
      DocUnreviewedChange - The reviewed date is older than the updated date.

  """
  And the validators resolution scenarios should read
  """
  The following are recommended resolution scenarios:
    @Sprint4 @JohnReviewer @Must
    Scenario: Page at '{rootUrl}/Sample/SiteValidator/MyReviewedDateOlderThanUpdatedDatePage' reviewed
      Given I am a team member
      When I navigate to the "{rootUrl}/Sample/SiteValidator/MyReviewedDateOlderThanUpdatedDatePage" page
      Then the page should be reviewed and the reviewed date should be after the updated date

  """
Scenario: Validate Documentation Page Reviewed Date is Older Than Updated Date With Missing Reviewer and Valid Test Settings Default
  Given I am a team member
  And I have a documentation page "with a reviewed date older than the updated date and a missing reviewer" at "/Sample/SiteValidator/MyReviewedDateOlderThanUpdatedDateSettingsReviewerPage"
  And the test settings have "Sally Reviewer" set as the default reviewer
  And the test settings have "Sprint4" set as the current sprint
  And the test settings have a "Must" priority for resolving "DocUnreviewedChange" errors
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyReviewedDateOlderThanUpdatedDateSettingsReviewerPage'
      DocUnreviewedChange - The reviewed date is older than the updated date.

  """
  And the validators resolution scenarios should read
  """
  The following are recommended resolution scenarios:
    @Sprint4 @SallyReviewer @Must
    Scenario: Page at '{rootUrl}/Sample/SiteValidator/MyReviewedDateOlderThanUpdatedDateSettingsReviewerPage' reviewed
      Given I am a team member
      When I navigate to the "{rootUrl}/Sample/SiteValidator/MyReviewedDateOlderThanUpdatedDateSettingsReviewerPage" page
      Then the page should be reviewed and the reviewed date should be after the updated date

  """
Scenario: Validate Documentation Page Reviewed Date is Older Than Updated Date With Missing Reviewer and Missing Test Settings Default
  Given I am a team member
  And I have a documentation page "with a reviewed date before the updated date with a missing reviewer" at "/Sample/SiteValidator/MyReviewedDateOlderThanUpdatedDateNoReviewerPage"
  And the test settings are missing a default reviewer
  And the test settings have "Sprint4" set as the current sprint
  And the test settings have a "Must" priority for resolving "DocUnreviewedChange" errors
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyReviewedDateOlderThanUpdatedDateNoReviewerPage'
      DocUnreviewedChange - The reviewed date is older than the updated date.

  """
  And the validators resolution scenarios should read
  """
  The following are recommended resolution scenarios:
    @Sprint4 @Unassigned @Must
    Scenario: Page at '{rootUrl}/Sample/SiteValidator/MyReviewedDateOlderThanUpdatedDateNoReviewerPage' reviewed
      Given I am a team member
      When I navigate to the "{rootUrl}/Sample/SiteValidator/MyReviewedDateOlderThanUpdatedDateNoReviewerPage" page
      Then the page should be reviewed and the reviewed date should be after the updated date

  """
Scenario: Validate Documentation Page Reviewed Date is Older Than Oldest Acceptible Review Date With Valid Reviewer
  Given I am a team member
  And I have a documentation page "with a reviewed date older than oldest allowed and a valid reviewer" at "/Sample/SiteValidator/MyReviewedDateOlderThanAllowedValidReviewerPage"
  And the page has "John Reviewer" tagged as the reviewer
  And the test settings have "Sprint4" set as the current sprint
  And the test settings have "9" months set at the oldest review date 
  And the test settings have a "Must" priority for resolving "DocAgedReview" errors
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyReviewedDateOlderThanAllowedValidReviewerPage'
      DocAgedReview - The reviewed date is older than allowed.

  """
  And the validators resolution scenarios should read
  """
  The following are recommended resolution scenarios:
    @Sprint4 @JohnReviewer @Must
    Scenario: Page at '{rootUrl}/Sample/SiteValidator/MyReviewedDateOlderThanAllowedValidReviewerPage' reviewed
      Given I am a team member
      When I navigate to the "{rootUrl}/Sample/SiteValidator/MyReviewedDateOlderThanAllowedValidReviewerPage" page
      Then the page should be reviewed and the reviewed date should be less than 9 months old

  """
Scenario: Validate Documentation Page Reviewed Date is Older Than Oldest Acceptible Review Date With Missing Reviewer and Valid Test Settings Default
  Given I am a team member
  And I have a documentation page "with a reviewed date older than oldest allowed and a reviewer from the app settings" at "/Sample/SiteValidator/MyReviewedDateOlderThanAllowedSettingsReviewerPage"
  And the test settings have "Sally Reviewer" set as the default reviewer
  And the test settings have "Sprint4" set as the current sprint
  And the test settings have "9" months set at the oldest review date 
  And the test settings have a "Must" priority for resolving "DocAgedReview" errors
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyReviewedDateOlderThanAllowedSettingsReviewerPage'
      DocAgedReview - The reviewed date is older than allowed.

  """
  And the validators resolution scenarios should read
  """
  The following are recommended resolution scenarios:
    @Sprint4 @SallyReviewer @Must
    Scenario: Page at '{rootUrl}/Sample/SiteValidator/MyReviewedDateOlderThanAllowedSettingsReviewerPage' reviewed
      Given I am a team member
      When I navigate to the "{rootUrl}/Sample/SiteValidator/MyReviewedDateOlderThanAllowedSettingsReviewerPage" page
      Then the page should be reviewed and the reviewed date should be less than 9 months old

  """
  @Current
Scenario: Validate Documentation Page Reviewed Date is Older Than Oldest Acceptible Review Date With Missing Reviewer and Missing Test Settings Default
  Given I am a team member
  And I have a documentation page "with a reviewed date older than oldest allowed and a reviewer from the app settings" at "/Sample/SiteValidator/MyReviewedDateOlderThanAllowedSettingsReviewerPage"
  And the test settings are missing a default reviewer
  And the test settings have "Sprint4" set as the current sprint
  And the test settings have "9" months set at the oldest review date 
  And the test settings have a "Must" priority for resolving "DocAgedReview" errors
  When I validate the page
  Then the validators error messages should read
  """
  The following pages had validation errors:
    Page: '{rootUrl}/Sample/SiteValidator/MyReviewedDateOlderThanAllowedSettingsReviewerPage'
      DocAgedReview - The reviewed date is older than allowed.

  """
  And the validators resolution scenarios should read
  """
  The following are recommended resolution scenarios:
    @Sprint4 @Unassigned @Must
    Scenario: Page at '{rootUrl}/Sample/SiteValidator/MyReviewedDateOlderThanAllowedSettingsReviewerPage' reviewed
      Given I am a team member
      When I navigate to the "{rootUrl}/Sample/SiteValidator/MyReviewedDateOlderThanAllowedSettingsReviewerPage" page
      Then the page should be reviewed and the reviewed date should be less than 9 months old

  """

