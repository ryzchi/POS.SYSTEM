using POSCommon;
using POSDataService;
using System.Collections.Generic;

namespace POSBusinessLogic
{
    public class POSManager
    {
        private DBCartManager db = new DBCartManager();
        private POSTextFile textFile = new POSTextFile();
        private POSJsonFile jsonFile = new POSJsonFile();

        public void AddItem(string name, double price, int quantity)
        {
            CartItems item = new CartItems(name, price, quantity);

            // Save to Database
            db.AddToCart(item);

            // Save to text and json 
            textFile.SaveCartItemToText(name, price, quantity);
            jsonFile.SaveCartItemToJson(name, price, quantity);
        }

        public bool RemoveItem(string name)
        {
            return db.RemoveItem(name);
        }

        public List<CartItems> ViewItems()
        {
            return db.ViewCart();
        }

        public void Checkout()
        {
            db.ClearCart();
        }
    }
}
