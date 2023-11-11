using LoremIpsumLogistica.Aplicacao.Dtos;
using LoremIpsumLogistica.Dominio.Entidades;

namespace LoremIpsumLogistica.Aplicacao.Interfaces
{
    public interface IServicoDeAplicacaoDeClientes
    {
        #region Manipulações
        Cliente? Cadastrar(ClienteCadastroDTO parametros);
        void Excluir(int id);
        #endregion Manipulações

        #region Recuperação
        Cliente? Recuperar(int id);

        ICollection<Cliente> RecuperarTodos();
        #endregion
    }
}
