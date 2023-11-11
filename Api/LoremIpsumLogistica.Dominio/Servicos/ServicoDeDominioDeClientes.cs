using LoremIpsumLogistica.Dominio.Entidades;
using LoremIpsumLogistica.Dominio.Interfaces.Repositorios;
using LoremIpsumLogistica.Dominio.Interfaces.Servicos;

namespace LoremIpsumLogistica.Dominio.Servicos
{
    public class ServicoDeDominioDeClientes : IServicoDeDominioDeClientes
    {
        private readonly IRepositorioDeClientes _repositorioDeClientes;

        public ServicoDeDominioDeClientes(IRepositorioDeClientes repositorioDeClientes)
        {
            _repositorioDeClientes = repositorioDeClientes;
        }

        public void Cadastrar(Cliente entidade)
        {
            if (entidade.Id == 0)
                _repositorioDeClientes.Adicionar(entidade);
            else
                _repositorioDeClientes.Atualizar(entidade);
        }

        public void Excluir(Cliente entidade)
        {
            _repositorioDeClientes.Apagar(entidade);
        }
    }
}
