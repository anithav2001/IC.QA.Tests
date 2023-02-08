using IC.QA.Services.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IC.QA.Services.UI.Models
{
    public class AddRemoveElementsPage
    {
        private readonly IWebDriver _browser;
        public AddRemoveElementsPage(IWebDriver browser)
        {
            _browser = browser;
        }

        public AddRemoveElementsPage()
        {
        }

        //Selectors
        public IWebElement AddElementBtn => _browser.FindElement(By.XPath("//button[text()='Add Element']"));
        public List<IWebElement> Elements => _browser.FindElements(By.XPath("//button[@class='added-manually']")).ToList();

        //Actions
        public void ClickAddElement()
        {
            AddElementBtn.Click();
            
        }
        public bool AddElementBtnExists()
        {
            try
            {
                return AddElementBtn.Exists();
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        
    }
}
