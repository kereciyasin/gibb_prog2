using FeWoVerwaltung.Data;
using FeWoVerwaltung.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeWoVerwaltung.Service
{
    public class BuchungService : IService<Buchung>
    {
        private readonly Context _context;

        public BuchungService(Context context)
        {
            _context = context;
        }

        public long Erstellen(Buchung model)
        {
            _context.Buchungen.Add(model);
            _context.SaveChanges();
            return model.Id;
        }

        public bool Aktualisieren(Buchung model)
        {
            if (!_context.Buchungen.Any(b => b.Id == model.Id)) return false;
            _context.Buchungen.Update(model);
            return _context.SaveChanges() > 0;
        }

        public bool Deaktivieren(long id)
        {
            var buchung = _context.Buchungen.Find(id);
            if (buchung == null) return false;
            buchung.Inaktiv = true;
            return _context.SaveChanges() > 0;
        }

        public Buchung LesenEinzeln(long id)
        {
            return _context.Buchungen
                .Include(b => b.FeWo)
                .FirstOrDefault(b => b.Id == id);
        }

        public List<Buchung> LesenAlle()
        {
            return _context.Buchungen
                .Include(b => b.FeWo)
                .ToList();
        }

        public List<Buchung> LesenAlleAktive()
        {
            return _context.Buchungen
                .Where(b => !b.Inaktiv)
                .Include(b => b.FeWo)
                .ToList();
        }
    }
}
