using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace IC.QA.Services.Selenium
{
    public static class SetupsAndTearDowns
    {
        public static IWebDriver StartBrowser(string browserToOpen, string urlToOpen)
        {
            SeleniumBrowserFactory.InitBrowser(browserToOpen);
            Thread.Sleep(3000);
            SeleniumBrowserFactory.Browser.Manage().Window.Maximize();
            SeleniumBrowserFactory.Browser.Navigate().GoToUrl(urlToOpen);
            return SeleniumBrowserFactory.Browser;
        }

        public static void CloseBrowser()
        {
            try
            {
                SeleniumBrowserFactory.CloseAllBrowsers();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}