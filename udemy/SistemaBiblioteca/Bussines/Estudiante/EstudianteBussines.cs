using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Runtime.Serialization;

namespace Bussines.Estudiante
{

    [DataContract]
    public class EstudianteModel
    {
        [DataMember]
        public int idLector { get; set; }
        [DataMember]
        public string ci { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string apellido { get; set; }
        [DataMember]
        public string direccion { get; set; }
        [DataMember]
        public string carrera { get; set; }
        [DataMember]
        public int edad { get; set; }

    }

    public class EstudianteBussines
    {
        public class select {

            public select() { }

            /// <summary>
            /// Realiza conversion de datos de la capa DATA para poder manejarlo como se antoja el negocio y poder manejar en todo el sitema
            /// </summary>
            /// <returns>Lista de estudiantes</returns>
            /// 
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


            public static EstudianteModel GetEstudiante(int id)
            {
                var bussines = Data.Estudiante.EstudianteData.getEstidiantes(id);
                EstudianteModel datos = new EstudianteModel() {
                    apellido = bussines.apellido,
                    carrera = bussines.carrera,
                    ci = bussines.ci,
                    direccion = bussines.direccion,
                    edad = bussines.edad,
                    idLector = bussines.idLector,
                    nombre = bussines.nombre
                };

                return datos;
            }

        }

        public class insert {

            public static void agregar(EstudianteModel obj)
            {
                ESTUDIANTE datos = new ESTUDIANTE()
                {
                    ci = obj.ci,
                    apellido = obj.apellido,
                    idLector = obj.idLector,
                    carrera = obj.carrera,
                    direccion = obj.direccion,
                    edad = obj.edad,
                    nombre = obj.nombre                    
                };

                var bussines = Data.Estudiante.EstudianteData.crearEstidiante(datos);
            }
        }

        public class update
        {
            public static void actualizar(EstudianteModel obj)
            {
                ESTUDIANTE es = new ESTUDIANTE() {
                    nombre = obj.nombre,
                    apellido = obj.apellido,
                    carrera = obj.carrera,
                    ci = obj.ci,
                    direccion = obj.direccion,
                    edad = obj.edad,
                    idLector = obj.idLector
                };

                Data.Estudiante.EstudianteData.update(es);
            }
        }


    }
}
