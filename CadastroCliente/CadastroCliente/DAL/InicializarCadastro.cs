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
                new Cliente{Nome="Láiza Guerreiro Maciel",DataNascimento=DateTime.Parse("1998-04-08"),Sexo="F"},
                new Cliente{Nome="Marcelo Henrique de Melo",DataNascimento=DateTime.Parse("1991-04-09"),Sexo="M"},
                new Cliente{Nome="José da Silva",DataNascimento=DateTime.Parse("1968-01-18"),Sexo="M"},
                new Cliente{Nome="Giovana Lima Souza",DataNascimento=DateTime.Parse("2002-03-24"),Sexo="F"},
                new Cliente{Nome="Anderson Soares",DataNascimento=DateTime.Parse("1982-11-27"),Sexo="M"}
            };
            clientes.ForEach(c => contexto.Clientes.Add(c));
            contexto.SaveChanges();

            var enderecos = new List<Endereco>
            {
                new Endereco{Id=1,CEP="87043-722",Logradouro="Rua Vereador Paulo de Barros Campelo",Numero=280,Complemento="",Bairro="Jardim Colina Verde",Estado="PR",Cidade="Maringá",ClienteId=1},
                new Endereco{Id=2,CEP="87043-722",Logradouro="Rua Vereador Paulo de Barros Campelo",Numero=280,Complemento="",Bairro="Jardim Colina Verde",Estado="PR",Cidade="Maringá",ClienteId=2},
                new Endereco{Id=3,CEP="87040-370",Logradouro="Rua Nicarágua",Numero=599,Complemento="A",Bairro="Lea Leal",Estado="PR",Cidade="Maringá",ClienteId=3},
                new Endereco{Id=4,CEP="	87013-204",Logradouro="Avenida Brasil",Numero=1000,Complemento="",Bairro="Centro",Estado="PR",Cidade="Maringá",ClienteId=4},
                new Endereco{Id=5,CEP="	87013-204",Logradouro="Avenida São Paulo",Numero=780,Complemento="",Bairro="Centro",Estado="PR",Cidade="Maringá",ClienteId=5},
                new Endereco{Id=1,CEP="87040-360",Logradouro="Avenida Tuiuti",Numero=1652,Complemento="",Bairro="Vila Morangueira",Estado="PR",Cidade="Maringá",ClienteId=2}
            };
            enderecos.ForEach(e => contexto.Enderecos.Add(e));
            contexto.SaveChanges();
        }
    }
}