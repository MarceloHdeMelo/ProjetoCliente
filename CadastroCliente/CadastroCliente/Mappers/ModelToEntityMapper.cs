using AutoMapper;
using CadastroCliente.Entidades;
using CadastroCliente.Models;

namespace CadastroCliente.Mappers
{
    public class ModelToEntityMapper : Profile
    {
        public ModelToEntityMapper()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<EnderecoViewModel, Endereco>();
        }
    }
}