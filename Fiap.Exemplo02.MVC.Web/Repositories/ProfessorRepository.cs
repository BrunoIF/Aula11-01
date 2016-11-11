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
    public class ProfessorRepository
    {
        private PortalContext _context;

        // Construtor
        public ProfessorRepository(PortalContext context)
        {
            _context = context;
        }

        public IEnumerable<Professor> Listar()
        {
            return _context.Professor.ToList();
        }

        public Professor BuscarPorId(int id)
        {
            return _context.Professor.Find(id);
        }

        public void Cadastrar(Professor professor)
        {
            _context.Professor.Add(professor);
        }

        public void Remover(int id)
        {
            var professor = BuscarPorId(id);
            _context.Professor.Remove(professor);
        }
        public void Atualizar(Professor professor)
        {
            _context.Entry(professor).State = EntityState.Modified;
        }
        public ICollection<Professor>
        BuscarPor(Expression<Func<Professor, bool>> filtro)
        {
            return _context.Professor.Where(filtro).ToList();
        }
    }
}
