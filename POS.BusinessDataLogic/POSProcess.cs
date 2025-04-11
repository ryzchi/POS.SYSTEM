using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BusinessDataLogic
{
    public class POSProcess
    {
        // Login validation  
        static string ADMIN_USERNAME = "admin", ADMIN_PASSWORD = "admin123";
        static short loginAttempts = 0;  // Track login attempts  

        // Check if the entered username and password are valid  
        public static bool LogInValid(string userInput, string passInput)
        {
            return userInput == ADMIN_USERNAME && passInput == ADMIN_PASSWORD;  // Returns true if match  
        }

        // Track the number of failed login attempts  
        public static bool LogInAttempts()
        {
            loginAttempts++;  // Increment login attempts  

            if (loginAttempts == 3)  // Check if attempts reach the limit
            {
                loginAttempts = 0;  // Reset attempts after reaching limit  
                return true;  
            }

            return false;
        }
    }
}
