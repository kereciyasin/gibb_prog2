using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BooksApi.Models; // Book modeli için referans

namespace BooksConsoleClient
{
    class Program
    {
        static readonly string apiUrl = "http://localhost:5051/api/Books";
        static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n1 - Bücher auflisten");
                Console.WriteLine("2 - Buch hinzufügen");
                Console.WriteLine("0 - Beenden");
                Console.Write("Ihre Auswahl: ");
                var auswahl = Console.ReadLine();

                if (auswahl == "1")
                    await BücherAuflisten();
                else if (auswahl == "2")
                    await BuchHinzufügen();
                else if (auswahl == "0")
                    break;
                else
                    Console.WriteLine("Ungültige Auswahl!");
            }
        }

        static async Task BücherAuflisten()
        {
            try
            {
                var response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var bücher = JsonConvert.DeserializeObject<List<Book>>(json);

                Console.WriteLine("--- Bücher ---");
                foreach (var buch in bücher)
                {
                    Console.WriteLine($"Id: {buch.Id}, Titel: {buch.Title}, Autor: {buch.Author}, Jahr: {buch.Year}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler: " + ex.Message);
            }
        }

        static async Task BuchHinzufügen()
        {
            try
            {
                Console.Write("Titel: ");
                var titel = Console.ReadLine();
                Console.Write("Autor: ");
                var autor = Console.ReadLine();
                Console.Write("Jahr: ");
                var jahr = int.Parse(Console.ReadLine());

                var buch = new Book { Title = titel, Author = autor, Year = jahr };
                var json = JsonConvert.SerializeObject(buch);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                    Console.WriteLine("Buch wurde erfolgreich hinzugefügt!");
                else
                    Console.WriteLine("Ein Fehler ist aufgetreten: " + response.StatusCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler: " + ex.Message);
            }
        }
    }
}