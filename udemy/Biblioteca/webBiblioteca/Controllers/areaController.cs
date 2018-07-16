using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussines;
using webBiblioteca.Models;
using DataEntity;

namespace webBiblioteca.Controllers
{
    public class areaController : Controller
    {

        areaBussines ab;
        private List<areaEntity> lae = new List<areaEntity>();

        public areaController()
        {
            ab = new areaBussines();
        }
        // GET: area
        public ActionResult Index()
        {
            bool er = ab.getArea(ref lae);
            var model = new areaModels()
            {
                Areas = lae,
                Error = er
            };

            return View(model);
        }
    }
}