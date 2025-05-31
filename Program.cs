using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using POSBusinessDataLogic;

public class POSSystem
{
    static List<string> cart = new List<string>();
    static List<double> prices = new List<double>();
    static POSProcess account = new POSProcess();
    private static string connectionString = "Data Source=LAPTOP-ALICAWAY\\SQLEXPRESS01;Initial Catalog=DB_POS;Integrated Security=True;TrustServerCertificate=True;";

    static void Main()
    {
        string Username, Password;
        Console.WriteLine("Welcome to the Point of Sale System!");

        do
        {
            Console.Write("Username: ");
            Username = Console.ReadLine().Trim();
            Console.Write("Password: ");
            Password = Console.ReadLine().Trim();

            // Login validation
            if (!account.LogInValid(Username, Password))
            {
                Console.WriteLine("Invalid Username or Password.");

                if (account.LogInAttempts())
                {
                    Console.WriteLine("Too many attempts. Please try again later.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Welcome, Admin!");
                MainMenu();
                return;
            }

        } while (true);
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

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            Console.WriteLine("🔌 Using connection: " + connectionString);
            conn.Open();

            Console.WriteLine("✅ Connected to database: " + conn.Database);
            Console.WriteLine("🖥️ Server: " + conn.DataSource);

            string checkDbQuery = "SELECT DB_NAME() AS DbName, @@SERVERNAME AS ServerName";
            SqlCommand identityCmd = new SqlCommand(checkDbQuery, conn);
            SqlDataReader idReader = identityCmd.ExecuteReader();
            if (idReader.Read())
            {
                Console.WriteLine($"🎯 Actual DB: {idReader["DbName"]}, Server: {idReader["ServerName"]}");
            }
            idReader.Close();

            string query = "INSERT INTO Cart (ItemName, ItemPrice) VALUES (@itemName, @itemPrice)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@itemName", itemName);
            cmd.Parameters.AddWithValue("@itemPrice", itemPrice);
            cmd.ExecuteNonQuery();
        }

        Console.WriteLine("✅ Item added to cart successfully.");
    }

    static List<(int Id, string Name, double Price)> GetCartItems()
    {
        var cartItems = new List<(int, string, double)>();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT Id, ItemName, ItemPrice FROM Cart";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["Id"];
                string name = reader["ItemName"].ToString();
                double price = Convert.ToDouble(reader["ItemPrice"]);
                cartItems.Add((id, name, price));
            }
        }

        return cartItems;
    }

    static void RemoveItem()
    {
        var cartItems = GetCartItems();

        if (cartItems.Count == 0)
        {
            Console.WriteLine("Cart is empty. Nothing to remove.");
            return;
        }

        ViewCart();
        Console.Write("Enter the number of the item to remove: ");

        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > cartItems.Count)
        {
            Console.WriteLine("Invalid item number. Please try again.");
            return;
        }

        int idToRemove = cartItems[index - 1].Id;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "DELETE FROM Cart WHERE Id = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", idToRemove);
            cmd.ExecuteNonQuery();
        }

        Console.WriteLine("Item removed from cart.");
    }

    static void ViewCart()
    {
        var cartItems = GetCartItems();

        Console.WriteLine("\n🛒 Cart Items:");
        if (cartItems.Count == 0)
        {
            Console.WriteLine("Cart is empty.");
        }
        else
        {
            double total = 0;
            for (int i = 0; i < cartItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cartItems[i].Name} = Php{cartItems[i].Price:F2}");
                total += cartItems[i].Price;
            }
            Console.WriteLine($"🧾 Total: Php{total:F2}");
        }
    }

    static void Checkout()
    {
        var cartItems = GetCartItems();

        if (cartItems.Count == 0)
        {
            Console.WriteLine("Cart is empty. Nothing to checkout.");
            return;
        }

        ViewCart();
        Console.WriteLine("Proceeding to checkout...");

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "DELETE FROM Cart";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
        }

        Console.WriteLine("Checkout complete. Cart is now empty.");
    }
}
