using Bussines;
using Bussines.Download;
using Bussines.Employee;
using Bussines.Handler;
using Bussines.Product;
using Bussines.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Storage.Models.Download
{
    public class DownloadAssignmentViewModels
    {
        public int ID { get; set; }
        public ErrorObject Error { get; set; }
        public int total { get; set; }
        public int ActualAmountByAssignment { get; set; }
        public string step { get; set; }
        public string GetCategoryName { get; set; }
        public string CategoryID { get; set; }
        public string CellarArea { get; set; }
        public string FatherCateogryID { get; set; }


        public List<ConditionProduct> ConditionProductList { get; set; }
        public DownloadAssignment Download { get; set; }
        public List<DownloadAssignment> DownloadList { get; set; }
        public Transactions Transaction { get; set; }
        public List<Transactions> TransactionList { get; set; }
        public Products Product { get; set; }
        public List<Products> ProductList { get; set; }
        public ProductType ProductType { get; set; }
        public List<ProductType> ProductTypeList { get; set; }
        public Category Category { get; set; }
        public List<Category> CategoryList { get; set; }
        public Employees Employees { get; set; }
        public List<Employees> EmployeesList { get; set; }
    }
}