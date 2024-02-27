using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramowanieKuchenkaProjekt
{
    public class Diagnostic

    {
        public void RunDiagnostic()
        {
            Console.WriteLine("*** URUCHAMIANIE DIAGONOSTYKI ***");
            Thread.Sleep(1500);

            bool isAnythingBroken = false;

            Console.WriteLine("*** SPRAWDZANIE NAPIĘCIA PRĄDU ***");
            Thread.Sleep(1500);
            if (RandomFailure())
            {
                Console.WriteLine("!!! BŁĄD: Napięcie prądu nieprawidłowe !!!");
                isAnythingBroken = true;
            }

            Console.WriteLine("*** SPRAWDZANIE FUNCKJONALNOŚCI GRZAŁKI ***");
            Thread.Sleep(1500);
            if (RandomFailure())
            {
                Console.WriteLine("!!! BŁĄD: Grzałka nie działa poprawnie !!!");
                isAnythingBroken = true;
            }

            Console.WriteLine("*** SPRAWDZANIE FUNCKJONALNOŚCI ŻARÓWKI ***");
            Thread.Sleep(1500);
            if (RandomFailure())
            {
                Console.WriteLine("!!! BŁĄD: Żarówka nie działa poprawnie !!!");
                isAnythingBroken = true;
            }

            Console.WriteLine("*** SPRAWDZANIE FUNKCJONALNOŚCI TALERZA OBROTOWEGO ***");
            Thread.Sleep(1500);
            if (RandomFailure())
            {
                Console.WriteLine("!!! BŁĄD: Talerz obrotowy nie działa poprawnie !!!");
                isAnythingBroken = true;
            }

            Console.WriteLine("*** SPRAWDZANIE SZCZELNOŚCI DRZWI ***");
            Thread.Sleep(1500);
            if (RandomFailure())
            {
                Console.WriteLine("!!! BŁĄD: Drzwi nie są szczelne !!!");
                isAnythingBroken = true;
            }

            Console.WriteLine("*** SPRAWDZANIE WERSJI OPROGRAMOWANIA ***");
            Thread.Sleep(1500);
            if (RandomFailure())
            {
                Console.WriteLine("!!! BŁĄD: Wersja oprogramowania jest nieaktualna !!!");
                isAnythingBroken = true;
            }

            Console.WriteLine("*** SPRAWDZANIE ZABEZPIECZEŃ ***");
            Thread.Sleep(1500);
            if (RandomFailure())
            {
                Console.WriteLine("!!! BŁĄD: Zabezpieczenia nie działają poprawnie !!!");
                isAnythingBroken = true;
            }

            if (!isAnythingBroken)
            {
                Console.WriteLine("Diagnostyka przebiegła pomyślnie.");
            }

            else
            {
                Console.WriteLine("Czy chcesz próbować naprawić? (T/N)");

                string choice = Console.ReadLine();

                if (choice.Equals("T", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Próba naprawy...");
                    Thread.Sleep(3000);
                    Console.WriteLine("Naprawa zakończona sukcesem.");
                }
                else
                {
                    Console.WriteLine("Nie podjęto próby naprawy.");
                }
            }
        }

        public static bool RandomFailure()
        {

            return new Random().Next(10) == 0;
        }
    }
}
