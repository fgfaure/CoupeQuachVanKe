﻿namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class SatelliteController : Controller
    {
        // GET: Satellite
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EpreuveTechnique()
        {
            return View("EpreuveTechnique");
        }

        public ActionResult EpreuveCombat()
        {
            return View();
        }
    }
}