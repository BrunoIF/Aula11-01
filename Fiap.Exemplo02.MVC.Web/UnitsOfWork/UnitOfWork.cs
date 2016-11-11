using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.UnitsOfWork
{
    public class UnitOfWork : IDisposable
    {
        #region Fields
        private PortalContext _context = new PortalContext();

        // AlunoRepository
        private IGenericRepository<Aluno> _alunoRepository;

        // GrupoRepository
        private IGenericRepository<Grupo> _grupoRepository;

        //Professor com GenericRepository
        private IProfessorRepository _professorRepository;
        #endregion

        #region GETS
        public IProfessorRepository ProfessorRepository
        {
            get
            {
                if (_professorRepository == null)
                {
                    _professorRepository = new ProfessorRepository(_context);
                }
                return _professorRepository;
            }
        }


        public IGenericRepository<Aluno> AlunoRepository
        {
            get
            {
                if (_alunoRepository == null)
                {
                    _alunoRepository = new GenericRepository<Aluno>(_context);
                }
                return _alunoRepository;
            }
        }

        public IGenericRepository<Grupo> GrupoRepository
        {
            get
            {
                if (_grupoRepository == null)
                {
                    _grupoRepository = new GenericRepository<Grupo>(_context);
                }
                return _grupoRepository;
            }
        }
        #endregion

        #region Salvar
        public void Salvar()
        {
            _context.SaveChanges();
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
