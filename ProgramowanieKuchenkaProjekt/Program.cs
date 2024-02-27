using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProgramowanieKuchenkaProjekt
{
    public class Program
    {
        static void Main(string[] args)

        {
            Console.OutputEncoding = Encoding.UTF8;
            Microwave microwave = new Microwave();
            microwave.Run();
        }
    }
}