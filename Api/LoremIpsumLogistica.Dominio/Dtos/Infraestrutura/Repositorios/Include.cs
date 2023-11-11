using System.Linq.Expressions;
using LoremIpsumLogistica.Dominio.Interfaces;

namespace LoremIpsumLogistica.Dominio.Dtos.Infraestrutura.Repositorios
{
    public class Include<TEntidade> : List<Expression<Func<TEntidade, object>>> where TEntidade : IEntidade
    {
        public Include(params Expression<Func<TEntidade, object>>[] includes)
        {
            this.AddRange(includes.ToList());
        }
    }
}
