using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyBukepTests
{
    class Program
    {
        IWebDriver Browser;
        static void Main(string[] args)
        {
            Program program = new Program();
            string testName = Console.ReadLine();
            switch (testName)
            {
                case "Login":
                    program.LoginTest();
                    break;
                case "SendEmail":
                    program.SendEmailTest();
                    break;

            }



        }

        public IWebElement GetElement(By locator)
        {
            List<IWebElement> elements = Browser.FindElements(locator).ToList();
            if (elements.Count > 0)
                return elements[0];
            else
                return null;
        }

        public void SendEmailTest()
        {

        }



        public void LoginTest()
        {


            Browser = new ChromeDriver("/Users/alenagolovaneva/Documents/Repositories/MyBukepTests/bin/Debug/netcoreapp2.0/");
            Browser.Manage().Window.Maximize();
            Browser.Navigate().GoToUrl("https://my.bukep.ru:447");
            IWebElement loginInput = Browser.FindElement(By.Id("login"));
            IWebElement passwordInput = Browser.FindElement(By.Id("password"));
            IWebElement tofind = GetElement(By.LinkText("Расписание"));
            IWebElement battonInput = Browser.FindElement(By.CssSelector(".btn.btn-block.btn-primary"));
            loginInput.SendKeys("vtest");
            passwordInput.SendKeys("vtest");
            battonInput.Click();

            if (tofind != null)
            {
                Console.WriteLine("Test Passed :)");
            }
            else
            {
                Console.WriteLine("Test Failed :(");

            }
        }
    }
}
