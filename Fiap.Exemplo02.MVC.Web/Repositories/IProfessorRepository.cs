using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiap.Exemplo02.MVC.Web.Models;
using System.Linq.Expressions;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    public interface IProfessorRepository
    {
        IEnumerable<Professor> Listar();
        void Cadastrar(Professor professor);

        void Atualizar(Professor professor);

        void Remover(int id);

        Aluno BuscarPorId(int id);

        ICollection<Aluno> BuscarPor(Expression<Func<Professor, bool>> filtro);
    }
}
