using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;

namespace AppiumSummatorTest
{
    public class SummatorAppium_Tests
    {
        private WindowsDriver<WindowsElement> driver;
        private const string AppiumServer = "http://127.0.0.1:4723/wd/hub";
        private AppiumOptions options;
        

        [OneTimeSetUp]
        public void OpenApp()
        {
            this.options = new AppiumOptions() { PlatformName = "Windows" };
            options.AddAdditionalCapability(MobileCapabilityType.App, @"C:/Example/SummatorDesktopApp");
            this.driver = new WindowsDriver<WindowsElement>(new Uri(AppiumServer), options);

        }
        [OneTimeTearDown]
        public void ShutDownApp()
        {
            this.driver.Quit();
        }
        [Test]
        public void Test_Sum_TwoNegativeValue()
        {
            var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
            num1.Clear();
            num1.SendKeys("-11");

            var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
            num2.Clear();
            num2.SendKeys("-9");

            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            calcButton.Click();

            var result = driver.FindElementByAccessibilityId("textBoxSum").Text;

            Assert.That(result, Is.EqualTo("-20"));

        }
        [Test]
        public void Test_Sum_InvalidValue()
        {
            var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
            num1.Clear();
            num1.SendKeys("ayy");

            var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
            num2.Clear();
            num2.SendKeys("exoo");

            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            calcButton.Click();

            var result = driver.FindElementByAccessibilityId("textBoxSum").Text;

            Assert.That(result, Is.EqualTo("error"));

        }

        [Test]
        public void Test_Sum_PostiveNumbers()
        {
            var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
            num1.Clear();
            num1.SendKeys("10");

            var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
            num2.Clear();
            num2.SendKeys("9");

          
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            calcButton.Click();


            var result = driver.FindElementByAccessibilityId("textBoxSum").Text;

            Assert.That(result, Is.EqualTo("19"));
    
        }
   
       
    
    }

}