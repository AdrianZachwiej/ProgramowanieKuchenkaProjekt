using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramowanieKuchenkaProjekt
{
    public class ProductManager
    {
        private List<Product> products;

        public ProductManager(List<Product> products)
        {
            this.products = products;
        }

        public void ManageProducts()
        {
            Console.WriteLine("=== Zarządzanie produktami ===");
            Console.WriteLine("1. Dodaj nowy produkt");
            Console.WriteLine("2. Usuń produkt");
            Console.WriteLine("3. Edytuj produkt");
            Console.WriteLine("4. Wyjdź");
            Console.Write("Wybierz opcję: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    RemoveProduct();
                    break;
                case "3":
                    EditProduct();
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Nieprawidłowa opcja.");
                    break;
            }
        }

        private void AddProduct()
        {
            Console.WriteLine("Podaj nazwę nowego produktu: ");
            string productName = Console.ReadLine().ToLower();
            if (!Validator.ValidateProductName(productName))
            {
                Console.WriteLine("Nazwa produktu nie może być pusta.");
                return;
            }
            Console.WriteLine("Podaj czas grzania (w sekundach): ");
            int cookingTime;
            if (!int.TryParse(Console.ReadLine(), out cookingTime) || Validator.IsValidCookingTime(cookingTime))
            {
                Console.WriteLine("Nieprawidłowy czas grzania.");
                return;
            }
            products.Add(new Product(productName, cookingTime));
            SaveProducts();
            Console.WriteLine("Produkt dodany pomyślnie.");
        }

        private void RemoveProduct()
        {
            Console.WriteLine("Podaj nazwę produktu do usunięcia: ");
            string productToDelete = Console.ReadLine().ToLower();
            if (!Validator.ValidateProductName(productToDelete))
            {
                Console.WriteLine("Nazwa produktu nie może być pusta.");
                return;
            }
            Product productToRemove = products.FirstOrDefault(p => p.Name.Equals(productToDelete, StringComparison.OrdinalIgnoreCase));
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
                SaveProducts();
                Console.WriteLine("Produkt usunięty pomyślnie.");
            }
            else
            {
                Console.WriteLine("Nieprawidłowy produkt.");
            }
        }

        private void EditProduct()
        {
            Console.WriteLine("Podaj nazwę produktu do edycji: ");
            string productToEdit = Console.ReadLine().ToLower();
            if (!Validator.ValidateProductName(productToEdit))
            {
                Console.WriteLine("Nazwa produktu nie może być pusta.");
                return;
            }
            Product product = products.FirstOrDefault(p => p.Name.Equals(productToEdit, StringComparison.OrdinalIgnoreCase));
            if (product != null)
            {
                Console.WriteLine($"Podaj nową nazwę dla produktu '{product.Name}': ");
                string newName = Console.ReadLine().ToLower();
                if (!Validator.ValidateProductName(newName))
                {
                    Console.WriteLine("Nowa nazwa produktu nie może być pusta.");
                    return;
                }
                Console.WriteLine("Podaj nowy czas grzania (w sekundach): ");
                int newCookingTime;
                if (!int.TryParse(Console.ReadLine(), out newCookingTime) || Validator.IsValidCookingTime(newCookingTime))
                {
                    Console.WriteLine("Nieprawidłowy czas grzania.");
                    return;
                }
                product.Name = newName;
                product.CookingTime = newCookingTime;
                SaveProducts();
                Console.WriteLine("Produkt edytowany pomyślnie.");
            }
            else
            {
                Console.WriteLine("Nieprawidłowy produkt.");
            }
        }

        public void LoadProducts()
        {
            if (File.Exists("products.txt"))
            {
                string[] lines = File.ReadAllLines("products.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    products.Add(new Product(parts[0], int.Parse(parts[1])));
                }
            }
        }

        private void SaveProducts()
        {
            using (StreamWriter writer = new StreamWriter("products.txt"))
            {
                foreach (var product in products)
                {
                    writer.WriteLine($"{product.Name},{product.CookingTime}");
                }
            }
        }
    }
}
