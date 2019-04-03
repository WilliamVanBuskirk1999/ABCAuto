using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Types;

namespace SQLLayer
{
    public class StudentsDB
    {
        #region CRUD
        public Student GetStudentById(string studentId)
        {
            DAL db = new DAL();
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@StudentId", studentId, 0, SqlDbType.Int, ParameterDirection.Input));

            DataTable dt = db.ExecuteQuery("RetrieveStudent", CommandType.StoredProcedure, parms);

            return PopulateStudentObject(dt.Rows[0]);

        }

        private Student PopulateStudentObject(DataRow row)
        {
            Student s = new Student();
            s.StudentId = Convert.ToInt32(row["StudentId"]);
            s.Address = row["Address"].ToString();
            s.Status = (StudentStatus)row["Status"];
            s.FirstName = row["FirstName"].ToString();
            s.LastName = row["LastName"].ToString();
            s.StartDate = (DateTime)row["StartDate"];

            s.EndDate = (DateTime)row["EndDate"];

            s.EndDate = DateTime.MaxValue.AddYears(-5000);
            s.AmountDue = Convert.ToDecimal(row["AmountDue"]);
            s.Program = (ProgramOptions)row["Program"];
            s.City = row["City"].ToString();
            s.TelephoneNumber = row["TelephoneNumber"].ToString();
            s.PostalCode = row["PostalCode"].ToString();


            return s;
        }

        /// <summary>
        /// Insert a student into the students table
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int InsertStudent(Student student)
        {
            //Creating a Dataaccess object so we can execute the command later
            DAL db = new DAL();

            //Getting the year the student joined so that we can create a proper student Id
            string yearStudentJoined = "";
            yearStudentJoined = student.StartDate.Year.ToString() + "0000";

            //Converting it to an int
            int newIdTemplate = Convert.ToInt32(yearStudentJoined);
            int counter = 1;

            //Getting the Id
            int newId = newIdTemplate + counter;

            //Setting up a command to ensure that the student id doesn't already exist
            List<ParmStruct> studentId = new List<ParmStruct>();
            studentId.Add(new ParmStruct("@StudentId", newId, 0, SqlDbType.Int, ParameterDirection.Input));

            //Using a command to check if the student id exists
            SqlCommand cmd = db.CreateCommand("SELECT * from Students WHERE StudentId = @StudentId", CommandType.Text, studentId);
            DataTable dt = new DataTable();

            //Filling a datatable with results
            cmd.Connection.Open();
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                dt.Load(dr);
            }
            cmd.Connection.Close();

            //If a row is returned we know that the Id already exists
            while (dt.Rows.Count == 1)
            {
                //Up tick the counter
                counter += 1;

                //Set the newId 
                newId = newIdTemplate + counter;

                studentId = new List<ParmStruct>();
                studentId.Add(new ParmStruct("@StudentId", newId, 0, SqlDbType.Int, ParameterDirection.Input));

                cmd = db.CreateCommand("SELECT * from Students WHERE StudentId = @StudentId", CommandType.Text, studentId);
                cmd.Connection.Open();

                //Emptying previous datatable
                dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);
                }
                cmd.Connection.Close();
            }


            //Creating parameters
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@StudentId", newId, 0, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@Status", (int)student.Status, 20, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@FirstName", student.FirstName, 20, SqlDbType.VarChar, ParameterDirection.Input));
            parms.Add(new ParmStruct("@LastName", student.LastName, 30, SqlDbType.VarChar, ParameterDirection.Input));
            parms.Add(new ParmStruct("@StartDate", student.StartDate, 0, SqlDbType.Date, ParameterDirection.Input));
            parms.Add(new ParmStruct("@EndDate", student.EndDate, 0, SqlDbType.Date, ParameterDirection.Input));
            parms.Add(new ParmStruct("@Program", (int)student.Program, 0, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@Address", student.Address, 30, SqlDbType.VarChar, ParameterDirection.Input));
            parms.Add(new ParmStruct("@City", student.City, 30, SqlDbType.VarChar, ParameterDirection.Input));
            parms.Add(new ParmStruct("@PostalCode", student.PostalCode, 10, SqlDbType.VarChar, ParameterDirection.Input));
            parms.Add(new ParmStruct("@TelephoneNumber", student.TelephoneNumber, 15, SqlDbType.VarChar, ParameterDirection.Input));

            int result = db.ExecuteNonQuery("AddStudent", CommandType.StoredProcedure, parms);

            return result;
        }

        /// <summary>
        /// Deletes a student based on the student ID passed in
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int DeleteStudent(Student student)
        {
            //Creating a Dataaccess object so we can execute the command later
            DAL db = new DAL();

            //Creating parameters
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@StudentId", student.StudentId, 0, SqlDbType.Int, ParameterDirection.Input));

            int result = db.ExecuteNonQuery("DeleteStudent", CommandType.StoredProcedure, parms);

            return result;
        }

        /// <summary>
        /// Updates a student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int UpdateStudent(Student student)
        {
            //Creating a Dataaccess object so we can execute the command later
            DAL db = new DAL();

            //Creating parameters
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@StudentId", student.StudentId, 0, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@Status", (int)student.Status, 20, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@FirstName", student.FirstName, 20, SqlDbType.VarChar, ParameterDirection.Input));
            parms.Add(new ParmStruct("@LastName", student.LastName, 30, SqlDbType.VarChar, ParameterDirection.Input));
            parms.Add(new ParmStruct("@StartDate", student.StartDate, 0, SqlDbType.Date, ParameterDirection.Input));
            parms.Add(new ParmStruct("@EndDate", student.EndDate, 0, SqlDbType.Date, ParameterDirection.Input));
            parms.Add(new ParmStruct("@Program", (int)student.Program, 0, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@Address", student.Address, 30, SqlDbType.VarChar, ParameterDirection.Input));
            parms.Add(new ParmStruct("@City", student.City, 30, SqlDbType.VarChar, ParameterDirection.Input));
            parms.Add(new ParmStruct("@PostalCode", student.PostalCode, 10, SqlDbType.VarChar, ParameterDirection.Input));
            parms.Add(new ParmStruct("@TelephoneNumber", student.TelephoneNumber, 15, SqlDbType.VarChar, ParameterDirection.Input));

            return db.ExecuteNonQuery("UpdateStudent", CommandType.StoredProcedure, parms);
        }

        /// <summary>
        /// Gets the student based on the resourceId of the resource being searched for. 
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public Student GetStudentCheckingInResource(string resourceId)
        {
            //Creating a Dataaccess object so we can execute the command later
            DAL db = new DAL();

            //Creating parameters
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@ResourceId", resourceId, 0, SqlDbType.Int, ParameterDirection.Input));

            DataTable dt = db.ExecuteQuery("GetStudentCheckingInResource", CommandType.StoredProcedure, parms);

            if (dt.Rows.Count > 0)
            {
                return PopulateStudentForCheckIn(dt.Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// Make a payment for a student. Adds to the payment table, and updates the amountdue for a student
        /// </summary>
        /// <param name="student"></param>
        /// <param name="paymentAmount"></param>
        /// <returns></returns>
        public int MakePayments(Student student, decimal paymentAmount)
        {
            //Creating a Dataaccess object so we can execute the command later
            DAL db = new DAL();

            //Creating parameters
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@StudentId", student.StudentId, 0, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@PaymentAmount", paymentAmount, 0, SqlDbType.Decimal, ParameterDirection.Input));

            return db.ExecuteNonQuery("MakePayment", CommandType.StoredProcedure, parms);
        }

        /// <summary>
        /// Populating the student object with info for the check in
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Student PopulateStudentForCheckIn(DataRow row)
        {
            Student s = new Student();

            s.StudentId = Convert.ToInt32(row["StudentId"]);
            s.Status = (StudentStatus)row["Status"];
            s.FirstName = row["FirstName"].ToString();
            s.LastName = row["LastName"].ToString();
            s.StartDate = (DateTime)row["StartDate"];
            //If there is an EndDate, assign it. Otherwise, just give it a random value
            if (row["EndDate"] != null && row["EndDate"] != DBNull.Value)
            {
                s.EndDate = (DateTime)row["EndDate"];
            }
            s.EndDate = DateTime.MaxValue.AddYears(-5000);
            s.AmountDue = Convert.ToDecimal(row["AmountDue"]);
            s.Program = (ProgramOptions)row["Program"];

            return s;

        }
        #endregion

        #region Validation Checks

        /// <summary>
        /// Check to see if records for this student exist, if they do you cannot delete this student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public bool CheckIfStudentWasMadeInError(Student student)
        {
            DAL db = new DAL();

            //Creating parameter
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@StudentId", student.StudentId, 0, SqlDbType.Int, ParameterDirection.Input));

            //Check to see if rows exist in other tables for this student
            SqlCommand cmd = db.CreateCommand("SELECT COUNT(*) from Loans WHERE StudentId = @StudentId", CommandType.Text, parms);

            cmd.Connection.Open();
            int result1 = (int)cmd.ExecuteScalar();
            cmd.Connection.Close();


            cmd = db.CreateCommand("SELECT COUNT(*) FROM Resources WHERE StudentId = @StudentId", CommandType.Text, parms);

            cmd.Connection.Open();
            int result2 = (int)cmd.ExecuteScalar();
            cmd.Connection.Close();

            if (result1 > 0 || result2 > 0)
            {
                return false;
            }
            return true;
        }

        #endregion
    }
}
