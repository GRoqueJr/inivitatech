using LoremIpsumLogistica.Aplicacao.Dtos;
using LoremIpsumLogistica.Aplicacao.Interfaces;
using LoremIpsumLogistica.Dominio.Entidades;
using LoremIpsumLogistica.Dominio.Interfaces.Repositorios;
using LoremIpsumLogistica.Dominio.Interfaces.Servicos;
using LoremIpsumLogistica.Dominio.Interfaces.UnidadeDeTrabalho;
using Microsoft.Extensions.Configuration;

namespace LoremIpsumLogistica.Aplicacao.Servicos
{
    public class ServicoDeAplicacaoDeClientesEnderecos : ServicoDeAplicacao, IServicoDeAplicacaoDeClientesEnderecos
    {
        #region Construtores

        private readonly IServicoDeDominioDeClientesEnderecos _servicoDeDominioDeClientesEnderecos;
        private readonly IRepositorioDeClientes _repositorioDeClientes;
        private readonly IRepositorioDeClientesEnderecos _repositorioDeClientesEnderecos;


        public ServicoDeAplicacaoDeClientesEnderecos(
            IServicoDeDominioDeClientesEnderecos servicoDeDominioDeClientesEnderecos,
            IRepositorioDeClientes repositorioDeClientes,
            IRepositorioDeClientesEnderecos repositorioDeClientesEnderecos,
            IUnidadeDeTrabalho unidadeDeTrabalho,
            IConfiguration configuration) : base(unidadeDeTrabalho, configuration)
        {
            _servicoDeDominioDeClientesEnderecos = servicoDeDominioDeClientesEnderecos;
            _repositorioDeClientes = repositorioDeClientes;
            _repositorioDeClientesEnderecos = repositorioDeClientesEnderecos;
        }

        #endregion


        #region Manipulação
        public ClienteEndereco? Cadastrar(ClienteEnderecoCadastroDTO parametros)
        {
            ClienteEndereco? clienteEndereco;

            if (parametros.Id > 0)
            {
                /* EDIÇÃO */
                clienteEndereco = this.Recuperar(parametros.Id);

                /* Não encontrou o endereço através do ID */
                if (clienteEndereco == null)
                {
                    throw new Exception("Endereço não encontrado");
                }


                clienteEndereco.SetarCep(parametros.Cep);
                clienteEndereco.SetarCidade(parametros.Cidade);
                clienteEndereco.SetarComercial(parametros.Comercial);
                clienteEndereco.SetarComplemento(parametros.Complemento);
                clienteEndereco.SetarLogradouro(parametros.Logradouro);
                clienteEndereco.SetarBairro(parametros.Bairro);
                clienteEndereco.SetarCidade(parametros.Cidade);
                clienteEndereco.SetarUf(parametros.Uf);
                clienteEndereco.SetarNumero(parametros.Numero);

                clienteEndereco.SetarDataDeAlteracao();
                
            }
            else
            {

                /* Valida se o cliente informado é valido para receber um endereço */
                if (!_repositorioDeClientes.Existe(parametros.ClienteId))
                {
                    throw new Exception("Cliente não encontrado para receber o endereço");
                }

                /* INCLUSÃO */
                clienteEndereco = new ClienteEndereco(parametros.ClienteId,
                    parametros.Cep,
                    parametros.Logradouro,
                    parametros.Numero,
                    parametros.Complemento,
                    parametros.Bairro,
                    parametros.Cidade,
                    parametros.Uf,
                    parametros.Comercial);
            }

            /* Regras de validação da Entidade */
            clienteEndereco.Validar();


            /* Efetiva a persistencia no banco de dados */
            this.IniciarUnidadeDeTrabalho();
            _servicoDeDominioDeClientesEnderecos.Cadastrar(clienteEndereco);
            this.ConcluirUnidadeDeTrabalho();

            return clienteEndereco;
        }

        public void Excluir(int id)
        {

            /* Recupera o endereço na base */
            var clienteEndereco = this.Recuperar(id);

            /* Não encontrou o endereço através do ID */
            if (clienteEndereco == null)
            {
                throw new Exception("Endereço não encontrado");
            }


            /* Efetiva a exclusão no banco de dados */
            this.IniciarUnidadeDeTrabalho();
            _servicoDeDominioDeClientesEnderecos.Excluir(clienteEndereco);
            this.ConcluirUnidadeDeTrabalho();

        }
        #endregion

        #region Recuperação
        public ClienteEndereco? Recuperar(int id)
        {
            var clienteEndereco = _repositorioDeClientesEnderecos.Recuperar(id);
            return clienteEndereco;
        }

        public ICollection<ClienteEndereco> RecuperarTodos(int clienteId)
        {
            var clienteEnderecos = _repositorioDeClientesEnderecos.Recuperar(x => x.ClienteId == clienteId);
            return clienteEnderecos;
        }
        #endregion
    }
}
