//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rosnando_semG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Dica
    {
        public int dica_id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string dica_titulo { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string dica_descricao { get; set; }
        public int usuario_id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public int tipo_dica_id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public int tipo_animal_id { get; set; }
        public bool dica_status { get; set; }
        public System.DateTime dica_data { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string dica_texto { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string dica_img { get; set; }
    
        public virtual TipoAnimal TipoAnimal { get; set; }
        public virtual TipoDica TipoDica { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
