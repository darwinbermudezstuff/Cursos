using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entity; // Use entity

namespace Data.Cellar
{
    public class CellarData
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
            /// Return All Cellar
            /// </summary>
            /// <returns>All Cellar Or null If Exist Error</returns>
            public static Tuple<ErrorObject, List<tblCellar>> GetCellar()
            {
                List<tblCellar> data = new List<tblCellar>();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = db.tblCellar.ToList();
                    };
                    return new Tuple<ErrorObject, List<tblCellar>>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, List<tblCellar>>(erros, data);
                }
            }

            /// <summary>
            /// Return All Cellar By Specific Cellar Area ID
            /// </summary>
            /// <param name="CellarAreaID"></param>
            /// <returns>All Cellar</returns>
            public static Tuple<ErrorObject, List<tblCellar>> GetCellarToArea(int CellarAreaID)
            {
                List<tblCellar> data = new List<tblCellar>();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = db.tblCellar.Where(m => m.idcellarArea == CellarAreaID).ToList();
                    };
                    return new Tuple<ErrorObject, List<tblCellar>>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, List<tblCellar>>(erros, data);
                }
            }

            /// <summary>
            /// Return Cellar 
            /// </summary>
            /// <returns>All Cellar </returns>
            public static Tuple<ErrorObject, List<tblCellar>> GetCellarHome()
            {
                List<tblCellar> data = new List<tblCellar>();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = db.tblCellar.Where(c => c.amount <= c.min).ToList();
                    };
                    return new Tuple<ErrorObject, List<tblCellar>>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, List<tblCellar>>(erros, data);
                }
            }

            /// <summary>
            /// Return Cellar Information
            /// </summary>
            /// <param name="id">Cellar ID</param>
            /// <returns>Cellar Information</returns>
            public static Tuple<ErrorObject, tblCellar> GetCellar(int id)
            {
                tblCellar data = new tblCellar();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = db.tblCellar.Find(id);
                    };
                    return new Tuple<ErrorObject, tblCellar>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, tblCellar>(erros, data);
                }
            }


            /// <summary>
            /// Return All Cellar To Specific ID
            /// </summary>
            /// <param name="ProductID">ProductID</param>
            /// <returns>All Cellar</returns>
            public static Tuple<ErrorObject, List<tblCellar>> GetCellarByProductID(int ProductID)
            {
                List<tblCellar> data = new List<tblCellar>();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = db.tblCellar.Where(c => c.idProduct == ProductID).ToList();
                    };
                    return new Tuple<ErrorObject, List<tblCellar>>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, List<tblCellar>>(erros, data);
                }
            }

            /// <summary>
            /// Return Amount To ProductID and CellarID From Cellar
            /// </summary>
            /// <param name="ProductID">Product ID</param>
            /// <param name="CellarArea">CellarAreaID</param>
            /// <returns>Amount from Cellar</returns>
            public static Tuple<ErrorObject, tblCellar> GetCellarByProductIDAndCellarArea(int ProductID, int CellarAreaID, int conditionID, int transactionTypeID)
            {
                tblCellar Amount = new tblCellar();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        Amount = (
                            from TC in db.tblTransactionConfigurate
                            join C in db.tblCellar on TC.idAnchorTransaction equals C.id
                            join T in db.tblTransaction on TC.idTransaction equals T.id
                            where C.idProduct == ProductID && C.idcellarArea == CellarAreaID && TC.idTransactionType == transactionTypeID && T.idConditionProduct == conditionID
                            select C ).First();

                        return new Tuple<ErrorObject, tblCellar>(erros.IfError(false), Amount);
                    }
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, tblCellar>(erros, Amount);
                }
            }

            /// <summary>
            /// Return ID To Product ID and Cellar Area ID
            /// </summary>
            /// <param name="ProductID"></param>
            /// <param name="CellarArea"></param>
            /// <returns></returns>
            public static Tuple<ErrorObject, tblCellar> GetCellarIDByProductIDAndCellarArea(int ProductID, int CellarAreaID)
            {
                tblCellar data = new tblCellar();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = db.tblCellar.Single(C => C.idProduct == ProductID && C.idcellarArea == CellarAreaID);
                        return new Tuple<ErrorObject, tblCellar>(erros.IfError(false), data);
                    }
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, tblCellar>(erros, data);
                }
            }
        }
        #endregion

        #region Insert Data
        public class Insert
        {
            /// <summary>
            /// Insert Cellar Information
            /// </summary>
            /// <param name="data">Cellar Information</param>
            /// <returns>Cellar ID</returns>
            public static Tuple<ErrorObject, int> Cellar(tblCellar data)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())

                    {
                        int propertyFind = db.tblCellar.Count();
                        if (propertyFind > 0)
                        {
                            data.id = db.tblCellar.Max(s => s.id);
                        }
                        else
                        {
                            data.id = 1;
                        }
                        db.tblCellar.Add(data);
                        result = db.SaveChanges();
                        Message = "Affected Row: " + result.ToString();
                        return new Tuple<ErrorObject, int>(erros.IfError(false), data.id);
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
            /// Update Cellar Information
            /// </summary>
            /// <param name="data">Cellar Information</param>
            /// <returns>Number Affected Row</returns>
            public static Tuple<ErrorObject, string> Cellar(tblCellar data)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())

                    {
                        var row = db.tblCellar.Single(p => p.id == data.id);
                        row.amount = data.amount;
                        row.idProduct = data.idProduct;
                        row.idcellarArea = data.idcellarArea;
                        row.min = data.min;
                        row.max = data.max;
                        row.detail = data.detail;
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
            /// Update Specific Infomation to Cellar how Min, Max and detail
            /// </summary>
            /// <param name="data"></param>
            /// <returns>Number Affected Row</returns>
            public static Tuple<ErrorObject, string> CellarUpdate(tblCellar data)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())

                    {
                        var row = db.tblCellar.Single(p => p.id == data.id);
                        row.idcellarArea = data.idcellarArea;
                        row.min = data.min;
                        row.max = data.max;
                        row.detail = data.detail;
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
            /// Update Cellar Amount TO Specific Cellar ID
            /// </summary>
            /// <param name="CellarID">Cellar ID</param>
            /// <param name="CellarAmount">Cellar Amount</param>
            /// <returns>Number Affected Row</returns>
            public static Tuple<ErrorObject, string> CellarAmoun(int CellarID, int CellarAmount)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        var row = db.tblCellar.Single(p => p.id == CellarID);
                        row.amount = CellarAmount;
                        row.upDateDate = DateTime.Now;
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

        #region Delete or Disable Data
        public class Delete
        {
            /// <summary>
            /// Update State Fields To Specific Employee ID
            /// </summary>
            /// <param name="CellarID">Cellar ID</param>
            /// <param name="state">Active Or Disable</param>
            /// <returns>Number Affected Row</returns>
            public static Tuple<ErrorObject, string> CellarDisable(int CellarID, string state)
            {
                erros = new ErrorObject();
                try
                {
                    //                    using (HSCMEntities db = new HSCMEntities())
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        var row = db.tblEmployee.Single(p => p.id == CellarID);
                        row.state = state;
                        row.deleteDate = DateTime.Now;
                        result = db.SaveChanges();

                        Message = "Affected Row: " + result.ToString();
                        erros.Error = false;
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
