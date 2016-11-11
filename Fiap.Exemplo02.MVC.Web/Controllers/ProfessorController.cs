using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class ProfessorController : Controller
    {
        // GET: Professor
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }




    }
}