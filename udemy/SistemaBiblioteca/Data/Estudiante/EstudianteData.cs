using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Estudiante
{
    public class EstudianteData
    {

        #region Consulta

        /// <summary>
        /// Retorna todos los datos que se encuentra en la tabla de estudiante
        /// </summary>
        /// <returns>Listado de estudiantes</returns>
        public static List<ESTUDIANTE> getEstidiantes()
        {
            List<ESTUDIANTE> data = new List<ESTUDIANTE>();
            using (BIBLIOTECAEntities1 db = new BIBLIOTECAEntities1())
            {
                data = db.ESTUDIANTE.ToList();
            }
            return data;
        }

        public static ESTUDIANTE getEstidiantes(int id)
        {
            ESTUDIANTE data = new ESTUDIANTE();
            using (BIBLIOTECAEntities1 db = new BIBLIOTECAEntities1())
            {
                data = db.ESTUDIANTE.Find(id);
            }
            return data;
        }

        public static bool update(ESTUDIANTE obj)
        {


            using(BIBLIOTECAEntities1 db = new BIBLIOTECAEntities1())
            {
                var row = db.ESTUDIANTE.Single(p => p.idLector == obj.idLector);
                row.idLector = obj.idLector;
                row.apellido = obj.apellido;
                row.nombre = obj.nombre;
                row.direccion = obj.direccion;
                row.carrera = obj.carrera;
                row.edad = obj.edad;
                row.ci = obj.ci;
                db.SaveChanges();
            }
            return true;
        }

        public static bool crearEstidiante(ESTUDIANTE obj)
        {

            using(BIBLIOTECAEntities1 db = new BIBLIOTECAEntities1())
            {
                var data = db.CREATEESTUDIANTE(obj.ci, obj.nombre, obj.apellido, obj.direccion, obj.carrera, obj.edad);
            }
            return true;
        }


        #endregion
    }
}
