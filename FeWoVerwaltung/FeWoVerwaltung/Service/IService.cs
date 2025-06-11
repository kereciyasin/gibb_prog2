using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeWoVerwaltung.Service
{
    public interface IService<T> where T : class
    {
        T LesenEinzeln(long id);
        List<T> LesenAlleAktive();
        List<T> LesenAlle();
        long Erstellen(T model);
        bool Aktualisieren(T model);
        bool Deaktivieren(long id);
    }
}
