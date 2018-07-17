using Bussines.Assignment;
using Bussines.Transaction;
using Data.Download;
using Data; // Use entity
using Entity;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Download
{

    public partial class DownloadAssignment
    {
        public int id { get; set; }
        [DisplayName("Amoun")]
        public Nullable<int> amount { get; set; }
        [DisplayName("Product")]
        public Nullable<int> idProduct { get; set; }
        [DisplayName("Employee")]
        public Nullable<int> idEmployee { get; set; }
        [DisplayName("Area")]
        public Nullable<int> idCategory { get; set; }
        [DisplayName("Detail")]
        [DataType(DataType.MultilineText)]
        public string detail { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> upDateDate { get; set; }
        public Nullable<System.DateTime> deleteDate { get; set; }
        [DisplayName("State")]
        public string state { get; set; }
    }

    public class DownloadAssignmentBussines
    {

        #region Logic, Responces and Requests

        /// <summary>
        /// When You Need To Get Response
        /// </summary>
        public class GetDownloadResponse
        {
            public Handler.ErrorObject Error { get; set; }
            public string Message { get; set; }
            public DownloadAssignment Download { get; set; }
            public List<DownloadAssignment> DownloadList { get; set; }
            public Transactions transaction { get; set; }
        }

        /// <summary>
        /// When you Need To Specify Petition
        /// </summary>
        public class GetDownloadRequest
        {
            public int DownloadID { get; set; }
            public int CellarArea { get; set; }
            public int CategoryID { get; set; }
            public int ProductID { get; set; }
            public int TransactionTypeID { get; set; }
            public int amount { get; set; }
        }

        #endregion

        #region Select Data
        public class Select
        {

            public static GetDownloadResponse GetDownloadList(GetDownloadRequest request)
            {
                GetDownloadResponse response = new GetDownloadResponse();
                response.DownloadList = new List<DownloadAssignment>();
                response.Error = new Handler.ErrorObject();

                try
                {
                    var bussines = DownloadAssignmentData.Select.GetDownloadByCategoryID(request.CategoryID);
                    if (!bussines.Item1.Error)
                    {
                        foreach (var item in bussines.Item2)
                        {
                            response.DownloadList.Add(new DownloadAssignment()
                            {
                                id = item.id,
                                amount = item.amount,
                                detail = item.detail,
                                idCategory = item.idCategory,
                                idEmployee = item.idEmployee,
                                idProduct = item.idProduct,
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

            public static GetDownloadResponse GetDownloadByProductID(GetDownloadRequest request)
            {
                GetDownloadResponse response = new GetDownloadResponse();
                response.DownloadList = new List<DownloadAssignment>();
                response.Error = new Handler.ErrorObject();

                try
                {
                    var bussines = DownloadAssignmentData.Select.GetDownloadByProductID(request.ProductID);
                    if (!bussines.Item1.Error)
                    {
                        foreach (var item in bussines.Item2)
                        {
                            response.DownloadList.Add(new DownloadAssignment()
                            {
                                id = item.id,
                                amount = item.amount,
                                detail = item.detail,
                                idCategory = item.idCategory,
                                idEmployee = item.idEmployee,
                                idProduct = item.idProduct,
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

            public static GetDownloadResponse GetDownload(GetDownloadRequest request)
            {
                GetDownloadResponse response = new GetDownloadResponse();
                response.Error = new Handler.ErrorObject();
                response.Download = new DownloadAssignment();
                try
                {
                    var bussines = DownloadAssignmentData.Select.GetDownload(request.DownloadID);
                    if (!bussines.Item1.Error)
                    {
                        response.Download = new DownloadAssignment()
                        {
                            id = bussines.Item2.id,
                            amount = bussines.Item2.amount,
                            detail = bussines.Item2.detail,
                            idCategory = bussines.Item2.idCategory,
                            idEmployee = bussines.Item2.idEmployee,
                            idProduct = bussines.Item2.idProduct,
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
        }
        #endregion

        #region Insert Data
        public class Insert
        {
            public static GetDownloadResponse Download(GetDownloadResponse AssignmentInformation, GetDownloadRequest request)
            {
                GetDownloadResponse response = new GetDownloadResponse();
                response.Error = new Handler.ErrorObject();
                try
                {
                    request.DownloadID = Convert.ToInt16(Downloads(AssignmentInformation).Message);
                    var result = Transaction.TransactionConfigurateBussines.Insert.TransactionConfigurate(request.DownloadID, request.TransactionTypeID, AssignmentInformation.transaction);


                    #region Assignment Update
                    AssignmentBussines.GetAssignmentRequest req = new AssignmentBussines.GetAssignmentRequest()
                    {
                        ProductID = (int)AssignmentInformation.Download.idProduct,
                        CategoryID = (int)request.CategoryID
                    };
                    var data = AssignmentBussines.Select.GetAssignmentToProductIDAndCategory(req).Assignment;
                    int newAmountCellar = (int)data.amount - (int)AssignmentInformation.transaction.amount;

                    AssignmentBussines.GetAssignmentRequest requestCellar = new AssignmentBussines.GetAssignmentRequest()
                    {
                        AssignmentID = data.id,
                        amount = newAmountCellar
                    };
                    AssignmentBussines.Update.AssignmentAmount(requestCellar);
                    #endregion

                    #region Condition Update
                    TransactionConfigurateBussines.Insert.ConditionBackUpdate(2, data.id, (int)AssignmentInformation.transaction.idConditionProduct, (int)AssignmentInformation.transaction.amount);
                    #endregion



                    response.Message = result.Message.ToString();
                }
                catch (Exception ex)
                {
                    response.Error.InfoError(ex);
                }
                return response;
            }
            private static GetDownloadResponse Downloads(GetDownloadResponse request)
            {
                GetDownloadResponse response = new GetDownloadResponse();
                response.Error = new Handler.ErrorObject();

                try
                {
                    tblDownloadAssignment bussines = new tblDownloadAssignment()
                    {
                        id = request.Download.id,
                        amount = request.Download.amount,
                        idProduct = request.Download.idProduct,
                        idEmployee = request.Download.idEmployee,
                        detail = request.Download.detail,
                        idCategory = request.Download.idCategory,
                        createDate = request.Download.createDate,
                        upDateDate = null,
                        deleteDate = null,
                        state = "Active"
                    };

                    var result = DownloadAssignmentData.Insert.Download(bussines);
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
            public static GetDownloadResponse Download(GetDownloadResponse AssignmentInformation, GetDownloadRequest request)
            {
                GetDownloadResponse response = new GetDownloadResponse();
                response.Error = new Handler.ErrorObject();
                try
                {

                    DownloadAmount(request);

                    var result = Transaction.TransactionConfigurateBussines.Insert.TransactionConfigurate(request.DownloadID, request.TransactionTypeID, AssignmentInformation.transaction);

                    #region Assignment Update
                    AssignmentBussines.GetAssignmentRequest req = new AssignmentBussines.GetAssignmentRequest()
                    {
                        ProductID = (int)AssignmentInformation.Download.idProduct,
                        CategoryID = (int)request.CategoryID
                    };
                    var data = AssignmentBussines.Select.GetAssignmentToProductIDAndCategory(req).Assignment;
                    int newAmountCellar = (int)data.amount - (int)AssignmentInformation.transaction.amount;

                    AssignmentBussines.GetAssignmentRequest requestCellar = new AssignmentBussines.GetAssignmentRequest()
                    {
                        AssignmentID = data.id,
                        amount = newAmountCellar
                    };
                    AssignmentBussines.Update.AssignmentAmount(requestCellar);
                    #endregion

                    #region Condition Update
                    TransactionConfigurateBussines.Insert.ConditionBackUpdate(2, data.id, (int)AssignmentInformation.transaction.idConditionProduct, (int)AssignmentInformation.transaction.amount);
                    #endregion

                    response.Message = result.Message.ToString();
                }
                catch (Exception ex)
                {
                    response.Error.InfoError(ex);
                }
                return response;
            }

            public static GetDownloadResponse Downloads(GetDownloadResponse request)
            {
                GetDownloadResponse response = new GetDownloadResponse();
                try
                {
                    tblDownloadAssignment bussines = new tblDownloadAssignment()
                    {
                        id = request.Download.id,
                        amount = request.Download.amount,
                        detail = request.Download.detail,
                        idCategory = request.Download.idCategory,
                        idEmployee = request.Download.idEmployee,
                        idProduct = request.Download.idProduct,
                        createDate = request.Download.createDate,
                        upDateDate = request.Download.upDateDate,
                        deleteDate = request.Download.deleteDate,
                        state = request.Download.state
                    };

                    var result = DownloadAssignmentData.Update.Download(bussines);
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

            public static GetDownloadResponse DownloadAmount(GetDownloadRequest request)
            {
                GetDownloadResponse response = new GetDownloadResponse();
                response.Error = new Handler.ErrorObject();
                try
                {
                    var result = DownloadAssignmentData.Update.DownloadAmount(request.DownloadID, request.amount);

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
