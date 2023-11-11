namespace LoremIpsumLogistica.Aplicacao.Interfaces
{
    public interface IServicoDeAplicacao
    {
        Guid Instancia { get; }
        void IniciarUnidadeDeTrabalho();
        bool ConcluirUnidadeDeTrabalho();
    }
}
