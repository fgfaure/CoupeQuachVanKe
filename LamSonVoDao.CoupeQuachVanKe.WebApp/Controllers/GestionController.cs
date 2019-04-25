using LamSonVoDao.CoupeQuachVanKe.AccesPattern;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    public class GestionController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Gestion
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetDetails(string id)
        {
            int parsed;

            if (int.TryParse(id, out parsed))
            {
                var participations = this.unitOfWork.Repository<Participation>().Read();
                var epreuves = this.unitOfWork.Repository<Epreuve>().Read(e => e.Statut == (StatutEpreuve)parsed);
                var query = from epreuve in epreuves
                            select new { Nom = epreuve.Nom, Participants = (epreuve.Participations != null && epreuve.Participations.Count > 0) ? epreuve.Participations.Count : 0 };
                var result = new JsonResult();
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                result.Data = query.ToList();
                return result;

            }
            else
            {
                throw new ArgumentException("parameter is not valid.");
            }
        }
        [HttpGet]
        public JsonResult GetEpreuveStatut()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var epreuvesRepo = this.unitOfWork.Repository<Epreuve>();

            var epreuves = epreuvesRepo.Read();

            var counted = from epreuve in epreuves.Where(e => e.Statut != StatutEpreuve.Exclue && e.Statut != StatutEpreuve.Fermee)
                          group epreuve by epreuve.Statut into res
                          orderby res.Key
                          select new { Statut = res.Key, EpreuveStatut = StatutEpreuves.ResourceManager.GetString(((StatutEpreuve)res.Key).ToString()), Count = res.Count(), Couleur = ColorChoice((StatutEpreuve)res.Key) };
            result.Data = counted.OrderBy(a => a.Statut);
            return result;
        }

        private string ColorChoice(StatutEpreuve statutEpreuve)
        {
            var result = "#b12b2b";

            switch (statutEpreuve)
            {
                case StatutEpreuve.Assignee:
                    result = "#00609f";
                    break;
                case StatutEpreuve.EnCours:
                    result = "#00b14f";
                    break;
                case StatutEpreuve.Ouverte:
                    result = "#0000ff";
                    break;
                case StatutEpreuve.Prete:
                    result = "#00857a";
                    break;
                case StatutEpreuve.Terminee:
                    result = "#00ff00";
                    break;
            }

            return result;
        }

    }
}