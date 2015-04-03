using LamSonVoDao.CoupeQuachVanKe.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    public class EpreuveVentileeController : Controller
    {
        // GET: EpreuvesVentilees
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Get()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            using (var context = new CoupeQuachVanKeContext())
            {
                var competiteurs = context.Competiteurs.Include(c => c.Resultats);
                var resultats = context.Resultats.Include(r => r.Epreuve);

                result.Data = competiteurs.Select(c => new
                {
                    Nom = c.Nom,
                    Prenom = c.Prenom,
                    EpreuvesId = c.Resultats.Where(r => r.CompetiteurId == c.Id).Select(r => new { rId = r.EpreuveId })
                }).ToList();
            }
            return result;
        }
    }
}