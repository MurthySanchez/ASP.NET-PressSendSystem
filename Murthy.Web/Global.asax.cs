using Murthy.Web.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Murthy.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["user_sessions"] = 0;
            Application["clickCount"] = 0;
            Application["chatcon"] = "";
            Application.UnLock();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //VerificationCode verificationCode = new VerificationCode();
            //verificationCode.
            Session["ValidateNum"] = "";
            Session["username"] = "";
            Session["userid"] = "";
            Session["tmpUsername"] = "";
            Application.Lock();
            Application["user_sessions"] = (int)Application["user_sessions"] + 1;
            Application.UnLock();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["user_sessions"] = (int)Application["user_sessions"] - 1;
            Application.UnLock();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            
        }
    }
}