using FeWoVerwaltung.Data;
using FeWoVerwaltung.Model;
using FeWoVerwaltung.Service;

namespace FeWoVerwaltung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                var fewoService = new FeWoService(context);
                var buchungService = new BuchungService(context);

                // Temiz başlangıç için tüm verileri kaldır
                context.Buchungen.RemoveRange(context.Buchungen);
                context.FeWos.RemoveRange(context.FeWos);
                context.SaveChanges();

                // 3 FeWo ekle
                var fewos = new[]
                {
                    new FeWo { Name = "FeWo1", Ort = "Ort1", PreisProWoche = 100 },
                    new FeWo { Name = "FeWo2", Ort = "Ort2", PreisProWoche = 200 },
                    new FeWo { Name = "FeWo3", Ort = "Ort3", PreisProWoche = 300 }
                };
                foreach (var f in fewos) fewoService.Erstellen(f);

                // FeWos'u JSON ile yazdır
                foreach (var f in fewoService.LesenAlle())
                    Console.WriteLine(f.ToJSON());

                // 3 Buchung ekle
                var buchungen = new[]
                {
                    new Buchung { Name = "Buchung1", Kalenderwoche = 1, AnzahlPersonen = 1, FeWoId = fewos[0].Id },
                    new Buchung { Name = "Buchung2", Kalenderwoche = 2, AnzahlPersonen = 2, FeWoId = fewos[0].Id },
                    new Buchung { Name = "Buchung3", Kalenderwoche = 3, AnzahlPersonen = 3, FeWoId = fewos[1].Id }
                };
                foreach (var b in buchungen) buchungService.Erstellen(b);

                // Buchungen'i JSON ile yazdır
                foreach (var b in buchungService.LesenAlle()
                    .OrderBy(x => x.Id))
                    Console.WriteLine(b.ToJSON());

                // Aynı FeWo ve Kalenderwoche'da yeni rezervasyon dene
                var neueBuchung = new Buchung
                {
                    Name = "Buchung4",
                    Kalenderwoche = 2,
                    AnzahlPersonen = 4,
                    FeWoId = fewos[0].Id
                };

                var existiert = buchungService.LesenAlle()
                    .Any(b => b.FeWoId == neueBuchung.FeWoId && b.Kalenderwoche == neueBuchung.Kalenderwoche);

                if (existiert)
                    Console.WriteLine("Ferienwohnung Feld besetzt in Kalenderwoche 2");
                else
                    buchungService.Erstellen(neueBuchung);

                // FeWo2 güncelle (ör: Ort değişsin)
                var updateFeWo = fewoService.LesenEinzeln(fewos[0].Id);
                updateFeWo.Ort = "Neuer Ort";
                fewoService.Aktualisieren(updateFeWo);

                // Tekrar FeWos'u yazdır
                foreach (var f in fewoService.LesenAlle())
                    Console.WriteLine(f.ToJSON());

                // Buchungen'i tekrar yazdır
                foreach (var b in buchungService.LesenAlle()
                    .OrderBy(x => x.Id))
                    Console.WriteLine(b.ToJSON());
            }

            Console.ReadLine();
        }
    }

}
