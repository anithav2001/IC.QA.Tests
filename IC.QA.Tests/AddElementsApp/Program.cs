using IC.QA.Services.Selenium;
using IC.QA.Services.UI.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Xml.Linq;

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
                //inout rom the consoe
                Console.WriteLine("Enter the number of elements to add: ");
                var numElements = Convert.ToInt32(Console.ReadLine());
                //weriver init
                IWebDriver driver = SetupsAndTearDowns.StartBrowser("Chrome", urlToOpen);
                //pom
                AddRemoveElementsPage addRemoveElementsPage = new AddRemoveElementsPage(driver);
                //recursive method
                AddElements(addRemoveElementsPage, numElements);
                //output to console
                Console.WriteLine(numElements + " elements added");
                //assertion
                Assert.IsTrue(addRemoveElementsPage.Elements.Count() == numElements, $"Expectd : {numElements}, Actual : {addRemoveElementsPage.Elements.Count()}");
               
            }catch (Exception ex)
            {
                throw;
            }finally
            {
                SetupsAndTearDowns.CloseBrowser();
            }
           
        }

        public static void AddElements(AddRemoveElementsPage addRemoveElementsPage, int n)
        {
            if (n == 0)
                return ;
            else
            {
                addRemoveElementsPage.ClickAddElement();
                AddElements(addRemoveElementsPage, n-1);
            }
                
        }
    }
}