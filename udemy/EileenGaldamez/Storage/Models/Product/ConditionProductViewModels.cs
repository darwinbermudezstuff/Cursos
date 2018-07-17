using Bussines.Handler;
using Bussines.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Storage.Models.Product
{
    public class ConditionProductViewModels
    {
        public int ID { get; set; }
        public ErrorObject Error { get; set; }
        public ConditionProduct ConditionProduct { get; set; }
        public List<ConditionProduct> ConditionProductList { get; set; }
    }
}