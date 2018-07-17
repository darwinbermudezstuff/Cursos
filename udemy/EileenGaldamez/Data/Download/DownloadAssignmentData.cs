using Entity; // Use entity
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Download
{
    public class DownloadAssignmentData
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
            /// Return All Download Assignment By Specific Categlry ID
            /// </summary>
            /// <param name="CategoryID">CategoryID</param>
            /// <returns>All Download Assignment</returns>
            public static Tuple<ErrorObject, List<tblDownloadAssignment>> GetDownloadByCategoryID(int CategoryID)
            {
                List<tblDownloadAssignment> data = new List<tblDownloadAssignment>();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = db.tblDownloadAssignment.Where(c => c.idCategory == CategoryID).ToList();
                    };
                    return new Tuple<ErrorObject, List<tblDownloadAssignment>>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, List<tblDownloadAssignment>>(erros, data);
                }

            }

            /// <summary>
            /// Return All Download Assignment By Specific Product ID
            /// </summary>
            /// <param name="ProductID">Product ID</param>
            /// <returns>All Download Assignment</returns>
            public static Tuple<ErrorObject, List<tblDownloadAssignment>> GetDownloadByProductID(int ProductID)
            {
                List<tblDownloadAssignment> data = new List<tblDownloadAssignment>();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = db.tblDownloadAssignment.Where(c => c.idProduct == ProductID).ToList();
                    };
                    return new Tuple<ErrorObject, List<tblDownloadAssignment>>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, List<tblDownloadAssignment>>(erros, data);
                }

            }

            /// <summary>
            /// Return Downloan Assignment Information By Specific ID
            /// </summary>
            /// <param name="id">Download Assignment ID</param>
            /// <returns>Download Assignment Information</returns>
            public static Tuple<ErrorObject, tblDownloadAssignment> GetDownload(int id)
            {
                tblDownloadAssignment data = new tblDownloadAssignment();
                erros = new ErrorObject();

                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = db.tblDownloadAssignment.Find(id);
                    }
                    erros.Error = false;
                    return new Tuple<ErrorObject, tblDownloadAssignment>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, tblDownloadAssignment>(erros, data);
                }
            }
        }
        #endregion

        #region Insert Data
        public class Insert
        {

            /// <summary>
            /// Insert Assignment Information
            /// </summary>
            /// <param name="data">Assignment Information</param>
            /// <returns>Number Affected Row</returns>
            public static Tuple<ErrorObject, int> Download(tblDownloadAssignment data)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        int propertyFind = db.tblDownloadAssignment.Count();
                        if (propertyFind > 0)
                        {
                            data.id = db.tblDownloadAssignment.Max(s => s.id);
                        }
                        else
                        {
                            data.id = 1;
                        }
                        db.tblDownloadAssignment.Add(data);
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
            /// Update Assignment Information
            /// </summary>
            /// <param name="data">Assignment Information</param>
            /// <returns>Number Affected Row</returns>
            public static Tuple<ErrorObject, string> Download(tblDownloadAssignment data)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        var row = db.tblDownloadAssignment.Single(p => p.id == data.id);
                        row.idEmployee = data.idEmployee;
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
            /// Update Amount Assignment Information
            /// </summary>
            /// <param name="idAssignment">Assignment ID</param>
            /// <param name="DownloadAmount">Amount</param>
            /// <returns>Number Affected Row</returns>
            public static Tuple<ErrorObject, string> DownloadAmount(int idAssignment, int DownloadAmount)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        var row = db.tblDownloadAssignment.Find(idAssignment);
                        row.amount = DownloadAmount;
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

    }
}
