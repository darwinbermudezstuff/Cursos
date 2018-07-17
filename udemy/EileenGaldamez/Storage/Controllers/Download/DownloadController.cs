using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussines.Download;
using Storage.Models.Download;
using Bussines;
using Bussines.Product;
using Bussines.Transaction;
using Bussines.Employee;
using Bussines.Cellar;
using Bussines.Assignment;

namespace Storage.Download.Controllers
{
    public class DownloadController : Controller
    {
        #region Proerties
        private static string result = "";
        #endregion

        #region Views
        public ActionResult DownloadView(string CategoryID, string FatherCateogryID, string CellarArea, bool successful = false, string ResultAction = "")
        {
            ViewBag.Title = "Download";
            ViewBag.successful = successful;
            ViewBag.Message = ResultAction;

            DownloadAssignmentBussines.GetDownloadRequest request = new DownloadAssignmentBussines.GetDownloadRequest()
            {
                CategoryID = Convert.ToInt16(CategoryID),
                TransactionTypeID = 3
            };

            var BussinesData = DownloadAssignmentBussines.Select.GetDownloadList(request);
            var model = new DownloadAssignmentViewModels()
            {
                Error = BussinesData.Error,
                CategoryID = CategoryID,
                CellarArea = CellarArea,
                DownloadList = BussinesData.DownloadList,
                GetCategoryName = CategoryBussines.Select.GetCategoryName(Convert.ToInt16(CategoryID)).Category.name,
                ConditionProductList = ConditionProductBussines.Select.GetConditionProductList().ConditionProductList
            };

            return View(model);
        }

        public ActionResult DownloadDetail(int AnchorTransactionID, int TransactionTypeID)
        {
            ViewBag.Title = "Detail Download";
            ViewBag.Message = "";

            DownloadAssignmentBussines.GetDownloadRequest request = new DownloadAssignmentBussines.GetDownloadRequest()
            {
                DownloadID = AnchorTransactionID,
            };
            TransactionConfigurateBussines.GetTransactionConfigurateRequest requestTransaction = new TransactionConfigurateBussines.GetTransactionConfigurateRequest()
            {
                AnchorTransactionID = AnchorTransactionID,
                TransactionTypeID = TransactionTypeID
            };

            DownloadAssignmentBussines.GetDownloadResponse d = DownloadAssignmentBussines.Select.GetDownload(request);
            int to = TransactionConfigurateBussines.Select.GetTotalAmountToTransaction(requestTransaction).TotalAmount;
            request.ProductID = (int)d.Download.idProduct;

            var model = new DownloadAssignmentViewModels()
            {
                Error = d.Error,
                total = to,
                Download = d.Download,
                Transaction = new Transactions(),
                TransactionList = TransactionConfigurateBussines.Select.GetTransactionList(requestTransaction).TransactionList,
                ProductList = ProductBussines.Select.GetProduct().ProductList,
                DownloadList = DownloadAssignmentBussines.Select.GetDownloadByProductID(request).DownloadList,
                ConditionProductList = ConditionProductBussines.Select.GetConditionProductList().ConditionProductList
            };
            return PartialView(model);
        }

        #endregion

        #region Create
        [HttpGet]
        public ActionResult DownloadCreate(string CategoryID, string FatherCateogryID, string CellarArea)
        {
            ViewBag.Title = "New Download";
            ViewBag.Message = "";
            ProductBussines.GetProductandTransactionTypeRequest request = new ProductBussines.GetProductandTransactionTypeRequest()
            {
                CellarAreaID = Convert.ToInt16(CellarArea),
                CategoryID = Convert.ToInt16(CategoryID),
                TransactionType = 2
            };
            var model = new DownloadAssignmentViewModels()
            {
                Download = new DownloadAssignment(),
                CategoryID = CategoryID,
                CellarArea = CellarArea,
                ProductList = ProductBussines.Select.GetProductByAssignmentTypeAndTransactionType(request).ProductList,
                EmployeesList = EmployeeBussines.Select.GetEmployeeList().EmployeeList,
                ConditionProductList = ConditionProductBussines.Select.GetConditionProductList().ConditionProductList
            };
            model.Download.idCategory = Convert.ToInt16(CategoryID);

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DownloadCreate(DownloadAssignmentViewModels data)
        {
            DownloadAssignmentBussines.GetDownloadResponse assignmentData = new DownloadAssignmentBussines.GetDownloadResponse()
            {
                Download = data.Download,
                transaction = data.Transaction
            };
            assignmentData.Download.amount = data.Transaction.amount;
            assignmentData.Download.createDate = data.Transaction.createDate;

            DownloadAssignmentBussines.GetDownloadRequest request = new DownloadAssignmentBussines.GetDownloadRequest()
            {
                TransactionTypeID = 3,        
                CategoryID = (int)data.Download.idCategory,        
                CellarArea = Convert.ToInt16(data.CellarArea)
            };

            result = DownloadAssignmentBussines.Insert.Download(assignmentData, request).Message;

            return RedirectToAction("DownloadView", new { CategoryID = data.CategoryID, FatherCateogryID = data.FatherCateogryID, CellarArea = data.CellarArea, successful = true, ResultAction = "All Changes was successful" });
        }

        [HttpGet]
        public ActionResult DownloadNewInflow(string CategoryID, string FatherCateogryID, string CellarArea, int AnchorTransactionID, int TransactionTypeID)
        {
            ViewBag.Title = "New Download";
            ViewBag.Message = "";

            DownloadAssignmentBussines.GetDownloadRequest request = new DownloadAssignmentBussines.GetDownloadRequest()
            {
                DownloadID = AnchorTransactionID
            };
            TransactionConfigurateBussines.GetTransactionConfigurateRequest requestTransaction = new TransactionConfigurateBussines.GetTransactionConfigurateRequest()
            {
                AnchorTransactionID = AnchorTransactionID,
                TransactionTypeID = TransactionTypeID
            };
            ProductBussines.GetProductRequest requestProduct = new ProductBussines.GetProductRequest()
            {
                CellarAreaID = Convert.ToInt16(CellarArea)
            };

            DownloadAssignmentBussines.GetDownloadResponse c = DownloadAssignmentBussines.Select.GetDownload(request);
            int to = TransactionConfigurateBussines.Select.GetTotalAmountToTransaction(requestTransaction).TotalAmount;
            request.ProductID = (int)c.Download.idProduct;

            var model = new DownloadAssignmentViewModels()
            {
                Error = c.Error,
                total = to,
                Download = c.Download,
                Transaction = new Transactions(),
                TransactionList = TransactionConfigurateBussines.Select.GetTransactionList(requestTransaction).TransactionList,
                DownloadList = DownloadAssignmentBussines.Select.GetDownloadByProductID(request).DownloadList,
                ConditionProductList = ConditionProductBussines.Select.GetConditionProductList().ConditionProductList,



                CategoryID = CategoryID,
                FatherCateogryID = FatherCateogryID,
                CellarArea = CellarArea,
                ProductList = ProductBussines.Select.GetProductByAssignmentType(requestProduct).ProductList,
                EmployeesList = EmployeeBussines.Select.GetEmployeeList().EmployeeList,
            };

            model.Download.idCategory = Convert.ToInt16(CategoryID);


            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DownloadNewInflow(DownloadAssignmentViewModels data)
        {
            DownloadAssignmentBussines.GetDownloadResponse assignmentData = new DownloadAssignmentBussines.GetDownloadResponse()
            {
                Download = data.Download,
                transaction = data.Transaction
            };

            DownloadAssignmentBussines.GetDownloadRequest request = new DownloadAssignmentBussines.GetDownloadRequest()
            {
                DownloadID = data.Download.id,
                TransactionTypeID = 3,
                CellarArea = Convert.ToInt16(data.CellarArea),
                CategoryID = (int)data.Download.idCategory,
                amount = (int)data.Download.amount + (int)data.Transaction.amount
            };

            result = DownloadAssignmentBussines.Update.Download(assignmentData, request).Message;

            return RedirectToAction("DownloadView", new { CategoryID = data.CategoryID, FatherCateogryID = data.FatherCateogryID, CellarArea = data.CellarArea, successful = true, ResultAction = "All Changes was successful" });
        }

        #endregion

        #region Update
        [HttpGet]
        public ActionResult DownloadUpdate(int id, string CategoryID, string FatherCateogryID, string CellarArea)
        {

            DownloadAssignmentBussines.GetDownloadRequest request = new DownloadAssignmentBussines.GetDownloadRequest()
            {
                DownloadID = id,
            };
            DownloadAssignmentBussines.GetDownloadResponse a = DownloadAssignmentBussines.Select.GetDownload(request);
            request.ProductID = (int)a.Download.idProduct;

            ProductBussines.GetProductRequest request2 = new ProductBussines.GetProductRequest()
            {
                ProductID = (int)a.Download.idProduct
            };
            var model = new DownloadAssignmentViewModels()
            {
                Error = a.Error,
                Download = a.Download,
                CategoryID = CategoryID,
                FatherCateogryID = FatherCateogryID,
                CellarArea = CellarArea,
                EmployeesList = EmployeeBussines.Select.GetEmployeeList().EmployeeList
            };

            ViewBag.Title = "Update Download To " + ProductBussines.Select.GetProduct(request2).Product.name;
            ViewBag.Message = "";

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DownloadUpdate(DownloadAssignmentViewModels data)
        {
            DownloadAssignmentBussines.GetDownloadResponse assignmentData = new DownloadAssignmentBussines.GetDownloadResponse()
            {
                Download = data.Download
            };

            result = DownloadAssignmentBussines.Update.Downloads(assignmentData).Message;

            return RedirectToAction("DownloadView", new { CategoryID = data.CategoryID, FatherCateogryID = data.FatherCateogryID, CellarArea = data.CellarArea, successful = true, ResultAction = "All Changes was successful" });
        }
        #endregion

        public JsonResult ActualAmountByDownload(int ProductID, int CategoryID, int condition, int transactionType)
        {
            AssignmentBussines.GetAssignmentWithConditionRequest request = new AssignmentBussines.GetAssignmentWithConditionRequest()
            {
                ProductID = ProductID,
                CategoryID = CategoryID,
                ConditionID = condition,
                TransactionTypeID = transactionType
            };

            var AssignmentInformation = AssignmentBussines.Select.GetAssignmentByProductIDAndCategoryID(request).Assignment;
            TransactionTypeConditionDetailBussines.GetTransactionTypeConditionDetailRequest requestCondition = new TransactionTypeConditionDetailBussines.GetTransactionTypeConditionDetailRequest()
            {
                ConditionID = condition,
                TransactionTypeID = transactionType,
                TransactionID = AssignmentInformation.id
            };

            return Json(
                new
                {
                    AmountTotal = AssignmentInformation.amount,
                    AmountCondition = TransactionTypeConditionDetailBussines.Select.GetTransactionTypeConditionDetail(requestCondition).TransactionTypeConditionDetail.amount
                },
                JsonRequestBehavior.AllowGet);
        }
    }

}