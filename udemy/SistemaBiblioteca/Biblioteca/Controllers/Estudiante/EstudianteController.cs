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


        // GET: EstidianteAdd
        [HttpGet]
        public ActionResult EstidianteAdd() {

            return View();
        }

        // POST: EstidianteAdd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EstidianteAdd(EstudianteViewModels obj)
        {

            EstudianteModel es = obj.Estudi;
            EstudianteBussines.insert.agregar(es);

            return RedirectToAction("EstudianteView");
        }

        // GET: EstidianteEdd
        [HttpGet]
        public ActionResult EstidianteEdd(int id)
        {
            var BussinesData = Bussines.Estudiante.EstudianteBussines.select.GetEstudiante(id);
            var model = new EstudianteViewModels()
            {
                Estudi = BussinesData
            };
            return View(model);
        }

        // POST: EstidianteEdd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EstidianteEdd(EstudianteViewModels obj)
        {

            EstudianteModel es = obj.Estudi;
            EstudianteBussines.update.actualizar(es);

            return RedirectToAction("EstudianteView");
        }


    }
}