using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadastroCliente.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Nome deve ter no maximo {1} caracteres.")]
        [MinLength(3, ErrorMessage = "Nome deve ter no minimo {1} caracteres.")]
        [Display(Name = "Nome Completo: ")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }

        //public Endereco Endereco { get; set; }

        public virtual ICollection<EnderecoViewModel> Enderecos { get; set; }

        public ClienteViewModel()
        {
            Enderecos = new Collection<EnderecoViewModel>();
        }
    }
}