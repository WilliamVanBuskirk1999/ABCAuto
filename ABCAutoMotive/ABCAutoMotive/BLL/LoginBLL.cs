using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLLayer;

namespace BLL
{
    public class LoginBLL
    {
        public bool LoginUser(string user, string pass)
        {
            LoginDB db = new LoginDB();
            return db.LoginAuthentication(user, pass);
        }

        public int GetAccessLevel(string user, string pass)
        {
            LoginDB db = new LoginDB();
            return db.GetAuthenticationLevel(user,pass);
        }
    }
}
