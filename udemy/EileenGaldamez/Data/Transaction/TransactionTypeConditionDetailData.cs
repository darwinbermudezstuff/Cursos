using Entity; // Use entity
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Transaction
{
    public class TransactionTypeConditionDetailData
    {
        #region Property
        private static int result = 0;
        private static string Message = "";
        private static ErrorObject erros;
        #endregion

        #region Select Data
        public class Select
        {

            /// <summary>
            /// Return All Transaction Condition Detail By Specific TransactionType ID and TransactionAnchorID
            /// </summary>
            /// <param name="TransactionTypeID">TransactionTypeID</param>
            /// <param name="TransactionAnchorID">TransactionAnchorID</param>
            /// <returns>All Transaction Condition Detail</returns>
            public static Tuple<ErrorObject, List<tblTransactionTypeConditionDetail>> GetTransactionTypeConditionDetailListView(int TransactionTypeID, int TransactionAnchorID)
            {
                List<tblTransactionTypeConditionDetail> data = new List<tblTransactionTypeConditionDetail>();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = db.tblTransactionTypeConditionDetail.Where(T => T.idTransactionType == TransactionTypeID && T.idTransactionAnchor == TransactionAnchorID).ToList();
                    };
                    return new Tuple<ErrorObject, List<tblTransactionTypeConditionDetail>>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, List<tblTransactionTypeConditionDetail>>(erros, data);
                }

            }

            /// <summary>
            /// Return All Transaction Condition Detail By Specific TransactionType ID and TransactionAnchorID
            /// </summary>
            /// <param name="TransactionTypeID">TransactionType ID</param>
            /// <param name="TransactionAnchorID">TransactionAnchor ID</param>
            /// <param name="ConditionID">Condition ID</param>
            /// <returns>All Transaction Condition Detail</returns>
            public static Tuple<ErrorObject, List<tblTransactionTypeConditionDetail>> GetTransactionTypeConditionDetailList(int TransactionTypeID, int TransactionAnchorID, int ConditionID)
            {
                List<tblTransactionTypeConditionDetail> data = new List<tblTransactionTypeConditionDetail>();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = db.tblTransactionTypeConditionDetail.Where( T => T.idTransactionType == TransactionTypeID && T.idTransactionAnchor == TransactionAnchorID && T.idCondition == ConditionID).ToList();
                    };
                    return new Tuple<ErrorObject, List<tblTransactionTypeConditionDetail>>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, List<tblTransactionTypeConditionDetail>>(erros, data);
                }

            }

            /// <summary>
            /// Return All Transaction Condition Detail By Specific TransactionType ID and TransactionAnchorID
            /// </summary>
            /// <param name="TransactionTypeID">TransactionType ID</param>
            /// <param name="TransactionAnchorID">TransactionAnchor ID</param>
            /// <param name="ConditionID">Condition ID</param>
            /// <returns>All Transaction Condition Detail</returns>
            public static Tuple<ErrorObject, tblTransactionTypeConditionDetail> GetTransactionTypeConditionDetail(int TransactionTypeID, int TransactionAnchorID, int ConditionID)
            {
                tblTransactionTypeConditionDetail data = new tblTransactionTypeConditionDetail();
                erros = new ErrorObject();

                try
                {
                    //                    using (HSCMEntities db = new HSCMEntities())
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = db.tblTransactionTypeConditionDetail.Where(t => t.idTransactionType == TransactionTypeID && t.idTransactionAnchor == TransactionAnchorID && t.idCondition == ConditionID).First();
                    }
                    erros.Error = false;
                    return new Tuple<ErrorObject, tblTransactionTypeConditionDetail>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, tblTransactionTypeConditionDetail>(erros, data);
                }
            }

            /// <summary>
            /// Return All Transaction Condition Detail By Specific TransactionType ID and TransactionAnchorID
            /// </summary>
            /// <param name="TransactionTypeID">TransactionType ID</param>
            /// <param name="TransactionAnchorID">TransactionAnchor ID</param>
            /// <param name="ConditionID">Condition ID</param>
            /// <returns>All Transaction Condition Detail</returns>
            public static Tuple<ErrorObject, bool> GetTransactionTypeConditionDetailCount(int TransactionTypeID, int TransactionAnchorID, int ConditionID)
            {
                erros = new ErrorObject();

                try
                {
                    //                    using (HSCMEntities db = new HSCMEntities())
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        var data = db.tblTransactionTypeConditionDetail.Where(t => t.idTransactionType == TransactionTypeID && t.idTransactionAnchor == TransactionAnchorID && t.idCondition == ConditionID).Count();
                        erros.Error = false;

                        if (data > 0)
                        {
                            return new Tuple<ErrorObject, bool>(erros.IfError(false), true);
                        }
                        else
                        {
                            return new Tuple<ErrorObject, bool>(erros.IfError(false), false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, bool>(erros, false);
                }
            }


        }
        #endregion

        #region Insert Data
        public class Insert
        {
            /// <summary>
            /// Insert TransactionType Information
            /// </summary>
            /// <param name="data">Transaction Information</param>
            /// <returns>Number Affected Row</returns>
            public static Tuple<ErrorObject, int> TransactionTypeConditionDetail(tblTransactionTypeConditionDetail data)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        int propertyFind = db.tblTransactionTypeConditionDetail.Count();
                        if (propertyFind > 0)
                        {
                            data.id = db.tblTransactionTypeConditionDetail.Max(s => s.id);
                        }
                        else
                        {
                            data.id = 1;
                        }
                        db.tblTransactionTypeConditionDetail.Add(data);
                        result = db.SaveChanges();
                        Message = "Affected Row: " + result.ToString();
                        if (result > 0)
                        {
                            return new Tuple<ErrorObject, int>(erros.IfError(false), data.id);
                        }
                        else
                        {
                            return new Tuple<ErrorObject, int>(erros.IfError(false), result);
                        }

                    }
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, int>(erros, 0);
                }

            }

        }
        #endregion 

        #region Update Data
        public class Update
        {
            /// <summary>
            /// Update Transaction Information
            /// </summary>
            /// <param name="data">Transaction Information</param>
            /// <returns>Number Affected Row</returns>
            public static Tuple<ErrorObject, string> TransactionTypeConditionDetail(tblTransactionTypeConditionDetail data)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        var row = db.tblTransactionTypeConditionDetail.Single(p => p.id == data.id);
                        row.amount = data.amount;
                        row.upDateDate = data.upDateDate;
                        result = db.SaveChanges();
                        Message = "Affected Row: " + result.ToString();

                        return new Tuple<ErrorObject, string>(erros.IfError(false), Message);
                    }
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, string>(erros, String.Empty);
                }
            }

            /// <summary>
            /// Update Transaction Information
            /// </summary>
            /// <param name="data">Transaction Information</param>
            /// <returns>Number Affected Row</returns>
            public static Tuple<ErrorObject, string> TransactionTypeConditionDetailAmount(tblTransactionTypeConditionDetail data)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        var row = db.tblTransactionTypeConditionDetail.Single(p => p.idCondition == data.idCondition && p.idTransactionAnchor == data.idTransactionAnchor && p.idTransactionType == data.idTransactionType);
                        row.amount = data.amount;
                        row.upDateDate = data.upDateDate;
                        result = db.SaveChanges();
                        Message = "Affected Row: " + result.ToString();

                        return new Tuple<ErrorObject, string>(erros.IfError(false), Message);
                    }
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, string>(erros, String.Empty);
                }
            }
        }



        #endregion
    }
}
