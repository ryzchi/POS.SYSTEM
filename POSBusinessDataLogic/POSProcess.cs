namespace POS.BusinessDataLogic
{
    public class POSProcess
    {
        // Login validation  
        POSDataService.POSDataService account = new POSDataService.POSDataService(); // Add namespace here
        static short loginAttempts = 0;  // Track login attempts  

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
