using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ProcessoSeletivoModel;
using StructureMap;
using System;

namespace ProcessoSeletivoDataContext
{
    #region Constructors
    public class ProcessoSeletivoContext : DbContext
    {
        public ProcessoSeletivoContext() : base()
        {
            
        }
        #endregion

        public DbSet<NivelExperienciaModel> NivelExperiencia { get; set; }
        public DbSet<VagaModel> Vaga { get; set; }
        public DbSet<PessoaModel> Pessoa { get; set; }
        public DbSet<CandidaturaModel> Candidatura { get; set; }
        public DbSet<DistanciaModel> Distancia { get; set; }

        #region Overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(@"ProcessoSeletivo");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VagaModel>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<PessoaModel>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<CandidaturaModel>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<DistanciaModel>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

            builder.Entity<VagaModel>().Property(f => f.Descricao).IsRequired();

        }
        #endregion
    }
}