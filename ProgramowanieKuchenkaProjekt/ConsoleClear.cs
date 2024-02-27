using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramowanieKuchenkaProjekt
{
    public class ConsoleClear
    {
        public void Clean()
        {
            Console.WriteLine("Naciśnij dowolny klawisz, aby powrócić do menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
