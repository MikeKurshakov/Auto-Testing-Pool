﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace AutoTestChek
{
        [TestFixture]
        public class Test
        {
            public static IWebDriver driver;

            [SetUp] // вызывается перед каждым тестом
            public void SetUp()
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://www.google.com.ua");
                driver.FindElement(By.Id("lst-ib")).SendKeys("Hotline" + Keys.Enter);
                driver.FindElement(By.XPath(".//*[@id='vn1s0p1c0']")).Click();
            }

            [TearDown] // вызывается после каждого теста
            public void TearDown()
            {
                driver.Quit();
            }

            [Test]
            public void TEST_ForSearchHotline()
            {

                Assert.AreEqual(driver.Title, "Hotline - сравнить цены в интернет-магазинах Украины");
            }

            [Test]
            public void TEST_LocalizationChek()
            {
                
                driver.FindElement(By.ClassName("close")).Click();
                driver.FindElement(By.CssSelector(".cell-sm-none [data-language='uk']")).Click();
                Assert.AreEqual(driver.Title, "Hotline - порівняти ціни в інтернет-магазинах України");
        }
            [Test]
            public void TEST_PerfumeCosmeticsSectionChek()
            {

                driver.FindElement(By.ClassName("close")).Click();
                driver.FindElement(By.CssSelector(".cell-sm-none [data-language='uk']")).Click();
                driver.FindElement(By.LinkText("Парфуми та Косметика")).Click();
                driver.FindElement(By.CssSelector(".item:nth-of-type(2) > span:nth-of-type(1)")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.LinkText("Кисті")).Click();
                Assert.AreEqual(driver.Title, "Косметичні кисті | ціни, купити в інтернет-магазині | Hotline");
        }
            [Test]
            public void TEST_FiltrationCosmeticChek()
            {

                driver.FindElement(By.ClassName("close")).Click();
                driver.FindElement(By.CssSelector(".cell-sm-none [data-language='uk']")).Click();
                driver.FindElement(By.LinkText("Парфуми та Косметика")).Click();
                driver.FindElement(By.CssSelector(".item:nth-of-type(2) > span:nth-of-type(1)")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.LinkText("Кисті")).Click();
                driver.FindElement(By.XPath("//div[@class='nowrap m_b-lg']/input[1]")).SendKeys(Keys.Control+"a");
                driver.FindElement(By.XPath("//div[@class='nowrap m_b-lg']/input[1]")).SendKeys("0");
                driver.FindElement(By.XPath("//div[@class='nowrap m_b-lg']/input[3]")).SendKeys(Keys.Control + "a");
                driver.FindElement(By.XPath("//div[@class='nowrap m_b-lg']/input[3]")).SendKeys("2500");
                //Для закрытия случайно появившегося блока рекламы(не всегда он появляется)
                try
                {
                driver.FindElement(By.Id("close")).Click();
                }
                catch {}
                driver.FindElement(By.XPath("//div[@class='nowrap m_b-lg']/input[5]")).Click();
                driver.FindElement(By.XPath("//div[@class='item-bd'][@data-filters-id='filters-gr-104598']/ul/li[3]")).Click();
                Assert.LessOrEqual(Int32.Parse((driver.FindElement(By.XPath("//div[@class='price-md']/span[1]/span[1]")).Text)),2500);  
        }
            [Test]
        public void TEST_FiltrationSnowboardsChek()
            {

                driver.FindElement(By.ClassName("close")).Click();
                driver.FindElement(By.CssSelector(".cell-sm-none [data-language='uk']")).Click();
                driver.FindElement(By.LinkText("Спорт, Активний відпочинок")).Click();
                driver.FindElement(By.CssSelector("[data-dropdown-target='-1077'] > span:nth-of-type(1)")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.LinkText("Сноуборди")).Click();
                //Для закрытия случайно появившегося блока рекламы(не всегда он появляется)
                try
                {
                    driver.FindElement(By.Id("close")).Click();
            }
                catch { }
                driver.FindElement(By.CssSelector(".sorting-in > [data-sortbox='select']:nth-child(1) .field")).Click();
                driver.FindElement(By.XPath("//select[@class='field']/option[@value='0']")).Click();
                //Для закрытия случайно появившегося блока рекламы(не всегда он появляется)
                try
                {
                    driver.FindElement(By.Id("close")).Click();
                }
                catch { }
                Assert.LessOrEqual(int.Parse(driver.FindElement(By.XPath("//div[@class='price-md'][1]/span[1]/span[1]")).Text, NumberStyles.AllowThousands), int.Parse(driver.FindElement(By.XPath("//div[@class='price-md']/span[1]/span[1]")).Text, NumberStyles.AllowThousands));
            }

    }
}
