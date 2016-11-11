using Fiap.Exemplo02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected PortalContext _context;
        protected DbSet<T> _dbset;

        public GenericRepository(PortalContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }
        public virtual void Alterar(T entidade)
        {
            _context.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual ICollection<T> BuscarPor(Expression<Func<T, bool>> filtro)
        {
            return _dbset.Where(filtro).ToList();
        }

        public virtual T BuscarPorId(int id)
        {
            return _dbset.Find(id);
        }

        public virtual void Cadastrar(T entidade)
        {
            _dbset.Add(entidade);
        }

        public virtual ICollection<T> Listar()
        {                                  
            return _dbset.ToList();        
        }                                  
                                           
        public virtual void Remover(int id)        
        {                                  
            var entidade = BuscarPorId(id);
            _dbset.Remove(entidade);
        }
    }
}
