﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entity; // Use entity

namespace Data.Employee
{
    public class EmployeeData
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
            /// Return All Employee
            /// </summary>
            /// <returns>All Employee Or null If Exist Error</returns>
            public static Tuple<ErrorObject, List<tblEmployee>> GetEmployeeList()
            {
                List<tblEmployee> data = new List<tblEmployee>();
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = db.tblEmployee.ToList();
                    };
                    return new Tuple<ErrorObject, List<tblEmployee>>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, List<tblEmployee>>(erros, data);
                }

            }

            /// <summary>
            /// Return Employee By Specific ID
            /// </summary>
            /// <param name="id">Employee ID</param>
            /// <returns>Employee By Specific ID Or null If Exist Error</returns>
            public static Tuple<ErrorObject, tblEmployee> GetEmployee(int id)
            {
                tblEmployee data = new tblEmployee();
                erros = new ErrorObject();

                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        data = db.tblEmployee.Find(id);
                    }
                    erros.Error = false;
                    return new Tuple<ErrorObject, tblEmployee>(erros.IfError(false), data);
                }
                catch (Exception ex)
                {
                    erros.InfoError(ex);
                    return new Tuple<ErrorObject, tblEmployee>(erros, data);
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
            public static Tuple<ErrorObject, string> Employee(tblEmployee data)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        int propertyFind = db.tblEmployee.Count();
                        if (propertyFind > 0)
                        {
                            data.id = db.tblEmployee.Max(s => s.id);
                        }
                        else
                        {
                            data.id = 1;
                        }
                        db.tblEmployee.Add(data);
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
            /// Update Employee Information
            /// </summary>
            /// <param name="data">Employee Information</param>
            /// <returns>Number Affected Row</returns>
            public static Tuple<ErrorObject, string> Employee(tblEmployee data)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        var row = db.tblEmployee.Single(p => p.id == data.id);
                        row.email = data.email;
                        row.firstName = data.firstName;
                        row.lastName = data.lastName;
                        row.idUser = data.idUser;
                        row.idUserType = data.idUserType;               
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
            /// <param name="EmployeeID">Employee ID</param>
            /// <param name="state">Active Or Disable</param>
            /// <returns>ID Department ID</returns>
            public static Tuple<ErrorObject, string> EmployeeDisable(int EmployeeID, string state)
            {
                erros = new ErrorObject();
                try
                {
                    using (EileenGaldamezEntities db = new EileenGaldamezEntities())
                    {
                        var row = db.tblEmployee.Single(p => p.id == EmployeeID);
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