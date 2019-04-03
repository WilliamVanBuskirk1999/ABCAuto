using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Model;
using Model.Entities;
using Types;
using System.Data;
using System.Data.SqlClient;

namespace SQLLayer
{
    public class LoanDB
    {
        
        /// <summary>
        /// Getting a specific students loan info
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public DataTable RetrieveLoanInfo(Student student)
        {
            DAL db = new DAL();

            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@StudentId", student.StudentId, 0, SqlDbType.Int, ParameterDirection.Input));

            DataTable dt = db.ExecuteQuery("GetLoanInfo", CommandType.StoredProcedure, parms);

            //Cloning the datatable so I can change the datatype of the type column
            DataTable dtCloned = dt.Clone();

            //Changing the datatype of the type columns rows
            dtCloned.Columns["Type"].DataType = typeof(ResourceType);
            

            foreach (DataRow row in dt.Rows)
            {
                dtCloned.ImportRow(row);

                
            }

            return dtCloned;
        }

        /// <summary>
        /// Checking in a list of resources
        /// </summary>
        /// <param name="loans"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        public int CheckInResources(List<Loans> loans, Student student)
        {
            int result = 0;

            DAL db = new DAL();

            List<ParmStruct> parms = new List<ParmStruct>();

           

            foreach(Loans loan in loans)
            {
                parms = new List<ParmStruct>();

                parms.Add(new ParmStruct("@ResourceId", loan.ResourceId, 0, SqlDbType.Int, ParameterDirection.Input));
                parms.Add(new ParmStruct("@StudentId", student.StudentId, 0, SqlDbType.Int, ParameterDirection.Input));
                parms.Add(new ParmStruct("@Status", (int)loan.ResourceStatus, 0, SqlDbType.Int, ParameterDirection.Input));
                parms.Add(new ParmStruct("@LoanStatus", (int)loan.LoanStatus, 0, SqlDbType.Int, ParameterDirection.Input));
                parms.Add(new ParmStruct("@DateReturned", loan.CheckInDate, 0, SqlDbType.DateTime, ParameterDirection.Input));
                parms.Add(new ParmStruct("@DateRemoved", loan.DateRemoved, 0, SqlDbType.DateTime, ParameterDirection.Input));
                parms.Add(new ParmStruct("@OverDueCharge", CalculateOverDueCharge(loan), 0, SqlDbType.Decimal, ParameterDirection.Input));
                

                result += db.ExecuteNonQuery("CheckInResource", CommandType.StoredProcedure, parms);
            }

            //If the amount of successful executions of the query is equal to the count of loans in the list, return a 1 to indicate success
            if(result == loans.Count * 3) //We multiply by three because three records for each loand are affected
            {
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// Calculating whether or not the user has an overdue charge
        /// </summary>
        /// <param name="loan"></param>
        /// <returns></returns>
        private decimal CalculateOverDueCharge(Loans loan)
        {
            if (loan.DueDate < DateTime.Now)
            {
                double daysLate = (loan.DueDate - DateTime.Now).TotalDays;

                //Had to multiply days late by negative one because it was returning negative
                decimal overDueCharge = Convert.ToDecimal((daysLate * -1) * 5);

                //Rounding to two decimals
                return Math.Round(overDueCharge, 2);
            }

            return 0;
        }



        /// <summary>
        /// Retrieves the list of currently signed out resources of the student trying to check in an item
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>

        public DataTable RetrieveResourcesStudentCheckedOut(string resourceId, Student student)
        {
            //Creating a list of resources to retrun
            List<Loans> resourcesStudentLoaned = new List<Loans>();

            //Creating a list of parameter
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@ResourceId", resourceId, 0, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@StudentId", student.StudentId, 0, SqlDbType.Int, ParameterDirection.Input));

            DAL db = new DAL();

            DataTable dt = db.ExecuteQuery("GetResourcesStudentCheckedOut", CommandType.StoredProcedure, parms);

            return dt;

        }

        /// <summary>
        /// Gets a list of loans based of a datatable
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<Loans> GetListOfLoans(DataTable dt)
        {
            List<Loans> loans = new List<Loans>();

            foreach(DataRow row in dt.Rows)
            {
                Loans loan = new Loans()
                {
                    ResourceId = Convert.ToInt32(row["ResourceId"]),
                    Title = row["Title"].ToString(),
                    ResourceStatus = (ResourceStatus)row["Status"],
                    Type = (ResourceType)row["Type"],
                    CheckOutDate = Convert.ToDateTime(row["CheckOutDate"]),
                    DueDate = Convert.ToDateTime(row["DueDate"]),
                    LoanStatus = (LoanStatus)row["LoanStatus"]
                    
                };

                loans.Add(loan);
            }

            return loans;
        }


        #region Validation
        /// <summary>
        /// Checks to see if a student already signed out a resource of this type
        /// </summary>
        /// <param name="student"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        public int ReturnStudentLoanTypes(Student student, Resource resource)
        {

            DAL db = new DAL();

            //Creating a list for parameters
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@StudentId", student.StudentId, 0, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@ResourceType", Convert.ToInt32(resource.Type), 0, SqlDbType.Int, ParameterDirection.Input));

            object result = db.ExecuteScaler("CheckIfStudentHasResourceType", CommandType.StoredProcedure, parms);

            if (result == null || result == DBNull.Value)
            {
                return -1;
            }

            return (int)result;
        }

        /// <summary>
        /// Querying the database to check if a student has any overdue items
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public decimal CheckForOverdueItems(Student student)
        {
            DAL db = new DAL();

            //Creating a list for parameters
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@StudentId", student.StudentId, 0, SqlDbType.Int, ParameterDirection.Input));

            object overDue = db.ExecuteScaler("CheckIfStudentHasOverDueBalance", CommandType.StoredProcedure, parms);

            if (overDue == null || overDue == DBNull.Value)
            {
                return 0;
            }

            return (decimal)overDue;

        }


        /// <summary>
        /// Gets whether or not the student is active or not
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>

        public int ReturnStudentActivityStatus(Student student)
        {
            DAL db = new DAL();

            //Creating a list for parameters
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@StudentId", student.StudentId, 0, SqlDbType.Int, ParameterDirection.Input));

            //Creating query
            SqlCommand cmd = db.CreateCommand("SELECT Status FROM Students WHERE StudentId = @StudentId", CommandType.Text, parms);

            cmd.Connection.Open();
            int result = (int)cmd.ExecuteScalar();
            cmd.Connection.Close();

            return result;
        }

        /// <summary>
        /// If this resource is reserved, check that the student trying to check it out is the one who reserved it
        /// </summary>
        /// <param name="student"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        public int ReturnIfStudentHasThisResourceReserved(Student student,Resource resource)
        {
            if (ReturnIfResourceIsReserved(resource) == 0)
            {
                //If the resource is reserved, ensure this student is the one who reserved it
                DAL db = new DAL();

                //Creating a list for parameters
                List<ParmStruct> parms = new List<ParmStruct>();

                parms.Add(new ParmStruct("@StudentId", student.StudentId, 0, SqlDbType.Int, ParameterDirection.Input));
                parms.Add(new ParmStruct("@ResourceId", resource.ResourceId, 0, SqlDbType.Int, ParameterDirection.Input));

                return (int)db.ExecuteScaler("CheckIfStudentHasResourceReserved", CommandType.StoredProcedure, parms);
            }

            return 1;
        }

        private int ReturnIfResourceIsReserved(Resource resource)
        {
            //If the resource is reserved, ensure this student is the one who reserved it
            DAL db = new DAL();

            //Creating a list for parameters
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@ResourceId", resource.ResourceId, 0, SqlDbType.Int, ParameterDirection.Input));

            //Creating a command
            SqlCommand cmd = db.CreateCommand("SELECT ReserveStatus FROM Resources WHERE ResourceId = @ResourceId", CommandType.Text, parms);

            cmd.Connection.Open();
            object result = cmd.ExecuteScalar();
            cmd.Connection.Close();

            return (int)result;
        }
        #endregion
    }
}
