using LoremIpsumLogistica.Aplicacao.Interfaces;
using LoremIpsumLogistica.Dominio.Interfaces.UnidadeDeTrabalho;
using Microsoft.Extensions.Configuration;

namespace LoremIpsumLogistica.Aplicacao.Servicos
{
    public abstract class ServicoDeAplicacao : IServicoDeAplicacao
    {
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

        public Guid Instancia { get; private set; }
        public IConfiguration _configuration;
       
        public ServicoDeAplicacao(IUnidadeDeTrabalho unidadeDeTrabalho, 
            IConfiguration configuration
            )
        {
            Instancia = Guid.NewGuid();
            
            _unidadeDeTrabalho = unidadeDeTrabalho;
            _configuration = configuration;

        }

        public void IniciarUnidadeDeTrabalho()
        {
            _unidadeDeTrabalho.Iniciar();
        }

        public bool UnidadeDeTrabalhoIniciada()
        {
            return _unidadeDeTrabalho.Inicializada();
        }

        public bool ConcluirUnidadeDeTrabalho()
        {
            if (this.UnidadeDeTrabalhoIniciada())
            {
                try
                {
                    return (_unidadeDeTrabalho.ConcluirTransacao());
                }
                catch (Exception e)
                {
                    return false;
                    throw;
                }
            }
            return false;
        }

        public void Dispose()
        {
            _unidadeDeTrabalho.Dispose();
        }
    }
}
