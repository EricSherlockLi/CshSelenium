using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.IO;

namespace AutomationTests.Config
{
    public class TestBaseConfig : IDisposable
    {
        protected IWebDriver Driver;
        private readonly ChromeOptions _options;

        public TestBaseConfig()
        {
            _options = new ChromeOptions();
            _options.AddArgument("--headless");
            _options.AddArgument("--no-sandbox");
            _options.AddArgument("--disable-dev-shm-usage");

            string runEnv = Environment.GetEnvironmentVariable("RUN_ENV") ?? "local";
            string executablePath;

            if (runEnv == "ci")
            {
                executablePath = "/usr/bin/chromedriver";
            }
            else
            {
                executablePath = @"C:\Users\hello\PythonSelenium\Test\utils\webdriver\chromedriver.exe";
            }

            Driver = new ChromeDriver(executablePath, _options);
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
