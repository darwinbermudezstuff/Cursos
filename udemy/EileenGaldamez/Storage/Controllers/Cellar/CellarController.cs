using Bussines;
using Bussines.Cellar;
using Bussines.Product;
using Bussines.Transaction;
using Storage.Models.Cellar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Storage.Controllers.Cellar
{
    public class CellarController : Controller
    {
        #region Views
        public ActionResult CellarView(string CellarArea = "", bool successful = false, string ResultAction = "")
        {
            ViewBag.Title = "Product Assignation";
            ViewBag.successful = successful;
            ViewBag.Message = ResultAction;
            int GetCellarToArea;

            if (!String.IsNullOrEmpty(CellarArea))
            {
                GetCellarToArea = Convert.ToInt16(CellarArea);
            }
            else {
                GetCellarToArea = CellarAreaBussines.Select.GetCellarAreaListMenu().MenuList.First().CellarAreaID;
            }

            var BussinesData = CellarBussines.Select.GetCellarToArea(GetCellarToArea);
            var model = new CellarViewModels()
            {
                Error = BussinesData.Error,
                GetCellarToArea = GetCellarToArea,
                CellarList = BussinesData.CellarList,
                ProductList = ProductBussines.Select.GetProduct().ProductList,
                ProductTypeList = ProductTypeBussines.Select.GetProductTypeList().ProductTypeList,
                CellarAreaList = CellarAreaBussines.Select.GetCellarAreaList().CellarAreaList,
                ConditionProductList = ConditionProductBussines.Select.GetConditionProductList().ConditionProductList
            };

            return View(model);
        }

        public ActionResult CellarHomePageView()
        {
            ViewBag.Title = "Min :S";

            var BussinesData = CellarBussines.Select.GetCellarHome();
            var model = new CellarViewModels()
            {
                Error = BussinesData.Error,
                CellarList = BussinesData.CellarList,
                ProductList = ProductBussines.Select.GetProduct().ProductList,
                ProductTypeList = ProductTypeBussines.Select.GetProductTypeList().ProductTypeList,
                CellarAreaList = CellarAreaBussines.Select.GetCellarAreaList().CellarAreaList,
                ConditionProductList = ConditionProductBussines.Select.GetConditionProductList().ConditionProductList
            };

            return View(model);
        }


        [HttpGet]
        public ActionResult CellarDetail(int AnchorTransactionID, int TransactionTypeID)
        {
            ViewBag.Title = "Detail Product Assignation";
            ViewBag.Message = "";

            CellarBussines.GetCellarRequest request = new CellarBussines.GetCellarRequest()
            {
                CellarID = AnchorTransactionID,
            };
            TransactionConfigurateBussines.GetTransactionConfigurateRequest requestTransaction = new TransactionConfigurateBussines.GetTransactionConfigurateRequest() {
                AnchorTransactionID = AnchorTransactionID,
                TransactionTypeID = TransactionTypeID
            };

            CellarBussines.GetCellarResponse c = CellarBussines.Select.GetCellar(request);
            int to = TransactionConfigurateBussines.Select.GetTotalAmountToTransaction(requestTransaction).TotalAmount;
            request.ProductID = (int)c.Cellar.idProduct;
            var model = new CellarViewModels()
            {
                Error = c.Error,
                total = to,
                Cellar = c.Cellar,
                Transaction = new Transactions(),
                TransactionList = TransactionConfigurateBussines.Select.GetTransactionList(requestTransaction).TransactionList,
                ProductList = ProductBussines.Select.GetProduct().ProductList,
                CellarAreaList = CellarAreaBussines.Select.GetCellarAreaList().CellarAreaList,
                CellarList = CellarBussines.Select.GetCellarByProductID(request).CellarList,
                ProviderList = ProviderBussines.Select.GetProviderList().ProviderList,
                ConditionProductList = ConditionProductBussines.Select.GetConditionProductList().ConditionProductList
            };
            return PartialView(model);
        }
        #endregion

        #region Create
        [HttpGet]
        public ActionResult CellarCreate(int CellarArea = 1)
        {
            ViewBag.Title = "New Product Assignation";
            ViewBag.Message = "";

            ProductBussines.GetProductRequest request = new ProductBussines.GetProductRequest() {
                CellarAreaID = CellarArea
            };


            var model = new CellarViewModels()
            {
                ProductList = ProductBussines.Select.GetProductToCellarArea(request).ProductList,
                CellarAreaList = CellarAreaBussines.Select.GetCellarAreaList().CellarAreaList,
                ProviderList = ProviderBussines.Select.GetProviderList().ProviderList,
                ConditionProductList = ConditionProductBussines.Select.GetConditionProductList().ConditionProductList,
                GetCellarToArea = CellarArea
            };

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CellarCreate(CellarViewModels data)
        {

            CellarBussines.GetCellarResponse CellarInformation = new CellarBussines.GetCellarResponse()
            {
                Cellar = data.Cellar,
                transaction = data.Transaction
                
            };
            CellarInformation.Cellar.amount = data.Transaction.amount;
            CellarInformation.Cellar.createDate = data.Transaction.createDate;
            //CellarInformation.Cellar.idcellarArea = data.GetCellarToArea;

            CellarBussines.GetCellarRequest request = new CellarBussines.GetCellarRequest() {
                TransactionTypeID = 1
            };

            CellarBussines.Insert.Cellar(CellarInformation, request);

            return RedirectToAction("CellarView", new { successful = true, ResultAction = "All Changes was successful" });
        }
        #endregion

        #region Update
      
        [HttpGet]
        public ActionResult CellarUpdate(int id)
        {
            CellarBussines.GetCellarRequest request = new CellarBussines.GetCellarRequest(){
                CellarID = id,
            };
            CellarBussines.GetCellarResponse c = CellarBussines.Select.GetCellar(request);
            request.ProductID = (int)c.Cellar.idProduct;
            ProductBussines.GetProductRequest request2 = new ProductBussines.GetProductRequest() {
                ProductID = (int)c.Cellar.idProduct
            };
            var model = new CellarViewModels()
            {
                Error = c.Error,
                Cellar = c.Cellar,
                CellarAreaList = CellarAreaBussines.Select.GetCellarAreaList().CellarAreaList,
                ConditionProductList = ConditionProductBussines.Select.GetConditionProductList().ConditionProductList
            };

            ViewBag.Title = "Update Product Assignation To " + ProductBussines.Select.GetProduct(request2).Product.name;
            ViewBag.Message = "";

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CellarUpdate(CellarViewModels data)
        {
            CellarBussines.GetCellarResponse request = new CellarBussines.GetCellarResponse()
            {
                Cellar = data.Cellar
            };
            CellarBussines.Update.Cellar(request);
            return RedirectToAction("CellarView", new { successful = true, ResultAction = "All Changes was successful" });
        }

        [HttpGet]
        public ActionResult CellarNewCellar(int AnchorTransactionID, int TransactionTypeID)
        {
            ViewBag.Title = "Update Product Assignation";
            ViewBag.Message = "";

            CellarBussines.GetCellarRequest request = new CellarBussines.GetCellarRequest()
            {
                CellarID = AnchorTransactionID,
            };
            TransactionConfigurateBussines.GetTransactionConfigurateRequest requestTransaction = new TransactionConfigurateBussines.GetTransactionConfigurateRequest()
            {
                AnchorTransactionID = AnchorTransactionID,
                TransactionTypeID = TransactionTypeID
            };

            CellarBussines.GetCellarResponse c = CellarBussines.Select.GetCellar(request);
            int to = TransactionConfigurateBussines.Select.GetTotalAmountToTransaction(requestTransaction).TotalAmount;
            request.ProductID = (int)c.Cellar.idProduct;
            var model = new CellarViewModels()
            {
                Error = c.Error,
                total = to,
                Cellar = c.Cellar,
                Transaction = new Transactions(),
                TransactionList = TransactionConfigurateBussines.Select.GetTransactionList(requestTransaction).TransactionList,
                ProductList = ProductBussines.Select.GetProduct().ProductList,
                CellarAreaList = CellarAreaBussines.Select.GetCellarAreaList().CellarAreaList,
                CellarList = CellarBussines.Select.GetCellarByProductID(request).CellarList,
                ProviderList = ProviderBussines.Select.GetProviderList().ProviderList,
                ConditionProductList = ConditionProductBussines.Select.GetConditionProductList().ConditionProductList
            };
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CellarNewCellar(CellarViewModels data)
        {
            CellarBussines.GetCellarRequest request = new CellarBussines.GetCellarRequest() {
                CellarID = data.Cellar.id,
                TransactionTypeID = 1
            };
            CellarBussines.GetCellarResponse cellarInformation = new CellarBussines.GetCellarResponse();
            cellarInformation.transaction = data.Transaction;

            int oldAmount = (int)CellarBussines.Select.GetCellar(request).Cellar.amount;
            int currentAmount = (int)data.Transaction.amount;
            int newAmount = oldAmount + currentAmount;
            request.amount = newAmount;

            cellarInformation.Cellar = new Cellars
            {
                id = data.Cellar.id,
                amount = newAmount
            };            
            CellarBussines.Update.Cellar(cellarInformation, request);
            return RedirectToAction("CellarView", new { successful = true, ResultAction = "All Changes was successful" });
        }
        #endregion

        public JsonResult ProductByDeparment(int CellarArea)
        {

            ProductBussines.GetProductRequest request = new ProductBussines.GetProductRequest() {
                CellarAreaID = CellarArea
            };


            var ProductList = ProductBussines.Select.GetProductToCellarArea(request).ProductList;

            return Json(
                new
                {
                    Product = ProductList
                },
                JsonRequestBehavior.AllowGet);
        }


    }



}