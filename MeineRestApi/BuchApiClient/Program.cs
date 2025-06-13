using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BuchApiClient
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static readonly string apiUrl = "http://localhost:7005/Buch";

        static async Task Main(string[] args)
        {
            Console.WriteLine("1: Buch hinzufügen");
            Console.WriteLine("2: Alle Bücher anzeigen");
            Console.WriteLine("Wähle eine Option:");
            var option = Console.ReadLine();

            if (option == "1")
            {
                await NeuesBuchAnlegen();
            }
            else if (option == "2")
            {
                await AlleBuecherAnzeigen();
            }
            else
            {
                Console.WriteLine("Ungültige Option!");
            }
        }

        static async Task NeuesBuchAnlegen()
        {
            var buch = new Buch();
            Console.Write("Titel: ");
            buch.Titel = Console.ReadLine();
            Console.Write("Autor: ");
            buch.Autor = Console.ReadLine();
            Console.Write("Erscheinungsjahr: ");
            buch.Erscheinungsjahr = int.Parse(Console.ReadLine());

            string json = JsonConvert.SerializeObject(buch);
            var content = new StringContent(json, Encoding.UTF8);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Buch erfolgreich hinzugefügt!");
            }
            else
            {
                Console.WriteLine("Fehler beim Hinzufügen: " + response.StatusCode);
            }
        }

        static async Task AlleBuecherAnzeigen()
        {
            var response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var buecher = JsonConvert.DeserializeObject<List<Buch>>(json);
                foreach (var buch in buecher)
                {
                    Console.WriteLine($"{buch.Id}: {buch.Titel} von {buch.Autor} ({buch.Erscheinungsjahr})");
                }
            }
            else
            {
                Console.WriteLine("Fehler beim Laden: " + response.StatusCode);
            }
        }
    }
}