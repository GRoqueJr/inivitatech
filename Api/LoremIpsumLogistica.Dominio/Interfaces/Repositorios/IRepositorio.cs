namespace LoremIpsumLogistica.Dominio.Interfaces.Repositorios
{
    public interface IRepositorio<TEntidade> :
        IRepositorioAdicionar<TEntidade>,
        IRepositorioAtualizar<TEntidade>,
        IRepositorioApagar<TEntidade>,
        IRepositorioRecuperar<TEntidade>
        where TEntidade : IEntidade
    {
    }
}
