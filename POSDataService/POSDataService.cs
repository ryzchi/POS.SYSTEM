using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSCommon;

namespace POSDataService
{
    public class POSDataService
    {
        List<POSAccount> account = new List<POSAccount>();

        public POSDataService()
        {
            CreateAccounts();
        }
        private void CreateAccounts()
        {
            account.Add(new POSAccount
            {
                Username = "admin",
                Password = "admin123",
            });
        }
        public bool ValidateUserAccount(string username, string password)
        {
            foreach (var account in account)
            {
                if (account.Username == username && account.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
