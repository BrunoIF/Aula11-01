using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;
using Fiap.Exemplo02.MVC.Web.Repositories;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class AlunoController : Controller
    {
        // private PortalContext _context = new PortalContext();
        private UnitOfWork _unit = new UnitOfWork();

        // GET: Aluno
        [HttpGet]
        public ActionResult Cadastrar()
        {
            // Buscar todos os grupos cadastrados         
            var lista = _unit.GrupoRepository.Listar();
            ViewBag.grupos = new SelectList(lista, "Id" , "Nome");

            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Aluno aluno)
        {
            _unit.AlunoRepository.Cadastrar(aluno);
            _unit.Salvar();

            TempData["msg"] = "Aluno cadastrado com sucesso"; 
            return RedirectToAction("Cadastrar");

            //excluir e editar
        }

        [HttpGet]
        public ActionResult Listar()
        {
            // Include -> busca o relacionamento (preenche o grupo que o aluno possui), faz o join
            //var lista = _context.Aluno.Include("Grupo").ToList();
            _unit.AlunoRepository.Listar();
            //enviar para a tela os grupos para o "select"
            ViewBag.grupos = new SelectList(_unit.GrupoRepository.Listar(), "Id", "Nome");
            return View(_unit.AlunoRepository.Listar());
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            // Buscar o objeto (aluno) no banco 
            _unit.AlunoRepository.BuscarPorId(id);

            ViewBag.grupos = new SelectList(_unit.AlunoRepository.Listar(), "Id", "Nome");
            //manda o aluno para a view
            return View(_unit.AlunoRepository.Listar());
        }

        [HttpPost]
        public ActionResult Editar(Aluno aluno)
        {
            _unit.AlunoRepository.Atualizar(aluno);
            _unit.Salvar();
            TempData["msg"] = "Aluno atualizado";

            return RedirectToAction("Listar");
        }

        public ActionResult Excluir(int alunoId)
        {
            _unit.AlunoRepository.BuscarPorId(alunoId);
            _unit.AlunoRepository.Remover(alunoId);
            _unit.Salvar();

            TempData["msg"] = "Aluno excluido";

            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Buscar(string nomeBusca, int? idGrupo)
        {
            ICollection<Aluno> lista;
            if (idGrupo == null)
            {
                // Busca  o aluno por parte do nome
                lista = _unit.AlunoRepository.BuscarPor(a => a.Nome.Contains(nomeBusca));
            }
            else
            {
                lista = _unit.AlunoRepository.BuscarPor(a => a.Nome.Contains(nomeBusca) && a.GrupoId == idGrupo);
            }

            // Retorna para a view com a lista
            return View("Listar", lista);
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}