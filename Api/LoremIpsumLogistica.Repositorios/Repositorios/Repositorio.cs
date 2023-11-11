using LoremIpsumLogistica.Dominio.Dtos.Infraestrutura.Repositorios;
using LoremIpsumLogistica.Dominio.Entidades;
using LoremIpsumLogistica.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Transactions;

namespace LoremIpsumLogistica.Infraestrutura.Repositorio.Repositorios
{
    public  class Repositorio<TEntidade> : IRepositorio<TEntidade> where TEntidade : Entidade
    {
        internal readonly Context.LoremDbContext _context;
        internal DbSet<TEntidade> dbset;

        public Repositorio(Context.LoremDbContext context)
        {
            _context = context;
            this.dbset = _context.Set<TEntidade>();
        }

        public void Adicionar(TEntidade entidade)
        {
            _context.Set<TEntidade>().Add(entidade);
            _context.SaveChanges();
        }

        public void Atualizar(TEntidade entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Apagar(TEntidade entidade)
        {
            _context.Set<TEntidade>().Remove(entidade);
            _context.SaveChanges();
        }

        public virtual TEntidade Recuperar(int id, bool somenteLeitura = false)
        {
            if (somenteLeitura)
            {
                return (this.dbset.AsNoTracking().SingleOrDefault(s => s.Id == id));
            }
            else
            {
                return (this.dbset.SingleOrDefault(s => s.Id == id));
            }
        }

        public virtual ICollection<TEntidade> RecuperarTodos(bool somenteLeitura = false)
        {
            if (somenteLeitura)
            {
                using (var scope = this.CriarScope())
                {
                    return (this.dbset.AsNoTracking().ToList());
                }
            }
            else
            {
                return (this.dbset.ToList());
            }
        }

        public virtual ICollection<TEntidade> Recuperar(int skip, int take, bool somenteLeitura = true)
        {
            skip = ((skip <= 0) ? 0 : (skip - 1));

            if (somenteLeitura)
            {
                using (var scope = this.CriarScope())
                {
                    return (this.dbset.AsNoTracking().OrderBy(e => e.Id).Skip(skip * take).Take(take).ToList());
                }
            }
            else
            {
                return (this.dbset.OrderBy(e => e.Id).Skip(skip * take).Take(take).ToList());
            }
        }

        public virtual ICollection<TEntidade> Recuperar(Expression<Func<TEntidade, bool>> predicate, bool somenteLeitura = false)
        {
            if (somenteLeitura)
            {
                using (var scope = this.CriarScope())
                {
                    return (this.dbset.AsNoTracking().Where(predicate).ToList());
                }
            }
            else
            {
                return (this.dbset.Where(predicate).ToList());
            }
        }

        public virtual ICollection<TEntidade> Recuperar(Expression<Func<TEntidade, bool>> predicate, int skip, int take, bool somenteLeitura = true)
        {
            skip = ((skip <= 0) ? 0 : (skip - 1));

            if (somenteLeitura)
            {
                using (var scope = this.CriarScope())
                {
                    return (this.dbset.AsNoTracking().Where(predicate).OrderBy(e => e.Id).Skip(skip * take).Take(take).ToList());
                }
            }
            else
            {
                return (this.dbset.Where(predicate).OrderBy(e => e.Id).Skip(skip * take).Take(take).ToList());
            }
        }

        public bool Existem(Expression<Func<TEntidade, bool>> predicate)
        {
            return (this.Contar(predicate) > 0);
        }

        public bool Existe(int id)
        {
            return (this.Contar(s => s.Id == id) > 0);
        }

        public TEntidade Recuperar(int id, Include<TEntidade> includes, bool somenteLeitura = false)
        {
            if (somenteLeitura)
            {
                using (var scope = this.CriarScope())
                {
                    return (this.Query(includes.ToArray()).AsNoTracking().SingleOrDefault(s => s.Id == id));
                }
            }
            else
            {
                return (this.Query(includes.ToArray()).SingleOrDefault(s => s.Id == id));
            }
        }

        public ICollection<TEntidade> RecuperarTodos(Include<TEntidade> includes, bool somenteLeitura = false)
        {
            if (somenteLeitura)
            {
                using (var scope = this.CriarScope())
                {
                    return (this.Query(includes.ToArray()).AsNoTracking().ToList());
                }
            }
            else
            {
                return (this.Query(includes.ToArray()).ToList());
            }
        }

        public ICollection<TEntidade> Recuperar(int skip, int take, Include<TEntidade> includes, bool somenteLeitura = true)
        {
            skip = ((skip <= 0) ? 0 : (skip - 1));

            if (somenteLeitura)
            {
                using (var scope = this.CriarScope())
                {
                    return (this.Query(includes.ToArray()).AsNoTracking().OrderBy(e => e.Id).Skip(skip * take).Take(take).ToList());
                }
            }
            else
            {
                return (this.Query(includes.ToArray()).OrderBy(e => e.Id).Skip(skip * take).Take(take).ToList());
            }
        }

        public ICollection<TEntidade> Recuperar(Expression<Func<TEntidade, bool>> predicate, int skip, int take, Include<TEntidade> includes, bool somenteLeitura = true)
        {
            skip = ((skip <= 0) ? 0 : (skip - 1));

            if (somenteLeitura)
            {
                using (var scope = this.CriarScope())
                {
                    var resultado = this.Query(includes.ToArray()).AsNoTracking().Where(predicate).OrderBy(e => e.Id).Skip(skip * take).Take(take).ToList();
                    return (resultado);
                }
            }
            else
            {
                return (this.Query(includes.ToArray()).Where(predicate).OrderBy(e => e.Id).Skip(skip * take).Take(take).ToList());
            }
        }

        public ICollection<TEntidade> Recuperar(Expression<Func<TEntidade, bool>> predicate, Include<TEntidade> includes, bool somenteLeitura = false)
        {
            try
            {
                if (somenteLeitura)
                {
                    using (var scope = this.CriarScope())
                    {
                        return (this.Query(includes.ToArray()).AsNoTracking().Where(predicate).ToList());
                    }
                }
                else
                {
                    return (this.Query(includes.ToArray()).Where(predicate).ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TEntidade Min<TKey>(Expression<Func<TEntidade, TKey>> orderBy, Include<TEntidade> includes, bool somenteLeitura = true)
        {
            if (somenteLeitura)
            {
                using (var scope = this.CriarScope())
                {
                    return (this.Query(includes.ToArray()).AsNoTracking().OrderBy(orderBy).FirstOrDefault());
                }
            }
            else
            {
                return (this.Query(includes.ToArray()).OrderBy(orderBy).FirstOrDefault());
            }
        }

        public TEntidade Max<TKey>(Expression<Func<TEntidade, TKey>> orderBy, Include<TEntidade> includes, bool somenteLeitura = true)
        {
            if (somenteLeitura)
            {
                using (var scope = this.CriarScope())
                {
                    return (this.Query(includes.ToArray()).AsNoTracking().OrderByDescending(orderBy).FirstOrDefault());
                }
            }
            else
            {
                return (this.Query(includes.ToArray()).OrderByDescending(orderBy).FirstOrDefault());
            }
        }

        public TEntidade Min<TKey>(Expression<Func<TEntidade, TKey>> orderBy, bool somenteLeitura = true)
        {
            if (somenteLeitura)
            {
                using (var scope = this.CriarScope())
                {
                    return (this.dbset.AsNoTracking().OrderBy(orderBy).FirstOrDefault());
                }
            }
            else
            {
                return (this.dbset.OrderBy(orderBy).FirstOrDefault());
            }
        }

        public TEntidade Max<TKey>(Expression<Func<TEntidade, TKey>> orderBy, bool somenteLeitura = true)
        {
            if (somenteLeitura)
            {
                using (var scope = this.CriarScope())
                {
                    return (this.dbset.AsNoTracking().OrderByDescending(orderBy).FirstOrDefault());
                }
            }
            else
            {
                return (this.dbset.OrderByDescending(orderBy).FirstOrDefault());
            }
        }

        private IQueryable<TEntidade> Query(Expression<Func<TEntidade, object>>[] includes)
        {
            var query = includes.Aggregate<Expression<Func<TEntidade, object>>, IQueryable<TEntidade>>(dbset, (current, expression) => current.Include(expression));
            return (query);
        }

        public int Contar()
        {
            using (var scope = this.CriarScope())
            {
                return (this.dbset.AsNoTracking().Count());
            }
        }

        public int Contar(Expression<Func<TEntidade, bool>> predicate)
        {
            using (var scope = this.CriarScope())
            {
                return (this.dbset.AsNoTracking().Where(predicate).Count());
            }
        }

        public int Contar(Expression<Func<TEntidade, bool>> predicate, Include<TEntidade> include)
        {
            using (var scope = this.CriarScope())
            {
                return (this.Query(include.ToArray()).AsNoTracking().Where(predicate).Count());
            }
        }

        /// <summary>
        /// Cria um TransactionScope para leitura de dados não comitados
        /// </summary>
        /// <returns></returns>
        internal TransactionScope CriarScope()
        {
            return (new TransactionScope(TransactionScopeOption.Suppress, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }));
        }
    }
}
