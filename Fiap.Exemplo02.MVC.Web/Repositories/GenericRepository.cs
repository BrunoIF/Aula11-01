﻿using Fiap.Exemplo02.MVC.Web.Models;
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
        private PortalContext _context;
        private DbSet<T> _dbset;

        public GenericRepository(PortalContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }
        public void Alterar(T entidade)
        {
            _context.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
        }

        public ICollection<T> BuscarPor(Expression<Func<T, bool>> filtro)
        {
            return _dbset.Where(filtro).ToList();
        }

        public T BuscarPorId(int id)
        {
            return _dbset.Find(id);
        }

        public void Cadastrar(T entidade)
        {
            _dbset.Add(entidade);
        }

        public ICollection<T> Listar()
        {
            return _dbset.ToList();
        }

        public void Remover(int id)
        {
            var entidade = _dbset.Find(id);
            _dbset.Remove(entidade);
        }
    }
}
