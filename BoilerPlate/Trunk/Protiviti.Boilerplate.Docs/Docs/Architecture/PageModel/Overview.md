Page Model Tutorial
========================

Overview
----------------

Page Object Model is the term that selenium users keep buzzing. Page object is a design pattern that can be implemented as a selenium best practices. The functionality classes (PageObjects) in this design represent a logical relationship between the pages of the application.

The Page Object pattern represents the screens of your web app as a series of objects and encapsulates the features represented by a page.
It allows us to model the UI in our tests.
A page object is an object-oriented class that serves as an interface to a page of your AUT.

### Some of the advantages of page object pattern as listed below,

* Reduces the duplication of code
* Makes tests more readable and robust
* Improves the maintainability of tests, particularly when there is frequent change in the AUT. (Useful in Agile methodology based projects)

### Example of Page Object which models the Google search page:

public class GoogleSearchPage {

        protected WebDriver driver;
        private WebElement q;
        private WebElement btn;

        public GoogleSearchPage(WebDriver driver) {
            this.driver = driver;
        }
        public void open(String url) {
            driver.get(url);
        }
        public void close() {
            driver.quit();
        }
        public String getTitle() {
            return driver.getTitle();
        }
        public void searchFor(String searchTerm) {
            q.sendKeys(searchTerm);
            btn.click();
        }
        public void typeSearchTerm(String searchTerm) {
            q.sendKeys(searchTerm);
        }
        public void clickOnSearch() {
            btn.click();
        }
}

Resources
-----------------------------
* [code.google.com](https://code.google.com/p/selenium/wiki/PageObjects)
* [blog.activelylazy.co.uk](http://blog.activelylazy.co.uk/2011/07/09/page-objects-in-selenium-2-0/)
* [chon.techliminal.com](http://chon.techliminal.com/page_object/#/intro)


<p class="updated">Updated on 9/29/2014 by Saleh Motan</p>
<p class="reviewed">Reviewed on 9/29/2014 by Saleh Motan</p>