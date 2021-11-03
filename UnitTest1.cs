using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace NUnitTestProject
{
    public class Tests
    {
        IWebDriver driver;
        public string UserName;
        public string Password = "JohnyBlack123***";


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://newbookmodels.com/");
            driver.Manage().Window.Maximize();
            GenerateEmail();
        }

        [Test]
        public void RegistrationTest()
        {
            IWebElement signUpButton = driver.FindElement(By.CssSelector("span.Navbar__navOptionsTabletUp--7X9au > button"));
            signUpButton.Click();
            IWebElement firstNameField = driver.FindElement(By.CssSelector("[class *= 'Input__input--_88SI Input__themeNewbook--1IRjd Input__fontRegular--2SStp']"));
            firstNameField.Click();
            firstNameField.SendKeys("Johny");
            IWebElement lastNameField = driver.FindElement(By.CssSelector("[name=\"last_name\"]"));
            lastNameField.Click();
            lastNameField.SendKeys("Black");

            string userName = GenerateEmail();

            IWebElement emailField = driver.FindElement(By.CssSelector("[name=\"email\"]"));
            emailField.Click();
            emailField.SendKeys(userName);
            IWebElement passwordsField = driver.FindElement(By.CssSelector("[name=\"password\"]"));
            passwordsField.Click();
            passwordsField.SendKeys(Password);
            IWebElement confirmPasswordField = driver.FindElement(By.CssSelector("[name=\"password_confirm\"]"));
            confirmPasswordField.Click();
            confirmPasswordField.SendKeys(Password);
            IWebElement mobileField = driver.FindElement(By.CssSelector("[name=\"phone_number\"]"));
            mobileField.Click();
            mobileField.SendKeys("06666666666");
            IWebElement nextButton = driver.FindElement(By.CssSelector("[class *= \"Button__button---rQSB\"]"));
            nextButton.Click();
            IWebElement nameCompanyField = driver.FindElement(By.CssSelector("[name=\"company_name\"]"));
            nameCompanyField.Click();
            nameCompanyField.SendKeys("FashionHub");
            IWebElement companyUrlField = driver.FindElement(By.CssSelector("[name=\"company_website\"]"));
            companyUrlField.Click();
            companyUrlField.SendKeys("FashionHub.ua");
            IWebElement address = driver.FindElement(By.CssSelector("[name=\"location\"]"));
            address.SendKeys("2259 Bentley Ave, Los Angeles, CA 90025, USA");
            Thread.Sleep(500);
            address.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            address.SendKeys(Keys.Enter);
            IWebElement industrySelect = driver.FindElement(By.CssSelector("[name=\"industry\"]"));
            industrySelect.Click();
            IWebElement industrySelectEntartaiment = driver.FindElements(By.CssSelector("[class = \"Select__option--1IbG6\"]"))[2];
            industrySelectEntartaiment.Click();
            IWebElement finishButton = driver.FindElement(By.CssSelector("[type=\"submit\"]"));
            finishButton.Click();
        }

        [Test]
        public void AutorizationTest()
        {
            
            IWebElement logInButton = driver.FindElement(By.CssSelector("[class *=\"Navbar__navLink--3lL7S Navbar__navLinkSingle--3x6Lx Navbar__login--28b35\"]"));
            logInButton.Click();
            IWebElement emailField = driver.FindElement(By.CssSelector("[class *=\"Input__input--_88SI Input__themeNewbook--1IRjd Input__fontRegular--2SStp\"]"));
            emailField.Click();
            GenerateEmail();
            emailField.SendKeys(GenerateEmail());
            IWebElement passwordField = driver.FindElement(By.CssSelector("[name=\"password\"]"));
            passwordField.Click();
            passwordField.SendKeys(Password);
            IWebElement logInButtonInAutorisation = driver.FindElement(By.CssSelector("[type= \"submit\"]"));
            logInButtonInAutorisation.Click();
        }

        [TearDown]
        public void After()
        {
            //driver.Quit();
        }

        public string GenerateEmail()
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            string userName = dateTime.ToString();
            userName = userName.Replace(".", "");
            userName = userName.Replace(" ", "");
            userName = userName.Replace(":", "");
            userName = "JohnyBlack" + userName + "@supermodel.ua";
            return userName;
        }
    }
}