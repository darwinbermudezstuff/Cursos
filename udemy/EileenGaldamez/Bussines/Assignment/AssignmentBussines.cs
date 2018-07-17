using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Employee;
using Data; // Use entity
using Entity;

using System.ComponentModel.DataAnnotations;
using Bussines.Handler;
using Data.Assignment;
using Bussines.Transaction;
using Bussines.Cellar;
using System.ComponentModel;

namespace Bussines.Assignment
{
    public class Assignments
    {
        public int id { get; set; }
        [DisplayName("Amount")]
        public Nullable<int> amount { get; set; }
        [DisplayName("Product Loan")]
        public Nullable<int> loan { get; set; }

        [DisplayName("Producto Max")]
        public Nullable<int> Max { get; set; }
        [DisplayName("Producto Min")]
        public Nullable<int> Min { get; set; }

        [DisplayName("Products")]
        public Nullable<int> idProduct { get; set; }
        [DisplayName("Employees")]
        public Nullable<int> idEmployee { get; set; }
        [DisplayName("Areas")]
        public Nullable<int> idCategory { get; set; }
        [DisplayName("Detail")]
        [DataType(DataType.MultilineText)]
        public string detail { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> upDateDate { get; set; }
        public Nullable<System.DateTime> deleteDate { get; set; }
        [DisplayName("State")]
        public string state { get; set; }
    }


    public class AssignmentBussines
    {

        #region Logic, Responces and Requests

        /// <summary>
        /// When You Need To Get Response
        /// </summary>
        public class GetAssignmentResponse
        {
            public Handler.ErrorObject Error { get; set; }
            public string Message { get; set; }
            public Assignments Assignment { get; set; }
            public List<Assignments> AssignmentList { get; set; }
            public Transactions transaction { get; set; }
        }

        /// <summary>
        /// When you Need To Specify Petition
        /// </summary>
        public class GetAssignmentRequest
        {
            public int AssignmentID { get; set; }
            public int CellarArea { get; set; }
            public int CategoryID { get; set; }
            public int ProductID { get; set; }
            public int TransactionTypeID { get; set; }
            public int amount { get; set; }
        }

        /// <summary>
        /// When you Need To Specify Petition
        /// </summary>
        public class GetAssignmentWithConditionRequest
        {
            public int AssignmentID { get; set; }
            public int ConditionID { get; set; }
            public int CategoryID { get; set; }
            public int ProductID { get; set; }
            public int TransactionTypeID { get; set; }
            public int amount { get; set; }
        }


        #endregion

        #region Select Data
        public class Select
        {

            public static GetAssignmentResponse GetAssignmentList(GetAssignmentRequest request)
            {
                GetAssignmentResponse response = new GetAssignmentResponse();
                response.AssignmentList = new List<Assignments>();
                response.Error = new Handler.ErrorObject();

                try
                {
                    var bussines = AssignmentData.Select.GetAssignmentByCategoryID(request.CategoryID);
                    if (!bussines.Item1.Error)
                    {
                        foreach (var item in bussines.Item2)
                        {
                            response.AssignmentList.Add(new Assignments()
                            {
                                id = item.id,
                                amount = item.amount,
                                detail = item.detail,
                                Max = item.max,
                                Min = item.min,                                
                                idCategory = item.idCategory,
                                idEmployee = item.idEmployee,
                                idProduct = item.idProduct,
                                loan = item.loan,
                                createDate = item.createDate,
                                upDateDate = item.upDateDate,
                                deleteDate = item.deleteDate,
                                state = item.state
                            });
                        }
                    }
                    else
                    {
                        response.Error.InfoError(bussines.Item1);
                    }
                }
                catch (Exception ex)
                {
                    response.Error.InfoError(ex);
                }
                return response;
            }

            public static GetAssignmentResponse GetAssignmentByProductID(GetAssignmentRequest request)
            {
                GetAssignmentResponse response = new GetAssignmentResponse();
                response.AssignmentList = new List<Assignments>();
                response.Error = new Handler.ErrorObject();

                try
                {
                    var bussines = AssignmentData.Select.GetAssignmentByProductID(request.ProductID);
                    if (!bussines.Item1.Error)
                    {
                        foreach (var item in bussines.Item2)
                        {
                            response.AssignmentList.Add(new Assignments()
                            {
                                id = item.id,
                                amount = item.amount,
                                detail = item.detail,
                                idCategory = item.idCategory,
                                idEmployee = item.idEmployee,
                                Min = item.min,
                                Max = item.max,
                                idProduct = item.idProduct,
                                loan = item.loan,
                                createDate = item.createDate,
                                upDateDate = item.upDateDate,
                                deleteDate = item.deleteDate,
                                state = item.state
                            });
                        }
                    }
                    else
                    {
                        response.Error.InfoError(bussines.Item1);
                    }
                }
                catch (Exception ex)
                {
                    response.Error.InfoError(ex);
                }
                return response;
            }

            public static GetAssignmentResponse GetAssignment(GetAssignmentRequest request)
            {
                GetAssignmentResponse response = new GetAssignmentResponse();
                response.Error = new Handler.ErrorObject();
                response.Assignment = new Assignments();
                try
                {
                    var bussines = AssignmentData.Select.GetAssignment(request.AssignmentID);
                    if (!bussines.Item1.Error)
                    {
                        response.Assignment = new Assignments()
                        {
                            id = bussines.Item2.id,
                            amount = bussines.Item2.amount,
                            detail = bussines.Item2.detail,
                            idCategory = bussines.Item2.idCategory,
                            idEmployee = bussines.Item2.idEmployee,
                            Max = bussines.Item2.max,
                            Min = bussines.Item2.min,
                            idProduct = bussines.Item2.idProduct,
                            loan = bussines.Item2.loan,
                            createDate = bussines.Item2.createDate,
                            upDateDate = bussines.Item2.upDateDate,
                            deleteDate = bussines.Item2.deleteDate,
                            state = bussines.Item2.state
                        };

                    }
                    else
                    {
                        response.Error.InfoError(bussines.Item1);
                    }
                }
                catch (Exception ex)
                {
                    response.Error.InfoError(ex);
                }

                return response;
            }

            public static GetAssignmentResponse GetAssignmentToProductIDAndCategory(GetAssignmentRequest request)
            {
                GetAssignmentResponse response = new GetAssignmentResponse();
                response.Error = new Handler.ErrorObject();
                response.Assignment = new Assignments();
                try
                {
                    var bussines = AssignmentData.Select.GetAssignmentByProductIDAndCategoryID(request.ProductID, request.CategoryID);
                    if (!bussines.Item1.Error)
                    {
                        response.Assignment = new Assignments()
                        {
                            id = bussines.Item2.id,
                            amount = bussines.Item2.amount,
                            detail = bussines.Item2.detail,
                            idCategory = bussines.Item2.idCategory,
                            idEmployee = bussines.Item2.idEmployee,
                            Max = bussines.Item2.max,
                            Min = bussines.Item2.min,
                            idProduct = bussines.Item2.idProduct,
                            loan = bussines.Item2.loan,
                            createDate = bussines.Item2.createDate,
                            upDateDate = bussines.Item2.upDateDate,
                            deleteDate = bussines.Item2.deleteDate,
                            state = bussines.Item2.state
                        };

                    }
                    else
                    {
                        response.Error.InfoError(bussines.Item1);
                    }
                }
                catch (Exception ex)
                {
                    response.Error.InfoError(ex);
                }

                return response;
            }

            public static GetAssignmentResponse GetAssignmentByProductIDAndCategoryID(GetAssignmentWithConditionRequest request) {
                GetAssignmentResponse response = new GetAssignmentResponse();
                response.Error = new Handler.ErrorObject();
                response.Assignment = new Assignments();
                try
                {
                    var bussines = AssignmentData.Select.GetAssignmentByProductIDAndCategoryWithCondition(request.ProductID, request.CategoryID, request.ConditionID, request.TransactionTypeID);
                    if (!bussines.Item1.Error)
                    {
                        response.Assignment = new Assignments()
                        {
                            id = bussines.Item2.id,
                            amount = bussines.Item2.amount,
                            detail = bussines.Item2.detail,
                            idCategory = bussines.Item2.idCategory,
                            idEmployee = bussines.Item2.idEmployee,
                            Max = bussines.Item2.max,
                            Min = bussines.Item2.min,
                            idProduct = bussines.Item2.idProduct,
                            loan = bussines.Item2.loan,
                            createDate = bussines.Item2.createDate,
                            upDateDate = bussines.Item2.upDateDate,
                            deleteDate = bussines.Item2.deleteDate,
                            state = bussines.Item2.state
                        };

                    }
                    else
                    {
                        response.Error.InfoError(bussines.Item1);
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
            public static GetAssignmentResponse Assignment(GetAssignmentResponse AssignmentInformation, GetAssignmentRequest request)
            {
                GetAssignmentResponse response = new GetAssignmentResponse();
                response.Error = new Handler.ErrorObject();
                try
                {
                    request.AssignmentID = Convert.ToInt16(Assignments(AssignmentInformation).Message);
                    var result = Transaction.TransactionConfigurateBussines.Insert.TransactionConfigurate(request.AssignmentID, request.TransactionTypeID, AssignmentInformation.transaction);


                    #region Cellar Update
                    CellarBussines.GetCellarRequest req = new CellarBussines.GetCellarRequest() {
                        ProductID = (int)AssignmentInformation.Assignment.idProduct,
                        CellarAreaID = (int)request.CellarArea
                    };
                    var data = CellarBussines.Select.GetCellarDataByProductIDAndCellarArea(req).Cellar;                    
                    int newAmountCellar = (int)data.amount - (int)AssignmentInformation.transaction.amount;

                    CellarBussines.GetCellarRequest requestCellar = new CellarBussines.GetCellarRequest() {
                        CellarID = data.id,
                        amount = newAmountCellar
                    };
                    CellarBussines.Update.CellarAmount(requestCellar);
                    #endregion

                    #region Condition Update
                    TransactionConfigurateBussines.Insert.ConditionBackUpdate(1, data.id, (int)AssignmentInformation.transaction.idConditionProduct, (int)AssignmentInformation.transaction.amount);
                    #endregion



                    response.Message = result.Message.ToString();
                }
                catch (Exception ex)
                {
                    response.Error.InfoError(ex);
                }
                return response;
            }
            private static GetAssignmentResponse Assignments(GetAssignmentResponse request)
            {
                GetAssignmentResponse response = new GetAssignmentResponse();
                response.Error = new Handler.ErrorObject();

                try
                {
                    tblAssignment bussines = new tblAssignment()
                    {
                        id = request.Assignment.id,
                        amount = request.Assignment.amount,
                        loan = request.Assignment.loan,
                        idProduct = request.Assignment.idProduct,
                        idEmployee = request.Assignment.idEmployee,
                        detail = request.Assignment.detail,
                        max = request.Assignment.Max,
                        min = request.Assignment.Min,
                        idCategory = request.Assignment.idCategory,
                        createDate = request.Assignment.createDate,
                        upDateDate = null,
                        deleteDate = null,
                        state = "Active"
                    };

                    var result = AssignmentData.Insert.Assignment(bussines);
                    if (result.Item1.Error)
                    {
                        response.Error.InfoError(result.Item1);
                    }
                    else
                    {
                        response.Message = result.Item2.ToString();
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
            public static GetAssignmentResponse Assignment(GetAssignmentResponse AssignmentInformation, GetAssignmentRequest request)
            {
                GetAssignmentResponse response = new GetAssignmentResponse();
                response.Error = new Handler.ErrorObject();
                try
                {
                    
                    AssignmentAmount(request);

                    var result = Transaction.TransactionConfigurateBussines.Insert.TransactionConfigurate(request.AssignmentID, request.TransactionTypeID, AssignmentInformation.transaction);

                    CellarBussines.GetCellarRequest req = new CellarBussines.GetCellarRequest()
                    {
                        ProductID = (int)AssignmentInformation.Assignment.idProduct,
                        CellarAreaID = (int)request.CellarArea
                    };
                    var data = CellarBussines.Select.GetCellarDataByProductIDAndCellarArea(req).Cellar;
                    int newAmountCellar = (int)data.amount - (int)AssignmentInformation.transaction.amount;

                    CellarBussines.GetCellarRequest requestCellar = new CellarBussines.GetCellarRequest()
                    {
                        CellarID = data.id,
                        amount = newAmountCellar
                    };
                    CellarBussines.Update.CellarAmount(requestCellar);

                    #region Condition Update
                    TransactionConfigurateBussines.Insert.ConditionBackUpdate(1, data.id, (int)AssignmentInformation.transaction.idConditionProduct, (int)AssignmentInformation.transaction.amount);
                    #endregion

                    response.Message = result.Message.ToString();
                }
                catch (Exception ex)
                {
                    response.Error.InfoError(ex);
                }
                return response;
            }

            public static GetAssignmentResponse Assignments(GetAssignmentResponse request)
            {
                GetAssignmentResponse response = new GetAssignmentResponse();
                try
                {
                    tblAssignment bussines = new tblAssignment()
                    {
                        id = request.Assignment.id,
                        amount = request.Assignment.amount,
                        detail = request.Assignment.detail,
                        idCategory = request.Assignment.idCategory,
                        idEmployee = request.Assignment.idEmployee,
                        idProduct = request.Assignment.idProduct,
                        min = request.Assignment.Min,
                        max = request.Assignment.Max,
                        loan = request.Assignment.loan,
                        createDate = request.Assignment.createDate,
                        upDateDate = request.Assignment.upDateDate,
                        deleteDate = request.Assignment.deleteDate,
                        state = request.Assignment.state
                    };

                    var result = AssignmentData.Update.Assignment(bussines);
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

            public static GetAssignmentResponse AssignmentAmount(GetAssignmentRequest request)
            {
                GetAssignmentResponse response = new GetAssignmentResponse();
                response.Error = new Handler.ErrorObject();
                try
                {
                    var result = AssignmentData.Update.AssignmentAmount(request.AssignmentID, request.amount);

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
