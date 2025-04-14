using System;
namespace POS.BusinessDataLogic
{
    public class POSProcess
    {
        POSDataService.POSDataService account = new POSDataService.POSDataService();
        static short loginAttempts = 0;

        public bool LogInValid(string userInput, string passInput)
        {
            return account.ValidateUserAccount(userInput, passInput);
        }

        public bool LogInAttempts()
        {
            loginAttempts++;

            if (loginAttempts == 3)
            {
                loginAttempts = 0;
                return true;
            }
            return false;
        }
    }
}
