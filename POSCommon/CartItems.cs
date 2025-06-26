namespace POSCommon
{
    public class CartItems
    {
        public string ItemName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public CartItems(string itemName, double price, int quantity)
        {
            ItemName = itemName;
            Price = price;
            Quantity = quantity;
        }
    }
}
