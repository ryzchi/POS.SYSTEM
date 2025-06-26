using POSCommon;
using POSDataService;
using System.Collections.Generic;

namespace POSBusinessLogic
{
    public class POSManager
    {
        private DBCartManager db = new DBCartManager();

        public void AddItem(string name, double price, int quantity)
        {
            CartItems item = new CartItems(name, price, quantity);
            db.AddToCart(item);
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
