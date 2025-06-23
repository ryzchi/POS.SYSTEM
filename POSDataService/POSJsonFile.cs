using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace POSDataService
{
    public class POSJsonFileCart
    {
        private string jsonFilePath = "cart.json";

        public List<(string Name, double Price)> GetCartItemsFromJson()
        {
            if (!File.Exists(jsonFilePath))
                return new List<(string, double)>();

            string jsonText = File.ReadAllText(jsonFilePath);
            return JsonSerializer.Deserialize<List<(string, double)>>(jsonText);
        }
    }
}
