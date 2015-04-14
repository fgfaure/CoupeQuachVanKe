using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using LamSonVoDao.CoupeQuachVanKe.EntityFrameworkBase2Model;

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
            using (var context = new CoupeQVK2Container())
            {
                var competiteurs = context.Competiteurs.Include(c => c.Participations.Select(p => p.Resultat)).ToList();                

                result.Data = competiteurs.Select(c => new
                {
                    Nom = c.Nom,
                    Prenom = c.Prenom,
                    EpreuvesId = c.Participations.Where(r => r.Epreuve.Id == c.Id).Select(r => new { rId = r.Epreuve.Id })
                }).ToList();
            }
            return result;
        }
    }
}