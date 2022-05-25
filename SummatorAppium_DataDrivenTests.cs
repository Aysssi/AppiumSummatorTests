using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Windows;
using System;


namespace AppiumSummator_DataDrivenTest
{
    public class SummatorAppium_DataDrivenTests
    {
        private WindowsDriver<WindowsElement> driver;
        private const string AppiumServer = "http://127.0.0.1:4723/wd/hub";
        private AppiumOptions options;
        private WindowsElement firstField;
        private WindowsElement secondField;
        private WindowsElement calcButton;
        private WindowsElement result;

        [OneTimeSetUp]
        public void OpenApp()
        {
            this.options = new AppiumOptions() { PlatformName = "Windows" };
            options.AddAdditionalCapability(MobileCapabilityType.App, @"C:/Example/SummatorDesktopApp");
            this.driver = new WindowsDriver<WindowsElement>(new Uri(AppiumServer), options);
            firstField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            secondField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            result = driver.FindElementByAccessibilityId("textBoxSum");

        }
       

        [OneTimeTearDown]
        public void ShutDownApp()
        {
            this.driver.Quit();
        }



        public void Clear()
        {
            firstField.Clear();
            secondField.Clear();

        }
        
        [TestCase("10", "ayyy", "error")]
        [TestCase("", "", "error")]
        [TestCase("", "7", "error")]
        [TestCase("28", "", "error")]
        [TestCase("@", "#", "error")]
        [TestCase("5.9", "7.1", "error")]
        [TestCase("6", "5", "11")]
        [TestCase("-8", "-9", "-17")]

        public void Test_Summator(string num1, string num2, string expect)
        {
            firstField.SendKeys(num1);

            secondField.SendKeys(num2);

            calcButton.Click();


            Assert.That(result.Text, Is.EqualTo(expect));

            
            Clear();
        }
      



    }
}