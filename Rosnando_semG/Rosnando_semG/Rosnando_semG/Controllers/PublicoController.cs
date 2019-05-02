using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rosnando_semG.Models;


namespace Rosnando_semG.Controllers
{
    public class PublicoController : Controller
    {
        DB_A41AF6_rosnandoEntities bd = new DB_A41AF6_rosnandoEntities();
        // GET: Publico

        public ActionResult Index(int? a, int? b, int? tipo_dica_id)
        {
            var topp = bd.Usuario.OrderByDescending(x => x.usuario_pontos).Take(5).ToList();
            var topd = bd.Usuario.OrderByDescending(x => x.Animais.Count).Take(5).ToList();
            var topa = bd.TipoAnimal.OrderByDescending(x => x.Animais.Count).Take(5).ToList();
            var dicas = bd.Dica.Where(x => x.dica_status == true).OrderByDescending(x => x.dica_data).Take(5).ToList();
            ViewBag.dicas = dicas;
            ViewBag.topp = topp;
            ViewBag.topd = topd;
            ViewBag.topa = topa;

            ViewBag.a = a;
            ViewBag.b = b;
            //  a = 1 --> Dica
            //  a = 2 --> SOS
            if (a == 1)
            {
                ViewBag.dic = bd.TipoDica.Where(x => x.primeiro_socorros == false).ToList();
            }
            else
            {
                ViewBag.dic = bd.TipoDica.Where(x => x.primeiro_socorros == true).ToList();
            }
            ViewBag.ani = bd.TipoAnimal.ToList();
            //  b = 0 --> Todos os animais
            //  b = 1 --> Gato 
            //  b = 3 --> Cachorro 
            //  b = 4 --> Outros 
            //  b = 5 --> para todos

            if (a == 1 && b == 0 && tipo_dica_id == null)
            {
                
                var mostrar = bd.Dica.Where(x => x.TipoDica.primeiro_socorros == false && x.dica_status == true).ToList().OrderByDescending(x => x.dica_data);     
                return View(mostrar);
            }
            else if (a == 1 && b == 0 && tipo_dica_id != null)
            {
                var mostrar = bd.Dica.Where(x => x.TipoDica.primeiro_socorros == false && x.dica_status == true && x.tipo_dica_id == tipo_dica_id).ToList().OrderByDescending(x => x.dica_data);
                return View(mostrar);
            }
            else if (a == 1 && b == 1 && tipo_dica_id == null)
            {
                var mostrar = bd.Dica.Where(x => x.TipoDica.primeiro_socorros == false && x.dica_status == true && x.tipo_animal_id == 1).ToList().OrderByDescending(x => x.dica_data);
                return View(mostrar);
            }
            else if (a == 1 && b == 1 && tipo_dica_id != null)
            {
                var mostrar = bd.Dica.Where(x => x.TipoDica.primeiro_socorros == false && x.dica_status == true && x.tipo_animal_id == 1 && x.tipo_dica_id == tipo_dica_id).ToList().OrderByDescending(x => x.dica_data);
                return View(mostrar);
            }
            else if (a == 1 && b == 3 && tipo_dica_id == null)
            {
                var mostrar = bd.Dica.Where(x => x.TipoDica.primeiro_socorros == false && x.dica_status == true && x.tipo_animal_id == 3).ToList().OrderByDescending(x => x.dica_data);
                return View(mostrar);
            }
            else if (a == 1 && b == 3 && tipo_dica_id != null)
            {
                var mostrar = bd.Dica.Where(x => x.TipoDica.primeiro_socorros == false && x.dica_status == true && x.tipo_animal_id == 3 && x.tipo_dica_id == tipo_dica_id).ToList().OrderByDescending(x => x.dica_data);
                return View(mostrar);
            }
            else if (a == 1 && b == 4 && tipo_dica_id == null)
            {
                var mostrar = bd.Dica.Where(x => x.TipoDica.primeiro_socorros == false && x.dica_status == true && x.tipo_animal_id == 5).ToList().OrderByDescending(x => x.dica_data);
                return View(mostrar);
            }

            else if (a == 1 && b == 4 && tipo_dica_id != null)
            {
                var mostrar = bd.Dica.Where(x => x.TipoDica.primeiro_socorros == false && x.dica_status == true && x.tipo_animal_id == 5 && x.tipo_dica_id == tipo_dica_id).ToList().OrderByDescending(x => x.dica_data);
                return View(mostrar);
            }
            else if (a == 2 && b == 0 && tipo_dica_id == null)
            {
                var mostrar = bd.Dica.Where(x => x.TipoDica.primeiro_socorros == true && x.dica_status == true).ToList().OrderBy(x => x.dica_data).OrderByDescending(x => x.dica_data);
                return View(mostrar);
            }
            else if (a == 2 && b == 0 && tipo_dica_id != null)
            {
                var mostrar = bd.Dica.Where(x => x.TipoDica.primeiro_socorros == true && x.dica_status == true && x.tipo_dica_id == tipo_dica_id).ToList().OrderBy(x => x.dica_data).OrderByDescending(x => x.dica_data);
                return View(mostrar);
            }
            else if (a == 2 && b == 1 && tipo_dica_id == null)
            {
                var mostrar = bd.Dica.Where(x => x.TipoDica.primeiro_socorros == true && x.dica_status == true && x.tipo_animal_id == 1).ToList().OrderByDescending(x => x.dica_data);
                return View(mostrar);
            }
            else if (a == 2 && b == 1 && tipo_dica_id != null)
            {
                var mostrar = bd.Dica.Where(x => x.TipoDica.primeiro_socorros == true && x.dica_status == true && x.tipo_animal_id == 1 && x.tipo_dica_id == tipo_dica_id).ToList().OrderByDescending(x => x.dica_data);
                return View(mostrar);
            }
            else if (a == 2 && b == 3 && tipo_dica_id == null)
            {
                var mostrar = bd.Dica.Where(x => x.TipoDica.primeiro_socorros == true && x.dica_status == true && x.tipo_animal_id == 3).ToList().OrderByDescending(x => x.dica_data);
                return View(mostrar);
            }
            else if (a == 2 && b == 3 && tipo_dica_id != null)
            {
                var mostrar = bd.Dica.Where(x => x.TipoDica.primeiro_socorros == true && x.dica_status == true && x.tipo_animal_id == 3 && x.tipo_dica_id == tipo_dica_id).ToList().OrderByDescending(x => x.dica_data);
                return View(mostrar);
            }
            else if (a == 2 && b == 4 && tipo_dica_id == null)
            {
                var mostrar = bd.Dica.Where(x => x.TipoDica.primeiro_socorros == true && x.dica_status == true && x.tipo_animal_id == 5).ToList().OrderByDescending(x => x.dica_data);
                return View(mostrar);
            }
            else if (a == 2 && b == 4 && tipo_dica_id != null)
            {
                var mostrar = bd.Dica.Where(x => x.TipoDica.primeiro_socorros == true && x.dica_status == true && x.tipo_animal_id == 5 && x.tipo_dica_id == tipo_dica_id).ToList().OrderByDescending(x => x.dica_data);
                return View(mostrar);
            }
            else
            {
                var mostrar = bd.Dica.Where(x=> x.dica_status==true).ToList();
                return View(mostrar);
            }


        }
        public ActionResult Dica(int dica_id)
        {
            var dicas = bd.Dica.Where(x => x.dica_status == true).OrderByDescending(x => x.dica_data).Take(5).ToList();
            var topp = bd.Usuario.OrderByDescending(x => x.usuario_pontos).Take(5).ToList();
            var topd = bd.Usuario.OrderByDescending(x => x.Animais.Count).Take(5).ToList();
            var topa = bd.TipoAnimal.OrderByDescending(x => x.Animais.Count).Take(5).ToList();
            ViewBag.dicas = dicas;
            ViewBag.topp = topp;
            ViewBag.topd = topd;
            ViewBag.topa = topa;

            var dica = bd.Dica.FirstOrDefault(x => x.dica_id == dica_id);

            return View(dica);

        }
    }
}