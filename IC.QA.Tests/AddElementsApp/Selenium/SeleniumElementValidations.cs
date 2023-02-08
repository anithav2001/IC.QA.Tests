using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Internal;


namespace IC.QA.Services.Selenium
{
    public static class SeleniumElementValidations
    {
        public static bool Exists(this IWebElement element)
        {
            try
            {
                if (element != null)
                    return true;
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        public static bool IsPresent(this IWebElement element)
        {
            try
            {
                if (element != null)
                    return element.Enabled && element.Displayed;
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }

        public static bool IsDisplayed(this IWebElement element)
        {
            try
            {
                if (element == null)
                {
                    return false;
                }
                else
                {
                    return element.Displayed;
                }
            }
            catch (NoSuchElementException)
            {
               
                return false;
            }
            catch (NullReferenceException)
            {
              
                return false;
            }
            catch(StaleElementReferenceException)
            {
              
                return false;
            }
        }

    }
}