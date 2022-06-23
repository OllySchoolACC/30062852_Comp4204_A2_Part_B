using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30062852_Comp4204_A2_Part_B
{
    internal class Program // This application is going to be a tech store. All of the product information is from PB Tech.
    {
        public static int[] GiftCards = new int[] { 500, 1000, 2500, 5000, 7500, 10000 }; // 6 different giftcard values
        public static List<string> Cart = new List<string>(); // Add and remove items here (dynamically resizing)
        public static Random Rnd = new Random(); // Creates a random instance function
        public static string UserInput;
        public static string FirstName;
        public static string LastName;
        public static string NameConcat;
        public static decimal Bal;
        public static decimal Cost;
        public static void GiveAwayDisplay()
        {
            Console.ForegroundColor = ConsoleColor.Blue; // Makes the text blue
            Out(string.Format("\n\tWelcome to Forever Kiwi NZ retail tech store\t\t\t\tThe current time is {0:hh:mm tt}.\n\n\n\tPlease enter your First Name & Last Name to go into the draw to win.\n\n\tPrize: A giftcard ranging from $500 to $10,000 NZD.\n\n", DateTime.Now)); // Displays the time, also prompts the user to enter their First & Last Name

            Console.Write("\tFirst Name: "); // Prompts the user for their First Name
            FirstName = Console.ReadLine();
            Console.Write("\tLast Name: "); // Prompts the user for their Last Name
            LastName = Console.ReadLine();

            NameConcat = (char.ToUpper(FirstName[0]) + FirstName.Substring(1)) + " " + (char.ToUpper(LastName[0]) + LastName.Substring(1)); // Makes the first char of the First & Last Name uppercase and adds the substring to both the First & Last Name accordingly then stores the argument in the NameConcat Variable 
            Bal = GiftCards[Rnd.Next(GiftCards.Length)]; // Will store a random value ranging from 500 to 10,000 into the Bal Variable
            Out($"\n\n\tHello {NameConcat}, you have won a giftcard which value is ${Bal} NZD.\n\n\tPlease purchase what you would like from the categories below.\n"); // Will make you choose one of the random 6 gift cards priced from $500 - $10,000 NZD

            ItemsMenuDisplayAndProcessing1();
        }
        public static void CheckOutDisplay()
        {
            if (Bal < 0) // If Bal is less than zero it will give the user the **option** to add Funds to the Bal Variable
            {
                Out("Insufficient Funds\n\nEnter 1 to add funds\nEnter 2 to not add funds");
                UserInput = Console.ReadLine();
                if (UserInput == "1")
                { Bal += decimal.Parse(Console.ReadLine()); }
                if (UserInput == "2")
                { ItemsMenuDisplayAndProcessing1(); }
            }
            if (Cart.Count > 0)
            {
                if (Bal >= 0) // If Bal is greater than or equal to 0 it will display the CheckOut function
                {
                    Out($"{NameConcat}'s Shopping Cart:\n-----------------------------");
                    Out("Purchased Items:");
                    foreach (string temp in Cart)
                    { Console.Write(temp + ", "); }
                    Out("\n-----------------------------");
                    Out($"Balance ${Bal}");
                    Out($"Total Cost: ${Cost}\n-----------------------------");
                }
                RestartApplication();
            }
            if (Cart.Count <= 0) // Give the user the option to exit the application or go back through the product menu
            {
                Out("Enter 1  -  Continue Shopping\nEnter 2  -  Exit Application");
                CheckInput();

                if (UserInput == "1")
                { ItemsMenuDisplayAndProcessing1(); }
                if (UserInput == "2")
                { Environment.Exit(0); }
            }
        }
        public static void ItemsMenuDisplayAndProcessing1()
        {
            Out("\n\n\tEnter 1 - $1 Apple\n\tEnter 2 - $2 Pear\n\tEnter 3 - $3 Bananas\n\tEnter 4 - $4 Lime\n\tEnter 5 - $5 Grapes\n\tEnter 6 - $6 Kiwifruit" + // REPLACE THE TEMP ITEMS LATER HERE
            "\n\tEnter 7 - $7 Strawberries \n\tEnter 8 - $8 Mango\n\tEnter 9 - $9 Passionfruit\n\tEnter 10 - $10 Watermelon\n");

            UserInput = Console.ReadLine();
            while (UserInput != "1" && UserInput != "2" && UserInput != "2" && UserInput != "3" && UserInput != "4" && UserInput != "5" && UserInput != "6" && UserInput != "7" && UserInput != "8" && UserInput != "9" && UserInput != "10")
            {
                Out("\tInvalid Input, Try Again.");
                UserInput = Console.ReadLine();
            }
            Out("Enter 1  -  Add Item\nEnter 2  -  Remove Item");

            if (UserInput == "1") // 1st item which is Apple
            {
                Out($"{NameConcat}, you have selected Apple"); CheckInput();
                if (UserInput == "1") // Add an item
                { Cart.Add("Apple"); Bal -= 1; Cost += 1; Out($"{NameConcat}, you have added (Apple) to your Cart"); }
                if (UserInput == "2") // Remove an item
                {
                    if (Cart.Contains("Apple")) // If it doesn't contain the item it won't offset the variables Bal and Cost
                    { Cart.Remove("Apple"); Bal += 1; Cost -= 1; Out($"{NameConcat}, you have removed (Apple) from your Cart"); }
                }
                ItemsMenuDisplayAndProcessing2();
            }
            if (UserInput == "2") // 2nd item which is Pear
            {
                Out($"{NameConcat}, you have selected Pear"); CheckInput();
                if (UserInput == "1") 
                { Cart.Add("Pear"); Bal -= 2; Cost += 2; Out($"{NameConcat}, you have added (Pear) to your Cart"); }
                if (UserInput == "2") 
                {
                    if (Cart.Contains("Pear"))
                    { Cart.Remove("Pear"); Bal += 2; Cost -= 2; Out($"{NameConcat}, you have removed (Pear) from your Cart"); }
                }
                ItemsMenuDisplayAndProcessing2();
            }
            if (UserInput == "3") // 3rd item which is Bananas
            {
                Out($"{NameConcat}, you have selected Bananas"); CheckInput();
                if (UserInput == "1")
                { Cart.Add("Bananas"); Bal -= 3; Cost += 3; Out($"{NameConcat}, you have added (Bananas) to your Cart"); }
                if (UserInput == "2")
                {
                    if (Cart.Contains("Bananas"))
                    { Cart.Remove("Bananas"); Bal += 3; Cost -= 3; Out($"{NameConcat}, you have removed (Bananas) from your Cart"); }
                }
                ItemsMenuDisplayAndProcessing2();
            }
            if (UserInput == "4") // 4th item which is Lime
            {
                Out($"{NameConcat}, you have selected Lime"); CheckInput();
                if (UserInput == "1")
                { Cart.Add("Lime"); Bal -= 4; Cost += 4; Out($"{NameConcat}, you have added (Lime) to your Cart"); }
                if (UserInput == "2")
                {
                    if (Cart.Contains("Lime"))
                    { Cart.Remove("Lime"); Bal += 4; Cost -= 4; Out($"{NameConcat}, you have removed (Lime) from your Cart"); }
                }
                ItemsMenuDisplayAndProcessing2();
            }
            if (UserInput == "5") // 5th item which is Grapes
            {
                Out($"{NameConcat}, you have selected Grapes"); CheckInput();
                if (UserInput == "1")
                { Cart.Add("Grapes"); Bal -= 5; Cost += 5; Out($"{NameConcat}, you have added (Grapes) to your Cart"); }
                if (UserInput == "2")
                {
                    if (Cart.Contains("Grapes"))
                    { Cart.Remove("Grapes"); Bal += 5; Cost -= 5; Out($"{NameConcat}, you have removed (Grapes) from your Cart"); }
                }
                ItemsMenuDisplayAndProcessing2();
            }
            if (UserInput == "6") // 6th item which is Kiwifruit
            {
                Out($"{NameConcat}, you have selected Kiwifruit"); CheckInput();
                if (UserInput == "1")
                { Cart.Add("Kiwifruit"); Bal -= 6; Cost += 6; Out($"{NameConcat}, you have added (Kiwifruit) to your Cart"); }
                if (UserInput == "2")
                {
                    if (Cart.Contains("Kiwifruit"))
                    { Cart.Remove("Kiwifruit"); Bal += 6; Cost -= 6; Out($"{NameConcat}, you have removed (Kiwifruit) from your Cart"); }
                }
                ItemsMenuDisplayAndProcessing2();
            }
            if (UserInput == "7") // 7th item which is Strawberries
            {
                Out($"{NameConcat}, you have selected Strawberries"); CheckInput();
                if (UserInput == "1")
                { Cart.Add("Strawberries"); Bal -= 7; Cost += 7; Out($"{NameConcat}, you have added (Strawberries) to your Cart"); }
                if (UserInput == "2")
                {
                    if (Cart.Contains("Strawberries"))
                    { Cart.Remove("Strawberries"); Bal += 7; Cost -= 7; Out($"{NameConcat}, you have removed (Strawberries) from your Cart"); }
                }
                ItemsMenuDisplayAndProcessing2();
            }
            if (UserInput == "8") // 8th item which is Mango
            {
                Out($"{NameConcat}, you have selected Mango"); CheckInput();
                if (UserInput == "1")
                { Cart.Add("Mango"); Bal -= 8; Cost += 8; Out($"{NameConcat}, you have added (Mango) to your Cart"); }
                if (UserInput == "2")
                {
                    if (Cart.Contains("Mango"))
                    { Cart.Remove("Mango"); Bal += 8; Cost -= 8; Out($"{NameConcat}, you have removed (Mango) from your Cart"); }
                }
                ItemsMenuDisplayAndProcessing2();
            }
            if (UserInput == "9") // 9th item which is Passionfruit
            {
                Out($"{NameConcat}, you have selected Passionfruit"); CheckInput();
                if (UserInput == "1")
                { Cart.Add("Passionfruit"); Bal -= 9; Cost += 9; Out($"{NameConcat}, you have added (Passionfruit) to your Cart"); }
                if (UserInput == "2")
                {
                    if (Cart.Contains("Passionfruit"))
                    { Cart.Remove("Passionfruit"); Bal += 9; Cost -= 9; Out($"{NameConcat}, you have removed (Passionfruit) from your Cart"); }
                }
                ItemsMenuDisplayAndProcessing2();
            }
            if (UserInput == "10") // 10th item which is Watermelon
            {
                Out($"{NameConcat}, you have selected Watermelon"); CheckInput();
                if (UserInput == "1")
                { Cart.Add("Watermelon"); Bal -= 10; Cost += 10; Out($"{NameConcat}, you have added (Watermelon) to your Cart"); }
                if (UserInput == "2")
                {
                    if (Cart.Contains("Watermelon"))
                    { Cart.Remove("Watermelon"); Bal += 10; Cost -= 10; Out($"{NameConcat}, you have removed (Watermelon) from your Cart"); }
                }
                ItemsMenuDisplayAndProcessing2();
            }
        }
        public static void ItemsMenuDisplayAndProcessing2()
        {
            // run this block after every if statement out of 10 (1 through to 10)

            if (Cart.Count > 0) // Skips over this code if the number of items in the cart is 0
            {
                Out($"\nItems Cart:\n-----------------------------\nItems:");
                foreach (string temp in Cart) // Displays items in the Cart
                { Console.Write(temp + ", "); }
                Out($"\n-----------------------------\nCurrent Total: ${Cost}\n-----------------------------\n\n");
            }
            Out("Enter 1  -  Checkout\nEnter 2  -  Continue Shopping");
            CheckInput();
            if (UserInput == "1")
            { CheckOutDisplay(); }
            if (UserInput == "2")
            { ItemsMenuDisplayAndProcessing1(); }
        }
        public static void CheckInput()
        {
            UserInput = Console.ReadLine();
            while (UserInput != "1" && UserInput != "2")
            {
                Out("\tInvalid Input, Try Again.");
                UserInput = Console.ReadLine();
            }
        }
        public static void RestartApplication()
        {
            Out("Enter 1  -  Restart Application\nEnter 2  -  Exit The Application");

            CheckInput();
            if (UserInput == "1")
            {
                Out("\nRestarting Application....\n");
                Cart.Clear(); // Resets all values when restarting
                Bal = 0;      //
                Cost = 0;     //
                GiveAwayDisplay();
            }
            if (UserInput == "2")
            { Environment.Exit(0); }
        }
        public static void Out(string message) => Console.WriteLine(message); // Simplification to convert the argument Console.WriteLine(message); to Out(message);
        static void Main(string[] args) => GiveAwayDisplay();
    }
}


