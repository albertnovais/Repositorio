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
    
    public partial class TipoDica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoDica()
        {
            this.Dica = new HashSet<Dica>();
        }
    
        public int tipo_dica_id { get; set; }
        public string descricao { get; set; }
        public int usuario_id { get; set; }
        public bool primeiro_socorros { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dica> Dica { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}