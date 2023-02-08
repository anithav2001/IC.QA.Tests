using IC.QA.Services.Selenium;
using IC.QA.Services.UI.Models;
using OpenQA.Selenium;

namespace IC.QA.Selenium.Tests
{
    public class Tests
    {
        private IWebDriver? _browser;
        private string urlToOpen = "https://the-internet.herokuapp.com/add_remove_elements/";
        private AddRemoveElementsPage addRemoveElementsPage = new AddRemoveElementsPage();

        [SetUp]
        public void Setup()
        {
            _browser = SetupsAndTearDowns.StartBrowser("Chrome", urlToOpen);
            addRemoveElementsPage = new AddRemoveElementsPage(_browser!);
        }

        [Test]
        public void AddNoElement()
        {
            Assert.IsTrue(addRemoveElementsPage.Elements.Count() == 0, $"Expectd : 0, Actual : {addRemoveElementsPage.Elements.Count()}");
        }
        [Test]
        public void AddOneElement()
        {
           
            addRemoveElementsPage.ClickAddElement();
            Assert.IsTrue(addRemoveElementsPage.Elements.Count() == 1, $"Expectd : 1, Actual : {addRemoveElementsPage.Elements.Count()}");
        }
        [Test]
        public void AddTenElements()
        {
            int n = 10; 
            for (int i = 0; i < n; i++)
            {
                addRemoveElementsPage.ClickAddElement();
            }
            Assert.IsTrue(addRemoveElementsPage.Elements.Count() == 10, $"Expectd : {n}, Actual : {addRemoveElementsPage.Elements.Count()}");
        }

        [TearDown]
        public void Teardown()
        {
            SetupsAndTearDowns.CloseBrowser();
        }
    }
}