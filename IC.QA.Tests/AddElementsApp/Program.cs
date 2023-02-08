using IC.QA.Services.Selenium;
using IC.QA.Services.UI.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AddNElements
{
    class Program
    {

        static void Main(string[] args)
        {
            //Navigate to the url
            var urlToOpen = "https://the-internet.herokuapp.com/add_remove_elements/";
            try
            {
                Console.WriteLine("Enter the number of elements to add: ");
                var numElements = Convert.ToInt32(Console.ReadLine());
                IWebDriver driver = SetupsAndTearDowns.StartBrowser("Chrome", urlToOpen);
                AddRemoveElementsPage addRemoveElementsPage = new AddRemoveElementsPage(driver);
                for (int i = 0; i < numElements; i++)
                {
                    addRemoveElementsPage.ClickAddElement();
                }
                Console.WriteLine(numElements + " elements added");

                Assert.IsTrue(addRemoveElementsPage.Elements.Count() == numElements, $"Expectd : {numElements}, Actual : {addRemoveElementsPage.Elements.Count()}");
               
            }catch (Exception ex)
            {
                throw;
            }finally
            {
                SetupsAndTearDowns.CloseBrowser();
            }
           
        }
    }
}