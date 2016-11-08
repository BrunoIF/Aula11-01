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
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Aluno aluno)
        {
            _context.Aluno.Add(aluno);
            _context.SaveChanges();
            TempData["msg"] = "Aluno cadastrado com sucesso!";

            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var lista = _context.Aluno.ToList();
            return View(lista);
        }
    }
}