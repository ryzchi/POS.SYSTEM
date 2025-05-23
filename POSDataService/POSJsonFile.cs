using POSCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace POSDataService
{
    public class POSJsonFile : IPOSAccData
    {
        static List<POSAccount> accounts = new List<POSAccount>();
        static string jsonFilePath = "accounts.json";

        public POSJsonFile()
        {
            GetDataFromJsonFile();
        }

        private void GetDataFromJsonFile()
        {
            string jsonText = File.ReadAllText(jsonFilePath);

            accounts = JsonSerializer.Deserialize<List<POSAccount>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
        }

        public List<POSAccount> GetAccounts()
        {
            return accounts;
        }
    }
}
