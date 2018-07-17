using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity; // Use entity
using System.Data;

namespace Data
{
    public class CategoryData
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
            /// Return True Or False If Container Child
            /// </summary>
            /// <param name="id">Category ID</param>
            /// <returns>True Or False If Container Child</returns>
            public static Tuple<ErrorObject, bool> ContainerChild(int CategoryID)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        var algo = db.tblCategory.Where(ty => ty.idCategory == CategoryID).ToList();
                        if (algo.Count > 0)
                        {
                            return new Tuple<ErrorObject, bool>(erros, true);
                        }
                        else
                        {
                            return new Tuple<ErrorObject, bool>(erros, false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, bool>(erros, false);
                }
            }

            /// <summary>
            /// Return Category List 
            /// </summary>
            /// <returns>Category List</returns>
            public static Tuple<ErrorObject, List<tblCategory>> GetCategory()
            {
                List<tblCategory> c = new List<tblCategory>();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        c = db.tblCategory.OrderBy(d1 => d1.idCategory).OrderBy(d1 => d1.id).OrderBy(f => f.idCellarArea).ToList();
                        return new Tuple<ErrorObject, List<tblCategory>>(erros.IfError(false), c);
                    };
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, List<tblCategory>>(erros, c);
                }
            }

            /// <summary>
            /// Return Department Information
            /// </summary>
            /// <param name="CategoryID">Category ID</param>
            /// <returns>Department Information</returns>
            public static Tuple<ErrorObject, tblCategory> GetCategory(int CategoryID)
            {
                tblCategory c = new tblCategory();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        c = db.tblCategory.Find(CategoryID);
                        return new Tuple<ErrorObject, tblCategory>(erros.IfError(false), c);
                    }
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, tblCategory>(erros, c);
                }

            }

            /// <summary>
            /// Return Category List To Only father
            /// </summary>
            /// <returns>Category List</returns>
            public static Tuple<ErrorObject, List<tblCategory>> GetCategoryToFather()
            {
                List<tblCategory> c = new List<tblCategory>();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        c = db.tblCategory.Where(f => f.idCategory == 0).OrderBy(f => f.idCellarArea).ToList();
                        return new Tuple<ErrorObject, List<tblCategory>>(erros.IfError(false), c);
                    }
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, List<tblCategory>>(erros, c);
                }

            }

            /// <summary>
            /// Return Category List To Specific Father Category ID
            /// </summary>
            /// <param name="CategoryID">Father Category ID</param>
            /// <returns>Category List</returns>
            public static Tuple<ErrorObject, List<tblCategory>> GetCategoryToFather(int CategoryID)
            {
                List<tblCategory> c = new List<tblCategory>();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        c = db.tblCategory.Where(f => f.idCategory == CategoryID).OrderBy(f => f.idCellarArea).ToList();
                        return new Tuple<ErrorObject, List<tblCategory>>(erros.IfError(false), c);
                    }
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, List<tblCategory>>(erros, c);
                }

            }

            /// <summary>
            /// Return Category Name To Specific ID
            /// </summary>
            /// <param name="CategoryID">CategoryID</param>
            /// <returns>Category Name</returns>
            public static Tuple<ErrorObject, tblCategory> GetCategoryName(int CategoryID)
            {
                tblCategory c = new tblCategory();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        c.name = db.tblCategory.Find(CategoryID).name;
                        return new Tuple<ErrorObject, tblCategory>(erros.IfError(false), c);
                    }
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, tblCategory>(erros, c);
                }

            }

        }
        #endregion

        #region Insert Data
        public class Insert
        {
            /// <summary>
            /// Insert Category
            /// </summary>
            /// <param name="data">Information Cateogy</param>
            /// <returns>Number Affected Row</returns>
            public static Tuple<ErrorObject, string> Category(tblCategory data)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        int propertyFind = db.tblCategory.Count();
                        if (propertyFind > 0)
                        {
                            data.id = db.tblCategory.Max(s => s.id + 1);
                        }
                        else
                        {
                            data.id = 1;
                        }
                        db.tblCategory.Add(data);
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
            /// Update Category
            /// </summary>
            /// <param name="data">Category Information</param>
            /// <returns>Number Affected Row</returns>
            public static Tuple<ErrorObject, string> Category(tblCategory data)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        var row = db.tblCategory.Single(p => p.id == data.id);
                        row.name = data.name;
                        row.idCategory = data.idCategory;
                        row.idCellarArea = data.idCellarArea;
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
            /// Update Category and All category child 
            /// </summary>
            /// <param name="data">Category information</param>
            /// <returns>Number Affected Row</returns>
            public static Tuple<ErrorObject, string> CategoryAndAllChildCellarArea(tblCategory data)
            {

                List<int> Child = new List<int>();

                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        var row = db.tblCategory.Single(p => p.id == data.id);
                        row.name = data.name;
                        row.idCategory = data.idCategory;
                        row.idCellarArea = data.idCellarArea;
                        row.detail = data.detail;
                        row.upDateDate = data.upDateDate;
                        result = db.SaveChanges();
                        Message = "Affected Row: " + result.ToString();

                        Child = ( 
                            from C in db.tblCategory
                            where C.idCategory == data.id 
                            select C.id ).ToList();

                        if (Child.Count > 0)
                        {
                            foreach (var item in Child)
                            {
                                var row2 = db.tblCategory.Single(p => p.id == item);
                                row2.idCellarArea = data.idCellarArea;
                                db.SaveChanges();
                            }
                        }
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
            /// Update State Fields To Specific Category ID
            /// </summary>
            /// <param name="CategoryID">Category ID</param>
            /// <param name="state"></param>
            /// <returns>Number Affected Row</returns>
            public static Tuple<ErrorObject, string> CategoryDisable(int CategoryID, string state)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        var row = db.tblCategory.Single(p => p.id == CategoryID);
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
