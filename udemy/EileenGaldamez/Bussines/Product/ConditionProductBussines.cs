using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Product;
using Data; // Use entity
using Entity;

namespace Bussines.Product
{

    public partial class ConditionProduct
    {
        public int id { get; set; }
        [Display(Name = "Product Condition Name")]
        public string name { get; set; }
        [DisplayName("Detail")]
        [DataType(DataType.MultilineText)]
        public string detail { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> upDateDate { get; set; }
        public Nullable<System.DateTime> deleteDate { get; set; }
        [Display(Name = "Status")]
        public string state { get; set; }
    }

    public class ConditionProductBussines
    {


        #region Logic, Responces and Requests

        /// <summary>
        /// When You Need To Get Response
        /// </summary>
        public class GetConditionProductResponse
        {
            public Handler.ErrorObject Error { get; set; }
            public string Message { get; set; }
            public ConditionProduct ConditionProduct { get; set; }
            public List<ConditionProduct> ConditionProductList { get; set; }
        }

        /// <summary>
        /// When you Need To Specify Petition
        /// </summary>
        public class GetConditionProductRequest
        {
            public int ConditionProductID { get; set; }
        }
        #endregion

        #region Select Data
        public class Select
        {

            /// <summary>
            /// Return ConditionProduct List
            /// </summary>
            /// <returns>ConditionProduct List</returns>
            public static GetConditionProductResponse GetConditionProductList()
            {
                GetConditionProductResponse response = new GetConditionProductResponse();
                response.ConditionProductList = new List<ConditionProduct>();
                response.Error = new Handler.ErrorObject();

                try
                {
                    var GetCellarArea = ConditionProductData.Select.GetConditionProductList();
                    if (!GetCellarArea.Item1.Error)
                    {
                        foreach (var item in GetCellarArea.Item2)
                        {
                            response.ConditionProductList.Add(new ConditionProduct()
                            {
                                id = item.id,
                                name = item.name,
                                detail = item.detail,
                                createDate = item.createDate,
                                upDateDate = item.upDateDate,
                                deleteDate = item.deleteDate,
                                state = item.state
                            });
                        }
                    }
                    else
                    {
                        response.Error.InfoError(GetCellarArea.Item1);
                    }
                }
                catch (Exception ex)
                {
                    response.Error.InfoError(ex);
                }
                return response;
            }

            /// <summary>
            /// Return ConditionProduct Information
            /// </summary>
            /// <param name="request">ConditionProduct ID</param>
            /// <returns>ConditionProduct Information</returns>
            public static GetConditionProductResponse GetConditionProduct(GetConditionProductRequest request)
            {
                GetConditionProductResponse response = new GetConditionProductResponse();
                response.Error = new Handler.ErrorObject();
                response.ConditionProduct = new ConditionProduct();
                try
                {
                    var GetCellarArea = ConditionProductData.Select.GetConditionProduct(request.ConditionProductID);
                    if (!GetCellarArea.Item1.Error)
                    {
                        response.ConditionProduct = new ConditionProduct()
                        {
                            id = GetCellarArea.Item2.id,
                            name = GetCellarArea.Item2.name,
                            detail = GetCellarArea.Item2.detail,
                            createDate = GetCellarArea.Item2.createDate,
                            upDateDate = GetCellarArea.Item2.upDateDate,
                            deleteDate = GetCellarArea.Item2.deleteDate,
                            state = GetCellarArea.Item2.state
                        };

                    }
                    else
                    {
                        response.Error.InfoError(GetCellarArea.Item1);
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
            /// <param name="request">ConditionProduct Information</param>
            /// <returns>Affected Row Or Error If Exist</returns>
            public static GetConditionProductResponse ConditionProduct(GetConditionProductResponse request)
            {
                GetConditionProductResponse response = new GetConditionProductResponse();
                response.Error = new Handler.ErrorObject();

                try
                {
                    tblConditionProduct CellarArea = new tblConditionProduct()
                    {
                        id = request.ConditionProduct.id,
                        name = request.ConditionProduct.name,
                        detail = request.ConditionProduct.detail,
                        createDate = DateTime.Now,
                        upDateDate = null,
                        deleteDate = null,
                        state = "Active"
                    };

                    var result = ConditionProductData.Insert.ConditionProduct(CellarArea);
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

        #region Update Data
        public class Update
        {

            /// <summary>
            /// Return Affected Row Or Error If Exist
            /// </summary>
            /// <param name="request">ConditionProduct Information</param>
            /// <returns>Affected Row Or Error If Exist</returns>
            public static GetConditionProductResponse ConditionProduct(GetConditionProductResponse request)
            {

                GetConditionProductResponse response = new GetConditionProductResponse();
                response.Error = new Handler.ErrorObject();
                try
                {
                    tblConditionProduct CellarArea = new tblConditionProduct()
                    {
                        id = request.ConditionProduct.id,
                        name = request.ConditionProduct.name,
                        detail = request.ConditionProduct.detail,
                        createDate = request.ConditionProduct.createDate,
                        upDateDate = DateTime.Now,
                        deleteDate = null,
                        state = "Active"
                    };

                    var result = ConditionProductData.Update.ConditionProduct(CellarArea);
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
            /// <param name="ConditionProductID">Cellar Area ID</param>
            /// <param name="state">State</param>
            /// <returns>Affected Row Or Error If Exist</returns>
            public static GetConditionProductResponse ConditionProductDisable(int ConditionProductID, string state)
            {
                GetConditionProductResponse response = new GetConditionProductResponse();
                try
                {
                    var result = ConditionProductData.Delete.ConditionProductDisable(ConditionProductID, state);
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
