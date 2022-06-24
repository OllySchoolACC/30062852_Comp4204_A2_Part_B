using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30062852_Comp4204_A2_Part_B
{
    internal class Program // This application is going to be a tech store. All of the product information is from PB Tech.
    {
        public static int[] GiftCards = new int[6] { 500, 1000, 2500, 5000, 7500, 10000 }; // 6 different giftcard values
        public static List<string> Cart = new List<string>(); // Add and remove items here (dynamically resizing)
        public static Random Rnd = new Random(); // Creates a random instance function
        public static string UserInput;
        public static string FirstName;
        public static string LastName;
        public static string NameConcat;
        public static string Sel = "\n\n\tEnter 1  -  Add Item\n\tEnter 2  -  Exit Application\n\tEnter 3  -  Remove Item\n\n";
        public static string Decoration = "\n-----------------------------------------------------------------------------------------------------------------------\n";
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

            CategoriesMenu();
        }
        public static void CategoriesMenu()
        {
            Out("\n\tEnter 1 - Laptops\n\tEnter 2 - Desktops\n\tEnter 3 - Phones\n\tEnter 4 - Televisions\n\n");

            UserInput = Console.ReadLine();
            switch (UserInput)
            {
                case "1":
                    LaptopsMenu();
                    break;
                case "2":
                    DesktopsMenu();
                    break;
                case "3":
                    PhonesMenu();
                    break;
                case "4":
                    TelevisionsMenu();
                    break;
                default:
                    Out("\n\n\tInvalid Input, Try Again.\n");
                    CategoriesMenu(); // Runs the Categories Menu again if the UserInput is invalid
                    break;
            }
        }
        public static void LaptopsMenu()
        {
            string[] Product = new string[5] { "ASUS ROG Zephyrus G14 Gaming Laptop", "MSI Prestige 14 A11SC Gaming Laptop", "ASUS TUF Gaming A15 Gaming Laptop", "Apple 13 Macbook Air Laptop", "Apple Z15H000UD 14 Macbook Pro" }; // Product details
            string[] ProductPricing = new string[5] { "$2,054.00", "$2,300.00", "$1,540.00", "$1,699.00", "$5,675.90" }; // Product pricing

            for (int i = 1; i <= Product.Length; i++) // For loop used for showing the products
            {
                if (i == 1) // When i == 1 it breaks the text apart at the beginning
                { Out($"\n\n\t{NameConcat}, you have selected Laptops. Choose from all products listed below.\n\n\n\tGaming Laptops:\n"); }
                if (i == 3) // When i == 3 it breaks the text apart after 2 products are displayed
                { Out("\n\tApple Laptops:\n"); }

                Out($"\tEnter {i}  -  {ProductPricing[i - 1]}  -  {Product[i - 1]}"); // Displays the item details
            }
            Out("\n");

            UserInput = Console.ReadLine();
            switch (UserInput)
            {
                case "1": // Windows Laptops
                    Out($"\n\n\t{NameConcat}, you have selected the ASUS ROG Zephyrus G14 Gaming Laptop.\n\n\tThe specifications of this laptop are;\n\n\n\tWarranty: 1 Year\n\n\tDisplay: 14 inch 60HZ display that has a resolution of 1920x1080\n\n\tStorage: 512GB M.2 SSD with 8GB RAM\n\n\tProcessor: AMD Ryzen 7 5800HS\n\n\tGraphics: GTX 1650 with 4GB VRAM\n\n\tOperating System: Windows 11 Home\n\n\tOther Features: WiFi 6 + BT 5.1, USB-C (With Power Delivery), Display Port, HDMI 2.1b\n{Sel}");
                    CheckInput1();
                    if (UserInput == "1") // Add an item
                    { Cart.Add("ASUS ROG Zephyrus G14"); Bal -= 2054; Cost += 2054; Out($"\t{NameConcat}, you have added (ASUS ROG Zephyrus G14) to your Cart"); }
                    if (UserInput == "2")
                    { ExitApp(); }
                    if (UserInput == "3") // Remove an item
                    {
                        if (Cart.Contains("ASUS ROG Zephyrus G14")) // If it doesn't contain the item it won't offset the variables Bal and Cost
                        { Cart.Remove("ASUS ROG Zephyrus G14"); Bal += 2054; Cost -= 2054; Out($"\t{NameConcat}, you have removed (ASUS ROG Zephyrus G14) from your Cart"); }
                    }
                    ItemsMenuExtension();
                    break;
                case "2":
                    Out($"\t{NameConcat}, you have selected the MSI Prestige 14 A11SC Gaming Laptop.\n\n\tThe specifications of this laptop are;\n\n\n\tWarranty: 2 Years\n\n\tDisplay: 14 inch 60HZ display that has a resolution of 1920x1080\n\n\tStorage: 1TB M.2 SSD with 16GB RAM\n\n\tProcessor: Intel i7-1195G7\n\n\tGraphics: GTX 1650 Max-Q with 4GB VRAM\n\n\tOperating System: Windows 10 Home (Upgradable)\n\n\tOther Features: WiFi 6 + BT 5.1, Webcam, 2x Type-C (USB/DP/Thunderbolt) with PD charging\n{Sel}");
                    CheckInput1();
                    if (UserInput == "1")
                    { Cart.Add("MSI Prestige 14 A11SC"); Bal -= 2300; Cost += 2300; Out($"\t{NameConcat}, you have added (MSI Prestige 14 A11SC) to your Cart"); }
                    if (UserInput == "2")
                    { ExitApp(); }
                    if (UserInput == "3")
                    {
                        if (Cart.Contains("MSI Prestige 14 A11SC"))
                        { Cart.Remove("MSI Prestige 14 A11SC"); Bal += 2300; Cost -= 2300; Out($"\t{NameConcat}, you have removed (MSI Prestige 14 A11SC) from your Cart"); }
                    }
                    ItemsMenuExtension();
                    break;
                case "3":
                    Out($"\t{NameConcat}, you have selected the ASUS TUF Gaming A15 Gaming Laptop.\n\n\tThe specifications of this laptop are;\n\n\n\tWarranty: 1 Year\n\n\tDisplay: 15.6 inch 144HZ display that has a resolution of 1920x1080\n\n\tStorage: 512GB M.2 SSD with 8GB RAM\n\n\tProcessor: AMD Ryzen 5 4600H\n\n\tGraphics: GTX 1650 with 4GB VRAM\n\n\tOperating System: Windows 11 Home\n\n\tOther Features: WiFi 6 + BT 5.1, Webcam, RGB backlit keyboard, USB-C, DP, HDMI 2.0b\n{Sel}");
                    CheckInput1();
                    if (UserInput == "1")
                    { Cart.Add("ASUS TUF Gaming A15"); Bal -= 1540; Cost += 1540; Out($"\t{NameConcat}, you have added (ASUS TUF Gaming A15) to your Cart"); }
                    if (UserInput == "2")
                    { ExitApp(); }
                    if (UserInput == "3")
                    {
                        if (Cart.Contains("ASUS TUF Gaming A15"))
                        { Cart.Remove("ASUS TUF Gaming A15"); Bal += 1540; Cost -= 1540; Out($"\t{NameConcat}, you have removed (ASUS TUF Gaming A15) from your Cart"); }
                    }
                    ItemsMenuExtension();
                    break;
                case "4": // Apple Laptops
                    Out($"\t{NameConcat}, you have selected the Apple 13 Macbook Air Laptop.\n\n\tThe specifications of this laptop are;\n\n\n\tWarranty: 1 Year\n\n\tDisplay: 13 inch 60HZ display that has a resolution of 2560x1600\n\n\tStorage: 256GB SSD with 8GB RAM\n\n\tProcessor: Apple M1 Chip\n\n\tGraphics: Apple M1 Chip\n\n\tOperating System: MacOS\n\n\tOther Features: Retina display with true tone, Magic Keyboard, Touch ID, 2x Thunderbolt Ports\n{Sel}");
                    CheckInput1();
                    if (UserInput == "1")
                    { Cart.Add("Apple 13 Macbook Air Laptop"); Bal -= 1699; Cost += 1699; Out($"\t{NameConcat}, you have added (Apple 13 Macbook Air Laptop) to your Cart"); }
                    if (UserInput == "2")
                    { ExitApp(); }
                    if (UserInput == "3")
                    {
                        if (Cart.Contains("Apple 13 Macbook Air Laptop"))
                        { Cart.Remove("Apple 13 Macbook Air Laptop"); Bal += 1699; Cost -= 1699; Out($"\t{NameConcat}, you have removed (Apple 13 Macbook Air Laptop) from your Cart"); }
                    }
                    ItemsMenuExtension();
                    break;
                case "5":
                    Out($"\t{NameConcat}, you have selected the Apple Z15H000UD 14 Macbook Pro.\n\n\tThe specifications of this laptop are;\n\n\n\tWarranty: 1 Year\n\n\tDisplay: 14 inch 120HZ display that has a resolution of 3024x1964\n\n\tStorage: 2TB SSD with 32GB RAM\n\n\tProcessor: Apple M1 Pro Chip\n\n\tGraphics: Apple M1 Pro Chip\n\n\tOperating System: MacOS\n\n\tOther Features: Retina Display, Magic Keyboard, Touch ID, 3x Thunderbolt Ports, SDXC Card Reader\n{Sel}");
                    CheckInput1();
                    if (UserInput == "1")
                    { Cart.Add("Apple Z15H000UD 14 Macbook Pro"); Bal -= (decimal)5675.90; Cost += (decimal)5675.90; Out($"\t{NameConcat}, you have added (Apple Z15H000UD 14 Macbook Pro) to your Cart"); }
                    if (UserInput == "2")                         // Cast to convert the int to a decimal and store the decimal value in the Bal variable
                    { ExitApp(); }
                    if (UserInput == "3")
                    {
                        if (Cart.Contains("Apple Z15H000UD 14 Macbook Pro"))
                        { Cart.Remove("Apple Z15H000UD 14 Macbook Pro"); Bal += (decimal)5675.90; Cost -= (decimal)5675.90; Out($"\t{NameConcat}, you have removed (Apple Z15H000UD 14 Macbook Pro) from your Cart"); }
                    }
                    ItemsMenuExtension();
                    break;
                default:
                    Out($"\n\n\tInvalid Input, Try Again.\n");
                    LaptopsMenu();
                    break;
            }
        }
        public static void DesktopsMenu()
        {
            string[] Product = new string[5] { "GGPC RTX 3060 i5 10400F", "GGPC RX 6500 XT i3 10105F", "GGPC RX 6600 Ryzen 5 5600G", "PB Family PC Series 42512", "PB Everyday Home PC 43520" };
            string[] ProductPricing = new string[5] { "$1,896.40", "$1,249.00", "$1,723.90", "$1,378.90", "$1,493.90" };

            for (int i = 1; i <= Product.Length; i++)
            {
                if (i == 1)
                { Out($"\n\n\t{NameConcat}, you have selected Desktops. Choose from all products listed below.\n\n\n\tGaming Desktops:\n"); }
                if (i == 4)
                { Out("\n\tHome Desktops:\n"); }

                Out($"\tEnter {i}  -  {ProductPricing[i - 1]}  -  {Product[i - 1]}");
            }
            Out("\n");

            UserInput = Console.ReadLine();
            switch (UserInput)
            {
                case "1": // Gaming PC's
                    Out($"\t{NameConcat}, you have selected the GGPC RTX 3060 i5 10400F.\n\n\tThe specifications of this PC are;\n\n\n\tWarranty: 1 Year\n\n\tStorage: 500GB M.2 SSD with 16GB RAM\n\n\tProcessor: i5 10400F\n\n\tGraphics: RTX 3060\n\n\tOperating System: Windows 11 Home\n\n\tOther Features: AC WiFi + BT\n{Sel}");
                    CheckInput1();
                    if (UserInput == "1")
                    { Cart.Add("GGPC RTX 3060 i5 10400F"); Bal -= (decimal)1896.40; Cost += (decimal)1896.40; Out($"\t{NameConcat}, you have added (GGPC RTX 3060 i5 10400F) to your Cart"); }
                    if (UserInput == "2")
                    { ExitApp(); }
                    if (UserInput == "3")
                    {
                        if (Cart.Contains("GGPC RTX 3060 i5 10400F"))
                        { Cart.Remove("GGPC RTX 3060 i5 10400F"); Bal += (decimal)1896.40; Cost -= (decimal)1896.40; Out($"\t{NameConcat}, you have removed (GGPC RTX 3060 i5 10400F) from your Cart"); }
                    }
                    ItemsMenuExtension();
                    break;
                case "2":
                    Out($"\t{NameConcat}, you have selected the GGPC RX 6500 XT i3 10105F.\n\n\tThe specifications of this PC are;\n\n\n\tWarranty: 1 Year\n\n\tStorage: 480GB SSD with 16GB RAM\n\n\tProcessor: i3 10105F\n\n\tGraphics: RX 6500 XT\n\n\tOperating System: Windows 11 Home\n\n\tOther Features: AC WiFi + BT\n{Sel}");
                    CheckInput1();
                    if (UserInput == "1")
                    { Cart.Add("GGPC RX 6500 XT i3 10105F"); Bal -= 1249; Cost += 1249; Out($"\t{NameConcat}, you have added (GGPC RX 6500 XT i3 10105F) to your Cart"); }
                    if (UserInput == "2")
                    { ExitApp(); }
                    if (UserInput == "3")
                    {
                        if (Cart.Contains("GGPC RX 6500 XT i3 10105F"))
                        { Cart.Remove("GGPC RX 6500 XT i3 10105F"); Bal += 1249; Cost -= 1249; Out($"\t{NameConcat}, you have removed (GGPC RX 6500 XT i3 10105F) from your Cart"); }
                    }
                    ItemsMenuExtension();
                    break;
                case "3":
                    Out($"\t{NameConcat}, you have selected the GGPC RX 6600 Ryzen 5 5600G.\n\n\tThe specifications of this PC are;\n\n\n\tWarranty: 1 Year\n\n\tStorage: 500GB M.2 SSD with 16GB RAM\n\n\tProcessor: Ryzen 5 5600G\n\n\tGraphics: AMD Radeon RX 6600\n\n\tOperating System: Windows 11 Home\n\n\tOther Features: AC WiFi + BT\n{Sel}");
                    CheckInput1();
                    if (UserInput == "1")
                    { Cart.Add("GGPC RX 6600 Ryzen 5 5600G"); Bal -= (decimal)1723.90; Cost += (decimal)1723.90; Out($"\t{NameConcat}, you have added (GGPC RX 6600 Ryzen 5 5600G) to your Cart"); }
                    if (UserInput == "2")
                    { ExitApp(); }
                    if (UserInput == "3")
                    {
                        if (Cart.Contains("GGPC RX 6600 Ryzen 5 5600G"))
                        { Cart.Remove("GGPC RX 6600 Ryzen 5 5600G"); Bal += (decimal)1723.90; Cost -= (decimal)1723.90; Out($"\t{NameConcat}, you have removed (GGPC RX 6600 Ryzen 5 5600G) from your Cart"); }
                    }
                    ItemsMenuExtension();
                    break;
                case "4": // Home PC's
                    Out($"\t{NameConcat}, you have selected the PB Family PC Series 42512.\n\n\tThe specifications of this PC are;\n\n\n\tWarranty: 1 Year\n\n\tStorage: 500GB M.2 SSD with 16GB RAM\n\n\tProcessor: Ryzen 5 5600G\n\n\tGraphics: Integrated AMD Radeon Graphics\n\n\tOperating System: Windows 11 Home\n\n\tOther Features: AC WiFi + BT\n{Sel}");
                    CheckInput1();
                    if (UserInput == "1")
                    { Cart.Add("PB Family PC Series 42512"); Bal -= (decimal)1378.90; Cost += (decimal)1378.90; Out($"\t{NameConcat}, you have added (PB Family PC Series 42512) to your Cart"); }
                    if (UserInput == "2")
                    { ExitApp(); }
                    if (UserInput == "3")
                    {
                        if (Cart.Contains("PB Family PC Series 42512"))
                        { Cart.Remove("PB Family PC Series 42512"); Bal += (decimal)1378.90; Cost -= (decimal)1378.90; Out($"\t{NameConcat}, you have removed (PB Family PC Series 42512) from your Cart"); }
                    }
                    ItemsMenuExtension();
                    break;
                case "5":
                    Out($"\t{NameConcat}, you have selected the PB Everyday Home PC 43520.\n\n\tThe specifications of this PC are;\n\n\n\tWarranty: 1 Year\n\n\tStorage: 500GB M.2 SSD with 16GB RAM\n\n\tProcessor: i7 10700\n\n\tGraphics: Integrated Graphics\n\n\tOperating System: Windows 11 Home\n\n\tOther Features: AC WiFi + BT\n{Sel}");
                    CheckInput1();
                    if (UserInput == "1")
                    { Cart.Add("PB Everyday Home PC 43520"); Bal -= (decimal)1493.90; Cost += (decimal)1493.90; Out($"\t{NameConcat}, you have added (PB Everyday Home PC 43520) to your Cart"); }
                    if (UserInput == "2")
                    { ExitApp(); }
                    if (UserInput == "3")
                    {
                        if (Cart.Contains("PB Everyday Home PC 43520"))
                        { Cart.Remove("PB Everyday Home PC 43520"); Bal += (decimal)1493.90; Cost -= (decimal)1493.90; Out($"\t{NameConcat}, you have removed (PB Everyday Home PC 43520) from your Cart"); }
                    }
                    ItemsMenuExtension();
                    break;
                default:
                    Out("\n\n\tInvalid Input, Try Again.\n");
                    DesktopsMenu();
                    break;
            }
        }
        public static void PhonesMenu()
        {
            string[] Product = new string[8] { "Samsung Galaxy A52 2021", "ASUS ROG Phone 5s 2021", "Xiaomi Redmi Note 11 2022", "Apple iPhone 13 Pro Max", "Apple iPhone 13 Pro", "Apple iPhone 13", "Apple iPhone 13 Mini", "Apple iPhone SE 3rd Gen" };
            string[] ProductPricing = new string[8] { "$599.00", "$1,399.00", "$449.00", "$1,999.00", "$1,799.00", "$1,429.00", "$1,849.00", "$899.00" };

            for (int i = 1; i <= Product.Length; i++)
            {
                if (i == 1)
                { Out($"\n\n\t{NameConcat}, you have selected Phones. Choose from all products listed below.\n\n\n\tAndroid Phones:\n"); }
                if (i == 4)
                { Out("\n\tApple Phones:\n"); }

                Out($"\tEnter {i}  -  {ProductPricing[i - 1]}  -  {Product[i - 1]}");
            }
            Out("\n");

            UserInput = Console.ReadLine();
            switch (UserInput)
            {
                case "1":
                    Out($"\t{NameConcat}, you have selected the Samsung Galaxy A52 2021.\n\n\tThe specifications of this phone are;\n\n\n\tWarranty: 2 Years\n\n\tStorage: 128GB with 8GB RAM\n\n\tScreen: 6.5 inch 90HZ display with a resolution of 1080 x 2400\n\n\tBattery: 4500 MAH\n\n\tCamera: Quad camera with 64 MP main\n\n\tProcessor: Snapdragon 720G\n\n\tGraphics: Adreno 618\n\n\tOperating System: Android 11 (Upgradable)\n\n\tOther Features: Dual SIM, Micro SD Card Support (1TB), IP67 Water & Dust Resistant\n{Sel}");
                    CheckInput1();
                    if (UserInput == "1")
                    { Cart.Add("Samsung Galaxy A52 2021"); Bal -= 599; Cost += 599; Out($"\t{NameConcat}, you have added (Samsung Galaxy A52 2021) to your Cart"); }
                    if (UserInput == "2")
                    { ExitApp(); }
                    if (UserInput == "3")
                    {
                        if (Cart.Contains("Samsung Galaxy A52 2021"))
                        { Cart.Remove("Samsung Galaxy A52 2021"); Bal += 599; Cost -= 599; Out($"\t{NameConcat}, you have removed (Samsung Galaxy A52 2021) from your Cart"); }
                    }
                    ItemsMenuExtension();
                    break;
                case "2":
                    Out($"\t{NameConcat}, you have selected the ASUS ROG Phone 5s 2021.\n\n\tThe specifications of this phone are;\n\n\n\tWarranty: 2 Years\n\n\tStorage: 512GB with 16GB RAM\n\n\tScreen: 6.78 inch 144HZ display with a resolution of 1080 x 2448\n\n\tBattery: 6000 MAH\n\n\tCamera: Triple camera with 64MP main\n\n\tProcessor: Snapdragon 888+\n\n\tGraphics: Adreno 660\n\n\tOperating System: Android 11 (Upgradable)\n\n\tOther Features: Dual SIM, Fast charging (65 W), Reverse charging\n{Sel}");
                    CheckInput1();
                    if (UserInput == "1")
                    { Cart.Add("ASUS ROG Phone 5s 2021"); Bal -= 1399; Cost += 1399; Out($"\t{NameConcat}, you have added (ASUS ROG Phone 5s 2021) to your Cart"); }
                    if (UserInput == "2")
                    { ExitApp(); }
                    if (UserInput == "3")
                    {
                        if (Cart.Contains("ASUS ROG Phone 5s 2021"))
                        { Cart.Remove("ASUS ROG Phone 5s 2021"); Bal += 1399; Cost -= 1399; Out($"\t{NameConcat}, you have removed (ASUS ROG Phone 5s 2021) from your Cart"); }
                    }
                    ItemsMenuExtension();
                    break;
                case "3":
                    Out($"\t{NameConcat}, you have selected the Xiaomi Redmi Note 11 2022.\n\n\tThe specifications of this phone are;\n\n\n\tWarranty: 2 Years\n\n\tStorage: 128GB with 6GB RAM\n\n\tScreen: 6.43 inch 90HZ display with a resolution of 1080 x 2400\n\n\tBattery: 5000 MAH\n\n\tCamera: Quad camera with 50MP main\n\n\tProcessor: Snapdragon 680\n\n\tGraphics: Adreno 610\n\n\tOperating System: Android 11\n\n\tOther Features: Dual SIM, Micro SDXC Card Support (2TB), Fast charging (33 W)\n{Sel}");
                    CheckInput1();
                    if (UserInput == "1")
                    { Cart.Add("Xiaomi Redmi Note 11 2022"); Bal -= 449; Cost += 449; Out($"\t{NameConcat}, you have added (Xiaomi Redmi Note 11 2022) to your Cart"); }
                    if (UserInput == "2")
                    { ExitApp(); }
                    if (UserInput == "3")
                    {
                        if (Cart.Contains("Xiaomi Redmi Note 11 2022"))
                        { Cart.Remove("Xiaomi Redmi Note 11 2022"); Bal += 449; Cost -= 449; Out($"\t{NameConcat}, you have removed (Xiaomi Redmi Note 11 2022) from your Cart"); }
                    }
                    ItemsMenuExtension();
                    break;
                case "4":
                    Out($"\t{NameConcat}, you have selected the Apple iPhone 13 Pro Max.\n\n\tThe specifications of this phone are;\n\n\n\tWarranty: 2 Years\n\n\tStorage: 128GB with 6GB RAM\n\n\tScreen: 6.7 inch 120HZ display with a resolution of 1284 x 2778\n\n\tBattery: 4352 MAH\n\n\tCamera: Triple camera with 12MP main\n\n\tProcessor: A15 Bionic Chip\n\n\tGraphics: A15 Bionic Chip\n\n\tOperating System: IOS 15\n\n\tOther Features: Single SIM, IP68 Water & Dust Resistant, Face ID, Apple Pay, Wireless Charging\n{Sel}");
                    CheckInput1();
                    if (UserInput == "1")
                    { Cart.Add("Apple iPhone 13 Pro Max"); Bal -= 1999; Cost += 1999; Out($"\t{NameConcat}, you have added (Apple iPhone 13 Pro Max) to your Cart"); }
                    if (UserInput == "2")
                    { ExitApp(); }
                    if (UserInput == "3")
                    {
                        if (Cart.Contains("Apple iPhone 13 Pro Max"))
                        { Cart.Remove("Apple iPhone 13 Pro Max"); Bal += 1999; Cost -= 1999; Out($"\t{NameConcat}, you have removed (Apple iPhone 13 Pro Max) from your Cart"); }
                    }
                    ItemsMenuExtension();
                    break;
                case "5":
                    Out($"\t{NameConcat}, you have selected the Apple iPhone 13 Pro.\n\n\tThe specifications of this phone are;\n\n\n\tWarranty: 2 Years\n\n\tStorage: 128GB with 6GB RAM\n\n\tScreen: 6.1 inch 120HZ display with a resolution of 1170 x 2532\n\n\tBattery: 3095 MAH\n\n\tCamera: Triple camera with 12MP main\n\n\tProcessor: A15 Bionic Chip\n\n\tGraphics: A15 Bionic Chip\n\n\tOperating System: IOS 15\n\n\tOther Features: Single SIM, IP68 Water & Dust Resistant, Face ID, Apple Pay, Wireless Charging\n{Sel}");
                    CheckInput1();
                    if (UserInput == "1")
                    { Cart.Add("Apple iPhone 13 Pro"); Bal -= 1799; Cost += 1799; Out($"\t{NameConcat}, you have added (Apple iPhone 13 Pro) to your Cart"); }
                    if (UserInput == "2")
                    { ExitApp(); }
                    if (UserInput == "3")
                    {
                        if (Cart.Contains("Apple iPhone 13 Pro"))
                        { Cart.Remove("Apple iPhone 13 Pro"); Bal += 1799; Cost -= 1799; Out($"\t{NameConcat}, you have removed (Apple iPhone 13 Pro) from your Cart"); }
                    }
                    ItemsMenuExtension();
                    break;
                case "6":
                    Out($"\t{NameConcat}, you have selected the Apple iPhone 13.\n\n\tThe specifications of this phone are;\n\n\n\tWarranty: 2 Years\n\n\tStorage: 128GB with 4GB RAM\n\n\tScreen: 6.1 inch 60HZ display with a resolution of 1170 x 2532\n\n\tBattery: 3227 MAH\n\n\tCamera: Dual camera with 12MP main\n\n\tProcessor: A15 Bionic Chip\n\n\tGraphics: A15 Bionic Chip\n\n\tOperating System: IOS 15\n\n\tOther Features: Single SIM, IP68 Water & Dust Resistant, Face ID, Apple Pay, Wireless Charging\n{Sel}");
                    CheckInput1();
                    if (UserInput == "1")
                    { Cart.Add("Apple iPhone 13"); Bal -= 1429; Cost += 1429; Out($"\t{NameConcat}, you have added (Apple iPhone 13) to your Cart"); }
                    if (UserInput == "2")
                    { ExitApp(); }
                    if (UserInput == "3")
                    {
                        if (Cart.Contains("Apple iPhone 13"))
                        { Cart.Remove("Apple iPhone 13"); Bal += 1429; Cost -= 1429; Out($"\t{NameConcat}, you have removed (Apple iPhone 13) from your Cart"); }
                    }
                    ItemsMenuExtension();
                    break;
                case "7":
                    Out($"\t{NameConcat}, you have selected the Apple iPhone 13 Mini.\n\n\tThe specifications of this phone are;\n\n\n\tWarranty: 2 Years\n\n\tStorage: 512GB with 4GB RAM\n\n\tScreen: 5.4 inch 60HZ display with a resolution of 1080 x 2340\n\n\tBattery: 2406 MAH\n\n\tCamera: Dual camera with 12MP main\n\n\tProcessor: A15 Bionic Chip\n\n\tGraphics: A15 Bionic Chip\n\n\tOperating System: IOS 15\n\n\tOther Features: Single SIM, IP68 Water & Dust Resistant, Face ID, Apple Pay, Wireless Charging\n{Sel}");
                    CheckInput1();
                    if (UserInput == "1")
                    { Cart.Add("Apple iPhone 13 Mini"); Bal -= 1849; Cost += 1849; Out($"\t{NameConcat}, you have added (Apple iPhone 13 Mini) to your Cart"); }
                    if (UserInput == "2")
                    { ExitApp(); }
                    if (UserInput == "3")
                    {
                        if (Cart.Contains("Apple iPhone 13 Mini"))
                        { Cart.Remove("Apple iPhone 13 Mini"); Bal += 1849; Cost -= 1849; Out($"\t{NameConcat}, you have removed (Apple iPhone 13 Mini) from your Cart"); }
                    }
                    ItemsMenuExtension();
                    break;
                case "8":
                    Out($"\t{NameConcat}, you have selected the Apple iPhone SE 3rd Gen.\n\n\tThe specifications of this phone are;\n\n\n\tWarranty: 2 Years\n\n\tStorage: 128GB with 4GB RAN\n\n\tScreen: 4.7 inch 60HZ display with a resolution of 750 x 1334\n\n\tBattery: 2018 MAH\n\n\tCamera: Single camera with 12MP main\n\n\tProcessor: A15 Bionic Chip\n\n\tGraphics: A15 Bionic Chip\n\n\tOperating System: IOS 15\n\n\tOther Features: Single SIM, IP67 Water & Dust Resistant, Face ID, Apple Pay, Wireless Charging\n{Sel}");
                    CheckInput1();
                    if (UserInput == "1")
                    { Cart.Add("Apple iPhone SE 3rd Gen"); Bal -= 899; Cost += 899; Out($"\t{NameConcat}, you have added (Apple iPhone SE 3rd Gen) to your Cart"); }
                    if (UserInput == "2")
                    { ExitApp(); }
                    if (UserInput == "3")
                    {
                        if (Cart.Contains("Apple iPhone SE 3rd Gen"))
                        { Cart.Remove("Apple iPhone SE 3rd Gen"); Bal += 899; Cost -= 899; Out($"\t{NameConcat}, you have removed (Apple iPhone SE 3rd Gen) from your Cart"); }
                    }
                    ItemsMenuExtension();
                    break;
                default:
                    Out("\n\n\tInvalid Input, Try Again.\n");
                    PhonesMenu();
                    break;
            }
        }
        public static void TelevisionsMenu()
        {
            string[] Product = new string[5] { "Philips PUT7906/75 55 Inch 4K Smart TV", "Philips PUT7906/75 65 Inch 4K Smart TV", "Samsung AU8000 50 Inch 4K Smart TV", "Samsung Neo QN700 75 Inch 8K Smart TV", "Samsung Neo QN800A 85 Inch 8K Smart TV" };
            string[] ProductPricing = new string[5] { "$899.00", "$1,399.00", "$1,099.00", "$4,999.00", "$8,050.00" };

            for (int i = 1; i <= Product.Length; i++)
            {
                if (i == 1)
                { Out($"\n\n\t{NameConcat}, you have selected Televisions. Choose from all products listed below.\n\n\n\t4K TV's:\n"); }
                if (i == 4)
                { Out("\n\t8K TV's:\n"); }

                Out($"\tEnter {i}  -  {ProductPricing[i - 1]}  -  {Product[i - 1]}");
            }
            Out("\n");

            UserInput = Console.ReadLine();
            switch (UserInput)
            {
                case "1": // 4K TV's
                    Out($"\t{NameConcat}, you have selected the Philips PUT7906/75 55 Inch 4K Smart TV.\n\n\tThe specifications of this TV are;\n\n\n\tWarranty: 2 Years\n\n\tScreen Size: 55 Inch\n\n\tResolution: 3840x2160\n\n\tRefresh Rate: 60HZ\n\n\tOther Features: HDR Compatible, Ambilight\n{Sel}");
                    CheckInput1();
                    if (UserInput == "1")
                    { Cart.Add("Philips PUT7906/75 55 Inch 4K Smart TV"); Bal -= 899; Cost += 899; Out($"\t{NameConcat}, you have added (Philips PUT7906/75 55 Inch 4K Smart TV) to your Cart"); }
                    if (UserInput == "2")
                    { ExitApp(); }
                    if (UserInput == "3")
                    {
                        if (Cart.Contains("Philips PUT7906/75 55 Inch 4K Smart TV"))
                        { Cart.Remove("Philips PUT7906/75 55 Inch 4K Smart TV"); Bal += 899; Cost -= 899; Out($"\t{NameConcat}, you have removed (Philips PUT7906/75 55 Inch 4K Smart TV) from your Cart"); }
                    }
                    ItemsMenuExtension();
                    break;
                case "2":
                    Out($"\t{NameConcat}, you have selected the Philips PUT7906/75 65 Inch 4K Smart TV.\n\n\tThe specifications of this TV are;\n\n\n\tWarranty: 2 Years\n\n\tScreen Size: 65 Inch\n\n\tResolution: 3840x2160\n\n\tRefresh Rate: 60HZ\n\n\tOther Features: HDR Compatible, Ambilight\n{Sel}");
                    CheckInput1();
                    if (UserInput == "1")
                    { Cart.Add("Philips PUT7906/75 65 Inch 4K Smart TV"); Bal -= 1399; Cost += 1399; Out($"\t{NameConcat}, you have added (Philips PUT7906/75 65 Inch 4K Smart TV) to your Cart"); }
                    if (UserInput == "2")
                    { ExitApp(); }
                    if (UserInput == "3")
                    {
                        if (Cart.Contains("Philips PUT7906/75 65 Inch 4K Smart TV"))
                        { Cart.Remove("Philips PUT7906/75 65 Inch 4K Smart TV"); Bal += 1399; Cost -= 1399; Out($"\t{NameConcat}, you have removed (Philips PUT7906/75 65 Inch 4K Smart TV) from your Cart"); }
                    }
                    ItemsMenuExtension();
                    break;
                case "3":
                    Out($"\t{NameConcat}, you have selected the Samsung AU8000 50 Inch 4K Smart TV.\n\n\tThe specifications of this TV are;\n\n\n\tWarranty: 1 Year\n\n\tScreen Size: 50 Inch\n\n\tResolution: 3840x2160\n\n\tRefresh Rate: 60HZ\n\n\tOther Features: HDR Compatible, Amazon Alexa\n{Sel}");
                    CheckInput1();
                    if (UserInput == "1")
                    { Cart.Add("Samsung AU8000 50 Inch 4K Smart TV"); Bal -= 1099; Cost += 1099; Out($"\t{NameConcat}, you have added (Samsung AU8000 50 Inch 4K Smart TV) to your Cart"); }
                    if (UserInput == "2")
                    { ExitApp(); }
                    if (UserInput == "3")
                    {
                        if (Cart.Contains("Samsung AU8000 50 Inch 4K Smart TV"))
                        { Cart.Remove("Samsung AU8000 50 Inch 4K Smart TV"); Bal += 1099; Cost -= 1099; Out($"\t{NameConcat}, you have removed (Samsung AU8000 50 Inch 4K Smart TV) from your Cart"); }
                    }
                    ItemsMenuExtension();
                    break;
                case "4": // 8K TV's
                    Out($"\t{NameConcat}, you have selected the Samsung Neo QN700 75 Inch 8K Smart TV.\n\n\tThe specifications of this TV are;\n\n\n\tWarranty: 1 Year\n\n\tScreen Size: 75 Inch\n\n\tResolution: 7680x4320\n\n\tRefresh Rate: 60HZ\n\n\tOther Features: HDR Compatible, Mini LED, Amazon Alexa\n{Sel}");
                    CheckInput1();
                    if (UserInput == "1")
                    { Cart.Add("Samsung Neo QN700 75 Inch 8K Smart TV"); Bal -= 4999; Cost += 4999; Out($"\t{NameConcat}, you have added (Samsung Neo QN700 75 Inch 8K Smart TV"); }
                    if (UserInput == "2")
                    { ExitApp(); }
                    if (UserInput == "3")
                    {
                        if (Cart.Contains("Samsung Neo QN700 75 Inch 8K Smart TV"))
                        { Cart.Remove("Samsung Neo QN700 75 Inch 8K Smart TV"); Bal += 4999; Cost -= 4999; Out($"\t{NameConcat}, you have removed (Samsung Neo QN700 75 Inch 8K Smart TV) from your Cart"); }
                    }
                    ItemsMenuExtension();
                    break;
                case "5":
                    Out($"\t{NameConcat}, you have selected the Samsung Neo QN800A 85 Inch 8K Smart TV.\n\n\tThe specifications of this TV are;\n\n\n\tWarranty: 1 Year\n\n\tScreen Size: 85 Inch\n\n\tResolution: 7680x4320\n\n\tRefresh Rate: 60HZ\n\n\tOther Features: HDR Compatible, Mini LED, Amazon Alexa\n{Sel}");
                    CheckInput1();
                    if (UserInput == "1")
                    { Cart.Add("Samsung Neo QN800A 85 Inch 8K Smart TV"); Bal -= 8050; Cost += 8050; Out($"\t{NameConcat}, you have added (Samsung Neo QN800A 85 Inch 8K Smart TV"); }
                    if (UserInput == "2")
                    { ExitApp(); }
                    if (UserInput == "3")
                    {
                        if (Cart.Contains("Samsung Neo QN800A 85 Inch 8K Smart TV"))
                        { Cart.Remove("Samsung Neo QN800A 85 Inch 8K Smart TV"); Bal += 8050; Cost -= 8050; Out($"\t{NameConcat}, you have removed (Samsung Neo QN800A 85 Inch 8K Smart TV) from your Cart"); }
                    }
                    ItemsMenuExtension();
                    break;
                default:
                    Out("\n\n\tInvalid Input, Try Again.\n");
                    TelevisionsMenu();
                    break;
            }
        }
        public static void ItemsMenuExtension()
        {
            if (Cart.Count > 0) // Skips over this code if the number of items in the cart is 0
            {
                Out($"\n\n{NameConcat}'s Cart:{Decoration}Items:");
                foreach (string temp in Cart)
                { Console.Write(temp + ", "); }
                Out($"{Decoration}Current Total: ${Cost}{Decoration}");
            }

            Out("\n\tEnter 1  -  Checkout\n\tEnter 2  -  Continue Shopping\n\tEnter 3  -  Exit Application\n\n");
            CheckInput1();
            if (UserInput == "1")
            { CheckOutDisplay(); }
            if (UserInput == "2")
            { CategoriesMenu(); }
            if (UserInput == "3")
            { ExitApp(); }
        }
        public static void CheckInput1() // Checks for 3 wrong inputs
        {
            UserInput = Console.ReadLine();
            while (UserInput != "1" && UserInput != "2" && UserInput != "3")
            {
                Out("\n\n\tInvalid Input, Try Again.\n\n");
                UserInput = Console.ReadLine();
            }
            Out("\n\n\tValid Input\n\n"); // when the loop stops because of a valid input it will break away from the while function. If it passes through to this part of the program its a valid input
        }
        public static void CheckInput2() // Checks for 2 wrong inputs
        {
            UserInput = Console.ReadLine();
            while (UserInput != "1" && UserInput != "2")
            {
                Out("\n\tInvalid Input, Try Again.\n\n");
                UserInput = Console.ReadLine();
            }
            Out("\n\n\tValid Input\n\n");
        }
        public static void CheckOutDisplay()
        {
            if (Bal < 0) // If Bal is less than zero it will give the user the **option** to add Funds to the Bal Variable
            {
                Out("\n\tInsufficient Funds\n\n\n\tEnter 1  -  Add Funds\n\tEnter 2  -  Continue Shopping (Don't Add Funds)\n\tEnter 3  -  Exit Application\n\n");
                CheckInput1();

                if (UserInput == "1")
                {
                    Out("\n\tEnter how much $$$$ you would like\n\n");
                    Bal += decimal.Parse(Console.ReadLine());
                }
                if (UserInput == "2")
                { CategoriesMenu(); }
                if (UserInput == "3")
                { ExitApp(); }
            }
            if (Cart.Count > 0)
            {
                if (Bal >= 0) // If Bal is greater than or equal to 0 it will display the CheckOut function
                {
                    Out($"\n\tPurchasing Items....\n\n\n{NameConcat}'s Shopping Cart:{Decoration}Purchased Items:");
                    foreach (string temp in Cart)
                    { Console.Write(temp + ", "); }
                    Out($"{Decoration}Remaining Balance: ${Bal}\nTotal Cost: ${Cost}{Decoration}");
                }
                Out("\n\n\tEnter 1  -  Restart Application\n\tEnter 2  -  Exit Application\n\n");

                CheckInput2();
                if (UserInput == "1")
                {
                    Out("\n\tRestarting Application....\n\n");
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
                Out("\n\n\tEnter 1  -  Continue Shopping\n\tEnter 2  -  Exit Application\n\n");

                CheckInput2();
                if (UserInput == "1")
                { CategoriesMenu(); }
                if (UserInput == "2")
                { ExitApp(); }
            }
        }
        public static void ExitApp()
        {
            Out($"\n\n\tAre you sure you want to Exit the Application you have ({Cart.Count}) Item(s) in your Cart\n\n\n\tEnter 1  -  Continue Shopping\n\tEnter 2  -  Exit Application\n\n");

            CheckInput2();
            if (UserInput == "1")
            { CategoriesMenu(); }
            if (UserInput == "2")
            { Environment.Exit(0); }
        }
        public static void Out(string message) => Console.WriteLine(message); // Simplification to convert the argument Console.WriteLine(message); to Out(message);
        static void Main(string[] args) => GiveAwayDisplay();
    }
}

