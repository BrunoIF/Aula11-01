using Fiap.Exemplo01.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo01.MVC.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private static List<Produto> _lista = new List<Produto>();

        [HttpGet]
        public ActionResult Listar()
        {
            return View(_lista);
        }

        [HttpGet] //Carrega a página com o formulário
        public ActionResult Cadastrar()
        {
            return View();
        }

        //mvcaction4 -> tab tab
        [HttpPost]
        public ActionResult Cadastrar(Produto produto)
        {
           // Adicionando o produto na lista (simulando DB)
            _lista.Add(produto);
            //Passa informações para a view
            ViewBag.prod = produto;
            TempData["mensagem"] = "Produto cadastrado!";
            //retorna a view Sucesso.cshtml
            return View("Sucesso",produto);
            //return Content(produto.Nome + " " + produto.Quantidade + " " + produto.Valor);
        }
    }
}