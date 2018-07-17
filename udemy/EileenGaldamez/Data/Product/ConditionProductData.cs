using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity; // Use entity
namespace Data.Product
{
    public class ConditionProductData
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
            /// Return All ConditionProduct
            /// </summary>
            /// <returns>All ConditionProduct Or null If Exist Error</returns>
            public static Tuple<ErrorObject, List<tblConditionProduct>> GetConditionProductList()
            {
                List<tblConditionProduct> data = new List<tblConditionProduct>();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = db.tblConditionProduct.ToList();
                    };
                    return new Tuple<ErrorObject, List<tblConditionProduct>>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, List<tblConditionProduct>>(erros, data);
                }

            }

            /// <summary>
            /// Return ConditionProduct By Specific ID
            /// </summary>
            /// <param name="id">ConditionProduct ID</param>
            /// <returns>ConditionProduct By Specific ID Or null If Exist Error</returns>
            public static Tuple<ErrorObject, tblConditionProduct> GetConditionProduct(int id)
            {
                tblConditionProduct data = new tblConditionProduct();
                erros = new ErrorObject();

                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = db.tblConditionProduct.Find(id);
                    }
                    erros.Error = false;
                    return new Tuple<ErrorObject, tblConditionProduct>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, tblConditionProduct>(erros, data);
                }
            }
        }
        #endregion

        #region Insert Data
        public class Insert
        {
            /// <summary>
            /// Insert ConditionProduct Information
            /// </summary>
            /// <param name="data">ConditionProduct Information</param>
            /// <returns>Number Affected Row</returns>
            public static Tuple<ErrorObject, string> ConditionProduct(tblConditionProduct data)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        int propertyFind = db.tblConditionProduct.Count();
                        if (propertyFind > 0)
                        {
                            data.id = db.tblConditionProduct.Max(s => s.id);
                        }
                        else
                        {
                            data.id = 1;
                        }
                        db.tblConditionProduct.Add(data);
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

        #region Update Data
        public class Update
        {
            /// <summary>
            /// Update ConditionProduct Information
            /// </summary>
            /// <param name="data">ConditionProduct Information</param>
            /// <returns>Number Affected Row</returns>
            public static Tuple<ErrorObject, string> ConditionProduct(tblConditionProduct data)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        var row = db.tblConditionProduct.Single(p => p.id == data.id);
                        row.name = data.name;
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
        }
        #endregion

        #region Delete or Disable Data
        public class Delete
        {
            /// <summary>
            /// Update State Fields To Specific Employee ID
            /// </summary>
            /// <param name="ConditionProductID">ConditionProductID</param>
            /// <param name="state">Active Or Disable</param>
            /// <returns>Number Affected Row</returns>
            public static Tuple<ErrorObject, string> ConditionProductDisable(int ConditionProductID, string state)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        var row = db.tblConditionProduct.Single(p => p.id == ConditionProductID);
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
