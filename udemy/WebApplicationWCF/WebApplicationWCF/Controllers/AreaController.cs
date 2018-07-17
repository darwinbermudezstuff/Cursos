using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bussines;

namespace WebApplicationWCF.Controllers
{
    public class AreaController : ApiController
    {


        // GET http://<servidor>/api/Area
        public List<Bussines.Estudiante.EstudianteModel> getEstudiantes() {
            List<Bussines.Estudiante.EstudianteModel> datos = Bussines.Estudiante.EstudianteBussines.select.GetEstudiante();
            return datos;
        }

        // GET http://<servidor>/api/Area/5

        public Bussines.Estudiante.EstudianteModel getEstudiantes(int id)
        {
            Bussines.Estudiante.EstudianteModel datos = Bussines.Estudiante.EstudianteBussines.select.GetEstudiante(id);
            return datos;
        }


    }
}
