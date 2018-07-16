using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bussines.Estudiante;

namespace WebApiWCF.Models
{
    public class Empleado
    {
        int ID { get; set; }
        EstudianteModel estModelo = new EstudianteModel();
        List<EstudianteModel> listEstModelo = new List<EstudianteModel>();

    }
}