using GP.Aplicacao.DTO;
using GP.Dados.EntidadesConfig;
using GP.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RecursosCompartilhados.Dados.Contexto;
using System;

namespace GP.Dados.Contexto
{
    public class GPContexto : BaseContexto
    {
        public DbSet<Patrimonio> Patrimonios { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatrimonioConfig());
            modelBuilder.ApplyConfiguration(new MarcaConfig());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("connection.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
