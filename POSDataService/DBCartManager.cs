using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using POSCommon;

namespace POSDataService
{
    public class DBCartManager
    {
        private string connectionString = "Data Source=LAPTOP-ALICAWAY\\SQLEXPRESS01;Initial Catalog=DB_POS;Integrated Security=True;TrustServerCertificate=True;";

        public void AddToCart(CartItems item)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Cart (ItemName, ItemPrice) VALUES (@ItemName, @Price)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ItemName", item.ItemName);
                cmd.Parameters.AddWithValue("@Price", item.Price);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public bool RemoveItem(string itemName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Cart WHERE ItemName = @ItemName";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ItemName", itemName);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0; // ✅ TRUE if deleted
            }
        }

        public List<CartItems> ViewCart()
        {
            List<CartItems> cart = new List<CartItems>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ItemName, ItemPrice FROM Cart";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string itemName = reader.GetString(0);
                    double price = reader.GetDouble(1);
                    cart.Add(new CartItems(itemName, price));
                }
            }
            return cart;
        }

        public void ClearCart()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Cart";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
