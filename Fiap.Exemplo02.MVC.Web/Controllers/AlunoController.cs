using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fiap.Exemplo02.MVC.Web.Models;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class AlunoController : Controller
    {
        private PortalContext _context = new PortalContext();
        // GET: Aluno
        [HttpGet]
        public ActionResult Cadastrar()
        {
            // Buscar todos os grupos cadastrados
            var lista = _context.Grupo.ToList();
            ViewBag.grupos = new SelectList(lista, "Id" , "Nome");

            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Aluno aluno)
        {
            _context.Aluno.Add(aluno);
            _context.SaveChanges();
           
            TempData["msg"] = "Aluno cadastrado com sucesso"; 
            return RedirectToAction("Cadastrar");

            //excluir e editar
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var lista = _context.Aluno.ToList();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            // Buscar o objeto (aluno) no banco 
            var aluno = _context.Aluno.Find(id);

            //manda o aluno para a view
            return View(aluno);
        }

        [HttpPost]
        public ActionResult Editar(Aluno aluno)
        {
            _context.Entry(aluno).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            TempData["msg"] = "Aluno atualizado";

            return RedirectToAction("Listar");
        }

        public ActionResult Excluir(int alunoId)
        {
            var aluno = _context.Aluno.Find(alunoId);
            _context.Aluno.Remove(aluno);
            _context.SaveChanges();

            TempData["msg"] = "Aluno excluido";

            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Buscar(string nomeBusca)
        {
            // Busca  o aluno por parte do nome
            var lista = _context.Aluno.Where(a => a.Nome.Contains(nomeBusca)).ToList();

            // Retorna para a view com a lista
            return View("Listar", lista);
        }
    }
}