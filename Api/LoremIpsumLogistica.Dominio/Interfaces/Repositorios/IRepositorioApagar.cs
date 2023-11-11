namespace LoremIpsumLogistica.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioApagar<TEntidade> where TEntidade : IEntidade
    {
        void Apagar(TEntidade entidade);
    }
}
