using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    public class prestamoEntity
    {
        public int idLector { get; set; }
        public int idLibro { get; set; }
        public string fechaPrestamo { get; set; }
        public string fechaDevolucion { get; set; }
        public char devuelto { get; set; }

    }
}
