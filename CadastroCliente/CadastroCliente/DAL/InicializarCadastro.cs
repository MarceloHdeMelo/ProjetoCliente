using CadastroCliente.Entidades;
using CadastroCliente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroCliente.DAL
{
    public class InicializarCadastro : System.Data.Entity.DropCreateDatabaseIfModelChanges<ContextoCliente>
    {
        protected override void Seed(ContextoCliente contexto)
        {
            var clientes = new List<Cliente>
            {
                new Cliente{Nome="Luiza Pereira Ramos",DataNascimento=DateTime.Parse("1998-04-08"),Sexo=Sexo.F,CEP="87040-200",Logradouro="Rua Maracaibo",Numero=280,Complemento="A",Bairro="Vila Morangueira",Estado="PR",Cidade="Maringá"},
                new Cliente{Nome="Marcelo Henrique de Melo",DataNascimento=DateTime.Parse("1991-04-09"),Sexo=Sexo.M,CEP="87043-722",Logradouro="Rua Vereador Paulo de Barros Campelo",Numero=280,Complemento="B",Bairro="Jardim Colina Verde",Estado="PR",Cidade="Maringá"},
                new Cliente{Nome="José da Silva",DataNascimento=DateTime.Parse("1968-01-12"),Sexo=Sexo.M,CEP="87040-370",Logradouro="Rua Nicarágua",Numero=599,Complemento="A",Bairro="Lea Leal",Estado="PR",Cidade="Maringá"},
                new Cliente{Nome="Giovana Lima Souza",DataNascimento=DateTime.Parse("2002-03-01"),Sexo=Sexo.F,CEP="87013-204",Logradouro="Avenida Brasil",Numero=1000,Complemento="",Bairro="Centro",Estado="PR",Cidade="Maringá"},
                new Cliente{Nome="Anderson Soares",DataNascimento=DateTime.Parse("1982-11-03"),Sexo=Sexo.M,CEP="87013-204",Logradouro="Avenida São Paulo",Numero=780,Complemento="",Bairro="Centro",Estado="PR",Cidade="Maringá"}
            };
            clientes.ForEach(c => contexto.Clientes.Add(c));
            contexto.SaveChanges();
        }
    }
}