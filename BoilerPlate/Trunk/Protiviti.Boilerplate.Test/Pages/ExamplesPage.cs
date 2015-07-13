using OpenQA.Selenium;
using Protiviti.Boilerplate.Test.Support;

namespace Protiviti.Boilerplate.Test.Pages
{
    public class ExamplesPage
    {
        public static void GoTo()
        {
            SeleniumController.Instance.Driver.Navigate().GoToUrl("URL");
        }

        public static bool IsAt
        {
            get
            {
                var h4s = SeleniumController.Instance.Driver.FindElements(By.TagName("h4"));
                if (h4s.Count > 0)
                    return h4s[0].Text == "Examples";
                return false;
            }
        }

        public static void GoToShoppingCart()
        {
            var shoppingCartLink = SeleniumController.Instance.Driver.FindElement(By.LinkText("Shopping Cart"));
            //use ID if I later have it
            shoppingCartLink.Click();
        }

        public static string TableTitle
        {
            get
            {
                var title = SeleniumController.Instance.Driver.FindElement(By.Id("ENTER ID"));
                if (title != null)
                    return title.GetAttribute("ENTER THE VALUE OF ATTRIBUTE");
                return string.Empty;
            }
        }

        public static string SearchButtonTitle
        {
            get
            {
                var title = SeleniumController.Instance.Driver.FindElement(By.Id("ENTER ID"));
                if (title != null)
                    return title.GetAttribute("ENTER THE VALUE OF ATTRIBUTE");
                return string.Empty;
            }
        }

        public static void FilterByProductName()
        {
            throw new System.NotImplementedException();
        }

        public static bool DoesProductsExistWithProductName()
        {
            throw new System.NotImplementedException();
        }

        public static bool DoesProductsExistWithPrice()
        {
            throw new System.NotImplementedException();
        }
    }
}

