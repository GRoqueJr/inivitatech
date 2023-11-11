using AutoMapper;
using LoremIpsumLogistica.Dominio.Entidades;
using LoremIpsumLogistica.UI.Api.Models;

namespace LoremIpsumLogistica.UI.Api.AutoMapper
{
    public class DominioParaModel : Profile
    {
        public DominioParaModel() 
        {
            CreateMap<ClienteEndereco, ClienteEnderecoModel>();
            CreateMap<Cliente, ClienteModel>();
        }
    }
}
