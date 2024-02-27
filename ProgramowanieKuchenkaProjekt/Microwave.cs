using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramowanieKuchenkaProjekt
{
    public class Microwave
    {
        private const int cleanAfter = 5;
        private List<Product> products = new List<Product>();
        private int usageCount = 0;
        private ProductManager productManager;
        private UsageHistoryManager usageHistoryManager = new UsageHistoryManager();
        private ConsoleClear consoleClear = new ConsoleClear();
        private Diagnostic diagnostic = new Diagnostic();

        public Microwave()
        {
            productManager = new ProductManager(products);
            productManager.LoadProducts();
            usageHistoryManager.LoadUsageHistory("usage_history.txt");
        }

        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("=== Menu ===");
                Console.WriteLine("1. Rozpocznij nowy cykl podgrzewania");
                Console.WriteLine("2. Wyświetl historię użycia");
                Console.WriteLine("3. Pokaż listę produktów");
                Console.WriteLine("4. Zarządzaj produktami");
                Console.WriteLine("5. Wyczyść historię użycia");
                Console.WriteLine("6. Posprzątaj mikrofalówkę");
                Console.WriteLine("7. Diagnostyka");
                Console.WriteLine("8. Wyjdź");
                Console.Write("Wybierz opcję: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        StartCooking();
                        consoleClear.Clean();
                        break;
                    case "2":
                        Console.Clear();
                        DisplayUsageHistory();
                        consoleClear.Clean();
                        break;
                    case "3":
                        Console.Clear();
                        DisplayProductList();
                        consoleClear.Clean();
                        break;
                    case "4":
                        Console.Clear();
                        productManager.ManageProducts();
                        consoleClear.Clean();
                        break;
                    case "5":
                        Console.Clear();
                        usageHistoryManager.ClearUsageHistory();
                        Console.WriteLine("Historia użycia została wyczyszczona.");
                        consoleClear.Clean();
                        break;
                    case "6":
                        Console.Clear();
                        CleanMicrowave();
                        Console.WriteLine("Mikrofalówka została posprzątana.");
                        consoleClear.Clean();
                        break;
                    case "7":
                        Console.Clear();
                        diagnostic.RunDiagnostic();
                        consoleClear.Clean();
                        break;
                    case "8":
                        exit = true;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                        break;
                }
            }

            usageHistoryManager.SaveUsageHistory("usage_history.txt");
        }

        public void StartCooking()
        {
            if (usageCount >= cleanAfter)
            {
                Console.WriteLine("Uwaga: Mikrofalówka wymaga czyszczenia!");
                return;
            }
            Console.WriteLine("Podaj nazwę produktu z listy:");
            DisplayProductList();
            Console.WriteLine("Wybierz produkt: ");
            string selectedProduct = Console.ReadLine();

            Product product = products.FirstOrDefault(p => p.Name.Equals(selectedProduct, StringComparison.OrdinalIgnoreCase));

            if (product != null)

            {
                Console.WriteLine("Podaj czas podgrzewania (w sekundach): ");
                int realCookingTime;
                if (!int.TryParse(Console.ReadLine(), out realCookingTime) || Validator.IsValidCookingTime(realCookingTime))
                {
                    Console.WriteLine("Nieprawidłowy czas podgrzewania.");
                    return;
                }

                Console.WriteLine($"Mikrofalówka włączyła się i rozpoczyna podgrzewanie produktu '{product.Name}' przez {realCookingTime} sekund.");

                Console.WriteLine("Czy chcesz przerwać podgrzewanie? (T/N)");
                string choice = Console.ReadLine();

                if (choice.Equals("T", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Podgrzewanie przerwane.");
                    return;
                }

                Console.WriteLine("Podgrzewanie w toku...");

                int acceptableDifference = (int)(product.CookingTime * 0.1);
                int difference = realCookingTime - product.CookingTime;
                if (difference > acceptableDifference)
                {
                    Console.WriteLine("Podgrzewanie zakończone. Uwaga: Jedzenie jest spalone!");
                    string logMessage = $"Uwaga: Podgrzewanie '{product.Name}' zakończone po czasie {realCookingTime} sekund - jedzenie spalone!";
                    usageHistoryManager.AddUsage(logMessage);
                }
                else if (difference < -acceptableDifference)
                {
                    Console.WriteLine("Podgrzewanie zakończone. Uwaga: Jedzenie jest zimne!");
                    string logMessage = $"Uwaga: Podgrzewanie '{product.Name}' zakończone po czasie {realCookingTime} sekund - jedzenie zimne!";
                    usageHistoryManager.AddUsage(logMessage);
                }
                else
                {
                    Console.WriteLine("Podgrzewanie zakończone, pyszne jedzenie gotowe.");
                    string logMessage = $"Podgrzewanie '{product.Name}' zakończone po czasie {realCookingTime} sekund.";
                    usageHistoryManager.AddUsage(logMessage);
                }

                usageCount++;
                
            }
            else
            {
                Console.WriteLine("Nieprawidłowy produkt.");
            }
        }

        public void DisplayUsageHistory()
        {
            Console.WriteLine("=== Historia użycia ===");
            foreach (var usage in usageHistoryManager.UsageHistory)
            {
                Console.WriteLine(usage);
            }
        }

        public void DisplayProductList()
        {
            Console.WriteLine("=== Lista produktów ===");
            foreach (var product in products)
            {
                Console.WriteLine($"{char.ToUpper(product.Name[0])}{product.Name.Substring(1)} - Zalecany czas grzania: {product.CookingTime} sekund");
            }
        }

        
        public void CleanMicrowave()
        {
            usageCount = 0;
        }
              
    }
}

