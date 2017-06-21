using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace BookishNet.Mvc.Tests.WrapperFactory
{
    internal class BrowserFactory
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();

        public static IWebDriver Driver { get; private set; }

        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    if (Driver == null)
                    {
                        Driver = new FirefoxDriver();
                        Drivers.Add("Firefox", Driver);
                    }
                    break;

                case "IE":
                    if (Driver == null)
                    {
                        Driver = new InternetExplorerDriver();
                        Drivers.Add("IE", Driver);
                    }
                    break;

                case "Chrome":
                    if (Driver == null)
                    {
                        Driver = new ChromeDriver();
                        Drivers.Add("Chrome", Driver);
                    }
                    break;
                case "":
                    if (Driver == null)
                    {
                        Driver = new ChromeDriver();
                        Drivers.Add("Chrome", Driver);
                    }
                    break;
            }
        }

        public static void LoadApplication(string url)
        {
            Driver.Manage().Window.Maximize();
            Driver.Url = url;
        }

        public static void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
            }
        }
    }
}