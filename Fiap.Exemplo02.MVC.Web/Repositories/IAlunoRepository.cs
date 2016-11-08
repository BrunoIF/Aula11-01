using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiap.Exemplo02.MVC.Web.Models;
using System.Linq.Expressions;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    public interface IAlunoRepository
    {
        IEnumerable<Aluno> Listar();
        void Cadastrar(Aluno aluno);

        void Atualizar(Aluno aluno);

        void Remover(int id);

        Aluno BuscarPorId(int id);      

        ICollection<Aluno> BuscarPor(Expression<Func<Aluno, bool>> filtro);
    }
}
