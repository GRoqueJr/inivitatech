namespace LoremIpsumLogistica.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioAdicionar<TEntidade> where TEntidade : IEntidade
    {
        void Adicionar(TEntidade entidade);
    }
}
