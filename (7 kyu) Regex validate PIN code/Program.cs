using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace Regex_validate_PIN_code
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ValidatePin("1234\n"));
            Console.WriteLine(ValidatePin("125"));
            Console.WriteLine(ValidatePin("2234"));
            Console.WriteLine(ValidatePin("王老五喔"));
            Console.WriteLine(string.Empty);
            Console.WriteLine(ValidatePin2("1234\n"));
            Console.WriteLine(ValidatePin2("125"));
            Console.WriteLine(ValidatePin2("2234"));
            Console.WriteLine(ValidatePin2("王老五喔"));
        }

        public static bool ValidatePin(string pin)
        {
            //↓↓↓ First Practice
            return Regex.IsMatch(pin, "\\D") ? false : Regex.IsMatch(pin, "^\\d{4}$|^\\d{6}$") || false;
        }

        //↓↓↓ Use Linq
        public static bool ValidatePin2(string pin)
        {
            return (pin.Length == 4 || pin.Length == 6) && pin.All(c => char.IsDigit(c));
        }
    }
}
