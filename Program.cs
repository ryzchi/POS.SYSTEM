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
                string[] actions = new string[]
                {
                    "[1] Add Item", "[2] Remove Item", "[3] View Cart", "[4] Checkout", "[5] Exit"
                };

                foreach (var action in actions)
                {
                    Console.WriteLine(action);
                }

                Console.Write("Enter Action: ");
                if (!int.TryParse(Console.ReadLine(), out userAction))
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1-5.");
                    Thread.Sleep(1500);
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
            Console.WriteLine("=== Add Item ===");

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

            if (!double.TryParse(priceInput, out double price))
            {
                Console.WriteLine("Invalid price. Press Enter to retry.");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter quantity: ");
            string? qtyInput = Console.ReadLine();

            if (!int.TryParse(qtyInput, out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid quantity. Press Enter to retry.");
                Console.ReadLine();
                return;
            }

            manager.AddItem(name, price, quantity);
            Console.WriteLine("Item added! Press Enter to continue.");
            Console.ReadLine();
        }

        static void RemoveItem()
        {
            List<CartItems> items = manager.ViewItems();

            if (items.Count == 0)
            {
                Console.WriteLine("Cart is empty. No item to remove. Press Enter to return.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("=== Remove Item ===");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i].ItemName} x{items[i].Quantity} - Php {items[i].Price:F2}");
            }

            Console.Write("Enter item number to remove: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= items.Count)
            {
                string name = items[choice - 1].ItemName;
                bool success = manager.RemoveItem(name);
                Console.WriteLine(success
                    ? "Item removed. Press Enter to continue."
                    : "Item not found. Press Enter to continue.");
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

            Console.WriteLine("=== View Cart ===");

            if (items.Count == 0)
            {
                Console.WriteLine("Cart is empty.");
            }
            else
            {
                double total = 0;
                for (int i = 0; i < items.Count; i++)
                {
                    double subtotal = items[i].Price * items[i].Quantity;
                    Console.WriteLine($"{i + 1}. {items[i].ItemName} x{items[i].Quantity} - Php {items[i].Price:F2} each | Subtotal: Php {subtotal:F2}");
                    total += subtotal;
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
                Console.WriteLine("Cart is empty. Nothing to checkout.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Checking out...");
            Thread.Sleep(2000);
            manager.Checkout();

            Console.WriteLine("Checkout complete. Cart cleared. Press Enter to continue.");
            Console.ReadLine();
        }
    }
}
