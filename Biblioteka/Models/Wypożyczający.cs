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
    
    public partial class Wypożyczający
    {
        public int Id { get; set; }
        public string Imię { get; set; }
        public string Nazwisko { get; set; }
        public int TytułKsiążkiId { get; set; }
        public string NumerTelefonu { get; set; }
        public string AdresMailowy { get; set; }
    
        public virtual Książki Książki { get; set; }
    }
}
