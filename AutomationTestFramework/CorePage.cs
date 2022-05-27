using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTestFramework
{
    public class CorePage
    {
        public static IWebDriver driver;

        public static void SeleniumInit(string browser)
        {
            if (browser == "Chrome")
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("--start-maximized");
                chromeOptions.AddArguments("--incognito");
                IWebDriver ChromeDriver = new ChromeDriver(chromeOptions);
                driver = ChromeDriver;
            }
            //return driver;
            else if (browser == "Firefox")
            {
                FirefoxOptions options = new FirefoxOptions();
                options.AddArguments("");
                driver = new FirefoxDriver(options);
            }
            /*
            else if (browser == "MicrosoftEdge")
            {
                var options = new OpenQA.Selenium.Edge.EdgeOptions();
                var service = EdgeDriverService.CreateDefaultService(@"C:\Users\khurram.muslim\Source\Repos\AutomationTestFramework\AutomationTestFramework\bin\Debug", @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe");
                service.Start();

                driver = new RemoteWebDriver(service.ServiceUrl, options);
            }*/
        }
    }
}
