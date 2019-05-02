using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rosnando_semG.Models;
using System.ComponentModel.DataAnnotations;

namespace Rosnando_semG.Models
{
    public class Usu
    {
        [Required (ErrorMessage ="Campo Obrigatório")]
        public string email { get; set; }

    }
}