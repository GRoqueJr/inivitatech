using LoremIpsumLogistica.Dominio.Entidades;
using LoremIpsumLogistica.Dominio.Interfaces.Repositorios;
using LoremIpsumLogistica.Dominio.Interfaces.Servicos;

namespace LoremIpsumLogistica.Dominio.Servicos
{
    public class ServicoDeDominioDeClientesEnderecos : IServicoDeDominioDeClientesEnderecos
    {
        private readonly IRepositorioDeClientesEnderecos _repositorioDeClientesEnderecos;

        public ServicoDeDominioDeClientesEnderecos(IRepositorioDeClientesEnderecos repositorioDeClientesEnderecos)
        {
            _repositorioDeClientesEnderecos = repositorioDeClientesEnderecos;
        }

        public void Cadastrar(ClienteEndereco entidade)
        {
            if(entidade.Id == 0)
            _repositorioDeClientesEnderecos.Adicionar(entidade);
            else
            _repositorioDeClientesEnderecos.Atualizar(entidade);
        }

        public void Excluir(ClienteEndereco entidade)
        {
            _repositorioDeClientesEnderecos.Apagar(entidade);
        }
    }
}
