using System;
using System.Collections.Generic;
using System.Linq;
using POSCommon;

namespace POSDataService
{
    public class POSInMemoryCart : IPOSCartData
    {
        private Dictionary<string, List<CartItems>> userCarts = new();

        public POSInMemoryCart()
        {
            DefaultData("admin");
        }

        private void DefaultData(string user)
        {
            userCarts[user] = new List<CartItems>
            {
                new CartItems("Milk Tea", 120),
                new CartItems("Fries", 65),
                new CartItems("Burger", 99)
            };
        }

        public void AddItem(string user, string itemName, double price)
        {
            if (!userCarts.ContainsKey(user))
                userCarts[user] = new List<CartItems>();

            userCarts[user].Add(new CartItems(itemName, price));
        }

        public List<CartItems> GetAllItems(string user)
        {
            if (userCarts.ContainsKey(user))
                return userCarts[user];

            return new List<CartItems>();
        }

        public bool RemoveItem(int index, string user)
        {
            if (userCarts.ContainsKey(user) && index >= 0 && index < userCarts[user].Count)
            {
                userCarts[user].RemoveAt(index);
                return true;
            }
            return false;
        }

        public void ClearCart(string user)
        {
            if (userCarts.ContainsKey(user))
                userCarts[user].Clear();
        }
    }
}
