namespace LoremIpsumLogistica.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioAtualizar<TEntidade> where TEntidade : IEntidade
    {
        void Atualizar(TEntidade entidade);
    }
}
