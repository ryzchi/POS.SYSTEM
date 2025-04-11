using System;
using System.Collections.Generic;
using POS.BusinessDataLogic;

public class POSSystem
{
    static List<string> cart = new List<string>();  // List to store cart items  
    static List<double> prices = new List<double>();  // List to store item prices  
<<<<<<< HEAD
    static POS.BusinessDataLogic.POSProcess account = new POS.BusinessDataLogic.POSProcess();

    static void Main()
    {
        string Username, Password;
=======

    static void Main()
    {
>>>>>>> b8cf9e30921696de99513a5610668c0ac27b2b84
        Console.WriteLine("Welcome to the Point of Sale System!");

        do
        {
<<<<<<< HEAD
            Console.Write("Username: ");
            Username = Console.ReadLine();
            Console.Write("Password: ");
            Password = Console.ReadLine();

            if (!account.LogInValid(Username, Password))
            {
                Console.WriteLine("Invalid Username or Password.");

                if (account.LogInAttempts())
                {
                    Console.WriteLine("Too many attempts. Please try again later.");
                    return;
=======
            // Ask for username and password  
            Console.WriteLine("Username: ");
            string inputUsername = Console.ReadLine();
            Console.WriteLine("Password: ");
            string inputPassword = Console.ReadLine();

            if (!POSProcess.LogInValid(inputUsername, inputPassword))
            {
                Console.WriteLine("Your Username or Password is invalid. Please check your details carefully.");

                // Check if the 3 attempts limit is reached
                if (POSProcess.LogInAttempts())
                {
                    Console.WriteLine("You have reached the maximum login attempts. Please try again later.");
                    return;  // Exit after 3 failed attempts
>>>>>>> b8cf9e30921696de99513a5610668c0ac27b2b84
                }
            }
            else
            {
                Console.WriteLine("Welcome, Admin!");
                MainMenu();  // Login successful, proceed to main menu
                return;
            }
<<<<<<< HEAD

        } while (true); 
    }

        static void MainMenu()
=======
        } while (true);  // Keep looping until login is successful or 3 attempts are reached
    }
    static void MainMenu()
>>>>>>> b8cf9e30921696de99513a5610668c0ac27b2b84
    {
        int userAction;
        do
        {
            Console.WriteLine("\nMain Menu:");

            // Define menu options  
            string[] actions = new string[] { "[1] Add Item", "[2] Remove Item", "[3] View Cart", "[4] Checkout", "[5] Exit" };

            // Display each action in the menu  
            foreach (var action in actions)
            {
                Console.WriteLine(action);
                continue;
            }

            // Ask user to choose an action  
            Console.Write("Enter Action: ");
            userAction = Convert.ToInt16(Console.ReadLine());

            // Handle user's choice  
            switch (userAction)
            {
                case 1:
                    AddItem();
                    break;
                case 2:
                    RemoveItem();
                    break;
                case 3:
                    ViewCart();
                    break;
                case 4:
                    Checkout();
                    break;
                case 5:
                    Console.WriteLine("Exiting system. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (userAction != 5);  // Loop until user chooses to exit  
    }

    static void AddItem()
    {
        Console.Write("Enter item name: ");
        string itemName = Console.ReadLine();
        Console.Write("Enter item price: ");

        // Validate item price input  
        if (!double.TryParse(Console.ReadLine(), out double itemPrice))
        {
            Console.WriteLine("Invalid price input. Please try again.");
            return;
        }

        cart.Add(itemName);
        prices.Add(itemPrice);

        Console.WriteLine("Item added to cart successfully.");
    }

    static void RemoveItem()
    {
        // Check if the cart is empty  
        if (cart.Count == 0)
        {
            Console.WriteLine("Cart is empty. Nothing to remove.");
            return;
        }

        ViewCart();
        Console.Write("Enter the number of the item to remove: ");

        // Validate item number input  
        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > cart.Count)
        {
            Console.WriteLine("Invalid item number. Please try again.");
            return;
        }

        string removedItem = cart[index - 1];
        cart.RemoveAt(index - 1);
        prices.RemoveAt(index - 1);
        Console.WriteLine($"Removed {removedItem} from the cart.");
    }

    static void ViewCart()
    {
        Console.WriteLine("\nCart Items:");
        if (cart.Count == 0)  // Check if cart is empty  
        {
            Console.WriteLine("Cart is empty.");
        }
        else
        {
            double total = 0;  // Initialize total price  
            for (int i = 0; i < cart.Count; i++)
            {
                // Display item name and price  
                Console.WriteLine($"{i + 1}. {cart[i]} = Php{prices[i]:F2}");
                total += prices[i];  // Calculate total  
            }
            Console.WriteLine($"Total: Php{total:F2}");  // Display total price  
        }
    }

    static void Checkout()
    {
        if (cart.Count == 0)
        {
            Console.WriteLine("Cart is empty. Nothing to checkout.");
            return;
        }

        ViewCart();
        Console.WriteLine("Proceeding to checkout...");
        cart.Clear();
        prices.Clear();
        Console.WriteLine("Checkout complete. Cart is now empty.");
    }
}
