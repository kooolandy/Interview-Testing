using OpenQA.Selenium;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace Testing.StepDefinitions
{
    [Binding]
    public class SimpleCalculatorSteps : StartupHooks
    {
        [When(@"the 1st value (.*) is entered")]
        public void WhenThe1stValueIsEntered(Decimal value)
        {
            var inp = Webdriver.FindElement(By.Id("number1"));
            inp.SendKeys(value.ToString());
        }

        [When(@"the 2nd value (.*) is entered")]
        public void WhenThe2ndValueIsEntered(Decimal value)
        {
            var inp = Webdriver.FindElement(By.Id("number2"));
            inp.SendKeys(value.ToString());
        }

        [When(@"the calculator (.*) is selected")]
        public void WhenTheCalculatorIsSelected(string method)
        {
            var functions = Webdriver.FindElement(By.Id("function"));
            var function = functions.FindElement(By.CssSelector($"option[value={method}"));
            functions.Click();
            function.Click();
        }

        [When(@"the sum is submitted")]
        public void WhenTheSumIsSubmitted()
        {
            var submit = Webdriver.FindElement(By.Id("calculate"));
            submit.Click();
        }

        [Then(@"the (.*) is validated")]
        public void ThenTheAnswerIsValidated(Decimal answer)
        {
            var t_answer = Webdriver.FindElement(By.Id("answer")).Text;
            Debug.WriteLine($"{t_answer} = {answer}");
            Assert.IsTrue(t_answer.Equals(answer.ToString()));
        }
    }
}
