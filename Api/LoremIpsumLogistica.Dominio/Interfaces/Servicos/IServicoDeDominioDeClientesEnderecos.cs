using LoremIpsumLogistica.Dominio.Entidades;

namespace LoremIpsumLogistica.Dominio.Interfaces.Servicos
{
    public interface IServicoDeDominioDeClientesEnderecos
    {
        void Cadastrar(ClienteEndereco entidade);
        void Excluir(ClienteEndereco entidade);
    }
}
