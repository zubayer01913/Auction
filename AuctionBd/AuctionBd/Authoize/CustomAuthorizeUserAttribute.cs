using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionBd.Authoize
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizeUserAttribute : AuthorizeAttribute
    {
        public bool MyFalg { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }

            if (MyFalg)
            {
                //Do something
            }

            if (Users.Split(',').Contains(httpContext.User.Identity.Name.ToString()))
                return true;
            else
                return false;
        }
    }
}