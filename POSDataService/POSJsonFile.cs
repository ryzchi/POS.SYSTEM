using POSCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace POSDataService
{
    public class POSJsonFile
    {
        private string jsonFilePath = "cart.json";

        public List<CartItems> GetCartItemsFromJson()
        {
            if (!File.Exists(jsonFilePath))
                return new List<CartItems>();

            string jsonText = File.ReadAllText(jsonFilePath);
            return JsonSerializer.Deserialize<List<CartItems>>(jsonText);
        }

        public void SaveCartItemToJson(string name, double price, int quantity)
        {
            var items = GetCartItemsFromJson();
            items.Add(new CartItems(name, price, quantity));

            string jsonText = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonFilePath, jsonText);

            Console.WriteLine("Saved to JSON at: " + Path.GetFullPath(jsonFilePath));
        }
    }
}
