using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bussines.Estudiante;


namespace Biblioteca.Models.Estudiante
{
    public class EstudianteViewModels
    {
        public List<EstudianteModel> EstudianteLista { get; set; }
        public EstudianteModel Estudi { get; set; }
        public int idLector { get; set; }


    }
}