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
    
    public partial class Pelicula
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pelicula()
        {
            this.Funcions = new HashSet<Funcion>();
        }
    
        public int ID { get; set; }
        public string MovieN { get; set; }
        public Nullable<bool> Estado { get; set; }
        public Nullable<int> GeneroID { get; set; }
        public string Img { get; set; }
        public string Sinopsis { get; set; }
        public string Clasificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Funcion> Funcions { get; set; }
        public virtual Genero Genero { get; set; }
    }
}