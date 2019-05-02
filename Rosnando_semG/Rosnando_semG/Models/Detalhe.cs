using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rosnando_semG.Models;

namespace Rosnando_semG.Views
{
    public static class Detalhe
    {
        public static Usuario GetUsuario()
        {
            
            var nome = HttpContext.Current.User.Identity.Name;
        
            DB_A41AF6_rosnandoEntities bd = new DB_A41AF6_rosnandoEntities();
            var u = bd.Usuario.FirstOrDefault(x => x.usuario_id==Convert.ToInt32(nome));

            return u;

        }
    }
}