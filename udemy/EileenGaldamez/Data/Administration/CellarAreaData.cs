using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using Entity; // Use entity

namespace Data
{
    public class CellarAreaData
    {
        
        #region Property
        private static int result = 0;
        private static string Message = "";
        private static ErrorObject erros;
        #endregion

        public class GetMenuResult {
            public int CategoryID { get; set; }
            public int CellarAreaID { get; set; }
            public int FatherCategoryID { get; set; }
            public bool Father { get; set; }
            public string Department { get; set; }
            public string Area { get; set; }
        }

        #region Select Data
        public class Select
        {
            /// <summary>
            /// Return All Cellar Area
            /// </summary>
            /// <returns>All Cellar Area Or null If Exist Error</returns>
            public static Tuple<ErrorObject, List<tblCellarArea>> GetCellarArea()
            {
                List<tblCellarArea> CellarArea = new List<tblCellarArea>();
                erros = new ErrorObject();

                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        CellarArea = db.tblCellarArea.ToList();
                    };

                    return new Tuple<ErrorObject, List<tblCellarArea>>(erros.IfError(false), CellarArea);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, List<tblCellarArea>>(erros, CellarArea);
                }

            }

            /// <summary>
            /// Return Cellar Area By Specific ID
            /// </summary>
            /// <param name="id">Cellar Area ID</param>
            /// <returns>Cellar Area By Specific ID Or null If Exist Error</returns>
            public static Tuple<ErrorObject, tblCellarArea> GetCellarArea(int id)
            {
                tblCellarArea CellarArea = new tblCellarArea();
                erros = new ErrorObject();

                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        CellarArea = db.tblCellarArea.Find(id);
                    }
                    erros.Error = false;
                    return new Tuple<ErrorObject, tblCellarArea>(erros.IfError(false), CellarArea);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, tblCellarArea>(erros, CellarArea);
                }
            }

            /// <summary>
            /// Return Cellar Area Name
            /// </summary>
            /// <param name="id">CellarAreaID</param>
            /// <returns>Cellar Area Name</returns>
            public static Tuple<ErrorObject, tblCellarArea> GetCellarAreaName(int id)
            {
                tblCellarArea CellarArea = new tblCellarArea();
                erros = new ErrorObject();

                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        CellarArea.name = db.tblCellarArea.Find(id).name;
                    }
                    erros.Error = false;
                    return new Tuple<ErrorObject, tblCellarArea>(erros.IfError(false), CellarArea);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, tblCellarArea>(erros, CellarArea);
                }
            }

            /// <summary>
            /// Return all items to menu
            /// </summary>
            /// <returns>All items to menu</returns>
            public static Tuple<ErrorObject, List<GetMenuResult>> GetCellarAreaListMenu()
            {
                List<GetMenuResult> data = new List<GetMenuResult>();
                erros = new ErrorObject();

                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        var datas =( from CA in db.tblCellarArea 
                                join C in db.tblCategory 
                                on CA.id equals C.idCellarArea 
                                select new GetMenuResult {
                                    Department = CA.name,
                                    CategoryID = C.id,
                                    CellarAreaID = CA.id,
                                    FatherCategoryID = (int)C.idCategory,
                                    Area = C.name
                                }).OrderBy(C => C.CellarAreaID).ToList();

                        foreach (var data3 in datas) {
                            int f = ( from C in db.tblCategory where C.idCategory == data3.CategoryID select C.id  ).Count();

                            data.Add(new GetMenuResult() {
                                Area = data3.Area,
                                CellarAreaID = data3.CellarAreaID,
                                CategoryID = data3.CategoryID,
                                Department = data3.Department,
                                FatherCategoryID = data3.FatherCategoryID,
                                Father = ( f > 0 ? true : false )
                            });
                        }
                    };

                    return new Tuple<ErrorObject, List<GetMenuResult>>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, List<GetMenuResult>>(erros, data);
                }

            }

        }
        #endregion

        #region Insert Data
        public class Insert
        {
            /// <summary>
            /// Insert Cellar Area Information
            /// </summary>
            /// <param name="data">Cellar Area Information</param>
            /// <returns>Number Affected Row</returns>
            public static Tuple<ErrorObject, string> CellarArea(tblCellarArea data)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        int propertyFind = db.tblCellarArea.Count();
                        if (propertyFind > 0)
                        {
                            data.id = db.tblCellarArea.Max(s => s.id);
                        }
                        else
                        {
                            data.id = 1;
                        }
                        db.tblCellarArea.Add(data);
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
            /// Update Cellar Area Information
            /// </summary>
            /// <param name="data">Cellar Area Information</param>
            /// <returns>Number Affected Row</returns>
            public static Tuple<ErrorObject, string> CellarArea(tblCellarArea data)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        var row = db.tblCellarArea.Single(p => p.id == data.id);
                        row.name = data.name;
                        row.detail = data.detail;
                        row.upDateDate = data.upDateDate;
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

        #region Delete or Disable Data
        public class Delete
        {
            /// <summary>
            /// Update State Fields To Specific CellarAreaID ID
            /// </summary>
            /// <param name="CellarAreaID">Cellar Area ID</param>
            /// <param name="state">Active Or Disable</param>
            /// <returns>ID Department ID</returns>
            public static Tuple<ErrorObject, string> CellarAreaDisable(int CellarAreaID, string state)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        var row = db.tblCellarArea.Single(p => p.id == CellarAreaID);
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
