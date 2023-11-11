using LoremIpsumLogistica.Dominio.Entidades;
using LoremIpsumLogistica.Dominio.Interfaces.Repositorios;
using LoremIpsumLogistica.Infraestrutura.Repositorio.Context;

namespace LoremIpsumLogistica.Infraestrutura.Repositorio.Repositorios
{
    public class RepositorioDeClientes : Repositorio<Cliente>, IRepositorioDeClientes
    {
        public RepositorioDeClientes(
            LoremDbContext context) : base(context) 
        { }
    }
}
