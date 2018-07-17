using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Transaction;
using Data; // Use entity
using Entity;

using System.ComponentModel.DataAnnotations;
using Bussines.Handler;
using System.ComponentModel;

namespace Bussines.Transaction
{

    public class Transactions
    {
        public int id { get; set; }
        [DisplayName("Amount")]
        public Nullable<int> amount { get; set; }
        [DisplayName("Supplier")]
        public Nullable<int> idProvide { get; set; }
        [DisplayName("Detail")]
        [DataType(DataType.MultilineText)]
        public string detail { get; set; }
        [Display(Name = "Condition Product")]
        public Nullable<int> idConditionProduct { get; set; }
        [DisplayName("Expiration Date")]
        public Nullable<System.DateTime> expeditionDate { get; set; }
        [DisplayName("Create Date")]
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> upDateDate { get; set; }
        public Nullable<System.DateTime> deleteDate { get; set; }
        [DisplayName("State")]
        public string state { get; set; }
    }


    class TransactionBussines
    {
        #region Logic, Responces and Requests

        /// <summary>
        /// When You Need To Get Response
        /// </summary>
        public class GetTransactionResponse
        {
            public Handler.ErrorObject Error { get; set; }
            public string Message { get; set; }
            public Transactions Transaction { get; set; }
        }

        /// <summary>
        /// When you Need To Specify Petition
        /// </summary>
        public class GetTransactionRequest
        {
            public int TransactionID { get; set; }
        }

        #endregion

        #region Insert Data
        public class Insert
        {

            /// <summary>
            /// Return Affected Row Or Error If Exist
            /// </summary>
            /// <param name="request">Transaction Information</param>
            /// <returns>Affected Row Or Error If Exist</returns>
            public static GetTransactionResponse Transaction(GetTransactionResponse request)
            {
                GetTransactionResponse response = new GetTransactionResponse();
                response.Error = new Handler.ErrorObject();

                try
                {
                    tblTransaction bussines = new tblTransaction()
                    {
                        id = request.Transaction.id,
                        amount = request.Transaction.amount,
                        detail = request.Transaction.detail,
                        idProvide = request.Transaction.idProvide,
                        createDate = request.Transaction.createDate,
                        idConditionProduct = request.Transaction.idConditionProduct,
                        expeditionDate = request.Transaction.expeditionDate,
                        upDateDate = null,
                        deleteDate = null,
                        state = "Active"
                    };

                    var result = TransactionData.Insert.Transaction(bussines);
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
            /// <param name="request">Transaction Information</param>
            /// <returns>Affected Row Or Error If Exist</returns>
            public static GetTransactionResponse Transaction(GetTransactionResponse request)
            {

                GetTransactionResponse response = new GetTransactionResponse();
                try
                {
                    tblTransaction bussines = new tblTransaction()
                    {
                        id = request.Transaction.id,
                        amount = request.Transaction.amount,
                        detail = request.Transaction.detail,
                        idProvide = request.Transaction.idProvide,
                        expeditionDate = request.Transaction.expeditionDate,
                        idConditionProduct = request.Transaction.idConditionProduct,
                        createDate = DateTime.Now,
                        upDateDate = null,
                        deleteDate = null,
                        state = "Active"
                    };

                    var result = TransactionData.Update.Transaction(bussines);
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
