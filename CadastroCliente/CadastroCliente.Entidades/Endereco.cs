﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroCliente.Entidades
{
    public class Endereco
    {
        public int Id { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

    }
}