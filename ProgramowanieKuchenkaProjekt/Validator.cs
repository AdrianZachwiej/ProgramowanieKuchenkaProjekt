using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramowanieKuchenkaProjekt
{
    public static class Validator
    {
        public static bool IsValidCookingTime(int cookingTime)
        {
            return cookingTime <= 0;
        }

        public static bool ValidateProductName(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }
    }
}
