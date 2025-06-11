using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmfrageApp
{
    public class Umfrage
    {
        // 1. Versiyon: Sadece frageNr ve frageText
        public static string StelleFrage(string frageNr, string frageText)
        {
            Console.WriteLine($"{frageNr}: {frageText}");
            string eingabe = Console.ReadLine();
            return eingabe;
        }

        // 2. Versiyon: frageNr, frageText, pflicht
        public static string StelleFrage(string frageNr, string frageText, bool pflicht)
        {
            string eingabe;
            do
            {
                Console.WriteLine($"{frageNr}: {frageText}");
                eingabe = Console.ReadLine();
                if (pflicht && string.IsNullOrWhiteSpace(eingabe))
                {
                    Console.WriteLine("Dies ist eine Pflichtfrage. Bitte eine Eingabe machen!");
                }
            } while (pflicht && string.IsNullOrWhiteSpace(eingabe));
            return eingabe;
        }

        // 3. Versiyon: frageNr, frageText, hinweis, regex
        public static string StelleFrage(string frageNr, string frageText, string hinweis, string regex)
        {
            string eingabe;
            System.Text.RegularExpressions.Regex muster = new System.Text.RegularExpressions.Regex(regex);
            do
            {
                Console.WriteLine($"{frageNr}: {frageText}");
                Console.WriteLine(hinweis);
                eingabe = Console.ReadLine();
                if (!muster.IsMatch(eingabe ?? ""))
                {
                    Console.WriteLine("Ungültiges Format! Bitte erneut versuchen.");
                }
            } while (!muster.IsMatch(eingabe ?? ""));
            return eingabe;
        }
    }
}
