using System.Linq.Expressions;
using LoremIpsumLogistica.Dominio.Dtos.Infraestrutura.Repositorios;

namespace LoremIpsumLogistica.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioRecuperar<TEntidade> where TEntidade : IEntidade
    {
        TEntidade Recuperar(int id, bool somenteLeitura = false);
        ICollection<TEntidade> RecuperarTodos(bool somenteLeitura = false);
        ICollection<TEntidade> Recuperar(int skip, int take, bool somenteLeitura = true);
        ICollection<TEntidade> Recuperar(Expression<Func<TEntidade, bool>> predicate, int skip, int take, bool somenteLeitura = true);
        ICollection<TEntidade> Recuperar(Expression<Func<TEntidade, bool>> predicate, bool somenteLeitura = false);
        bool Existe(int id);
        bool Existem(Expression<Func<TEntidade, bool>> predicate);
        TEntidade Recuperar(int id, Include<TEntidade> include, bool somenteLeitura = false);
        ICollection<TEntidade> RecuperarTodos(Include<TEntidade> include, bool somenteLeitura = false);
        ICollection<TEntidade> Recuperar(int skip, int take, Include<TEntidade> include, bool somenteLeitura = true);
        ICollection<TEntidade> Recuperar(Expression<Func<TEntidade, bool>> predicate, int skip, int take, Include<TEntidade> include, bool somenteLeitura = true);
        ICollection<TEntidade> Recuperar(Expression<Func<TEntidade, bool>> predicate, Include<TEntidade> include, bool somenteLeitura = false);

        TEntidade Max<TKey>(Expression<Func<TEntidade, TKey>> orderBy, Include<TEntidade> includes, bool somenteLeitura = true);
        TEntidade Min<TKey>(Expression<Func<TEntidade, TKey>> orderBy, Include<TEntidade> includes, bool somenteLeitura = true);
        TEntidade Max<TKey>(Expression<Func<TEntidade, TKey>> orderBy, bool somenteLeitura = true);
        TEntidade Min<TKey>(Expression<Func<TEntidade, TKey>> orderBy, bool somenteLeitura = true);


        int Contar();
        int Contar(Expression<Func<TEntidade, bool>> predicate);
        int Contar(Expression<Func<TEntidade, bool>> predicate, Include<TEntidade> include);
    }
}
