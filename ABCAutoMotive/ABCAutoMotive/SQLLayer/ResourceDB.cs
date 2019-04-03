using DataAccess;
using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using Types;

namespace SQLLayer
{
    public class ResourceDB
    {
        #region Use Case Methods
        /// <summary>
        /// Retrieve a resource based off the resourceId
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public Resource RetrieveResource(string resourceId)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@ResourceId", resourceId, 0, SqlDbType.Int, ParameterDirection.Input));

            DAL db = new DAL();

            DataTable dt = db.ExecuteQuery("RetrieveResource", CommandType.StoredProcedure, parms);

            return PopulateResourceObjectSearch(dt.Rows[0]);
        }

        /// <summary>
        /// Get all the resource info
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public Resource RetrieveAllResourceInfo(string resourceId)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@ResourceId", resourceId, 0, SqlDbType.Int, ParameterDirection.Input));

            DAL db = new DAL();

            DataTable dt = db.ExecuteQuery("RetrieveResource", CommandType.StoredProcedure, parms);

            return PopulateResourceObject(dt.Rows[0]);
        }


        /// <summary>
        /// Populating all props of a resource object
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Resource PopulateResourceObject(DataRow row)
        {
            //Creating a new resource to return and filling it's properties with data 
            Resource resource = new Resource()
            {
                ResourceId = Convert.ToInt32(row["ResourceId"]),
                Title = row["Title"].ToString(),
                ResourceStatus = (ResourceStatus)row["Status"],
                Stock = Convert.ToInt32(row["Stock"]),
                Type = (ResourceType)row["Type"],
                Description = row["Description"].ToString(),
                Image = row["Image"].ToString(),
                ReserveStatus = (ReserveStatus)row["ReserveStatus"]

            };

            if (row["PublisherReferenceNumber"] != DBNull.Value)
            {
                resource.PublisherReferenceNumber = (PublisherReferenceNum)row["PublisherReferenceNumber"];
            }

            return resource;
        }

        /// <summary>
        /// Filling a resource object with values from a datarow. Use this one for the search
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Resource PopulateResourceObjectSearch(DataRow row)
        {
            Resource resource = new Resource()
            {
                ResourceId = Convert.ToInt32(row["ResourceId"]),
                Title = row["Title"].ToString(),
                ResourceStatus = (ResourceStatus)row["Status"],
                Type = (ResourceType)row["Type"],
                ReserveStatus = (ReserveStatus)row["ReserveStatus"]
            };

            return resource;
        }


        /// <summary>
        /// Check out a resource. Returns an int based on the success of the query
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public int CheckOutResource(List<Loans> loans)
        {
            if (loans == null || loans.Count == 0)
            {
                return 0;
            }
            int results = 0;
            foreach (Loans loan in loans)
            {
                DAL db = new DAL();
                //Setting parameters
                List<ParmStruct> parms = new List<ParmStruct>();

                parms.Add(new ParmStruct("@StudentId", loan.StudentId, 0, SqlDbType.Int, ParameterDirection.Input));
                parms.Add(new ParmStruct("@ResourceId", loan.ResourceId, 0, SqlDbType.Int, ParameterDirection.Input));
                parms.Add(new ParmStruct("@DateDue", ReturnDueDate(), 0, SqlDbType.DateTime, ParameterDirection.Input));

                //Storing the result of the query in a variable
                int result = db.ExecuteNonQuery("CheckOutResource", CommandType.StoredProcedure, parms);

                //If it queries correctly, add to the counter
                if (result > 0)
                {
                    results++;
                }
            }

            //If the amount of successful results is equal to the number of items in the list, return a success
            if (results == loans.Count)
            {
                return results;
            }
            return 0;
        }

        /// <summary>
        /// Reserve a resource for a student
        /// </summary>
        /// <param name="student"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        public int ReserveResource(Student student, Resource resource)
        {
            DAL db = new DAL();

            //Parameter list
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@StudentId", student.StudentId, 0, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@ResourceId", resource.ResourceId, 0, SqlDbType.Int, ParameterDirection.Input));

            return db.ExecuteNonQuery("ReserveResource", CommandType.StoredProcedure, parms);
        }

        /// <summary>
        /// Used to modify the resource status
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public int ChangeResourceStatus(Resource resource)
        {
            DAL db = new DAL();

            //Parameter list
            List<ParmStruct> parms = new List<ParmStruct>();

            //If the resource status is set to not available for loan, pass in a date removed
            if(resource.ResourceStatus == (ResourceStatus)2)
            {
                parms.Add(new ParmStruct("@DateRemoved", DateTime.Now, 0, SqlDbType.DateTime, ParameterDirection.Input));
            }

            parms.Add(new ParmStruct("@Status", (int)resource.ResourceStatus, 0, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@ResourceId", resource.ResourceId, 0, SqlDbType.Int, ParameterDirection.Input));

            return db.ExecuteNonQuery("ChangeResourceStatus", CommandType.StoredProcedure, parms);
        }

        public int AddResource(Resource resource)
        {
            DAL db = new DAL();

            //Parameter list
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@Title", resource.Title, 20, SqlDbType.NVarChar, ParameterDirection.Input));
            parms.Add(new ParmStruct("@Status", (int)resource.ResourceStatus, 0, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@Price", resource.Price, 0, SqlDbType.Decimal, ParameterDirection.Input));
            parms.Add(new ParmStruct("@Publisher", resource.Publisher, 40, SqlDbType.NVarChar, ParameterDirection.Input));
            parms.Add(new ParmStruct("@DateAdded", resource.DateAdded, 0, SqlDbType.DateTime, ParameterDirection.Input));
            parms.Add(new ParmStruct("@Description", resource.Description, int.MaxValue, SqlDbType.NText, ParameterDirection.Input));
            parms.Add(new ParmStruct("@Type", (int)resource.Type, 0, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@Image", resource.Image, 20, SqlDbType.VarChar, ParameterDirection.Input));

            if (resource.PublisherReferenceNumber == (PublisherReferenceNum)0 || resource.PublisherReferenceNumber == (PublisherReferenceNum)1 ||
                resource.PublisherReferenceNumber == (PublisherReferenceNum)2)
            {
                parms.Add(new ParmStruct("@PublisherReferenceNumber", (int)resource.PublisherReferenceNumber, 0, SqlDbType.Int, ParameterDirection.Input));
            }

            int result = db.ExecuteNonQuery("AddResource", CommandType.StoredProcedure, parms);

            return result;
        }
        #endregion
        #region Other
        /// <summary>
        /// Check to see if they're signing a resource out on thursday or friday, if they are, make sure you don't include the weekend in due dates
        /// </summary>
        /// <returns></returns>
        private DateTime ReturnDueDate()
        {
            DateTime now = DateTime.Now;

            if (now.DayOfWeek == DayOfWeek.Thursday)
            {
                //If it's thursday add 4 days to set the due date on monday
                return now.AddDays(4);
            }
            else if (now.DayOfWeek == DayOfWeek.Friday)
            {
                return now.AddDays(4);
            }

            return now.AddDays(2);
        }


        #endregion

        #region Validations

        /// <summary>
        /// Querying the database to check if a student has any overdue items
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        //public decimal CheckForOverdueItems(Student student)
        //{
        //    DAL db = new DAL();

        //    //Creating a list for parameters
        //    List<ParmStruct> parms = new List<ParmStruct>();

        //    parms.Add(new ParmStruct("@StudentId", student.StudentId, 0, SqlDbType.Int, ParameterDirection.Input));

        //    object overDue = db.ExecuteScaler("CheckIfStudentHasOverDueBalance", CommandType.StoredProcedure, parms);

        //    if (overDue == null || overDue == DBNull.Value)
        //    {
        //        return 0;
        //    }

        //    return (decimal)overDue;

        //}

        #endregion
    }
}

