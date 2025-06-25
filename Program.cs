using POSBusinessLogic;
using POSCommon;
using System;
using System.Collections.Generic;
using System.Threading;

namespace POSSystem
{
    public class Program
    {
        static POSManager manager = new POSManager();

        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            int userAction;
            do
            {
                Console.WriteLine("\n===== POINT OF SALE SYSTEM =====");
                string[] actions = new string[] { "[1] Add Item", "[2] Remove Item", "[3] View Cart", "[4] Checkout", "[5] Exit" };

                foreach (var action in actions)
                {
                    Console.WriteLine(action);
                }

                Console.Write("Enter Action: ");
                if (!int.TryParse(Console.ReadLine(), out userAction))
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1-5.");
                    continue;
                }

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
            } while (userAction != 5);
        }

        static void AddItem()
        {
            Console.Write("Enter item name: ");
            string? name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Item name cannot be empty. Press Enter to retry.");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter price: ");
            string? priceInput = Console.ReadLine();

            if (double.TryParse(priceInput, out double price))
            {
                manager.AddItem(name, price);
                Console.WriteLine("Item added! Press Enter to continue.");
            }
            else
            {
                Console.WriteLine("Invalid price. Press Enter to retry.");
            }

            Console.ReadLine();
        }

        static void RemoveItem()
        {
            List<CartItems> items = manager.ViewItems();

            if (items.Count == 0)
            {
                Console.WriteLine("Cart is empty. No item to remove. Press Enter to return to menu.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("\nSelect item to remove:");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i].ItemName} - Php {items[i].Price:F2}");
            }
            Console.Write("Enter item number: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= items.Count)
            {
                string name = items[choice - 1].ItemName;
                bool success = manager.RemoveItem(name);
                if (success)
                {
                    Console.WriteLine("Item removed. Press Enter to continue.");
                }
                else
                {
                    Console.WriteLine("Item already removed or not found. Press Enter to continue.");
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Press Enter to continue.");
            }
            Console.ReadLine();
        }

        static void ViewCart()
        {
            List<CartItems> items = manager.ViewItems();
            Console.WriteLine("\n--- Cart Items ---");

            if (items.Count == 0)
            {
                Console.WriteLine("Cart is empty.");
            }
            else
            {
                double total = 0;
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {items[i].ItemName} - Php {items[i].Price:F2}");
                    total += items[i].Price;
                }
                Console.WriteLine($"Total: Php {total:F2}");
            }

            Console.WriteLine("\nPress Enter to continue.");
            Console.ReadLine();
        }

        static void Checkout()
        {
            List<CartItems> items = manager.ViewItems();
            if (items.Count == 0)
            {
                Console.WriteLine("Cart is empty. Nothing to checkout. Press Enter to return to menu.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Checking out... Please wait.");
            Thread.Sleep(3000); 
            manager.Checkout();
            Console.WriteLine("Cart cleared! Press Enter to return to menu.");
            Console.ReadLine();
        }
    }
}
