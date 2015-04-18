using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using LamSonVoDao.CoupeQuachVanKe.AccesPattern;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    public class EpreuveVentileeController : Controller
    {
        private Repository<Participation>  participations;
        private Repository<Competiteur> competiteurs;
        private UnitOfWork unitOfWork = new UnitOfWork();
        
        public EpreuveVentileeController()
        {
            this.competiteurs = this.unitOfWork.Repository<Competiteur>();
            this.participations = this.unitOfWork.Repository<Participation>();
        }

        // GET: EpreuvesVentilees
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Get()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                          
                result.Data = competiteurs.Read().Select(c => new
                {
                    Nom = c.Nom,
                    Prenom = c.Prenom,
                    EpreuvesId = participations.Read().Where(r => r.CompetiteurId == c.Id).Select(r => new { rId = r.EpreuveId })
                }).ToList();
           
            return result;
        }
    }
}