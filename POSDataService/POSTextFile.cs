using System;
using System.Collections.Generic;
using System.IO;

namespace POSDataService
{
    public class POSTextFileCart
    {
        private string filePath = "cart.txt";

        public List<(string Name, double Price)> GetCartItemsFromText()
        {
            var items = new List<(string, double)>();

            if (!File.Exists(filePath)) return items;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split('|');
                if (parts.Length == 2 && double.TryParse(parts[1], out double price))
                {
                    items.Add((parts[0], price));
                }
            }

            return items;
        }
    }
}
