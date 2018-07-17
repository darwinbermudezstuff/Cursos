using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Entity;

namespace Data.Product
{
    public class ProductData
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
            /// Return All Product
            /// </summary>
            /// <returns>All Product</returns>
            public static Tuple<ErrorObject, List<tblProduct>> GetProduct()
            {
                List<tblProduct> data = new List<tblProduct>();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = db.tblProduct.ToList();
                    };
                    return new Tuple<ErrorObject, List<tblProduct>>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, List<tblProduct>>(erros, data);
                }

            }

            /// <summary>
            /// Return Product By Specific ID
            /// </summary>
            /// <param name="id">Product ID</param>
            /// <returns>Product</returns>
            public static Tuple<ErrorObject, tblProduct> GetProduct(int id)
            {
                tblProduct data = new tblProduct();
                erros = new ErrorObject();

                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = db.tblProduct.Find(id);
                    }
                    erros.Error = false;
                    return new Tuple<ErrorObject, tblProduct>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, tblProduct>(erros, data);
                }
            }

            /// <summary>
            /// Return All Product By Specific Cellar Area ID
            /// </summary>
            /// <param name="CellarAreaID">CellarAreaID</param>
            /// <returns>All Product</returns>
            public static Tuple<ErrorObject, List<tblProduct>> GetProductToCellarArea(int CellarAreaID)
            {
                List<tblProduct> data = new List<tblProduct>();
                List<int> ids = new List<int>();

                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        //ids = (from C in db.tblCellar where C.idcellarArea == CellarAreaID select (int)C.idProduct).ToList();
                        //data = db.tblProduct.ToList();
                        //for (int v = 0; v < ids.Count; v++)
                        //{
                        //    var itemToRemove = data.SingleOrDefault(r => r.id == ids[v]);
                        //    if (itemToRemove != null)
                        //        data.Remove(itemToRemove);
                        //}
                        data = db.SP_Product_SelectProduct("GetProductToCellarArea", CellarAreaID, 0, 0).ToList();

                    };
                    return new Tuple<ErrorObject, List<tblProduct>>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, List<tblProduct>>(erros, data);
                }

            }

            /// <summary>
            /// Return All Product List To Specific Cella Area ID
            /// </summary>
            /// <param name="CellarAreaID">Cellar Area ID</param>
            /// <returns>All Product</returns>
            public static Tuple<ErrorObject, List<tblProduct>> GetProductByAssignmentType(int CellarAreaID)
            {
                List<tblProduct> data = new List<tblProduct>();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = (from P in db.tblProduct
                                join C in db.tblCellar on P.id equals C.idProduct
                                where C.idcellarArea == CellarAreaID
                                select P).ToList();
                    };
                    return new Tuple<ErrorObject, List<tblProduct>>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, List<tblProduct>>(erros, data);
                }

            }

            /// <summary>
            /// Return All Product To Cellar Category and Category Father IDs
            /// </summary>
            /// <param name="CellarAreaID">CellarAreaID</param>
            /// <param name="Category">Category</param>
            /// <param name="FatherCateogryID">FatherCateogryID</param>
            /// <returns></returns>
            public static Tuple<ErrorObject, List<tblProduct>> GetProductListByDepartmentAndCategory(int CellarAreaID, int Category, int FatherCateogryID)
            {
                List<tblProduct> data = new List<tblProduct>();
                erros = new ErrorObject();

                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = db.SP_Product_SelectProduct("GetProductListByDepartmentAndCategory", CellarAreaID, Category, FatherCateogryID).ToList(); 
                    };

                    return new Tuple<ErrorObject, List<tblProduct>>(erros.IfError(false), data);
                }

                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, List<tblProduct>>(erros, data);
                }

            }

            /// <summary>
            /// Return All Producto By Especific Categoy, trasaction and Cellar Area ID
            /// </summary>
            /// <param name="CategoryID">CategoryID</param>
            /// <param name="CellarAreaID">CellarAreaID</param>
            /// <returns>All Product</returns>
            public static Tuple<ErrorObject, List<tblProduct>> GetProductByAssignmentTypeAndTransactionType(int CategoryID, int CellarAreaID)
            {
                List<tblProduct> data = new List<tblProduct>();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = (from P in db.tblProduct
                                join C in db.tblAssignment on P.id equals C.idProduct
                                where C.idCategory == CategoryID
                                select P).ToList();
                    };
                    return new Tuple<ErrorObject, List<tblProduct>>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, List<tblProduct>>(erros, data);
                }

            }

            /// <summary>
            /// Return Product List To Special AssignmentType and AnchorAssignment
            /// </summary>
            /// <param name="CategoryID">CategoryID</param>
            /// <returns>Product List</returns>
            public static Tuple<ErrorObject, List<tblProduct>> GetProductsOfAssignment(int CategoryID)
            {
                List<tblProduct> data = new List<tblProduct>();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = (
                        from A in db.tblAssignment
                        join P in db.tblProduct
                        on A.idProduct equals P.id
                        where A.idCategory == CategoryID
                        select P).ToList();
                    };
                    return new Tuple<ErrorObject, List<tblProduct>>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, List<tblProduct>>(erros, data);
                }

            }

        }
        #endregion

        #region Insert Data
        public class Insert
        {
            /// <summary>
            /// Insert Employee Information
            /// </summary>
            /// <param name="data">Employee Information</param>
            /// <returns>Number Affected Row</returns>
            public static Tuple<ErrorObject, int> product(tblProduct data)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        int propertyFind = db.tblProduct.Count();
                        if (propertyFind > 0)
                        {
                            data.id = db.tblProduct.Max(s => s.id);
                        }
                        else
                        {
                            data.id = 1;
                        }
                        db.tblProduct.Add(data);
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
            /// Update Product Information
            /// </summary>
            /// <param name="data">Product Information</param>
            /// <returns>Number Affected Row</returns>
            public static Tuple<ErrorObject, string> product(tblProduct data)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        var row = db.tblProduct.Single(p => p.id == data.id);
                        row.name = data.name;
                        row.code = data.code;
                        row.unit = data.unit;
                        row.idProductType = data.idProductType;
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
            /// Update State Fields To Specific Product ID
            /// </summary>
            /// <param name="ProductID">ProductID</param>
            /// <param name="state">Active Or Disable</param>
            /// <returns>ProductID</returns>
            public static Tuple<ErrorObject, string> productDisable(int ProductID, string state)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        var row = db.tblProduct.Single(p => p.id == ProductID);
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
