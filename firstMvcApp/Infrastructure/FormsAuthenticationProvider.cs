using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace firstMvcApp.Infrastructure
{
    public class FormsAuthenticationProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password, bool rememberMe)
        {
            bool status = false;
            if (username == "abcd" && password == "abcde")
                status = true;

            if (status)
            {
                System.Web.Security.FormsAuthentication.SetAuthCookie(username, rememberMe);
            }
            return status;
        }
    }
}