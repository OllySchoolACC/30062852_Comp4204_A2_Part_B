using System;
using System.Collections.Generic;

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
        public static bool Restart;
        public static void GiveAwayDisplay()
        {
            Console.ForegroundColor = ConsoleColor.Blue; // Makes the text blue
            Out(string.Format("\n\tWelcome to Forever Kiwi NZ retail tech store\t\t\t\tThe current time is {0:hh:mm tt}.\n\n\n\tPlease enter your First Name & Last Name to go into the draw to win.\n\n\tPrize: A giftcard ranging from $500 to $10,000 NZD.\n\n", DateTime.Now)); // Displays the time, also prompts the user to enter their First & Last Name

            Bal = GiftCards[Rnd.Next(GiftCards.Length)]; // Will store a random value ranging from 500 to 10,000 into the Bal Variable

            Console.Write("\tFirst Name: "); // Prompts the user for their First Name
            FirstName = Console.ReadLine();
            Console.Write("\tLast Name: "); // Prompts the user for their Last Name
            LastName = Console.ReadLine();
            NameConcat = (char.ToUpper(FirstName[0]) + FirstName.Substring(1)) + " " + (char.ToUpper(LastName[0]) + LastName.Substring(1)); // Makes the first char of the First & Last Name uppercase and adds the substring to both the First & Last Name accordingly then stores the argument in the NameConcat Variable 
            Out($"\n\n\tHello {NameConcat}, you have won a giftcard which value is ${Bal} NZD.\n\n\tPlease purchase what you would like from the categories below.\n"); // Will make you choose one of the random 6 gift cards priced from $500 - $10,000 NZD

            ItemSelectionMenu();
            RestartApplication();
        }
        public static void ItemSelectionMenu()
        {
            Out("\n\n\tEnter 1 - $1 Apple\n\tEnter 2 - $2 Pear\n\tEnter 3 - $3 Banana\n\tEnter 4 - $4 Lime\n\tEnter 5 - $5 Grape\n\tEnter 6 - $6 Kiwifruit" + // Temp items
            "\n\tEnter 7 - $7 Strawberry \n\tEnter 8 - $8 Mango\n\tEnter 9 - $9 Passionfruit\n\tEnter 10 - $10 Watermelon\n");

            UserInput = Console.ReadLine();
            Out("Enter 1  -  Add Item\nEnter 2  -  Remove Item");
            if (UserInput == "1") // 1st item which is Apple // REPLACE THE TEMP ITEMS LATER
            {
                Out($"{NameConcat}, you have selected Apple");
                UserInput = Console.ReadLine();
                if (UserInput == "1") // Add an item
                {
                    Cart.Add("Apple");
                    Bal -= 1;
                    Cost += 1;
                    Out($"{NameConcat}, you have added Apple to your Cart\n\nCurrent Total: ${Cost}\n\nItems Cart:\n-----------------------------");
                }
                if (UserInput == "2") // Remove an item
                {
                    if (Cart.Contains("Apple")) // If it doesn't contain the item it won't offset the variables Bal and Cost
                    {
                        Cart.Remove("Apple");
                        Bal += 1;
                        Cost -= 1;
                        Out($"{NameConcat}, you have removed Apple from your Cart\n\nCurrent Total: ${Cost}\n\nItems Cart:\n-----------------------------");
                    }
                }
            }
            foreach (string temp in Cart) // Displays items in the Cart
            { Console.Write(temp + ", "); }
            Out("\n-----------------------------\n\nEnter 1 to checkout, Enter 2 to continue shopping");

            UserInput = Console.ReadLine();
            if (UserInput == "1")
            { CheckOutDisplay(); }
            if (UserInput == "2")
            { ItemSelectionMenu(); }
        }
        public static void CheckOutDisplay()
        {
            if (Bal < 0) // If Bal is less than zero it will give the user the **option** to add Funds to the Bal Variable
            {
                Out("Insufficient Funds\n\nEnter 1 to add funds\nEnter 2 to not add funds");
                UserInput = Console.ReadLine();
                if (UserInput == "1")
                { Bal += decimal.Parse(Console.ReadLine()); }
                if (UserInput == "2") { }
                ItemSelectionMenu();
            }
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
        }
        public static void RestartApplication()
        {
            Out("Enter 1 to restart the application\nEnter 2 to exit the application");
            UserInput = Console.ReadLine();
            while (!Restart) // ( ! ) Returns true when not satisfied, when it returns false it will stop the function
            {
                if (UserInput == "1")
                {
                    Out("\nRestarting Application....\n");
                    Cart.Clear(); // Resets all values when restarting
                    Bal = 0;      //
                    Cost = 0;     //
                    GiveAwayDisplay();
                }
                if (UserInput == "2")
                { Restart = true; } // Exits the program by stopping the while loop function
            }
        }
        public static void Out(string message) => Console.WriteLine(message); // Simplification to convert the argument Console.WriteLine(message); to Out(message);
        static void Main(string[] args) => GiveAwayDisplay();
    }
}
