using LoremIpsumLogistica.Aplicacao.Dtos;
using LoremIpsumLogistica.Dominio.Entidades;

namespace LoremIpsumLogistica.Aplicacao.Interfaces
{
    public interface IServicoDeAplicacaoDeClientesEnderecos
    {
        #region Manipulações
        ClienteEndereco? Cadastrar(ClienteEnderecoCadastroDTO parametros);
        void Excluir(int id);
        #endregion Manipulações

        #region Recuperação
        ClienteEndereco? Recuperar(int id);

        ICollection<ClienteEndereco> RecuperarTodos(int clienteId);
        #endregion
    }
}
