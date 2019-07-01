using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary.Test
{
    public static class AuxiliaryMethods
    {
        public static bool IsDigitsOrLettersOnly(string line)
        {
            foreach (var symbol in line.ToCharArray())
            {
                if (symbol >= 128 || char.IsLetterOrDigit(symbol) == false)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsLettersOnly(string line)
        {
            foreach (var symbol in line.ToCharArray())
            {
                if (symbol >= 128 || char.IsLetter(symbol) == false)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsDigitsOnly(string line)
        {
            foreach (var symbol in line.ToCharArray())
            {
                if (symbol >= 128 || char.IsDigit(symbol) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
