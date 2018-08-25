using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace CrashMiningRobot
{
    class Robot
    {
        IWebDriver driver;
        string koef;
        double dkoef;
        string Hash;
        //static int access;
        BET st = new BET();
        Log RobotLogs = new Log("Robot_Logs");

        public void Start() //запускаем браузер
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true; //выключаем надоедливую консольку с мусором
            driver = new OpenQA.Selenium.Chrome.ChromeDriver(chromeDriverService, new ChromeOptions());
            driver.Navigate().GoToUrl("https://gamdom.com/crash");
        }

        public void Infinity_cheak() //проверка на конец партии
        {
            //access = 0;
            try { Hash = driver.FindElement(By.XPath("(//INPUT[@type='input'])")).GetAttribute("value").ToString(); 

            do { } while (Hash == driver.FindElement(By.XPath("(//INPUT[@type='input'])")).GetAttribute("value").ToString());
            }
            catch { RobotLogs.Add("ERROR: Чтение HASH — " + System.DateTime.Now.ToLongTimeString()); }
            //access = 1;
            Console.WriteLine(cheak_win(st.crash));
            Thread.Sleep(500);

        }
        public void Bet(int rate, double crash) //ставим
        {
            Thread.Sleep(1200);
            var txtBet = driver.FindElement(By.Name("bet-size"));//находим элемент "кол-во ставки"
            try
            {
                txtBet.Clear();
                txtBet.SendKeys(Convert.ToString(rate));
            }
            catch { }
            Thread.Sleep(500);
            var txtBetC = driver.FindElement(By.Name("cash-out"));//находим элемент "коеф на вывод"
            try
            {
                txtBetC.Clear();
                txtBetC.SendKeys(Convert.ToString(crash));
            }
            catch { }
            Thread.Sleep(1000);
            try
            {
                var BetClick = driver.FindElement(By.XPath("//SPAN[text()='Place Bet']"));//ставим
                BetClick.Click();
            }
            catch { }
        }
        public bool cheak_win(double crash) //проверка на победку
        {
            try { koef = driver.FindElement(By.XPath("//a[@href='#']/self::a")).Text; } catch { } //парсим последний коэф
            koef = koef.Remove(koef.Length - 1);
            koef = koef.Replace('.', ',');
            dkoef = Double.Parse(koef);
            if (dkoef >= crash) return true;
            return false;
        }
    }
}
