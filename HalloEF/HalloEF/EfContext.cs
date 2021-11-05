using HalloEF.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HalloEF
{
    internal class EfContext : DbContext
    {
        public DbSet<Person> Personen { get; set; }
        public DbSet<Mitarbeiter> Mitarbeiter { get; set; }
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Abteilung> Abteilungen { get; set; }

        public EfContext() : base("Server=(localdb)\\mssqllocaldb;Database=HalloEF;Trusted_Connection=true")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Mitarbeiter>().ToTable("Mitarbeiter");
            modelBuilder.Entity<Kunde>().ToTable("Kunden");
            modelBuilder.Entity<Person>().ToTable("Personen");

            modelBuilder.Entity<Mitarbeiter>().Property(x => x.Beruf)
                                              .IsRequired()
                                              .HasColumnName("Job")
                                              .HasMaxLength(68);


        }
    }
}
