using System;
using System.Collections.Generic;
using System.IO;

namespace POSDataService
{
    public class POSTextFile
    {
        private string filePath = "cart.txt";

        public List<(string Name, double Price, int Quantity)> GetCartItemsFromText()
        {
            var items = new List<(string, double, int)>();

            if (!File.Exists(filePath)) return items;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split('|');
                if (parts.Length == 3 &&
                    double.TryParse(parts[1], out double price) &&
                    int.TryParse(parts[2], out int quantity))
                {
                    items.Add((parts[0], price, quantity));
                }
            }

            return items;
        }

        public void SaveCartItemToText(string name, double price, int quantity)
        {
            string line = $"{name}|{price}|{quantity}";
            File.AppendAllLines(filePath, new[] { line });

            Console.WriteLine("Saved to TEXT at: " + Path.GetFullPath(filePath));
        }
    }
}
