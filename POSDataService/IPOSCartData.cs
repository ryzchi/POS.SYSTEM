using System.Collections.Generic;
using POSCommon;

namespace POSDataService
{
    public interface IPOSCartData
    {
        List<CartItems> GetAllItems(string user);                 
        void AddItem(string user, string itemName, double price); 
        bool RemoveItem(int index, string user);                 
        void ClearCart(string user);                           
    }
}
