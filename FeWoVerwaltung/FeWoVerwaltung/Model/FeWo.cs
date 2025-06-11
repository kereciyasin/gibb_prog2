using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeWoVerwaltung.Model
{
    public class FeWo : Model
    {
        public string Ort { get; set; } = string.Empty;
        public int PreisProWoche { get; set; }
    }
}
