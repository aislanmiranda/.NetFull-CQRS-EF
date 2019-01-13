using System.IO;
using Red.Domain.Models;
using Red.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Red.Infra.Data.Context
{
    public class RedContext : DbContext
    {
        
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
                        
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO: rever código abaixo para pegar string de conexão
            //var config = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();
            //optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

            // define the database to use  
            optionsBuilder.UseSqlServer("data source=NBRSK-045; initial catalog=CQRS; user id=sa; password=yourStrong(!)Password;");
        }
    }
}
