using Fiap.Exemplo02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    public class ProfessorRepository : GenericRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(PortalContext context):base(context)
        {

        }

        public void Promocao(decimal valor, int id)
        {
            var professor = BuscarPorId(id);
            // Aumenta o valor em %
            professor.Salario += professor.Salario * valor;   
        }
    }
}
