using CadastroCliente.Entidades;
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
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Data Nascimento: ")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Sexo: ")]
        public Sexo Sexo { get; set; }
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        [Display(Name = "E-mail: ")]
        public string Email { get; set; }
        [Display(Name = "CEP: ")]
        public string CEP { get; set; }
        [Display(Name = "Logradouro: ")]
        public string Logradouro { get; set; }
        [Display(Name = "Número: ")]
        public int Numero { get; set; }
        [Display(Name = "Complemento: ")]
        public string Complemento { get; set; }
        [Display(Name = "Bairro: ")]
        public string Bairro { get; set; }
        [Display(Name = "Estado: ")]
        public string Estado { get; set; }
        [Display(Name = "Cidade: ")]
        public string Cidade { get; set; }
    }
}