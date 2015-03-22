﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(LamSonVoDao.CoupeQuachVanKe.WebApp.Startup))]

namespace LamSonVoDao.CoupeQuachVanKe.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
           {
               AuthenticationType = "ApplicationCookie",
               LoginPath = new PathString("/auth/login")
           });
        }
    }
}
