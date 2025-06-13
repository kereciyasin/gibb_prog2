using MeineRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MeineRestApi.Context
{
    /// <summary>
    /// Der Datenbankkontext für die Buch-Tabelle.
    /// </summary>
    public class BuchContext : DbContext
    {
        public BuchContext(DbContextOptions<BuchContext> options) : base(options) { }
        public DbSet<Buch> Buecher { get; set; }
    }
}
