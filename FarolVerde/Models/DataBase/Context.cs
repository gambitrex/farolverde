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

        protected override void Dispose(bool disposing)
        {
            Configuration.LazyLoadingEnabled = false;
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<DTO.Company>().
            //  HasMany(c => c.Autorizations).
            //  WithMany(a => a.Companies).
            //  Map(
            //   m =>
            //   {
            //       m.ToTable("Companies_Autorizations");
            //       m.MapLeftKey("CompanyId");
            //       m.MapRightKey("AutorizationId");
            //   });
        }
    }
}
