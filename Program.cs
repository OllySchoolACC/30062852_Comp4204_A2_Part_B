using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30062852_Comp4204_A2_Part_B
{
    internal class Program // This application is going to be a tech store. All of the product information is from PB Tech.
    {
        public static string[] Products = new string[10] { "Apples", "Pears", "Bananas", "Limes", "Grapes", "Kiwifruit", "Strawberries", "Mangos", "Passionfruit", "Watermelon" }; // TEMP PRODUCTS 1 - 10
        public static int[] GiftCards = new int[6] { 500, 1000, 2500, 5000, 7500, 10000 }; // 6 different giftcard values
        public static List<string> Cart = new List<string>(); // Add and remove items here (dynamically resizing)
        public static Random Rnd = new Random(); // Creates a random instance function
        public static string UserInput;
        public static string FirstName;
        public static string LastName;
        public static string NameConcat;
        public static string Sel = "\n\nEnter 1  -  Add Item\nEnter 2  -  Exit Application\nEnter 3  -  Remove Item\n\n";
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
            Out($"\n\n\tHello {NameConcat}, you have won a giftcard which value is ${Bal} NZD.\n\n\tPlease purchase what you would like from the categories below.\n"); // Will make you choose one of the random 6 gift cards priced from $500 - $10,000 NZD\

            ItemsMenu1();
        }
        public static void ItemsMenu1()
        {
                for (int i = 1; i <= Products.Length; i++)
                { Out($"\tEnter {i}  -  {Products[i - 1]}"); }

                UserInput = Console.ReadLine();

                switch (UserInput)
                {
                    case "1":
                        Out($"{NameConcat}, you have selected Apples {Sel}"); CheckInput1();
                        if (UserInput == "1") // Add an item
                        { Cart.Add("Apples"); Bal -= 1; Cost += 1; Out($"{NameConcat}, you have added (Apples) to your Cart"); }
                        if (UserInput == "2")
                        { ExitApp(); }
                        if (UserInput == "3") // Remove an item
                        {
                            if (Cart.Contains("Apples")) // If it doesn't contain the item it won't offset the variables Bal and Cost
                            { Cart.Remove("Apples"); Bal += 1; Cost -= 1; Out($"{NameConcat}, you have removed (Apples) from your Cart"); }
                        }
                        ItemsMenu2();
                        break;
                    case "2":
                        Out($"{NameConcat}, you have selected Pear {Sel}"); CheckInput1();
                        if (UserInput == "1")
                        { Cart.Add("Pear"); Bal -= 2; Cost += 2; Out($"{NameConcat}, you have added (Pear) to your Cart"); }
                        if (UserInput == "2")
                        { ExitApp(); }
                        if (UserInput == "3")
                        {
                            if (Cart.Contains("Pear"))
                            { Cart.Remove("Pear"); Bal += 2; Cost -= 2; Out($"{NameConcat}, you have removed (Pear) from your Cart"); }
                        }
                        ItemsMenu2();
                        break;
                    case "3":
                        Out($"{NameConcat}, you have selected Bananas {Sel}"); CheckInput1();
                        if (UserInput == "1")
                        { Cart.Add("Bananas"); Bal -= 3; Cost += 3; Out($"{NameConcat}, you have added (Bananas) to your Cart"); }
                        if (UserInput == "2")
                        { ExitApp(); }
                        if (UserInput == "3")
                        {
                            if (Cart.Contains("Bananas"))
                            { Cart.Remove("Bananas"); Bal += 3; Cost -= 3; Out($"{NameConcat}, you have removed (Bananas) from your Cart"); }
                        }
                        ItemsMenu2();
                        break;
                    case "4":
                        Out($"{NameConcat}, you have selected Lime {Sel}"); CheckInput1();
                        if (UserInput == "1")
                        { Cart.Add("Lime"); Bal -= 4; Cost += 4; Out($"{NameConcat}, you have added (Lime) to your Cart"); }
                        if (UserInput == "2")
                        { ExitApp(); }
                        if (UserInput == "3")
                        {
                            if (Cart.Contains("Lime"))
                            { Cart.Remove("Lime"); Bal += 4; Cost -= 4; Out($"{NameConcat}, you have removed (Lime) from your Cart"); }
                        }
                        ItemsMenu2();
                        break;
                    case "5":
                        Out($"{NameConcat}, you have selected Grapes {Sel}"); CheckInput1();
                        if (UserInput == "1")
                        { Cart.Add("Grapes"); Bal -= 5; Cost += 5; Out($"{NameConcat}, you have added (Grapes) to your Cart"); }
                        if (UserInput == "2")
                        { ExitApp(); }
                        if (UserInput == "3")
                        {
                            if (Cart.Contains("Grapes"))
                            { Cart.Remove("Grapes"); Bal += 5; Cost -= 5; Out($"{NameConcat}, you have removed (Grapes) from your Cart"); }
                        }
                        ItemsMenu2();
                        break;
                    case "6":
                        Out($"{NameConcat}, you have selected Kiwifruit {Sel}"); CheckInput1();
                        if (UserInput == "1")
                        { Cart.Add("Kiwifruit"); Bal -= 6; Cost += 6; Out($"{NameConcat}, you have added (Kiwifruit) to your Cart"); }
                        if (UserInput == "2")
                        { ExitApp(); }
                        if (UserInput == "3")
                        {
                            if (Cart.Contains("Kiwifruit"))
                            { Cart.Remove("Kiwifruit"); Bal += 6; Cost -= 6; Out($"{NameConcat}, you have removed (Kiwifruit) from your Cart"); }
                        }
                        ItemsMenu2();
                        break;
                    case "7":
                        Out($"{NameConcat}, you have selected Strawberries {Sel}"); CheckInput1();
                        if (UserInput == "1")
                        { Cart.Add("Strawberries"); Bal -= 7; Cost += 7; Out($"{NameConcat}, you have added (Strawberries) to your Cart"); }
                        if (UserInput == "2")
                        { ExitApp(); }
                        if (UserInput == "3")
                        {
                            if (Cart.Contains("Strawberries"))
                            { Cart.Remove("Strawberries"); Bal += 7; Cost -= 7; Out($"{NameConcat}, you have removed (Strawberries) from your Cart"); }
                        }
                        ItemsMenu2();
                        break;
                    case "8":
                        Out($"{NameConcat}, you have selected Mango {Sel}"); CheckInput1();
                        if (UserInput == "1")
                        { Cart.Add("Mango"); Bal -= 8; Cost += 8; Out($"{NameConcat}, you have added (Mango) to your Cart"); }
                        if (UserInput == "2")
                        { ExitApp(); }
                        if (UserInput == "3")
                        {
                            if (Cart.Contains("Mango"))
                            { Cart.Remove("Mango"); Bal += 8; Cost -= 8; Out($"{NameConcat}, you have removed (Mango) from your Cart"); }
                        }
                        ItemsMenu2();
                        break;
                    case "9":
                        Out($"{NameConcat}, you have selected Passionfruit {Sel}"); CheckInput1();
                        if (UserInput == "1")
                        { Cart.Add("Passionfruit"); Bal -= 9; Cost += 9; Out($"{NameConcat}, you have added (Passionfruit) to your Cart"); }
                        if (UserInput == "2")
                        { ExitApp(); }
                        if (UserInput == "3")
                        {
                            if (Cart.Contains("Passionfruit"))
                            { Cart.Remove("Passionfruit"); Bal += 9; Cost -= 9; Out($"{NameConcat}, you have removed (Passionfruit) from your Cart"); }
                        }
                        ItemsMenu2();
                        break;
                    case "10":
                        Out($"{NameConcat}, you have selected Watermelon {Sel}"); CheckInput1();
                        if (UserInput == "1")
                        { Cart.Add("Watermelon"); Bal -= 10; Cost += 10; Out($"{NameConcat}, you have added (Watermelon) to your Cart"); }
                        if (UserInput == "2")
                        { ExitApp(); }
                        if (UserInput == "3")
                        {
                            if (Cart.Contains("Watermelon"))
                            { Cart.Remove("Watermelon"); Bal += 10; Cost -= 10; Out($"{NameConcat}, you have removed (Watermelon) from your Cart"); }
                        }
                        ItemsMenu2();
                        break;
                    default: 
                        Out("\n\tInvalid Input, Try Again.\n\n");
                        ItemsMenu1(); // Replays the menu if the input is invalid
                        break;
            }
        }
        public static void ItemsMenu2()
        {
            Out("\n\tValid Input\n\n"); // If it passes through to this part of the program its a valid input

            if (Cart.Count > 0) // Skips over this code if the number of items in the cart is 0
            {
                Out($"\n{NameConcat}'s Cart:\n-----------------------------\nItems:");
                foreach (string temp in Cart)
                { Console.Write(temp + ", "); }
                Out($"\n-----------------------------\nCurrent Total: ${Cost}\n-----------------------------\n\n");
            }
            
            Out("Enter 1  -  Checkout\nEnter 2  -  Continue Shopping\nEnter 3  -  Exit Application");
            CheckInput1();
            if (UserInput == "1")
            { CheckOutDisplay(); }
            if (UserInput == "2")
            { ItemsMenu1(); }
            if (UserInput == "3")
            { ExitApp(); }
        }
        public static void CheckInput1() // Checks for 3 wrong inputs
        {
            UserInput = Console.ReadLine();
            while (UserInput != "1" && UserInput != "2" && UserInput != "3")
            {
                Out("\tInvalid Input, Try Again.");
                UserInput = Console.ReadLine();
            }
            Out("\n\tValid Input\n\n"); // when the loop stops because of a valid input it will break away from the while function
        }
        public static void CheckInput2() // Checks for 2 wrong inputs
        {
            UserInput = Console.ReadLine();
            while (UserInput != "1" && UserInput != "2")
            {
                Out("\tInvalid Input, Try Again.");
                UserInput = Console.ReadLine();
            }
            Out("\n\tValid Input\n\n");
        }
        public static void CheckOutDisplay()
        {
            if (Bal < 0) // If Bal is less than zero it will give the user the **option** to add Funds to the Bal Variable
            {
                Out("Insufficient Funds\n\nEnter 1  -  Add Funds\nEnter 2  -  Don't Add Funds\nEnter 3  -  Exit Application\n");
                CheckInput1();

                if (UserInput == "1")
                {
                    Out("Enter how much $$$$ you would like");
                    Bal += decimal.Parse(Console.ReadLine());
                }
                if (UserInput == "2")
                { ItemsMenu1(); }
                if (UserInput == "3")
                { ExitApp(); }
            }
            if (Cart.Count > 0)
            {
                if (Bal >= 0) // If Bal is greater than or equal to 0 it will display the CheckOut function
                {
                    Out("\n\nPurchasing Items....\n\n");

                    Out($"{NameConcat}'s Shopping Cart:\n-----------------------------");
                    Out("Purchased Items:");
                    foreach (string temp in Cart)
                    { Console.Write(temp + ", "); }
                    Out("\n-----------------------------");
                    Out($"Balance ${Bal}");
                    Out($"Total Cost: ${Cost}\n-----------------------------");
                }
                Out("\n\tEnter 1  -  Restart Application\n\tEnter 2  -  Exit Application\n\n");

                CheckInput2();
                if (UserInput == "1")
                {
                    Out("\nRestarting Application....\n");
                    Cart.Clear(); // Resets all of these values when restarting
                    Bal = 0;      //
                    Cost = 0;     //
                    GiveAwayDisplay();
                }
                if (UserInput == "2")
                { ExitApp(); }
            }
            if (Cart.Count <= 0) // Give the user the option to exit the application or go back through the product menu
            {
                Out("Enter 1  -  Continue Shopping\nEnter 2  -  Exit Application");

                CheckInput2();
                if (UserInput == "1")
                { ItemsMenu1(); }
                if (UserInput == "2")
                { ExitApp(); }
            }
        }
        public static void ExitApp()
        {
            Out($"\n\n\tAre you sure you want to Exit the application you have ({Cart.Count}) item(s) left in your cart\n\n\n\tEnter 1  -  Continue Shopping\n\tEnter 2  -  Exit Application\n\n");

            CheckInput2();
            if (UserInput == "1")
            { ItemsMenu1(); }
            if (UserInput == "2")
            { Environment.Exit(0); }
        }
        public static void Out(string message) => Console.WriteLine(message); // Simplification to convert the argument Console.WriteLine(message); to Out(message);
        static void Main(string[] args) => GiveAwayDisplay();
    }
}


