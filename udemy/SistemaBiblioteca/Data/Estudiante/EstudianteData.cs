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

        #endregion
    }
}
