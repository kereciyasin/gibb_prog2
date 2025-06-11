using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeWoVerwaltung.Model
{
    public abstract class Model
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Inaktiv { get; set; } = false;

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
