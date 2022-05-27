using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;

namespace AutomationTestFramework
{
    [TestClass]
    public class TestExecution
    {
        #region Setups and Cleanups
        public TestContext instance;

        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [ClassInitialize()]

        public static void ClassInit(TestContext context)
        {

        }
        [ClassCleanup()]
        public static void ClassCleanup()
        {

        }

        [TestInitialize()]
        public void TestInit()
        {
            CorePage.SeleniumInit(ConfigurationManager.AppSettings["Browser"].ToString());
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            CorePage.driver.Close();
        }
        #endregion


        LoginPage loginPage = new LoginPage();
        InventoryPage inventoryPage = new InventoryPage();
        InventoryItem inventoryItem = new InventoryItem();


        [TestMethod]
        [TestCategory("Login")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML","Data.xml", "LoginWithValidUserValidPassword_TC001", DataAccessMethod.Sequential)]
        public void LoginWithValidUserValidPassword_TC001()
        {
            string url = TestContext.DataRow["url"].ToString();
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();


            loginPage.Login(url, user, pass);
            string actualText = CorePage.driver.FindElement(By.ClassName("title")).Text;
            Assert.AreEqual("PRODUCTS", actualText);
            
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "LoginWithInValidUserInValidPassword_TC002", DataAccessMethod.Sequential)]
        public void LoginWithInValidUserInValidPassword_TC002()
        {

            string url = TestContext.DataRow["url"].ToString();
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();

            loginPage.Login(url, user, pass);
            string actualText = CorePage.driver.FindElement(By.CssSelector("div.login_wrapper div.login_wrapper-inner div.form_column div.login-box form:nth-child(1) div.error-message-container.error:nth-child(3) > h3:nth-child(1)")).Text;
            Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", actualText);
            
        }

        [TestMethod]

        public void Filters_TC003()
        {
            
            loginPage.Login("https://www.saucedemo.com/", "standard_user", "secret_sauce");
            inventoryPage.Filters("az");
            inventoryPage.Filters("za");
            inventoryPage.Filters("lohi");
            inventoryPage.Filters("hilo");
            
        }

        [TestMethod]
        public void SelectItem_TC004()
        {
            
            loginPage.Login("https://www.saucedemo.com/", "standard_user", "secret_sauce");
            inventoryItem.SelectItem();
            string actualText = CorePage.driver.FindElement(By.Id("remove-sauce-labs-backpack")).Text;
            Assert.AreEqual("REMOVE", actualText);
            
        }

    }
}
