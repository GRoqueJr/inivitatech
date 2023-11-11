using LoremIpsumLogistica.Dominio.Entidades;
using LoremIpsumLogistica.Dominio.Interfaces.Repositorios;
using LoremIpsumLogistica.Infraestrutura.Repositorio.Context;

namespace LoremIpsumLogistica.Infraestrutura.Repositorio.Repositorios
{
    public class RepositorioDeClientesEnderecos : Repositorio<ClienteEndereco>, IRepositorioDeClientesEnderecos
    {
        public RepositorioDeClientesEnderecos(
            LoremDbContext context) : base(context) 
        { }
    }
}
