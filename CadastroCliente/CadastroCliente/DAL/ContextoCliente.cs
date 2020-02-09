using CadastroCliente.Entidades;
using CadastroCliente.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CadastroCliente.DAL
{
    public class ContextoCliente : DbContext

    {
        public ContextoCliente() : base("ContextoCliente")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new EnderecoConfiguration());
            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

    }

    

    public class EnderecoConfiguration : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfiguration()
        {
            ToTable("Endereco");
            HasKey(endereco => endereco.Id);

            Property(endereco => endereco.Id)
                .IsRequired();

            Property(endereco => endereco.Logradouro)
                 .HasColumnName("Logradouro")
                 .HasMaxLength(50)
                 .HasColumnType("varchar")
                 .IsRequired();

            HasRequired(endereco => endereco.Cliente)
                .WithMany(cliente => cliente.Enderecos);
        }
    }
}