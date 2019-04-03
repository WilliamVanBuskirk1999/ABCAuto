using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;
using SQLLayer;

namespace BLL
{
    public class OverDueChargeBLL
    {
        public List<OverDueCharge> GetOverDueCharges()
        {
            OverDueChargesDB db = new OverDueChargesDB();
            return db.ReturnOverDueLoans();
        }

        public bool ChargeStudent(List<OverDueCharge> charges)
        {
            OverDueChargesDB db = new OverDueChargesDB();
            return db.ChargeStudents(charges);
        }
    }
}
