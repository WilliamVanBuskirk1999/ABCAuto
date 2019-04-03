using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Types;
using Model.Lists;
using System.Data;
using Model;

namespace SQLLayer
{
    public class SearchDB
    {
        
        /// <summary>
        /// Search for a student based on the passed in parameter
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public List<StudentLookup> SearchForStudent(string parameter)
        {
            //Filling the datatable with results from the search query
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@SearchParam", parameter, 30, SqlDbType.NVarChar, ParameterDirection.Input));
            DAL dataAccess = new DAL();

            DataTable dt = dataAccess.ExecuteQuery("SearchForStudent", CommandType.StoredProcedure, parms);

            //Making a list of lookups
            List<StudentLookup> students = new List<StudentLookup>();

            foreach(DataRow row in dt.Rows)
            {
                StudentLookup student = new StudentLookup();

                student.FullName = row["FirstName"].ToString() + " " + row["LastName"].ToString();
                student.StudentId = Convert.ToInt32(row["StudentId"]);

                students.Add(student);
            }

            return students;


        }

        /// <summary>
        /// Gets the resource based on a search parameter
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public List<ResourceLookup> SearchForResource(string parameter)
        {
            //Filling the datatable with results from the search query
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@SearchParam", parameter, 40, SqlDbType.NVarChar, ParameterDirection.Input));

            DAL dataAccess = new DAL();

            DataTable dt = dataAccess.ExecuteQuery("SearchForResource", CommandType.StoredProcedure, parms);

            List<ResourceLookup> resources = new List<ResourceLookup>();

            foreach(DataRow row in dt.Rows)
            {
                ResourceLookup resource = new ResourceLookup();

                resource.ResourceId = Convert.ToInt32(row["ResourceId"]);
                resource.Title = row["Title"].ToString();

                resources.Add(resource);

            }

            return resources;


        }

       


       
    }
}
