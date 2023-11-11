namespace LoremIpsumLogistica.Dominio.Interfaces.UnidadeDeTrabalho
{
    public interface IUnidadeDeTrabalho : IDisposable
    {
        void Iniciar();
        bool Inicializada();
        bool CheckPoint();
        bool ConcluirTransacao();
        void DesfazerTransacao();
    }
}
