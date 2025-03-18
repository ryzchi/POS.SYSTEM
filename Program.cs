class POSSystem
{
    static List<string> cart = new List<string>();
    static List<double> prices = new List<double>();

    const string ADMIN_USERNAME = "admin";
    const string ADMIN_PASSWORD = "admin123";

    static void Main()
    {
        Console.WriteLine("Welcome to the Point of Sale System!");
        if (Login())
        {
            MainMenu();
        }
        else
        {
            Console.WriteLine("Login failed. Exiting system.");
        }
    }

    static bool Login()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        if (username == ADMIN_USERNAME && password == ADMIN_PASSWORD)
        {
            Console.WriteLine("Welcome, Admin!");
            return true;
        }
        else
        {
            Console.WriteLine("Invalid credentials.");
            return false;
        }
    }

    static void MainMenu()
    {
        int userAction;
        do
        {
            Console.WriteLine("\nMain Menu:");

            string[] actions = new string[] { "[1] Add Item", "[2] Remove Item", "[3] View Cart", "[4] Checkout", "[5] Exit" };

            foreach (var action in actions)

            {
                Console.WriteLine(action);
                continue;
            }

            Console.Write("Enter Action: ");

            userAction = Convert.ToInt16(Console.ReadLine());

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
        string itemName = Console.ReadLine();
        Console.Write("Enter item price: ");

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
        if (cart.Count == 0)
        {
            Console.WriteLine("Cart is empty. Nothing to remove.");
            return;
        }

        ViewCart();
        Console.Write("Enter the number of the item to remove: ");

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
        if (cart.Count == 0)
        {
            Console.WriteLine("Cart is empty.");
        }
        else
        {
            double total = 0;
            for (int i = 0; i < cart.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cart[i]} = Php{prices[i]:F2}");
                total += prices[i];
            }
            Console.WriteLine($"Total: Php{total:F2}");
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

