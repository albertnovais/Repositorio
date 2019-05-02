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
    
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            this.Animais = new HashSet<Animais>();
            this.Dica = new HashSet<Dica>();
            this.RacaAnimal = new HashSet<RacaAnimal>();
            this.TipoAnimal = new HashSet<TipoAnimal>();
            this.TipoDica = new HashSet<TipoDica>();
            this.Usuario1 = new HashSet<Usuario>();
        }
    
        public int usuario_id { get; set; }
        [Required(ErrorMessage ="Campo Obrigatorio")]
        public string usuario_email { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string usuario_nome { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string usuario_sobrenome { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string usuario_senha { get; set; }
        public Nullable<int> acesso_id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [DataType(DataType.Date)]
        public System.DateTime usuario_dataNasc { get; set; }
        public Nullable<int> usuario_acesso { get; set; }
        public Nullable<int> usuario_pontos { get; set; }
    
        public virtual Acesso Acesso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Animais> Animais { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dica> Dica { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RacaAnimal> RacaAnimal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TipoAnimal> TipoAnimal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TipoDica> TipoDica { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario1 { get; set; }
        public virtual Usuario Usuario2 { get; set; }
    }
}