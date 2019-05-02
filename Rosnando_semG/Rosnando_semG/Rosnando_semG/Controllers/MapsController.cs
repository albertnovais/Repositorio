using Rosnando_semG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rosnando_semG.Controllers
{

    public class MapsController : Controller
    {
        // GET: Maps
        
        DB_A41AF6_rosnandoEntities bd = new DB_A41AF6_rosnandoEntities();
        [Authorize]
        public ActionResult Map()
        {
            var topp = bd.Usuario.OrderByDescending(x => x.usuario_pontos).Take(5).ToList();
            var topd = bd.Usuario.OrderByDescending(x => x.Animais.Count).Take(5).ToList();
            var topa = bd.TipoAnimal.OrderByDescending(x => x.Animais.Count).Take(5).ToList();
            var dicas = bd.Dica.Where(x => x.dica_status == true).OrderByDescending(x => x.dica_data).Take(5).ToList();
            ViewBag.dicas = dicas;
            ViewBag.topp = topp;
            ViewBag.topd = topd;
            ViewBag.topa = topa;
            return View();
        }
    }
}