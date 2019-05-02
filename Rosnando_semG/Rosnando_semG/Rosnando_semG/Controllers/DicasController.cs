using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rosnando_semG.Models;

namespace Rosnando_semG.Controllers
{
    public class DicasController : Controller
    {
        DB_A41AF6_rosnandoEntities bd = new DB_A41AF6_rosnandoEntities();
        // GET: Dicas
        [Authorize (Roles ="Administrador, Sub_adm")]
        public ActionResult List()
        {

            
            var dicas = bd.Dica.Where(x => x.TipoDica.primeiro_socorros == false).ToList();

            return View(dicas);
        }

        [Authorize(Roles = "Administrador, Sub_adm")]
        public ActionResult Create(){
           
            ViewBag.tipoanimal = new SelectList(bd.TipoAnimal, "tipo_animal_id", "tipo_animal_descricao");
            ViewBag.tipodica = new SelectList(bd.TipoDica.Where(x=> x.primeiro_socorros==false), "tipo_dica_id", "descricao");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Dica dica)
        {
            dica.usuario_id = Convert.ToInt32(HttpContext.User.Identity.Name);
            dica.dica_data = DateTime.Now;
            dica.dica_status = true;
            bd.Dica.Add(dica);
            bd.SaveChanges();
            return RedirectToAction("List");
        }

        [Authorize(Roles = "Administrador, Sub_adm")]
        public ActionResult Details(int dica_id)
        {
           
            var nome = Convert.ToInt32(HttpContext.User.Identity.Name);
            var u = bd.Usuario.FirstOrDefault(x => x.usuario_id == nome);
            ViewBag.usu = u;
            var dica = bd.Dica.FirstOrDefault(x => x.dica_id == dica_id);

            return View(dica);
        }

        [HttpPost]
        public ActionResult Details(Dica dica)
        {
            return RedirectToAction("List");
        }
        [Authorize(Roles = "Administrador, Sub_adm")]
        public ActionResult Edit(int dica_id)
        {
            ViewBag.tipoanimal = new SelectList(bd.TipoAnimal, "tipo_animal_id", "tipo_animal_descricao");
            var dica = bd.Dica.FirstOrDefault(x => x.dica_id == dica_id);
            return View(dica);
        }

        [HttpPost]
        public ActionResult Edit(Dica dica)
        {
            var di = bd.Dica.FirstOrDefault(x => x.dica_id == dica.dica_id);

            di.dica_descricao = dica.dica_descricao;
            di.dica_img = dica.dica_img;
            di.dica_status = dica.dica_status;
            di.dica_texto = dica.dica_texto;
            di.dica_titulo = di.dica_titulo;
            di.dica_data = DateTime.Now;
            di.usuario_id= Convert.ToInt32(HttpContext.User.Identity.Name);
            di.tipo_animal_id = dica.tipo_animal_id;

            bd.Entry(di).State = System.Data.Entity.EntityState.Modified;
            bd.SaveChanges();

            return RedirectToAction("List");
        }


    }
}