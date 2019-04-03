using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Model.Entities;
using Types;

namespace SQLLayer
{
    public class OverDueChargesDB
    {
        /// <summary>
        /// Gets back info about overdue charges
        /// </summary>
        /// <returns></returns>
        public List<OverDueCharge> ReturnOverDueLoans()
        {
            //Creating a list of overduecharges to return
            List<OverDueCharge> overDueItems = new List<OverDueCharge>();

            //Creating an instance of the dataaccess layer
            DAL db = new DAL();

            //Filling datatable with results
            DataTable dt = new DataTable();

            dt = db.ExecuteQuery("GetOverDueLoans", CommandType.StoredProcedure, null);

            foreach(DataRow row in dt.Rows)
            {
                OverDueCharge charge = new OverDueCharge();

                charge.ResourceId = Convert.ToInt32(row["ResourceId"]);
                charge.Price = Convert.ToDecimal(row["Price"]);
                charge.ResourceDescription = row["Description"].ToString();
                charge.ResourceType = (ResourceType)row["Type"];
                charge.StudentId = Convert.ToInt32(row["StudentId"]);
                charge.StudentName = row["FullName"].ToString();

                overDueItems.Add(charge);
            }

            return overDueItems;

            
        }

        public bool ChargeStudents(List<OverDueCharge> charges)
        {
            //Creating an instance of the dataaccess layer
            DAL db = new DAL();

            //Parameter list
            List<ParmStruct> parms = new List<ParmStruct>();

            //Setting a result variable 
            int result = 0;

            //Looping through the list of charges, for each one excuting the sproc to charge that specific student
            foreach (OverDueCharge charge in charges)
            {
                parms = new List<ParmStruct>();
                parms.Add(new ParmStruct("@StudentId", charge.StudentId, 0, SqlDbType.Int, ParameterDirection.Input));
                parms.Add(new ParmStruct("@Price", charge.Price,0,SqlDbType.Decimal,ParameterDirection.Input));
                parms.Add(new ParmStruct("@ResourceId", charge.ResourceId, 0, SqlDbType.Int, ParameterDirection.Input));

                result += db.ExecuteNonQuery("ChargeOverDueFees", CommandType.StoredProcedure, parms);

            }

            if(result == charges.Count * 3)
            {
                return true;
            }
            return false;
        }
    }
}
