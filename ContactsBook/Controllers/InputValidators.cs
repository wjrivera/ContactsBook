using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsBook.Controllers
{
    public class InputValidators
    {
        // TODO: IMPLEMENT THIS
        public static int CheckNumberInput()
        {
            var correct = true;
            string input;

            while (correct)
            {
                input = Console.ReadLine();
                if (input.All(char.IsDigit))
                {
                    correct = false;
                    return Convert.ToInt32(input);
                }
                Console.Write("Please enter the value: ");
            }
            return -1;
        }

        // TODO: IMPLEMENT THIS
        public static string CheckNoInput()
        {
            var correct = true;
            string input;

            while (correct)
            {
                input = Console.ReadLine();
                if (input.Length > 0)
                {
                    correct = false;
                    return input;
                }
                Console.Write("Please enter the word: ");
            }
            return "";
        }

        // TODO: IMPLEMENT THIS
        public static bool CheckYesOrNo()
        {
            var correct = true;
            string input;

            while (correct)
            {
                input = Console.ReadLine();
                if (input.Length > 0 && (input == "Y" || input == "y" || input == "Yes" || input == "yes" || input == "YES"))
                {
                    correct = false;
                    return true;
                }
                if (input.Length > 0 && (input == "N" || input == "n" || input == "No" || input == "no" || input == "NO"))
                {
                    correct = false;
                    return false;
                }
                Console.Write("Please enter a Yes or No answer: ");

            }
            return false;
        }
    }
}
