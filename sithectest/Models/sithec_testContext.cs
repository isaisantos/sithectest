using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace sithectest.Models
{
    public partial class sithec_testContext : DbContext
    {
        public sithec_testContext()
        {
        }

        public sithec_testContext(DbContextOptions<sithec_testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Humanos> Humanos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder();
                builder.AddJsonFile("appsettings.json", optional: false);
                IConfiguration _configuration = builder.Build();
                string connectionString = _configuration.GetConnectionString("sithectestContext").ToString();

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Humanos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Altura)
                    .HasColumnName("altura")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Peso)
                    .HasColumnName("peso")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Sexo)
                    .HasColumnName("sexo")
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
