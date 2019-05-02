using Rosnando_semG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rosnando_semG.Controllers
{
    public class AnimalController : Controller
    {
        DB_A41AF6_rosnandoEntities bd = new DB_A41AF6_rosnandoEntities();
        // GET: Animal
        [Authorize]
        public ActionResult List(int usuario_id)
        {
            //var dicas = bd.Dica.Where(x => x.dica_status == true).OrderByDescending(x => x.dica_data).Take(5).ToList();
            //var topp = bd.Usuario.OrderByDescending(x => x.usuario_pontos).Take(5).ToList();
            //var topd = bd.Usuario.OrderByDescending(x => x.Animais.Count).Take(5).ToList();
            //var topa = bd.TipoAnimal.OrderByDescending(x => x.Animais.Count).Take(5).ToList();

            //ViewBag.dicas = dicas;
            //ViewBag.topp = topp;
            //ViewBag.topd = topd;
            //ViewBag.topa = topa;
            var ani = bd.Animais.Where(x => x.usuario_id == usuario_id).ToList();
            int a = Convert.ToInt32(HttpContext.User.Identity.Name);
            string nome = bd.Usuario.FirstOrDefault(x => x.usuario_id == a).usuario_nome;
            ViewBag.nome = nome;

            return View(ani);
        }

        public ActionResult Create()
        {
            //    bd.Animais.FirstOrDefault(x =>x.animal_raca_id );
            ViewBag.tipoanimal = new SelectList(bd.TipoAnimal, "tipo_animal_id", "tipo_animal_descricao");
            // ViewBag.racaanimal = new SelectList(bd.RacaAnimal, "raca_animal_id", "raca_animal_descricao");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Animais animais)
        {
            animais.status_animal_id = 1;
            animais.usuario_id = Convert.ToInt32(HttpContext.User.Identity.Name);
            bd.Animais.Add(animais);
            var usu = bd.Usuario.FirstOrDefault(x => x.usuario_id == animais.usuario_id);
            usu.usuario_pontos += 20;
            bd.Entry(usu).State = System.Data.Entity.EntityState.Modified;
            bd.SaveChanges();

            return RedirectToAction("List", "Usuario");

        }

        public ActionResult Raca(int tipo_animal_id, int animal_id)
        {
            var animal = bd.Animais.FirstOrDefault(x => x.animal_id == animal_id);
            var racas = bd.RacaAnimal.Where(x => x.tipo_animal_id == tipo_animal_id);
            ViewBag.racaanimal = new SelectList(racas, "raca_animal_id", "raca_animal_descricao");
            return View(animal);

        }
        [HttpPost]
        public ActionResult Raca(Animais animais)
        {
            var ani = bd.Animais.FirstOrDefault(x => x.animal_id == animais.animal_id);
            ani.animal_raca_id = animais.animal_raca_id;
            bd.Entry(ani).State = System.Data.Entity.EntityState.Modified;
            bd.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        //public ActionResult Edit(int animal_id)
        //{
        //    var ani = bd.Animais.FirstOrDefault(x => x.animal_id == animal_id);
        //    return View(ani);

        //}


    }
}