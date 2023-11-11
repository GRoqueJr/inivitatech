using LoremIpsumLogistica.Dominio.Entidades;

namespace LoremIpsumLogistica.Dominio.Interfaces.Servicos
{
    public interface IServicoDeDominioDeClientes
    {
        void Cadastrar(Cliente entidade);
        void Excluir(Cliente entidade);
    }
}
