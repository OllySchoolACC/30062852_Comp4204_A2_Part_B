using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30062852_Comp4204_A2_Part_B
{
    internal class Program
    {
        public static List<string> Cart = new List<string>(); // Add and remove items here (dynamically resizing)
        public static string UserInput;
        public static decimal Bal;
        public static decimal Cost;
        public static bool Restart;
        public static void Start()
        {
            Out("\t\nEnter your balance\n\n");
            Bal = decimal.Parse(Console.ReadLine()); // Choose your balance
            ItemSelectionMenu();
            RestartApplication();
        }
        public static void ItemSelectionMenu()
        {
            Out("\n\n\tEnter 1 - $1 Apple\n\tEnter 2 - $2 Pear\n\tEnter 3 - $3 Banana\n\tEnter 4 - $4 Lime\n\tEnter 5 - $5 Grape\n\tEnter 6 - $6 Kiwifruit" + // temp items
            "\n\tEnter 7 - $7 Strawberry \n\tEnter 8 - $8 Mango\n\tEnter 9 - $9 Passionfruit\n\tEnter 10 - $10 Watermelon\n");

            UserInput = Console.ReadLine();
            Out("Enter 1  -  Add Item\nEnter 2  -  Remove Item");
            if (UserInput == "1") // 1st item which is apple
            {
                Out("You have selected Apple");
                UserInput = Console.ReadLine();
                if (UserInput == "1") // add an item
                {
                    Cart.Add("Apple");
                    Bal -= 1;
                    Cost += 1;
                    Out($"You have added Apple to your Cart\n\nCurrent Total: ${Cost}\n\nItems Cart:\n-----------------------------");
                }
                if (UserInput == "2") // remove an item
                {
                    if (Cart.Contains("Apple"))
                    {
                        Cart.Remove("Apple");
                        Bal += 1;
                        Cost -= 1;
                        Out($"You have removed Apple from your Cart\n\nCurrent Total: ${Cost}\n\nItems Cart:\n-----------------------------");
                    }
                }
            }
            foreach (string temp in Cart)
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
            if (Bal < 0)
            {
                Out("Insufficient Funds\n\nEnter 1 to add funds\nEnter 2 to not add funds");
                UserInput = Console.ReadLine();
                if (UserInput == "1")
                { Bal += decimal.Parse(Console.ReadLine()); }
                else if (UserInput == "2") { }
                ItemSelectionMenu();
            }
            if (Bal >= 0)
            {
                Out("Shopping Cart:\n-----------------------------");
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
            while (!Restart) // ( ! ) returns true when not satisfied, when it returns false it will stop the function
            {
                if (UserInput == "1")
                {
                    Out("\nRestarting Application....\n");
                    Cart.Clear(); // reset all values when restarting
                    Bal = 0;      //
                    Cost = 0;     //
                    Start();
                }
                if (UserInput == "2")
                { Restart = true; } // exits the program 
            }
        }
        public static void Out(string message) => Console.WriteLine(message);
        static void Main(string[] args) => Start();
    }
}
