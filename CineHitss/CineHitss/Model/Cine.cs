//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CineHitss.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cine()
        {
            this.Funcions = new HashSet<Funcion>();
        }
    
        public int ID { get; set; }
        public string CineN { get; set; }
        public string Direccion { get; set; }
        public Nullable<bool> Estado { get; set; }
        public Nullable<int> CiudadID { get; set; }
    
        public virtual Ciudad Ciudad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Funcion> Funcions { get; set; }
    }
}
