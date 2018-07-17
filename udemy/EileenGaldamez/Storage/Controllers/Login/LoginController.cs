using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Storage.Controllers.Login
{
//    [Bussines.Helper.AutenticadoAttributeBussines.NoLoginAttribute]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }



    }
}