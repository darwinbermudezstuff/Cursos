using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Bussines.Estudiante
{

    public class EstudianteModel
    {
        public int idLector { get; set; }
        public string ci { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string carrera { get; set; }
        public int edad { get; set; }

    }

    public class EstudianteBussines
    {
        public class select {

            /// <summary>
            /// Realiza conversion de datos de la capa DATA para poder manejarlo como se antoja el negocio y poder manejar en todo el sitema
            /// </summary>
            /// <returns>Lista de estudiantes</returns>
            public static List<EstudianteModel> GetEstudiante() {
                List<EstudianteModel> data = new List<EstudianteModel>();
                try
                {
                    var bussines = Data.Estudiante.EstudianteData.getEstidiantes();
                    foreach (var item in bussines)
                    {
                        data.Add(new EstudianteModel()
                        {
                            idLector = item.idLector,
                            ci = item.ci,
                            nombre = item.nombre,
                            apellido = item.apellido,
                            direccion = item.direccion,
                            carrera = item.carrera,
                            edad = item.edad
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return data;
            }


        }

    }
}
