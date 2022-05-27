using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTestFramework
{
    public class InventoryPage : CorePage
    {
        #region Locators
        By productName = By.ClassName("inventory_item_name");
        By productDesc = By.ClassName("inventory_item_desc");
        By productPrice = By.ClassName("inventory_item_price");
        By addtocartBtn = By.CssSelector("#add-to-cart-sauce-labs-backpack");
        By filter = By.ClassName("product_sort_container");
        #endregion
        /*
        public void ProductsCount()
        {
            IList<IWebElement> elements = driver.FindElements(productName);
           // for (IWebElement e: elements)
          //  {
            //    ;
           // }
        }
        public void AddtoCart()
        {
            driver.FindElements(addtocartBtn);
        }*/
        public void Filters(string filterDrpDwnValue)
        {
            var allFilters = driver.FindElement(filter);
            
            var selectElement = new SelectElement(allFilters);
            selectElement.SelectByValue(filterDrpDwnValue);
        }
    }
}
