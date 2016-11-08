using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fiap.Exemplo01.MVC.Web.Models
{
    public class Cliente
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public decimal Credito { get; set; }

        [Display(Name ="Possui necessidades especiais?")]
        public bool NecessidadesEspeciais { get; set; }

        [Display(Name = "Data de Nascimento")]    
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Estado Civil")]        
        public string EstadoCivil { get; set; }    

    }
}