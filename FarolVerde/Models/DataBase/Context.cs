using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace FarolVerde.Models.DataBase
{
    public class Context : DbContext
    {
        public Context(string connectionString = "FarolVerde") : base(connectionString)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public Context() : base("FarolVerde")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Ocorrencia> Ocorrencias { get; set; }
        public DbSet<Logradouro> Logradouros { get; set; }
        public DbSet<Acidente> Acidentes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Vitima> Vitimas { get; set; }
        public DbSet<Stop> Stops { get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void Dispose(bool disposing)
        {
            Configuration.LazyLoadingEnabled = false;
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Trip>().
            //  HasMany(t => t.Stops).
            //  WithMany(s => s.Trips).
            //  Map(
            //   m =>
            //   {
            //       m.ToTable("stop_times");
            //       m.MapLeftKey("trip_id");
            //       m.MapRightKey("stop_id");
            //   });
        }
    }
}
