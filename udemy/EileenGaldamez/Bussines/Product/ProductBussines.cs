using Data.Product;
using Data; // Use entity
using Entity;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Product
{

    public class Products
    {
        public int id { get; set; }
        [Display(Name = "Code")]
        public string code { get; set; }
        [Display(Name = "Product Name")]
        public string name { get; set; }
        [Display(Name = "Unit")]
        public string unit { get; set; }
        [Display(Name = "Product Type")]
        public Nullable<int> idProductType { get; set; }
        [DisplayName("Detail")]
        [DataType(DataType.MultilineText)]
        public string detail { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> upDateDate { get; set; }
        public Nullable<System.DateTime> deleteDate { get; set; }
        [Display(Name = "State")]
        public string state { get; set; }
    }

    public class ProductBussines
    {
        #region Logic, Responces and Requests

        /// <summary>
        /// When You Need To Get Response
        /// </summary>
        public class GetProductResponse
        {
            public Handler.ErrorObject Error { get; set; }
            public string Message { get; set; }
            public Products Product { get; set; }
            public List<Products> ProductList { get; set; }
        }

        /// <summary>
        /// When you Need To Specify Petition
        /// </summary>
        public class GetProductRequest
        {
            public int ProductID { get; set; }
            public int CategoryID { get; set; }
            public int CellarAreaID { get; set; }
        }

        /// <summary>
        /// When you Need To Specify Petition
        /// </summary>
        public class GetProductandTransactionTypeRequest
        {
            public int ProductID { get; set; }
            public int CategoryID { get; set; }
            public int CellarAreaID { get; set; }
            public int TransactionType { get; set; }
        }

        #endregion

        #region Select Data
        public class Select
        {

            /// <summary>
            /// Return Product List OF Assignment To Assignment Type and AnchorAssignment
            /// </summary>
            /// <param name="request">Assignment Type and AnchorAssignment</param>
            /// <returns>Product List</returns>
            public static GetProductResponse GetProductsOfAssignment(GetProductRequest request)
            {
                GetProductResponse response = new GetProductResponse();
                response.ProductList = new List<Products>();
                response.Error = new Handler.ErrorObject();

                try
                {
                    var bussines = ProductData.Select.GetProductsOfAssignment(request.CategoryID);
                    if (!bussines.Item1.Error)
                    {
                        foreach (var item in bussines.Item2)
                        {
                            response.ProductList.Add(new Products()
                            {
                                id = item.id,
                                code = item.code,
                                name = item.name,
                                unit = item.unit,
                                detail = item.detail,
                                idProductType = item.idProductType,
                                createDate = item.createDate,
                                upDateDate = item.upDateDate,
                                deleteDate = item.deleteDate,
                                state = item.state
                            });
                        }
                    }
                    else
                    {
                        response.Error.InfoError(bussines.Item1);
                    }
                }
                catch (Exception ex)
                {
                    response.Error.InfoError(ex);
                }
                return response;
            }

            /// <summary>
            /// Return Product List 
            /// </summary>
            /// <param name="request">Product ID</param>
            /// <returns>Product List</returns>
            public static GetProductResponse GetProduct()
            {
                GetProductResponse response = new GetProductResponse();
                response.ProductList = new List<Products>();
                response.Error = new Handler.ErrorObject();

                try
                {
                    var bussines = ProductData.Select.GetProduct();
                    if (!bussines.Item1.Error)
                    {
                        foreach (var item in bussines.Item2)
                        {
                            response.ProductList.Add(new Products()
                            {
                                id = item.id,
                                code = item.code,
                                name = item.name,
                                unit = item.unit,
                                detail = item.detail,
                                idProductType = item.idProductType,
                                createDate = item.createDate,
                                upDateDate = item.upDateDate,
                                deleteDate = item.deleteDate,
                                state = item.state
                            });
                        }
                    }
                    else
                    {
                        response.Error.InfoError(bussines.Item1);
                    }
                }
                catch (Exception ex)
                {
                    response.Error.InfoError(ex);
                }
                return response;
            }

            /// <summary>
            /// Return Product Information
            /// </summary>
            /// <param name="request">Product ID</param>
            /// <returns>Product Information</returns>
            public static GetProductResponse GetProduct(GetProductRequest request)
            {
                GetProductResponse response = new GetProductResponse();
                response.Error = new Handler.ErrorObject();
                response.Product = new Products();
                try
                {
                    var bussines = ProductData.Select.GetProduct(request.ProductID);
                    if (!bussines.Item1.Error)
                    {
                        response.Product = new Products()
                        {
                            id = bussines.Item2.id,
                            code = bussines.Item2.code,
                            name = bussines.Item2.name,
                            unit = bussines.Item2.unit,
                            detail = bussines.Item2.detail,
                            idProductType = bussines.Item2.idProductType,
                            createDate = bussines.Item2.createDate,
                            upDateDate = bussines.Item2.upDateDate,
                            deleteDate = bussines.Item2.deleteDate,
                            state = bussines.Item2.state
                        };

                    }
                    else
                    {
                        response.Error.InfoError(bussines.Item1);
                    }
                }
                catch (Exception ex)
                {
                    response.Error.InfoError(ex);
                }

                return response;
            }



            public static GetProductResponse GetProductToCellarArea(GetProductRequest request)
            {
                GetProductResponse response = new GetProductResponse();
                response.Error = new Handler.ErrorObject();
                response.ProductList = new List<Products>();

                try
                {
                    var bussines = ProductData.Select.GetProductToCellarArea(request.CellarAreaID);
                    if (!bussines.Item1.Error)
                    {
                        foreach (var item in bussines.Item2)
                        {
                            response.ProductList.Add(new Products()
                            {
                                id = item.id,
                                name = item.name
                            });
                        }
                    }
                    else
                    {
                        response.Error.InfoError(bussines.Item1);
                    }
                }
                catch (Exception ex)
                {
                    response.Error.InfoError(ex);
                }

                return response;
            }


            public static GetProductResponse GetProductByAssignmentType(GetProductRequest request)
            {
                GetProductResponse response = new GetProductResponse();
                response.ProductList = new List<Products>();
                response.Error = new Handler.ErrorObject();

                try
                {
                    var bussines = ProductData.Select.GetProductByAssignmentType(request.CellarAreaID);
                    if (!bussines.Item1.Error)
                    {
                        foreach (var item in bussines.Item2)
                        {
                            response.ProductList.Add(new Products()
                            {
                                id = item.id,
                                code = item.code,
                                name = item.name,
                                unit = item.unit,
                                detail = item.detail,
                                idProductType = item.idProductType,
                                createDate = item.createDate,
                                upDateDate = item.upDateDate,
                                deleteDate = item.deleteDate,
                                state = item.state
                            });
                        }
                    }
                    else
                    {
                        response.Error.InfoError(bussines.Item1);
                    }
                }
                catch (Exception ex)
                {
                    response.Error.InfoError(ex);
                }
                return response;
            }


            public static GetProductResponse GetProductListByDepartmentAndCategory(GetProductRequest request, int FatherCateogryID = 0)
            {
                GetProductResponse response = new GetProductResponse();
                response.ProductList = new List<Products>();
                response.Error = new Handler.ErrorObject();

                try
                {
                    var bussines = ProductData.Select.GetProductListByDepartmentAndCategory(request.CellarAreaID, request.CategoryID, FatherCateogryID) ;

                       // ProductData.Select.GetProductByAssignmentTypeAndTransactionType(request.CategoryID, 0, 0));


                    if (!bussines.Item1.Error)
                    {
                        foreach (var item in bussines.Item2)
                        {
                            response.ProductList.Add(new Products()
                            {
                                id = item.id,
                                code = item.code,
                                name = item.name,
                                unit = item.unit,
                                detail = item.detail,
                                idProductType = item.idProductType,
                                createDate = item.createDate,
                                upDateDate = item.upDateDate,
                                deleteDate = item.deleteDate,
                                state = item.state
                            });
                        }
                    }
                    else
                    {
                        response.Error.InfoError(bussines.Item1);
                    }
                }
                catch (Exception ex)
                {
                    response.Error.InfoError(ex);
                }
                return response;
            }


            public static GetProductResponse GetProductByAssignmentTypeAndTransactionType(GetProductandTransactionTypeRequest request)
            {
                GetProductResponse response = new GetProductResponse();
                response.ProductList = new List<Products>();
                response.Error = new Handler.ErrorObject();

                try
                {
                    var bussines = ProductData.Select.GetProductByAssignmentTypeAndTransactionType(request.CategoryID ,request.CellarAreaID);
                    if (!bussines.Item1.Error)
                    {
                        foreach (var item in bussines.Item2)
                        {
                            response.ProductList.Add(new Products()
                            {
                                id = item.id,
                                code = item.code,
                                name = item.name,
                                unit = item.unit,
                                detail = item.detail,
                                idProductType = item.idProductType,
                                createDate = item.createDate,
                                upDateDate = item.upDateDate,
                                deleteDate = item.deleteDate,
                                state = item.state
                            });
                        }
                    }
                    else
                    {
                        response.Error.InfoError(bussines.Item1);
                    }
                }
                catch (Exception ex)
                {
                    response.Error.InfoError(ex);
                }
                return response;
            }


        }
        #endregion

        #region Insert Data
        public class Insert
        {

            /// <summary>
            /// Return Affected Row Or Error If Exist
            /// </summary>
            /// <param name="request">Producto Information</param>
            /// <returns>Affected Row Or Error If Exist</returns>
            public static GetProductResponse Product(GetProductResponse request)
            {
                GetProductResponse response = new GetProductResponse();
                response.Error = new Handler.ErrorObject();

                try
                {
                    tblProduct bussines = new tblProduct()
                    {
                        id = request.Product.id,
                        code = request.Product.code,
                        name = request.Product.name,
                        unit = request.Product.unit,
                        detail = request.Product.detail,
                        idProductType = request.Product.idProductType,
                        createDate = DateTime.Now,
                        upDateDate = null,
                        deleteDate = null,
                        state = "Active"
                    };

                    var result = ProductData.Insert.product(bussines);
                    if (result.Item1.Error)
                    {
                        response.Error.InfoError(result.Item1);
                    }
                    else
                    {
                        response.Message = result.Item2.ToString();
                    }
                }
                catch (Exception ex)
                {
                    response.Error.InfoError(ex);
                }
                return response;
            }
        }
        #endregion

        #region Update Data
        public class Update
        {

            /// <summary>
            /// Return Affected Row Or Error If Exist
            /// </summary>
            /// <param name="request">Producto Information</param>
            /// <returns>Affected Row Or Error If Exist</returns>
            public static GetProductResponse Product(GetProductResponse request)
            {

                GetProductResponse response = new GetProductResponse();
                try
                {
                    tblProduct bussines = new tblProduct()
                    {
                        id = request.Product.id,
                        code = request.Product.code,
                        name = request.Product.name,
                        unit = request.Product.unit,
                        detail = request.Product.detail,
                        idProductType = request.Product.idProductType,
                        createDate = DateTime.Now,
                        upDateDate = null,
                        deleteDate = null,
                        state = "Active"
                    };

                    var result = ProductData.Update.product(bussines);
                    if (result.Item1.Error)
                    {
                        response.Error.InfoError(result.Item1);
                    }
                    else
                    {
                        response.Message = result.Item2;
                    }
                }
                catch (Exception ex)
                {
                    response.Error.InfoError(ex);
                }
                return response;
            }

        }
        #endregion

        #region Delete or Disable Data
        public class Delete
        {

            /// <summary>
            /// Return Affected Row Or Error If Exist
            /// </summary>
            /// <param name="ProductID">ProductID</param>
            /// <param name="state">State</param>
            /// <returns>Affected Row Or Error If Exist</returns>
            public static GetProductResponse ProductDisable(int ProductID, string state)
            {
                GetProductResponse response = new GetProductResponse();
                try
                {
                    var result = ProductData.Delete.productDisable(ProductID, state);
                    if (result.Item1.Error)
                    {
                        response.Error.InfoError(result.Item1);
                    }
                    else
                    {
                        response.Message = result.Item2;
                    }
                }
                catch (Exception ex)
                {
                    response.Error.InfoError(ex);
                }
                return response;
            }
        }
        #endregion

    }
}
