using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    [AllowAnonymous]    
    public class ChronoController : Controller
    {
        // GET: Chrono
        public ActionResult Index()
        {
            return View();
        }
    }
}