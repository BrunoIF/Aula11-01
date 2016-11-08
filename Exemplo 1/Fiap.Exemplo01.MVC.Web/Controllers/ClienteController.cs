using Fiap.Exemplo01.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo01.MVC.Web.Controllers
{
    public class ClienteController : Controller
    {
        private static List<Cliente> _lista = new List<Cliente>();

        // Abrir a tela
        [HttpGet]
        public ActionResult Cadastrar()
        {
            var lista = new List<string>();
            lista.Add("Solteiro");
            lista.Add("Casado");
            lista.Add("Divorciado");
            lista.Add("Viúvo");
            ViewBag.EstadoCivil = new SelectList(lista);

            return View();
        }

        // Processar as informações
        [HttpPost]
        public ActionResult Cadastrar(Cliente cliente)
        {
            _lista.Add(cliente);
            TempData["msg"] = "Cliente Cadastrado";
            //ViewBag.EstadoCivil = new SelectList(EstadoCivil, 1);          
            return RedirectToAction("Cadastrar");
        }

        public ActionResult Listar()
        {
            //ViewBag.lista = _lista; // 1º Opção
            return View(_lista); // 2º Opção
        }
    }
}