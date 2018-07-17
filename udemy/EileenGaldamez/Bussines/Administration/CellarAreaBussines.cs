using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data; // Use entity
using Entity;

using System.ComponentModel.DataAnnotations;
using Bussines.Handler;
using System.ComponentModel;

namespace Bussines
{

    /// <summary>
    /// Model Site
    /// </summary>
    public class CellarArea {
        public int id { get; set; }
        [DisplayName("Department Name")]
        public string name { get; set; }
        [DisplayName("Detail")]
        [DataType(DataType.MultilineText)]
        public string detail { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> upDateDate { get; set; }
        public Nullable<System.DateTime> deleteDate { get; set; }
        [DisplayName("State")]
        public string state { get; set; }
    }


    public class CellarAreaBussines
    {

        #region Logic, Responces and Requests

        /// <summary>
        /// When You Need To Get Response
        /// </summary>
        public class GetCellarAreaResponse
        {
            public Handler.ErrorObject Error { get; set; }
            public string Message { get; set; }
            public CellarArea CellarArea { get; set; }
            public List<CellarArea> CellarAreaList { get; set; }
        }

        public class GetCellarAreaMenuResponse
        {
            public Handler.ErrorObject Error { get; set; }

            public List<GetMenuResult> MenuList { get; set; }
        }

        public class GetMenuResult
        {
            public string Department { get; set; }
            public int FatherCategoryID { get; set; }
            public int CategoryID { get; set; }
            public int CellarAreaID { get; set; }
            public string Area { get; set; }
            public bool Father { get; set; }

        }

        /// <summary>
        /// When you Need To Specify Petition
        /// </summary>
        public class GetCellarAreaRequest
        {
            public int CellarAreaID { get; set; }
        }
        #endregion

        #region Select Data
        public class Select
        {

            /// <summary>
            /// Return Cellar Area List
            /// </summary>
            /// <returns>Cellar Area List</returns>
            public static GetCellarAreaResponse GetCellarAreaList()
            {
                GetCellarAreaResponse response = new GetCellarAreaResponse();
                response.CellarAreaList = new List<CellarArea>();
                response.Error = new Handler.ErrorObject();

                try
                {
                    var GetCellarArea = CellarAreaData.Select.GetCellarArea();
                    if (!GetCellarArea.Item1.Error)
                    {
                        foreach (var item in GetCellarArea.Item2)
                        {
                            response.CellarAreaList.Add(new CellarArea()
                            {
                                id = item.id,
                                name = item.name,
                                detail = item.detail,
                                createDate = item.createDate,
                                upDateDate = item.upDateDate,
                                deleteDate = item.deleteDate,
                                state = item.state
                            });
                        }
                    }
                    else
                    {
                        response.Error.InfoError(GetCellarArea.Item1);
                    }
                }
                catch (Exception ex)
                {
                    response.Error.InfoError(ex);
                }
                return response;
            }

            /// <summary>
            /// Return CellarArea Information
            /// </summary>
            /// <param name="request">Cellar Area ID</param>
            /// <returns>Department Information</returns>
            public static GetCellarAreaResponse GetCellarArea(GetCellarAreaRequest request)
            {
                GetCellarAreaResponse response = new GetCellarAreaResponse();
                response.Error = new Handler.ErrorObject();
                response.CellarArea = new CellarArea();
                try
                {
                    var GetCellarArea = CellarAreaData.Select.GetCellarArea(request.CellarAreaID);
                    if (!GetCellarArea.Item1.Error)
                    {
                        response.CellarArea = new CellarArea()
                        {
                            id = GetCellarArea.Item2.id,
                            name = GetCellarArea.Item2.name,
                            detail = GetCellarArea.Item2.detail,
                            createDate = GetCellarArea.Item2.createDate,
                            upDateDate = GetCellarArea.Item2.upDateDate,
                            deleteDate = GetCellarArea.Item2.deleteDate,
                            state = GetCellarArea.Item2.state
                        };

                    }
                    else
                    {
                        response.Error.InfoError(GetCellarArea.Item1);
                    }
                }
                catch (Exception ex)
                {
                    response.Error.InfoError(ex);
                }

                return response;
            }

            /// <summary>
            /// Return Cellar Area Name
            /// </summary>
            /// <param name="request">CellarAreaID</param>
            /// <returns>Cellar Area Name</returns>
            public static GetCellarAreaResponse GetCellarAreaName(int request)
            {
                GetCellarAreaResponse response = new GetCellarAreaResponse();
                response.Error = new Handler.ErrorObject();
                response.CellarArea = new CellarArea();
                try
                {
                    var GetCellarArea = CellarAreaData.Select.GetCellarAreaName(request);
                    if (!GetCellarArea.Item1.Error)
                    {
                        response.CellarArea = new CellarArea()
                        {
                            name = GetCellarArea.Item2.name
                        };

                    }
                    else
                    {
                        response.Error.InfoError(GetCellarArea.Item1);
                    }
                }
                catch (Exception ex)
                {
                    response.Error.InfoError(ex);
                }

                return response;
            }

            public static GetCellarAreaMenuResponse GetCellarAreaListMenu()
            {
                GetCellarAreaMenuResponse response = new GetCellarAreaMenuResponse();
                response.MenuList = new List<GetMenuResult>();
                response.Error = new Handler.ErrorObject();

                try
                {
                    var data = CellarAreaData.Select.GetCellarAreaListMenu();
                    if (!data.Item1.Error)
                    {
                        foreach (var item in data.Item2)
                        {
                            response.MenuList.Add(new GetMenuResult()
                            {
                                CellarAreaID = item.CellarAreaID,
                                Department = item.Department,                                 
                                CategoryID = item.CategoryID,
                                FatherCategoryID = item.FatherCategoryID,
                                Area = item.Area,
                                Father = item.Father
                            });
                        }
                    }
                    else
                    {
                        response.Error.InfoError(data.Item1);
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

        #region Insert Data
        public class Insert
        {

            /// <summary>
            /// Return Affected Row Or Error If Exist
            /// </summary>
            /// <param name="request">CellarArea Information</param>
            /// <returns>Affected Row Or Error If Exist</returns>
            public static GetCellarAreaResponse CellarArea(GetCellarAreaResponse request)
            {
                GetCellarAreaResponse response = new GetCellarAreaResponse();
                response.Error = new Handler.ErrorObject();

                try
                {
                    tblCellarArea CellarArea = new tblCellarArea()
                    {
                        id = request.CellarArea.id,
                        name = request.CellarArea.name,
                        detail = request.CellarArea.detail,
                        createDate = DateTime.Now,
                        upDateDate = null,
                        deleteDate = null,
                        state = "Active"
                    };

                    var result = CellarAreaData.Insert.CellarArea(CellarArea);
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

        #region Update Data
        public class Update
        {

            /// <summary>
            /// Return Affected Row Or Error If Exist
            /// </summary>
            /// <param name="request">CellarArea Information</param>
            /// <returns>Affected Row Or Error If Exist</returns>
            public static GetCellarAreaResponse CellarArea(GetCellarAreaResponse request)
            {

                GetCellarAreaResponse response = new GetCellarAreaResponse();
                response.Error = new Handler.ErrorObject();
                try
                {
                    tblCellarArea CellarArea = new tblCellarArea()
                    {
                        id = request.CellarArea.id,
                        name = request.CellarArea.name,
                        detail = request.CellarArea.detail,
                        createDate = request.CellarArea.createDate,
                        upDateDate = DateTime.Now,
                        deleteDate = null,
                        state = "Active"
                    };

                    var result = CellarAreaData.Update.CellarArea(CellarArea);
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

        #region Delete or Disable Data
        public class Delete
        {

            /// <summary>
            /// Return Affected Row Or Error If Exist
            /// </summary>
            /// <param name="CellarAreaID">Cellar Area ID</param>
            /// <param name="state">State</param>
            /// <returns>Affected Row Or Error If Exist</returns>
            public static GetCellarAreaResponse CellarAreaDisable(int CellarAreaID, string state)
            {
                GetCellarAreaResponse response = new GetCellarAreaResponse();
                try
                {
                    var result = CellarAreaData.Delete.CellarAreaDisable(CellarAreaID, state);
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
