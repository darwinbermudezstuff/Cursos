using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Bussines;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "estudiante" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select estudiante.svc or estudiante.svc.cs at the Solution Explorer and start debugging.
    public class estudiante : Iestudiante
    {

        public List<Bussines.Estudiante.EstudianteModel> GetEstudiante()
        {
            List<Bussines.Estudiante.EstudianteModel> datos = Bussines.Estudiante.EstudianteBussines.select.GetEstudiante();
            return datos;
        }

        public Bussines.Estudiante.EstudianteModel GetEstudiante(int id)
        {
            Bussines.Estudiante.EstudianteModel datos = Bussines.Estudiante.EstudianteBussines.select.GetEstudiante(id);
            return datos;
        }
    }
}
