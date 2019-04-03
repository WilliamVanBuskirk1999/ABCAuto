using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Types;

namespace DataAccess
{
    public class DAL
    {
        public DataSet ExecuteQuery(string sql, CommandType cmdType, List<ParmStruct> parms)
        {
            SqlConnection cnn = new SqlConnection(Properties.Settings.Default.cnnString);

            SqlCommand cmd = CreateCommand(sql, cmdType, parms);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds= new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet ExecuteQueryDS(string sql, CommandType cmdType, List<ParmStruct> parms)
        {
            SqlConnection cnn = new SqlConnection(Properties.Settings.Default.cnnString);

            SqlCommand cmd = CreateCommand(sql, cmdType, parms);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int ExecuteNonQuery(string sql, CommandType cmdType, List<ParmStruct> parmesan)
        {
            SqlCommand cmd = CreateCommand(sql, cmdType, parmesan);
            int result;

            using (cmd.Connection)
            {
                cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
            }

            if (parmesan[0].Direction == ParameterDirection.Output)
            {
                result = Convert.ToInt32(cmd.Parameters[0].Value);
            }
            return result;
        }

        public SqlCommand CreateCommand(string sql, CommandType cmdType, List<ParmStruct> parms)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = cmdType;

            //If the parms list exists, fill it with parameters
            if (parms != null)
            {
                foreach (ParmStruct parm in parms)
                {
                    cmd.Parameters.Add(new SqlParameter(parm.Name, parm.DataType, parm.Size));
                    cmd.Parameters[parm.Name].Value = parm.Value;
                    cmd.Parameters[parm.Name].Direction = parm.Direction;

                }
            }

            return cmd;
        }

        public object ExecuteScaler(string sql, CommandType cmdType, List<ParmStruct> parms = null)
        {
            SqlCommand cmd = CreateCommand(sql, cmdType, parms);
            cmd.Connection.Open();
            object retVal = cmd.ExecuteScalar();
            cmd.Connection.Close();
            return retVal;
        }
    }
}
