using AutoMapper;
using LoremIpsumLogistica.Aplicacao.Dtos;
using LoremIpsumLogistica.UI.Api.Models;

namespace LoremIpsumLogistica.UI.Api.AutoMapper
{
    public class DTOParaModel : Profile
    {
        public DTOParaModel()
        {

            CreateMap<ClienteCadastroModel, ClienteCadastroDTO>();
            CreateMap<ClienteEnderecoCadastroModel, ClienteEnderecoCadastroDTO>();
        }
    }
}
