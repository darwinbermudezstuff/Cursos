using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bussines.Handler;
using Bussines.Cellar;
using Bussines.Product;
using Bussines;
using Bussines.Transaction;
using Bussines.Employee;
using Bussines.Assignment;

namespace Storage.Models.Assignment
{
    public class AssignmentViewModels
    {
        public int ID { get; set; }
        public ErrorObject Error { get; set; }
        public int total { get; set; }
        public int ActualAmountByAssignment { get; set; }
        public string step { get; set; }
        public string GetCategoryFaherName { get; set; }
        public string GetCategoryName { get; set; }

        public string CategoryIDFhater { get; set; }
        public string CategoryID { get; set; }
        public string CellarArea { get; set; }

        public List<ConditionProduct> ConditionProductList { get; set; }
        public Assignments Assignment { get; set; }
        public List<Assignments> AssignmentList { get; set; }
        public Transactions Transaction { get; set; }
        public List<Transactions> TransactionList { get; set; }
        public Provider Provider { get; set; }
        public List<Provider> ProviderList { get; set; }
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