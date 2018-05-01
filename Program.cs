using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace MyBukepTests {
    class Program {
        IWebDriver Browser;
        static void Main (string[] args) {
            Program program = new Program ();
            string testName = Console.ReadLine ();
            switch (testName) {
                case "Login":
                    program.LoginTest ();
                    break;
                case "SendEmail":
                    program.SendEmailTest ();
                    break;

            }

        }

        public IWebElement GetElement (By locator) {
            List<IWebElement> elements = Browser.FindElements (locator).ToList ();
            if (elements.Count > 0)
                return elements[0];
            else
                return null;
        }

        public void SendEmailTest () {
            Browser = new ChromeDriver ("bin/Debug/netcoreapp2.0/");
            Browser.Manage ().Window.Maximize ();
            //Browser.Manage().Timeouts().ImplicitWait(T)
            Browser.Navigate ().GoToUrl ("https://my.bukep.ru:447/Admin/Admin/Login/8236196");
            IWebElement mail = Browser.FindElement (By.CssSelector (cssSelectorToFind: ".fa.fa-envelope-open-o"));
            mail.Click ();
            IWebElement write = Browser.FindElement (By.CssSelector (".btn.btn-block.btn-danger.portElements"));
            write.Click ();

            WebDriverWait wait = new WebDriverWait (Browser, new TimeSpan (0, 0, 5));
            IWebElement fioInput = wait.Until (b => b.FindElement (By.Id ("FIO")));
            fioInput.SendKeys ("Исаенко Виталий");

            new Actions (Browser).SendKeys (OpenQA.Selenium.Keys.ArrowDown).Perform ();
            new Actions (Browser).SendKeys (OpenQA.Selenium.Keys.Return).Perform ();

            IWebElement topic = Browser.FindElement (By.Id("Theme"));
            topic.SendKeys("testMyBUKEP");
            IWebElement text = Browser.FindElement(By.Id("Text"));
            text.SendKeys("hi!");
            IWebElement send = Browser.FindElement (By.Id ("sent"));
            send.Click ();
        }

        public void LoginTest () {

            Browser = new ChromeDriver ("/Users/alenagolovaneva/Documents/Repositories/MyBukepTests/bin/Debug/netcoreapp2.0/");
            Browser.Manage ().Window.Maximize ();
            Browser.Navigate ().GoToUrl ("https://my.bukep.ru:447");
            IWebElement loginInput = Browser.FindElement (By.Id ("login"));
            IWebElement passwordInput = Browser.FindElement (By.Id ("password"));
            //IWebElement tofind = GetElement(By.ClassName("dropdown-toggle"));
            IWebElement battonInput = Browser.FindElement (By.CssSelector (".btn.btn-block.btn-primary"));
            loginInput.SendKeys ("vtest");
            passwordInput.SendKeys ("vtest");
            battonInput.Click ();

            String url = Browser.Url;
            if (url == "https://my.bukep.ru:447/Home") {
                Console.WriteLine ("Test Passed :)");
            } else {
                Console.WriteLine ("Test Failed :(");

            }
        }
    }
}