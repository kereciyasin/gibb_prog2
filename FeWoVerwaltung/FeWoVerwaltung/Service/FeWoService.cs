using FeWoVerwaltung.Data;
using FeWoVerwaltung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeWoVerwaltung.Service
{
    public class FeWoService : IService<FeWo>
    {
        private readonly Context _context;

        public FeWoService(Context context)
        {
            _context = context;
        }

        public long Erstellen(FeWo model)
        {
            _context.FeWos.Add(model);
            _context.SaveChanges();
            return model.Id;
        }

        public bool Aktualisieren(FeWo model)
        {
            if (!_context.FeWos.Any(f => f.Id == model.Id)) return false;
            _context.FeWos.Update(model);
            return _context.SaveChanges() > 0;
        }

        public bool Deaktivieren(long id)
        {
            var fewo = _context.FeWos.Find(id);
            if (fewo == null) return false;
            fewo.Inaktiv = true;
            return _context.SaveChanges() > 0;
        }

        public FeWo LesenEinzeln(long id)
        {
            return _context.FeWos.Find(id);
        }

        public List<FeWo> LesenAlle()
        {
            return _context.FeWos.ToList();
        }

        public List<FeWo> LesenAlleAktive()
        {
            return _context.FeWos.Where(f => !f.Inaktiv).ToList();
        }
    }
}
