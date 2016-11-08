using Fiap.Exemplo02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    public interface IGrupoRepository
    {
        IEnumerable<Grupo> Listar();
        void Atualizar(Grupo grupo);

        void Cadastrar(Grupo grupo);

        void Remover(int id);

        Grupo BuscarPorId(int id);

        ICollection<Grupo> BuscarPor(Expression<Func<Grupo, bool>> filtro);
    }
}
