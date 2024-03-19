using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TPVehicule.Tools
{
    public static class ConsoleHelper
    {
        public static string GetStringFromConsole(string label)
        {
            WriteLine(label);
            var input = ReadLine();

            while (string.IsNullOrWhiteSpace(input))
            {
                WriteLine("Entrée incorrecte, veuilllez réessayer");
                input = ReadLine();
            }
            return input;
        }

        public static int GetIntFromConsole(string label) 
        {
            int inputNumber;
            var input = GetStringFromConsole(label);

            while (!int.TryParse(input, out inputNumber))
            {
                WriteLine("Entrée incorrecte, veuillez réessayer");
                input = ReadLine();
            }

            return inputNumber;
        }

        public static bool VerifInputNumberVehicle(this string numVehicle) 
        {
            if (!string.IsNullOrEmpty(numVehicle) && numVehicle.Length >= 4 && numVehicle.Length <= 6)
            {
                bool isValid = true;

                foreach (char c in numVehicle)
                {
                    if (!char.IsDigit(c))
                    {
                        isValid = false;
                        break;
                    }
                }
                return isValid ? true : throw new Exception("Le numéros doit contenir entre 4 et 6 caratères numériques uniquement");               
            }
            else throw new Exception("Le numéros doit contenir entre 4 et 6 caratères numériques");
        }

        public static void ExitConsoleApp()
        {
            WriteLine("----- Programe terminé, appuyez sur Entrée pour quitter -----");
            ReadLine();
        }
    }
}
