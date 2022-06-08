using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace AppiumSummatorTestsNew
{
    public class SummatorAppiumTests
    {
        private WindowsDriver<WindowsElement> driver;
        private const string AppiumServer = "http://127.0.0.1:4723/wd/hub";
        private AppiumOptions options;


        [SetUp]
        public void OpenApp()
        {


            this.options = new AppiumOptions() { PlatformName = "Windows" };

            options.AddAdditionalCapability(MobileCapabilityType.App, @"C:\WindowsFormsApp.exe");

            this.driver = new WindowsDriver<WindowsElement>(new Uri(AppiumServer), options);

        }

        [TearDown]
        public void ShutDownApp() => driver.Quit();

        [Test]
        public void Test_Sum_Two_positiveNumbers()
        {
            // Arrange
            var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
            num1.Click();
            num1.SendKeys("5");

            var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
            num2.Click();
            num2.SendKeys("15");
            //Act
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            calcButton.Click();

            //Assert
            string result = driver.FindElementByAccessibilityId("textBoxSum").Text;
            Assert.That(result, Is.EqualTo("20"));

        }
    }
}
