using Bussines;
using Bussines.Cellar;
using Bussines.Product;
using Storage.Models.Cellar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Storage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var BussinesData = CellarBussines.Select.GetCellarHome();
            BussinesData.Error = new Bussines.Handler.ErrorObject();
            var model = new CellarViewModels()
            {
                Error = BussinesData.Error,
                CellarList = BussinesData.CellarList,
                ProductList = ProductBussines.Select.GetProduct().ProductList,
                ProductTypeList = ProductTypeBussines.Select.GetProductTypeList().ProductTypeList,
                CellarAreaList = CellarAreaBussines.Select.GetCellarAreaList().CellarAreaList
            };


            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}