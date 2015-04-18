using LamSonVoDao.CoupeQuachVanKe.AccesPattern;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_End(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session_End");
            UnitOfWork unitOfWork = new UnitOfWork();            
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            var dbitem = unitOfWork.Repository<NetClient>().Read(nc => nc.ClientLogInName == authManager.User.Claims.First().Value).FirstOrDefault();
            if (dbitem != null)
            {
                dbitem.IsConnected = false;
                unitOfWork.Repository<NetClient>().Update(dbitem);
            }
        }
    }
}
