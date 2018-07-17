using Bussines.Cellar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Storage.Models.Employee;
using Bussines.Employee;
using Bussines.User;
using Storage.Models.Assignment;
using Bussines.Assignment;
using Bussines;
using Bussines.Product;
using Bussines.Transaction;

namespace Storage.Controllers.Assignment
{
    public class AssignmentController : Controller
    {
        #region Proerties
        private static string result = "";
        #endregion

        #region Views
        public ActionResult AssignmentView(string CategoryID, string FatherCateogryID, string CellarArea, bool successful = false, string ResultAction = "")
        {
            ViewBag.Title = "";
            ViewBag.successful = successful;
            ViewBag.Message = ResultAction;

            AssignmentBussines.GetAssignmentRequest request = new AssignmentBussines.GetAssignmentRequest() {
                CategoryID = Convert.ToInt16(CategoryID),
                TransactionTypeID = 2
            };
            AssignmentBussines.GetAssignmentRequest requestFather = new AssignmentBussines.GetAssignmentRequest()
            {
                CategoryID = Convert.ToInt16(CategoryID)
            };

            var BussinesData = AssignmentBussines.Select.GetAssignmentList(request);
            var model = new AssignmentViewModels() {
                Error = BussinesData.Error,
                CategoryID = CategoryID,
                CategoryIDFhater = FatherCateogryID,
                CellarArea = CellarArea,
                AssignmentList = BussinesData.AssignmentList,
                GetCategoryName = CategoryBussines.Select.GetCategoryName(Convert.ToInt16(CategoryID)).Category.name,
                GetCategoryFaherName = CategoryBussines.Select.GetCategoryName(Convert.ToInt16(FatherCateogryID)).Category.name,
                ConditionProductList = ConditionProductBussines.Select.GetConditionProductList().ConditionProductList
            };

            return View(model);
        }

        public ActionResult AssignmentDetail(int AnchorTransactionID, int TransactionTypeID)
        {
            ViewBag.Title = "";
            ViewBag.Message = "";

            AssignmentBussines.GetAssignmentRequest request = new AssignmentBussines.GetAssignmentRequest()
            {
                AssignmentID = AnchorTransactionID,
            };
            TransactionConfigurateBussines.GetTransactionConfigurateRequest requestTransaction = new TransactionConfigurateBussines.GetTransactionConfigurateRequest()
            {
                AnchorTransactionID = AnchorTransactionID,
                TransactionTypeID = TransactionTypeID
            };

            AssignmentBussines.GetAssignmentResponse c = AssignmentBussines.Select.GetAssignment(request);
            int to = TransactionConfigurateBussines.Select.GetTotalAmountToTransaction(requestTransaction).TotalAmount;
            request.ProductID = (int)c.Assignment.idProduct;

            var model = new AssignmentViewModels()
            {
                Error = c.Error,
                total = to,
                Assignment = c.Assignment,
                Transaction = new Transactions(),
                TransactionList = TransactionConfigurateBussines.Select.GetTransactionList(requestTransaction).TransactionList,
                ProductList = ProductBussines.Select.GetProduct().ProductList,
                AssignmentList = AssignmentBussines.Select.GetAssignmentByProductID(request).AssignmentList,
                ProviderList = ProviderBussines.Select.GetProviderList().ProviderList,
                ConditionProductList = ConditionProductBussines.Select.GetConditionProductList().ConditionProductList
            };
            return PartialView(model);
        }

        #endregion

        #region Create
        [HttpGet]
        public ActionResult AssignmentCreate(string FatherCateogryID, string CategoryID, string CellarArea)
        {
            ViewBag.Title = "";
            ViewBag.Message = "";
            ProductBussines.GetProductRequest request = new ProductBussines.GetProductRequest()
            {
                CellarAreaID = Convert.ToInt16(CellarArea), 
                CategoryID = Convert.ToInt16(CategoryID.ToString())
            };



            var model = new AssignmentViewModels()
            {
                Assignment = new Assignments(),
                CategoryID = CategoryID,
                CategoryIDFhater = FatherCateogryID,
                CellarArea = CellarArea,
                ProductList = ProductBussines.Select.GetProductListByDepartmentAndCategory(request, Convert.ToInt16(FatherCateogryID)).ProductList,
                EmployeesList = EmployeeBussines.Select.GetEmployeeList().EmployeeList,
                ConditionProductList = ConditionProductBussines.Select.GetConditionProductList().ConditionProductList
            };

            model.Assignment.idCategory = Convert.ToInt16(CategoryID);


            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignmentCreate(AssignmentViewModels data)
        {
            AssignmentBussines.GetAssignmentResponse assignmentData = new AssignmentBussines.GetAssignmentResponse()
            {
                Assignment = data.Assignment,
                transaction = data.Transaction
            };
            assignmentData.Assignment.amount = data.Transaction.amount;
            assignmentData.Assignment.createDate = data.Transaction.createDate;

            AssignmentBussines.GetAssignmentRequest request = new AssignmentBussines.GetAssignmentRequest() {
                TransactionTypeID = 2,
                CellarArea = Convert.ToInt16(data.CellarArea)
            };

            result = AssignmentBussines.Insert.Assignment(assignmentData, request).Message;

            return RedirectToAction("AssignmentView", new { CategoryID = data.CategoryID, FatherCateogryID = data.CategoryIDFhater, CellarArea = data.CellarArea, successful = true, ResultAction = "All Changes was successful" });
        }

        [HttpGet]
        public ActionResult AssignmentNewInflow(string CategoryID, string FatherCateogryID, string CellarArea, int AnchorTransactionID, int TransactionTypeID)
        {
            ViewBag.Title = "";
            ViewBag.Message = "";

            AssignmentBussines.GetAssignmentRequest request = new AssignmentBussines.GetAssignmentRequest()
            {
                AssignmentID = AnchorTransactionID,
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

            AssignmentBussines.GetAssignmentResponse c = AssignmentBussines.Select.GetAssignment(request);
            int to = TransactionConfigurateBussines.Select.GetTotalAmountToTransaction(requestTransaction).TotalAmount;
            request.ProductID = (int)c.Assignment.idProduct;

            var model = new AssignmentViewModels()
            {
                Error = c.Error,
                total = to,
                Assignment = c.Assignment,
                Transaction = new Transactions(),
                TransactionList = TransactionConfigurateBussines.Select.GetTransactionList(requestTransaction).TransactionList,
                AssignmentList = AssignmentBussines.Select.GetAssignmentByProductID(request).AssignmentList,
                ConditionProductList = ConditionProductBussines.Select.GetConditionProductList().ConditionProductList,



                CategoryID = CategoryID,
                CategoryIDFhater = FatherCateogryID,
                CellarArea = CellarArea,
                ProductList = ProductBussines.Select.GetProductByAssignmentType(requestProduct).ProductList,
                EmployeesList = EmployeeBussines.Select.GetEmployeeList().EmployeeList,
            };

            model.Assignment.idCategory = Convert.ToInt16(CategoryID);


            return PartialView(model);










        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignmentNewInflow(AssignmentViewModels data)
        {
            AssignmentBussines.GetAssignmentResponse assignmentData = new AssignmentBussines.GetAssignmentResponse()
            {
                Assignment = data.Assignment,
                transaction = data.Transaction                
            };

            AssignmentBussines.GetAssignmentRequest request = new AssignmentBussines.GetAssignmentRequest()
            {
                AssignmentID = data.Assignment.id,
                TransactionTypeID = 2,
                CellarArea = Convert.ToInt16(data.CellarArea), 
                amount = (int)data.Assignment.amount + (int)data.Transaction.amount
            };

            result = AssignmentBussines.Update.Assignment(assignmentData, request).Message;

            return RedirectToAction("AssignmentView", new { CategoryID = data.CategoryID, FatherCateogryID = data.CategoryIDFhater, CellarArea = data.CellarArea, successful = true, ResultAction = "All Changes was successful" });
        }

        #endregion

        #region Update
        [HttpGet]
        public ActionResult AssignmentUpdate(int id, string CategoryID, string FatherCateogryID, string CellarArea)
        {

            AssignmentBussines.GetAssignmentRequest request = new AssignmentBussines.GetAssignmentRequest()
            {
                AssignmentID = id,
            };
            AssignmentBussines.GetAssignmentResponse a = AssignmentBussines.Select.GetAssignment(request);
            request.ProductID = (int)a.Assignment.idProduct;

            ProductBussines.GetProductRequest request2 = new ProductBussines.GetProductRequest()
            {
                ProductID = (int)a.Assignment.idProduct
            };
            var model = new AssignmentViewModels()
            {
                Error = a.Error,
                Assignment = a.Assignment,
                CategoryID = CategoryID,
                CategoryIDFhater = FatherCateogryID,
                CellarArea = CellarArea,
                EmployeesList = EmployeeBussines.Select.GetEmployeeList().EmployeeList
            };

            ViewBag.Title = "Update Asignment To " + ProductBussines.Select.GetProduct(request2).Product.name;
            ViewBag.Message = "";

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignmentUpdate(AssignmentViewModels data)
        {
            AssignmentBussines.GetAssignmentResponse assignmentData = new AssignmentBussines.GetAssignmentResponse()
            {
                Assignment = data.Assignment
            };

            result = AssignmentBussines.Update.Assignments(assignmentData).Message;

            return RedirectToAction("AssignmentView", new { CategoryID = data.CategoryID, FatherCateogryID = data.CategoryIDFhater, CellarArea = data.CellarArea, successful = true, ResultAction = "All Changes was successful" });
        }
        #endregion

        public JsonResult ActualAmountByAssignment(int ProductID, int CellarArea, int condition, int transactionType)
        {
            CellarBussines.GetCellarRequest request = new CellarBussines.GetCellarRequest()
            {
                ProductID = ProductID,
                CellarAreaID = CellarArea,
                conditionID = condition,
                TransactionTypeID = transactionType
            };

            var cellarInformation = CellarBussines.Select.GetCellarByProductIDAndCellarArea(request).Cellar;
            TransactionTypeConditionDetailBussines.GetTransactionTypeConditionDetailRequest requestCondition = new TransactionTypeConditionDetailBussines.GetTransactionTypeConditionDetailRequest() {
                ConditionID = condition,
                TransactionTypeID = 1,
                TransactionID = cellarInformation.id
            };

            return Json(
                new {
                    AmountTotal = cellarInformation.amount,
                    AmountCondition = TransactionTypeConditionDetailBussines.Select.GetTransactionTypeConditionDetail(requestCondition).TransactionTypeConditionDetail.amount
//                    ActualAmount = CellarBussines.Select.GetCellarByProductIDAndCellarArea(request).Cellar.amount
                }, 
                JsonRequestBehavior.AllowGet);
        }
    }

}