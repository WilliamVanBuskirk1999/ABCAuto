using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Types;
using DataAccess;
using System.Data.SqlClient;

namespace SQLLayer
{
    public class LoginDB
    {
        public bool LoginAuthentication(string username, string password)
        {
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@UserName", username, 40, SqlDbType.NVarChar, ParameterDirection.Input));
            parms.Add(new ParmStruct("@Password", password, 40, SqlDbType.NVarChar, ParameterDirection.Input));

            DAL dal = new DAL();

            DataTable dt = dal.ExecuteQuery("Login", CommandType.StoredProcedure, parms);

            if(dt.Rows.Count == 1)
            {
                return true;
            }
            return false;
        }

        public int GetAuthenticationLevel(string username, string password)
        {
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@UserName", username, 40, SqlDbType.NVarChar, ParameterDirection.Input));
            parms.Add(new ParmStruct("@Password", password, 40, SqlDbType.NVarChar, ParameterDirection.Input));

            DAL DB = new DAL();

            SqlCommand cmd = DB.CreateCommand("SELECT CAST(AccessLevel AS INT) from Authenticate WHERE UserName = @UserName AND Password = @Password", CommandType.Text, parms);

            cmd.Connection.Open();
            int accessLevel = (int)cmd.ExecuteScalar();
            cmd.Connection.Close();

            return accessLevel;

        }
    }
}
