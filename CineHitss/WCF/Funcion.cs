//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Funcion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Funcion()
        {
            this.Boletoes = new HashSet<Boleto>();
            this.LugaresOcupados = new HashSet<LugaresOcupado>();
        }
    
        public int ID { get; set; }
        public string HoraInicio { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<bool> Estado { get; set; }
        public Nullable<double> Precio { get; set; }
        public string TipoSala { get; set; }
        public Nullable<int> PeliculaID { get; set; }
        public Nullable<int> CineID { get; set; }
        public Nullable<int> Sala { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Boleto> Boletoes { get; set; }
        public virtual Cine Cine { get; set; }
        public virtual Pelicula Pelicula { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LugaresOcupado> LugaresOcupados { get; set; }
    }
}
