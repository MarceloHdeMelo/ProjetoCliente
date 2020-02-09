using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroCliente.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}