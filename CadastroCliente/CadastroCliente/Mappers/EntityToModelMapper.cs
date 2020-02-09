using AutoMapper;
using CadastroCliente.Entidades;
using CadastroCliente.Models;

namespace CadastroCliente.Mappers
{
    public class EntityToModelMapper : Profile
    {
        public EntityToModelMapper()
        {
            CreateMap<Cliente, ClienteViewModel>()
                .AfterMap((ps, pst) => Mapper.Map(ps.Enderecos, pst));
            CreateMap<Endereco, EnderecoViewModel>();
        }
    }
}