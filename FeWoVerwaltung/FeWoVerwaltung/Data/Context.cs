using FeWoVerwaltung.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeWoVerwaltung.Data
{
    public class Context : DbContext
    {
        public DbSet<FeWo> FeWos { get; set; }
        public DbSet<Buchung> Buchungen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Verbindung zu KERECI\SQLEXPRESS mit Windows-Authentifizierung und Verschlüsselung
            optionsBuilder.UseSqlServer(
                "Server=KERECI\\SQLEXPRESS;Database=FeWoVerwaltung;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");
        }
    }
}
