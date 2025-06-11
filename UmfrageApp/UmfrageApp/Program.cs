namespace UmfrageApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Überladung
            string antwort1 = Umfrage.StelleFrage("Frage 1", "Wie heisst dein Haustier?");
            Console.WriteLine("Antwort: " + antwort1);

            // 2. Überladung
            string antwort2 = Umfrage.StelleFrage("Frage 2", "Wie alt bist du?", false);
            Console.WriteLine("Antwort: " + antwort2);

            // 3. Überladung
            string antwort3 = Umfrage.StelleFrage("Frage 3", "Bitte nur Kleinbuchstaben eingeben!", "Bitte Eingabe machen", "^[a-z]+$");
            Console.WriteLine("Antwort: " + antwort3);
        }
    }
}
