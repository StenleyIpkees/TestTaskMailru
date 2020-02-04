﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestTaskMailru
{
    class CommonMethods
    {
        public IWebDriver WebDriver;
        public WebDriverWait Wait;
        public WebDriverWait WaitLong;
        public IJavaScriptExecutor Js;


        public CommonMethods(IWebDriver wd)
        {
            WebDriver = wd;
            Js = (IJavaScriptExecutor)WebDriver;
            Wait = new WebDriverWait(WebDriver, ConfigWD.WaitTimeout);
            WaitLong = new WebDriverWait(WebDriver, ConfigWD.WaitTimeoutLong);
        }


        public void WaitPageLoad(string url = "")
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(url))
                {
                    Wait.Until(driver => driver.Url.Contains(url));
                }

                Wait.Until(driver => Js.ExecuteScript("return document.readyState").ToString().Equals("complete"));
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception($"Страница {url} полностью не загрузилась за {Wait.Timeout.Seconds} секунд.");
            }
        }

        public string GetUrl() => WebDriver.Url;
        public void GoToUrl(string url) => WebDriver.Navigate().GoToUrl("http://" + url);
        
        
       

    }
}
