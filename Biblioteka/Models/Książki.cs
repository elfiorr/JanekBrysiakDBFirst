//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Biblioteka.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Książki
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Książki()
        {
            this.Wypożyczający = new HashSet<Wypożyczający>();
        }
    
        public int Id { get; set; }
        public string TytułKsiążki { get; set; }
        public string Opis { get; set; }
        public string NumerWewKsiążki { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wypożyczający> Wypożyczający { get; set; }
    }
}
