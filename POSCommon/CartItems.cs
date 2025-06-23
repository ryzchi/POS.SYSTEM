namespace POSCommon
{
    public class CartItems
    {
        public string ItemName { get; set; }
        public double Price { get; set; }

        public CartItems(string itemName, double price)
        {
            ItemName = itemName;
            Price = price;
        }
    }
}
