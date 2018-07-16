using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Bussines.Estudiante;
using Biblioteca.Models.Estudiante;

namespace Biblioteca.Controllers.Estudiante
{
    public class EstudianteController : Controller
    {

        #region Proerties
        private static string result = "";
        #endregion


        // GET: Estudiante
        /// <summary>
        /// Trabaja la vista de los empleados
        /// </summary>
        /// <returns>No tiene retorno</returns>
        public ActionResult EstudianteView()
        {

            var BussinesData = Bussines.Estudiante.EstudianteBussines.select.GetEstudiante();
            var model = new EstudianteViewModels() {
                EstudianteLista = BussinesData
            };

            return View(model);
        }
    }
}