using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussines.Product;
using Storage.Models.Product;

namespace Storage.Controllers.Product
{
    public class ConditionProductController : Controller
    {



        #region Proerties
        private static string result = "";
        #endregion

        #region Views
        public ActionResult ProductConditionView(bool successful = false, string ResultAction = "")
        {
            ViewBag.Title = "Product Condition";
            ViewBag.successful = successful;
            ViewBag.Message = ResultAction;

            var BussinesData = ConditionProductBussines.Select.GetConditionProductList();
            var model = new ConditionProductViewModels()
            {
                Error = BussinesData.Error,
                ConditionProductList = BussinesData.ConditionProductList
            };

            return View(model);
        }
        #endregion

        #region Create
        [HttpGet]
        public ActionResult ProductConditionCreate()
        {
            ViewBag.Title = "New Product Condition";
            ViewBag.Message = "";
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductConditionCreate(ConditionProductViewModels data)
        {
            ConditionProductBussines.GetConditionProductResponse request = new ConditionProductBussines.GetConditionProductResponse()
            {
                ConditionProduct = data.ConditionProduct
            };

            result = ConditionProductBussines.Insert.ConditionProduct(request).Message;

            return RedirectToAction("ProductConditionView", new { successful = true, ResultAction = "All Changes was successful" });
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult ProductConditionUpdate(int id)
        {
            ViewBag.Title = "Update Product Condition";
            ViewBag.Message = "";

            ConditionProductBussines.GetConditionProductRequest request = new ConditionProductBussines.GetConditionProductRequest() { ConditionProductID = id };
            ConditionProduct C = ConditionProductBussines.Select.GetConditionProduct(request).ConditionProduct;

            var model = new ConditionProductViewModels() { ConditionProduct = C };
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductConditionUpdate(ConditionProductViewModels data)
        {

            if (ModelState.IsValid)
            {
                ConditionProductBussines.GetConditionProductResponse request = new ConditionProductBussines.GetConditionProductResponse()
                {
                    ConditionProduct = data.ConditionProduct
                };
                result = ConditionProductBussines.Update.ConditionProduct(request).Message;
            }

            return RedirectToAction("ProductConditionView", new { successful = true, ResultAction = "All Changes was successful" });
        }
        #endregion

        #region Disable
        public ActionResult ConditionProductDisable(int id, string state)
        {
            result = ConditionProductBussines.Delete.ConditionProductDisable(id, state).Message;
            return RedirectToAction("ProductConditionView", new { successful = true, ResultAction = "All Changes was successful" });
        }

        #endregion



    }
}