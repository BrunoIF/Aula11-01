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
    public class GrupoRepository : IGrupoRepository
    {
        private PortalContext _context;

        // Construtor
        public GrupoRepository(PortalContext context)
        {
            _context = context;
        }

        public IEnumerable<Grupo> Listar()
        {
            return _context.Grupo.ToList();
        }

        public Grupo BuscarPorId(int id)
        {
            return _context.Grupo.Find(id);
        }

        public void Cadastrar(Grupo grupo)
        {
            _context.Grupo.Add(grupo);
        }

        public void Remover(int id)
        {
            var grupo = BuscarPorId(id);
            _context.Grupo.Remove(grupo);
        }
        public void Atualizar(Grupo grupo)
        {
            _context.Entry(grupo).State = EntityState.Modified;
        }
        public ICollection<Grupo>
        BuscarPor(Expression<Func<Grupo, bool>> filtro)
        {
            return _context.Grupo.Where(filtro).ToList();
        }
    }
}
