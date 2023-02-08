using System;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace IC.QA.Services.Selenium
{
    public static class SeleniumBrowserFactory
    {
        private static readonly IDictionary<string, IWebDriver> BrowserDrivers = new Dictionary<string, IWebDriver>();
        private static IWebDriver? browser;

        public static string? baseUrl;
        public static string? BaseUrl
        {
            get { return baseUrl; }
            set { baseUrl = value; }
        }

        public static IWebDriver Browser
        {
            get
            {
                if (browser == null)
                    throw new InvalidOperationException("Webdriver browser instance was not initialized. First call method InitBrowser");
                return browser;
            }
            set
            {
                browser = value;
            }
        }

        public static void InitBrowser(string browserName)
        {
            string browserNamelower = browserName.ToLowerInvariant();

            switch (browserNamelower)
            {
                case "ie":
                    throw new NotImplementedException();
  

                case "chrome":
                    if (browser == null)
                    {

                        var cOptions = new ChromeOptions();
                        cOptions.AddArguments("chrome.switches", "--disable-extensions");
                        cOptions.AddUserProfilePreference("download.default_directory", Environment.CurrentDirectory);
                        var driverLocation = $"{Environment.CurrentDirectory}/Selenium/Chrome";
                        browser = new ChromeDriver(driverLocation, cOptions);
                        BrowserDrivers.Add("chrome", browser);
                    }
                    break;

                case "firefox":
                    throw new NotImplementedException();
     
                case "edge":
                    throw new NotImplementedException();
                default:
                    if (browser == null)
                    {
                        throw new ArgumentNullException("No browsers have been specified. Please update runsettings");
                    }
                    break;
            }
        }

        public static void CloseAllBrowsers()
        {
            try
            {
                foreach (var key in BrowserDrivers.Keys)
                {
                    BrowserDrivers[key].Close();
                    BrowserDrivers[key].Quit();
                }
                BrowserDrivers.Clear();
                Browser = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to close browser.\rException = {ex.Message}\r\rStackTrace = {ex.StackTrace}");
                Debug.WriteLine($"Failed to close browser.\rException = {ex.Message}\r\rStackTrace = {ex.StackTrace}");
            }
        }

        public static string WhatBrowserIsThis()
        {
            return BrowserDrivers.Keys.ElementAt(0).ToString();
        }
    }
}
