using POSCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSDataService
{
    public class POSTextFile : IPOSAccData
    {
        string filePath = "pos.txt";
        List<POSAccount> accounts = new List<POSAccount>();

        public POSTextFile()
        {
            GetDataFromFile();
        }

        private void GetDataFromFile()
        {
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var part = line.Split('|');

                accounts.Add(new POSAccount
                {
                    Username = part[0],
                    Password = part[1],
                });
            }
        }

        public List<POSAccount> GetAccounts()
        {
            return accounts;
        }
    }
}
