using Data.Transaction;
using Data; // Use entity
using Entity;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Transaction
{


    public class TransactionTypeConditionDetail
    {
        public int id { get; set; }
        [Display(Name = "Amount")]
        public Nullable<int> amount { get; set; }
        [Display(Name = "Transaction Type")]
        public Nullable<int> idTransactionType { get; set; }
        [Display(Name = "Transaction")]
        public Nullable<int> idTransactionAnchor { get; set; }
        [Display(Name = "Product Condition")]
        public Nullable<int> idCondition { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> upDateDate { get; set; }
        public Nullable<System.DateTime> deleteDate { get; set; }
        [Display(Name = "State")]
        public string state { get; set; }
    }

    public class TransactionTypeConditionDetailBussines
    {


        #region Logic, Responces and Requests

        /// <summary>
        /// When You Need To Get Response
        /// </summary>
        public class GetTransactionTypeConditionDetailResponse
        {
            public Handler.ErrorObject Error { get; set; }
            public string Message { get; set; }
            public TransactionTypeConditionDetail TransactionTypeConditionDetail { get; set; }
            public List<TransactionTypeConditionDetail> TransactionTypeConditionDetailList { get; set; }
            public bool Exist { get; set; }

        }

        /// <summary>
        /// When you Need To Specify Petition
        /// </summary>
        public class GetTransactionTypeConditionDetailRequest
        {
            public int TransactionTypeConditionDetailID { get; set; }
            public int TransactionTypeID { get; set; }
            public int ConditionID { get; set; }
            public int TransactionID { get; set; }
            public int Amount { get; set; }
        }

        #endregion

        #region Select Data
        public class Select
        {

            public static GetTransactionTypeConditionDetailResponse GetTransactionTypeConditionDetailListView(GetTransactionTypeConditionDetailRequest request)
            {
                GetTransactionTypeConditionDetailResponse response = new GetTransactionTypeConditionDetailResponse();
                response.TransactionTypeConditionDetailList = new List<TransactionTypeConditionDetail>();
                response.Error = new Handler.ErrorObject();

                try
                {

                    var bussines = TransactionTypeConditionDetailData.Select.GetTransactionTypeConditionDetailListView(request.TransactionTypeID, request.TransactionID);


                    if (!bussines.Item1.Error)
                    {
                        foreach (var item in bussines.Item2)
                        {
                            response.TransactionTypeConditionDetailList.Add(new TransactionTypeConditionDetail()
                            {
                                id = item.id,
                                amount = item.amount,
                                idCondition = item.idCondition,
                                idTransactionAnchor = item.idTransactionAnchor,
                                idTransactionType = item.idTransactionType,
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



            public static GetTransactionTypeConditionDetailResponse GetTransactionTypeConditionDetailList(GetTransactionTypeConditionDetailRequest request)
            {
                GetTransactionTypeConditionDetailResponse response = new GetTransactionTypeConditionDetailResponse();
                response.TransactionTypeConditionDetailList = new List<TransactionTypeConditionDetail>();
                response.Error = new Handler.ErrorObject();

                try
                {
                    var bussines = TransactionTypeConditionDetailData.Select.GetTransactionTypeConditionDetailList(request.TransactionTypeID, request.TransactionID, request.ConditionID);
                    if (!bussines.Item1.Error)
                    {
                        foreach (var item in bussines.Item2)
                        {
                            response.TransactionTypeConditionDetailList.Add(new TransactionTypeConditionDetail()
                            {
                                id = item.id,
                                amount = item.amount,
                                idCondition = item.idCondition,
                                idTransactionAnchor = item.idTransactionAnchor,
                                idTransactionType = item.idTransactionType,
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

            public static GetTransactionTypeConditionDetailResponse GetTransactionTypeConditionDetail(GetTransactionTypeConditionDetailRequest request)
            {
                GetTransactionTypeConditionDetailResponse response = new GetTransactionTypeConditionDetailResponse();
                response.Error = new Handler.ErrorObject();
                response.TransactionTypeConditionDetail = new TransactionTypeConditionDetail();
                try
                {
                    var bussines = TransactionTypeConditionDetailData.Select.GetTransactionTypeConditionDetail(request.TransactionTypeID, request.TransactionID, request.ConditionID);
                    if (!bussines.Item1.Error)
                    {
                        response.TransactionTypeConditionDetail = new TransactionTypeConditionDetail()
                        {
                            id = bussines.Item2.id,
                            amount = bussines.Item2.amount,
                            idCondition = bussines.Item2.idCondition,
                            idTransactionAnchor = bussines.Item2.idTransactionAnchor,
                            idTransactionType = bussines.Item2.idTransactionType,
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

            public static GetTransactionTypeConditionDetailResponse GetTransactionTypeConditionDetailCount(GetTransactionTypeConditionDetailRequest request)
            {
                GetTransactionTypeConditionDetailResponse response = new GetTransactionTypeConditionDetailResponse();
                response.Error = new Handler.ErrorObject();
                response.Exist = false;
                try
                {
                    var bussines = TransactionTypeConditionDetailData.Select.GetTransactionTypeConditionDetailCount(request.TransactionTypeID, request.TransactionID, request.ConditionID);
                    if (!bussines.Item1.Error)
                    {
                        response.Exist = bussines.Item2;
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
            /// <param name="request">Employee Information</param>
            /// <returns>Affected Row Or Error If Exist</returns>
            public static GetTransactionTypeConditionDetailResponse TransactionTypeConditionDetail(GetTransactionTypeConditionDetailResponse request)
            {
                GetTransactionTypeConditionDetailResponse response = new GetTransactionTypeConditionDetailResponse();
                response.Error = new Handler.ErrorObject();

                try
                {
                    tblTransactionTypeConditionDetail bussines = new tblTransactionTypeConditionDetail()
                    {
                        id = request.TransactionTypeConditionDetail.id,
                        amount = request.TransactionTypeConditionDetail.amount,
                        idCondition = request.TransactionTypeConditionDetail.idCondition,
                        idTransactionType = request.TransactionTypeConditionDetail.idTransactionType,
                        idTransactionAnchor = request.TransactionTypeConditionDetail.idTransactionAnchor,
                        createDate = DateTime.Now,
                        upDateDate = null,
                        deleteDate = null,
                        state = "Active"
                    };

                    var result = TransactionTypeConditionDetailData.Insert.TransactionTypeConditionDetail(bussines);
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
            /// <param name="request">Employee Information</param>
            /// <returns>Affected Row Or Error If Exist</returns>
            public static GetTransactionTypeConditionDetailResponse TransactionTypeConditionDetail(GetTransactionTypeConditionDetailResponse request)
            {

                GetTransactionTypeConditionDetailResponse response = new GetTransactionTypeConditionDetailResponse();
                try
                {
                    tblTransactionTypeConditionDetail bussines = new tblTransactionTypeConditionDetail()
                    {
                        id = request.TransactionTypeConditionDetail.id,
                        idTransactionAnchor = request.TransactionTypeConditionDetail.idTransactionAnchor,
                        amount = request.TransactionTypeConditionDetail.amount,
                        idTransactionType = request.TransactionTypeConditionDetail.idTransactionType,
                        idCondition = request.TransactionTypeConditionDetail.idCondition,
                        createDate = request.TransactionTypeConditionDetail.createDate,
                        upDateDate = DateTime.Now,
                        deleteDate = null,
                        state = "Active"
                    };

                    var result = TransactionTypeConditionDetailData.Update.TransactionTypeConditionDetailAmount(bussines);
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
