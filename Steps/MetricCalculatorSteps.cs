using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowTests_CalculatorApp.Steps
{
    [Binding, Scope(Feature = "Metric Calculator")]
    public class MetricCalculatorSteps
    {
        static RemoteWebDriver driver;
        static IWebElement textBoxInputValue;
        static SelectElement dropDownSourceMetric;
        static SelectElement dropDownDestMetric;
        static IWebElement buttonCalc;
        static IWebElement buttonReset;
        static IWebElement divResult;

        [BeforeFeature]
        public static void OpenCalculatorApp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://js-calculator.nakov.repl.co");
            var linkMetricCalc = 
                driver.FindElementByXPath("//a[@href='#'][contains(.,'Metric Calculator')]");
            linkMetricCalc.Click();
            textBoxInputValue = 
                driver.FindElementByCssSelector("#screenMetricCalc input#fromValue");
            dropDownSourceMetric = new SelectElement(
                driver.FindElementByCssSelector("#screenMetricCalc select#sourceMetric"));
            dropDownDestMetric = new SelectElement(
                driver.FindElementByCssSelector("#screenMetricCalc select#destMetric"));
            buttonCalc = driver.FindElementByCssSelector(
                "#screenMetricCalc input[value='Calculate']");
            buttonReset = driver.FindElementByCssSelector(
                "#screenMetricCalc input[value='Reset']");
            divResult = driver.FindElementByCssSelector("#screenMetricCalc div.result");
        }

        [AfterFeature]
        public static void CloseCalculatorApp()
        {
            driver.Quit();
        }

        [BeforeScenario]
        public static void ResetCalculatorApp()
        {
            buttonReset.Click();
        }

        [Given("the input value is (.*)")]
        public void GivenTheInputValueIs(string inputValue)
        {
            textBoxInputValue.SendKeys(inputValue);
        }

        [Given("the source metric is \"(.*)\"")]
        public void GivenTheSourceMetricIs(string sourceMetric)
        {
            dropDownSourceMetric.SelectByValue(sourceMetric);
        }

        [Given("the destination metric is \"(.*)\"")]
        public void GivenTheDestMetricIs(string destMetric)
        {
            dropDownDestMetric.SelectByValue(destMetric);
        }

        [When("the conversion is performed")]
        public void WhenTheConversionIsPerformed()
        {
            buttonCalc.Click();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(string expectedResult)
        {
            var result = divResult.Text;
            result = result.Substring("Result: ".Length);
            result.Should().Be(expectedResult);
            //Assert.AreEqual(expectedResult, result);
        }
    }
}
