using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rosnando_semG.Models;
using System.Web.Security;


namespace Rosnando_semG.Controllers
{
    public class HomeController : Controller
    {
        
        DB_A41AF6_rosnandoEntities bd = new DB_A41AF6_rosnandoEntities();
        public ActionResult Index()
        {
           
               
            ViewBag.tipodica = bd.TipoDica.Where(x=>x.primeiro_socorros==false).ToList();
            ViewBag.tiposos = bd.TipoDica.Where(x=>x.primeiro_socorros==true).ToList();
            var dicas = bd.Dica.Where(x => x.dica_status == true).OrderByDescending(x => x.dica_data).Take(6).ToList();
            var topp = bd.Usuario.OrderByDescending(x => x.usuario_pontos).Take(5).ToList();
            var topd = bd.Usuario.OrderByDescending(x => x.Animais.Count).Take(5).ToList();
            var topa = bd.TipoAnimal.OrderByDescending(x => x.Animais.Count).Take(5).ToList();
            ViewBag.topp = topp;
            ViewBag.topd = topd;
            ViewBag.topa = topa;
            
            
            return View(dicas);
        }

        public ActionResult Pontos()
        {
            return View();
        }



        }
}