using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entity; // Use entity

namespace Data.Assignment
{
    public class AssignmentData
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
            /// Return All Assignment TO AnchorAssignment ID and Assignment Type
            /// </summary>
            /// <returns>All Assignment Or null If Exist Error</returns>
            public static Tuple<ErrorObject, List<tblAssignment>> GetAssignmentByCategoryID(int CategoryID)
            {
                List<tblAssignment> data = new List<tblAssignment>();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = db.tblAssignment.Where(c => c.idCategory == CategoryID).ToList();
                    };
                    return new Tuple<ErrorObject, List<tblAssignment>>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, List<tblAssignment>>(erros, data);
                }

            }


            /// <summary>
            /// Return All Assignment TO Product ID
            /// </summary>
            /// <returns>All Assignment Or null If Exist Error</returns>
            public static Tuple<ErrorObject, List<tblAssignment>> GetAssignmentByProductID(int ProductID)
            {
                List<tblAssignment> data = new List<tblAssignment>();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = db.tblAssignment.Where(c => c.idProduct == ProductID).ToList();
                    };
                    return new Tuple<ErrorObject, List<tblAssignment>>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, List<tblAssignment>>(erros, data);
                }

            }


            /// <summary>
            /// Return Assignment By Specific ID
            /// </summary>
            /// <param name="id">Assignment ID</param>
            /// <returns>Assignment By Specific ID Or null If Exist Error</returns>
            public static Tuple<ErrorObject, tblAssignment> GetAssignment(int id)
            {
                tblAssignment data = new tblAssignment();
                erros = new ErrorObject();

                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = db.tblAssignment.Find(id);
                    }
                    erros.Error = false;
                    return new Tuple<ErrorObject, tblAssignment>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, tblAssignment>(erros, data);
                }
            }

            /// <summary>
            /// Return All Assingnment To specific Product, category IDS
            /// </summary>
            /// <param name="ProductID"></param>
            /// <param name="CategoryID"></param>
            /// <returns>All Assignment</returns>
            public static Tuple<ErrorObject, tblAssignment> GetAssignmentByProductIDAndCategoryID(int ProductID, int CategoryID)
            {
                tblAssignment data = new tblAssignment();
                erros = new ErrorObject();

                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = db.tblAssignment.Where(r => r.idProduct == ProductID && r.idCategory == CategoryID).First();
                    }
                    erros.Error = false;
                    return new Tuple<ErrorObject, tblAssignment>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, tblAssignment>(erros, data);
                }
            }

            /// <summary>
            /// Return All Assingnment To specific Product, category, Codition and TransactionType IDS
            /// </summary>
            /// <param name="ProductID"></param>
            /// <param name="CategoryID"></param>
            /// <param name="ConditionID"></param>
            /// <param name="TransactionTypeID"></param>
            /// <returns>All Assignment</returns>
            public static Tuple<ErrorObject, tblAssignment> GetAssignmentByProductIDAndCategoryWithCondition(int ProductID, int CategoryID, int ConditionID, int TransactionTypeID)
            {
                tblAssignment data = new tblAssignment();
                erros = new ErrorObject();

                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = (from TC in db.tblTransactionConfigurate 
                                join A in db.tblAssignment on TC.idAnchorTransaction equals A.id
                                join T in db.tblTransaction on TC.idTransaction equals T.id
                                where A.idProduct == ProductID && TC.idTransactionType == TransactionTypeID && T.idConditionProduct == ConditionID
                                select A).First();
                    }
                    erros.Error = false;
                    return new Tuple<ErrorObject, tblAssignment>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, tblAssignment>(erros, data);
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
            public static Tuple<ErrorObject, int> Assignment(tblAssignment data)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        int propertyFind = db.tblAssignment.Count();
                        if (propertyFind > 0)
                        {
                            data.id = db.tblAssignment.Max(s => s.id);
                        }
                        else
                        {
                            data.id = 1;
                        }
                        db.tblAssignment.Add(data);
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
            public static Tuple<ErrorObject, string> Assignment(tblAssignment data)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        var row = db.tblAssignment.Single(p => p.id == data.id);
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
            /// Update Amount To Specific Assignment ID
            /// </summary>
            /// <param name="idAssignment">Assignment ID</param>
            /// <param name="AssignmentAmount">Amount</param>
            /// <returns>Number Affected Row</returns>
            public static Tuple<ErrorObject, string> AssignmentAmount(int idAssignment, int AssignmentAmount)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        var row = db.tblAssignment.Find(idAssignment);
                        row.amount = AssignmentAmount;
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
