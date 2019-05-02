using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Rosnando_semG.Models;
using System.ComponentModel.DataAnnotations;

namespace Rosnando_semG.Controllers
{
    public class LoginController : Controller
    {

        DB_A41AF6_rosnandoEntities bd = new DB_A41AF6_rosnandoEntities();
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            var u = bd.Usuario.FirstOrDefault(x => x.usuario_email == usuario.usuario_email && x.usuario_senha == usuario.usuario_senha);
           
            if (u == null)
            {
                return RedirectToAction("Index", "Home", new { message = "Login ou senha inválidos!" });
            }
                
            FormsAuthentication.SetAuthCookie(u.usuario_id.ToString(), true);
            return RedirectToAction("Index", "Home");
           
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(Usuario usuario)
        {
            
           
            if (bd.Usuario.FirstOrDefault(x => x.usuario_email == usuario.usuario_email) != null) return RedirectToAction("Index", "Home");
            usuario.usuario_pontos = 50;
            usuario.acesso_id = 2;
            bd.Usuario.Add(usuario);
            bd.SaveChanges();
            FormsAuthentication.SetAuthCookie(usuario.usuario_id.ToString(), true);
            return RedirectToAction("Index","Home");
        }
        public ActionResult Logoff()
        {

            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
       

    }
}