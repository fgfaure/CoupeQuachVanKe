using LamSonVoDao.CoupeQuachVanKe.AccesPattern;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Helper;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
using Resources;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    public class AffectationController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<Aire> tapis;
        private Repository<EpreuveTechnique> techniques;
        private Repository<EpreuveCombat> combat;
        private Repository<Epreuve> epreuves;
        private Repository<NetClient> clients;
        private Repository<Participation> participations;

        public AffectationController()
        {
            this.tapis = this.unitOfWork.Repository<Aire>();
            this.techniques = this.unitOfWork.Repository<EpreuveTechnique>();
            this.combat = this.unitOfWork.Repository<EpreuveCombat>();
            this.epreuves = this.unitOfWork.Repository<Epreuve>();
            this.clients = this.unitOfWork.Repository<NetClient>();
            this.participations = this.unitOfWork.Repository<Participation>();
        }


        // GET: Affectation
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Get()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var tapis = this.tapis.Read().Where(t => t.Epreuves == null || t.Epreuves.Count(e => e.Statut == StatutEpreuve.Terminee || e.Statut == StatutEpreuve.Assignee) == t.Epreuves.Count).Select(t => t.ToModel());          
            result.Data = tapis;
            return result;
        }


        public JsonResult GetEpreuvesDisponibles()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var epreuves = this.epreuves.Read(e => e.Statut == StatutEpreuve.Ouverte).Where(e => this.participations.Read().Where(p => p.EpreuveId == e.Id && e.Statut == StatutEpreuve.Ouverte).Count() > 0).Select(e => new { value = e.Id, text = e.Nom });
            result.Data = epreuves;
            return result;
        }
        [HttpPost]
        public JsonResult CreateLink(TapisEpreuveModel model)
        {

            var epreuveTechnique = this.techniques.Read(e => e.Id == model.EpreuveId).FirstOrDefault();
            var epreuveCombat = this.combat.Read(e => e.Id == model.EpreuveId).FirstOrDefault();
            var dbitem = this.tapis.Read().FirstOrDefault(e => e.Id == model.Id && e.Description == e.Description);
            var epreuves = new List<Epreuve>();

            if (epreuveTechnique != null)
            {

                if (dbitem.Epreuves == null)
                {
                    epreuves.Add(epreuveTechnique);
                    dbitem.Epreuves = epreuves;
                }
                else
                {
                    var hasOneContestAssigned = dbitem.Epreuves.Count(e => e.Statut == StatutEpreuve.Assignee) > 0;
                    if (!hasOneContestAssigned)
                    {
                        dbitem.Epreuves.Add(epreuveTechnique);
                    }
                    else
                    {
                        throw new ArgumentException("Ce tapis a déjà une épreuve assignée non terminée");
                    }
                }

                epreuveTechnique.Statut = StatutEpreuve.Assignee;
                this.tapis.Update(dbitem);

                return Json(string.Empty);
            }
            else if (epreuveCombat != null)
            {
                if (dbitem.Epreuves == null)
                {
                    epreuves.Add(epreuveCombat);
                    dbitem.Epreuves = epreuves;
                }
                else
                {
                    var hasOneContestAssigned = dbitem.Epreuves.Count(e => e.Statut == StatutEpreuve.Assignee) > 0;
                    if (!hasOneContestAssigned)
                    {
                        dbitem.Epreuves.Add(epreuveCombat);
                    }
                    else
                    {
                        throw new ArgumentException("Cette épreuve a déjà une épreuve assignée non terminée");
                    }
                }
                epreuveCombat.Statut = StatutEpreuve.Assignee;
                this.tapis.Update(dbitem);
                return Json(string.Empty);
            }
            throw new ArgumentOutOfRangeException("model.Id", "Can't find epreuve.");
        }

        public JsonResult GetHistorique()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var aires = this.tapis.Read();
            var contests = this.epreuves.Read();
            try
            {
                var overContests = contests.Where(e => e.Statut != StatutEpreuve.Fermee && e.Statut != StatutEpreuve.Ouverte && e.Statut != StatutEpreuve.NotSet && e.Statut != StatutEpreuve.Exclue);
                result.Data = overContests.Select(e => new
                {
                    EpreuveId = e.Id,
                    EpreuveNom = e.Nom,
                    EpreuveStatutId = (int)e.Statut,
                    EpreuveStatut = StatutEpreuves.ResourceManager.GetString(e.Statut.ToString()),
                    TapisId = (aires.FirstOrDefault(a => a.Epreuves != null && a.Epreuves.FirstOrDefault(ae => ae.Id == e.Id) != null) != null) ? aires.FirstOrDefault(a => a.Epreuves != null && a.Epreuves.FirstOrDefault(ae => ae.Id == e.Id) != null).Id : 0,
                    TapisNom = (aires.FirstOrDefault(a => a.Epreuves != null && a.Epreuves.FirstOrDefault(ae => ae.Id == e.Id) != null) != null) ? aires.FirstOrDefault(a => a.Epreuves != null && a.Epreuves.FirstOrDefault(ae => ae.Id == e.Id) != null).Description : ""
                }).ToList();
            }
            catch (Exception)
            {

            }
            return result;
        }
    }
}