using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rosnando_semG.Models;


namespace Rosnando_semG.Controllers
{
    public class UsuarioController : Controller
    {
        DB_A41AF6_rosnandoEntities bd = new DB_A41AF6_rosnandoEntities();
        // GET: Usuario
        public ActionResult usuario(int usuario_id)
        {
            var usu = bd.Usuario.FirstOrDefault(x=> x.usuario_id==usuario_id);
            int a = Convert.ToInt32(HttpContext.User.Identity.Name);
            string nome = bd.Usuario.FirstOrDefault(x => x.usuario_id == a).usuario_nome;
            ViewBag.nome = nome;
            return View(usu);
        }
        [Authorize]
        public ActionResult Edit(int usuario_id)
        {
            var usu = bd.Usuario.FirstOrDefault(x => x.usuario_id == usuario_id);
            return View(usu);
        }
        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            var usu = bd.Usuario.FirstOrDefault(x => x.usuario_id == usuario.usuario_id);
            bd.Entry(usu).State = System.Data.Entity.EntityState.Modified;
            bd.SaveChanges();

            return RedirectToAction("List", "Usuario");

        }
        [Authorize]
        public ActionResult EditSenha(int usuario_id)
        {
            int a = Convert.ToInt32(HttpContext.User.Identity.Name);
            string nome = bd.Usuario.FirstOrDefault(x => x.usuario_id == a).usuario_nome;
            ViewBag.nome = nome;
            var usu = bd.Usuario.FirstOrDefault(x => x.usuario_id == usuario_id);
            return View(usu);
        }
        [HttpPost]
        public ActionResult EditSenha(Usuario usuario, string novaSenha)
        {
            var usu = bd.Usuario.FirstOrDefault(x => x.usuario_id == usuario.usuario_id);
            if(usuario.usuario_senha == usu.usuario_senha)
            {
                usu.usuario_senha = novaSenha;
                bd.Entry(usu).State = System.Data.Entity.EntityState.Modified;
                bd.SaveChanges();
            }
            else
            {

            }

           

            return RedirectToAction("List", "Usuario");

        }



        //Administrativo

        [Authorize(Roles = "Administrador, Sub_adm")]
        public ActionResult List()
        {

            var usu = bd.Usuario.ToList();
            return View(usu);
        }
        [Authorize(Roles = "Administrador, Sub_adm")]
        public ActionResult EditADM(int usuario_id)
        {
            var usu = bd.Usuario.FirstOrDefault(x => x.usuario_id == usuario_id);
            ViewBag.acesso = new SelectList(bd.Acesso, "acesso_id", "acesso_desricao");
            return View(usu);
        }
        [HttpPost]
        public ActionResult EditADM(Usuario usuario)
        {
            var usu = bd.Usuario.FirstOrDefault(x => x.usuario_id == usuario.usuario_id);
            usu.acesso_id = usuario.acesso_id;
            usu.usuario_acesso= Convert.ToInt32(HttpContext.User.Identity.Name);
            bd.Entry(usu).State = System.Data.Entity.EntityState.Modified;
            bd.SaveChanges();

            return RedirectToAction("List", "Usuario");

        }

    }
}