namespace POSWebAPI.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; } = "";
        public double ItemPrice { get; set; }
        public int Quantity { get; set; }
    }
}
