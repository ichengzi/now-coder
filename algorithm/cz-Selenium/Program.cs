using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace cz_Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            //var driver = new InternetExplorerDriver();
            try
            {
                //var driver = new InternetExplorerDriver();
                //var driver = new ChromeDriver();
                var driver = new EdgeDriver();
                //driver.Navigate().GoToUrl("http://www.baidu.com");
                driver.Navigate().GoToUrl("http://iichengzi.cn");
                //var query = driver.FindElementById("kw");
                //query.SendKeys("cc");
                //Console.WriteLine("Page Title: " + driver.Title);

                Console.ReadKey();
                driver.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
