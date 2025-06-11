using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeWoVerwaltung.Model
{
    public class Buchung : Model
    {
        public byte Kalenderwoche { get; set; }
        public byte AnzahlPersonen { get; set; }

        // Navigation Property: Welche FeWo wurde gebucht?
        public long FeWoId { get; set; }
        public FeWo? FeWo { get; set; }
    }
}
