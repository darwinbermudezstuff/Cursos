//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRESTAMO
    {
        public int idLector { get; set; }
        public int idLibro { get; set; }
        public System.DateTime fechaPrestamo { get; set; }
        public System.DateTime fechaDevolucion { get; set; }
        public bool devuelto { get; set; }
    
        public virtual ESTUDIANTE ESTUDIANTE { get; set; }
        public virtual LIBRO LIBRO { get; set; }
    }
}
