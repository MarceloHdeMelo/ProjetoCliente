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
        }

        public DbSet<Cliente> Clientes { get; set; }
    }    
}