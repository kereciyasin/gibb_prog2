using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuchApiClient
{
    public class Buch
    {
        public long Id { get; set; }
        public string Titel { get; set; }
        public string Autor { get; set; }
        public int Erscheinungsjahr { get; set; }
    }
}
