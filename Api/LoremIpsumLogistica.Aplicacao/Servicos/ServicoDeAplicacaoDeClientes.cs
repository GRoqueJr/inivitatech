using LoremIpsumLogistica.Aplicacao.Dtos;
using LoremIpsumLogistica.Aplicacao.Interfaces;
using LoremIpsumLogistica.Dominio.Entidades;
using LoremIpsumLogistica.Dominio.Interfaces.Repositorios;
using LoremIpsumLogistica.Dominio.Interfaces.Servicos;
using LoremIpsumLogistica.Dominio.Interfaces.UnidadeDeTrabalho;
using Microsoft.Extensions.Configuration;

namespace LoremIpsumLogistica.Aplicacao.Servicos
{
    public class ServicoDeAplicacaoDeClientes : ServicoDeAplicacao, IServicoDeAplicacaoDeClientes
    {
        #region Construtores

        private readonly IServicoDeDominioDeClientes _servicoDeDominioDeClientes;
        private readonly IRepositorioDeClientes _repositorioDeClientes;

        public ServicoDeAplicacaoDeClientes(
            IServicoDeDominioDeClientes servicoDeDominioDeClientes,
            IRepositorioDeClientes repositorioDeClientes,
            IUnidadeDeTrabalho unidadeDeTrabalho,
            IConfiguration configuration) : base(unidadeDeTrabalho, configuration)
        {
            _servicoDeDominioDeClientes = servicoDeDominioDeClientes;
            _repositorioDeClientes = repositorioDeClientes;
        }

        #endregion


        #region Manipulação
        public Cliente? Cadastrar(ClienteCadastroDTO parametros)
        {
            Cliente? cliente;

            if (parametros.Id > 0)
            {
                /* EDIÇÃO */
                cliente = this.Recuperar(parametros.Id);

                /* Não encontrou o cliente através do ID */
                if (cliente == null)
                {
                    throw new Exception("Cliente não encontrado");
                }

                cliente.SetarNome(parametros.Nome);
                cliente.SetarDataDeNascimento(parametros.DataDeNascimento);
                cliente.SetarTipoDeClienteSexo(parametros.TipoDeClienteSexo);
                cliente.SetarDataDeAlteracao();

            }
            else
            {
                /* INCLUSÃO */
                cliente = new Cliente(  parametros.Nome,
                                        parametros.DataDeNascimento,
                                        parametros.TipoDeClienteSexo);
            }

            /* Regras de validação da Entidade */
            cliente.Validar();


            /* Efetiva a persistencia no banco de dados */
            this.IniciarUnidadeDeTrabalho();
            _servicoDeDominioDeClientes.Cadastrar(cliente);
            this.ConcluirUnidadeDeTrabalho();

            return cliente;
        }

        public void Excluir(int id)
        {

                /* Recupera o cliente na base */
                var cliente = this.Recuperar(id);

                /* Não encontrou o cliente através do ID */
                if (cliente == null)
                {
                    throw new Exception("Cliente não encontrado");
                }


            /* Efetiva a exclusão no banco de dados */
            this.IniciarUnidadeDeTrabalho();
            _servicoDeDominioDeClientes.Excluir(cliente);
            this.ConcluirUnidadeDeTrabalho();

        }
        #endregion

        #region Recuperação
        public Cliente? Recuperar(int id)
        {
            var cliente = _repositorioDeClientes.Recuperar(id);
            return cliente;
        }

        public ICollection<Cliente> RecuperarTodos()
        {
            var clientes = _repositorioDeClientes.RecuperarTodos();
            return clientes;
        }
        #endregion
    }
}
