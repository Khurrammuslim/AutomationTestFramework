using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTestFramework
{
    public class InventoryItem : CorePage
    {
        #region Locators
        By firstProduct = By.CssSelector("div.page_wrapper div.inventory_container div.inventory_list div.inventory_item:nth-child(1) div.inventory_item_description div.inventory_item_label a:nth-child(1) > div.inventory_item_name");
       // By invName = By.ClassName("inventory_details_name large_size");
       // By invDetais = By.ClassName("inventory_details_desc large_size");
       // By invPrice = By.ClassName("inventory_details_price");
       // By bckBtn = By.ClassName("back-to-products");
        By addtocartBtnItem = By.CssSelector("#add-to-cart-sauce-labs-backpack");
        #endregion

        public void SelectItem()
        {
            driver.FindElement(firstProduct).Click();
            driver.FindElement(addtocartBtnItem).Click();
        }
    }
}
