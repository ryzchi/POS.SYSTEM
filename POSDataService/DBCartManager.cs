using Microsoft.Data.SqlClient;
using POSCommon;
using System;
using System.Collections.Generic;

namespace POSDataService
{
    public class DBCartManager
    {
        private readonly string connectionString = "Data Source=LAPTOP-ALICAWAY\\SQLEXPRESS01;Initial Catalog=DB_POS;Integrated Security=True;TrustServerCertificate=True;";

        public void AddToCart(CartItems item)
        {
            if (item == null || string.IsNullOrWhiteSpace(item.ItemName)) return;

            using SqlConnection conn = new SqlConnection(connectionString);
            string query = "INSERT INTO Cart (ItemName, ItemPrice) VALUES (@ItemName, @Price)";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ItemName", item.ItemName);
            cmd.Parameters.AddWithValue("@Price", item.Price);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public bool RemoveItem(string itemName)
        {
            if (string.IsNullOrWhiteSpace(itemName)) return false;

            using SqlConnection conn = new SqlConnection(connectionString);
            string query = "DELETE FROM Cart WHERE ItemName = @ItemName";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ItemName", itemName);
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public List<CartItems> ViewCart()
        {
            List<CartItems> cart = new List<CartItems>();

            using SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT ItemName, ItemPrice FROM Cart";
            using SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string itemName = reader["ItemName"]?.ToString() ?? "";
                double price = reader["ItemPrice"] is double p ? p : Convert.ToDouble(reader["ItemPrice"]);
                cart.Add(new CartItems(itemName, price));
            }

            return cart;
        }

        public void ClearCart()
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            string query = "DELETE FROM Cart";
            using SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
