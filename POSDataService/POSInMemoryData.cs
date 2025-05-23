using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSCommon;

namespace POSDataService
{
    public class POSInMemoryData : IPOSAccData
    {
        List<POSAccount> accounts = new List<POSAccount>();
        public POSInMemoryData()
        {
            CreateAccounts();
        }
        private void CreateAccounts()
        {
            accounts.Add(new POSAccount
            {
                Username = "admin",
                Password = "admin123",
        });

            accounts.Add(new POSAccount
            {
                Username = "cashier",
                Password = "cashier123",
            });
        }
        public List<POSAccount> GetAccounts()
        {
            return accounts;
        }
    }
}