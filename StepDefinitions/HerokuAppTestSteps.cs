using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Testing.StepDefinitions
{
    [Binding]
    public class HerokuAppTestSteps : StartupHooks
    {
        private TimeSpan _ts = new TimeSpan(0,5,0);

        [Given(@"the herokuapp.com url is selected ​")]
        public void GivenTheHerokuapp_ComUrlIsSelected()
        {
            StartupHooks.Url = "https://testpages.herokuapp.com/";
        }

        [When(@"the following buttons are selected")]
        public void WhenTheFollowingButtonsAreSelected(Table table)
        {
            foreach (var row in table.Rows)
            {
                WhenTheButtonIsSelected(row.Values.First());
            }
        }

        [When(@"the (.*) button is selected")]
        public void WhenTheButtonIsSelected(string name)
        {
            GetClickableElement("button", name).Click();
        }

        [When(@"the (.*) link is selected")]
        public void WhenTheLinkIsSelected(string name)
        {
            GetClickableElement("a", name).Click();
        }

        [Then(@"the (.*) text is displayed")]
        public void ThenTheTextIsDisplayed(string text)
        {
            var msg = Webdriver.FindElement(By.Id("buttonmessage"));
            Assert.IsTrue(msg.Text.Equals(text), "Not all buttons clicked");
        }

        private IWebElement GetClickableElement(string type, string name)
        {
            Debug.WriteLine($"Trying to find {name}");
            do
            {
                var items = Webdriver.FindElements(By.CssSelector(type));
                var item = items.SingleOrDefault(x => x.Text.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (item != null)
                    return item;
            } while (true);
        }
    }
}
