using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace SocialTap
{
    public class Autentification
    {
        public Boolean CheckLogin(string username, string password)
        {
            Boolean loginValidation = Membership.ValidateUser(username, password);
            if (loginValidation)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        private Boolean Register(string username, string password)
        {
            try
            {
                MembershipUser user;
                user = Membership.CreateUser(username, password);
                return true;
            }
            catch (MembershipCreateUserException)
            {
                return false;
            }
        }
    }
}
