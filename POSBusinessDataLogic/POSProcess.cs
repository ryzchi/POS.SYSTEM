using POSCommon;
using POSDataService;

namespace POSBusinessDataLogic
{
    public class POSProcess
    {

        IPOSAccData AccountData = new POSMemoryData();
        static short loginAttempts = 0;

        public bool LogInValid(string userInput, string passInput)
        {
            var account = GetPOSAccount(userInput, passInput);

            if (account.Username != null)
            {
                return true;
            }

            return false;
        }

        private POSAccount GetPOSAccount(string username, string password)
        {
            var POSAccounts = AccountData.GetAccounts();

            foreach (var account in POSAccounts)
            {
                if (account.Username == username && account.Password == password)
                {
                    return account;
                }
            }

            return new POSAccount();
        }


        public bool LogInAttempts()
        {
            loginAttempts++;

            if (loginAttempts == 5)
            {
                loginAttempts = 0;
                return true;
            }

            return false;
        }



    }
}
