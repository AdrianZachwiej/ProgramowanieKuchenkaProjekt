using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramowanieKuchenkaProjekt
{
    public class Product
    {
        public string Name { get; set; }
        public int CookingTime { get; set; }

        public Product(string name, int cookingTime)
        {
            Name = name;
            CookingTime = cookingTime;
        }
    }
}
