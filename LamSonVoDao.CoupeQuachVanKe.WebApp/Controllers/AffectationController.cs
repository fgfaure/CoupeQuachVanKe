using LamSonVoDao.CoupeQuachVanKe.AccesPattern;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Helper;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    public class AffectationController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<Aire> tapis;
        private Repository<EpreuveTechnique> techniques;
        private Repository<EpreuveCombat> combat;
        private Repository<NetClient> clients;

        public AffectationController()
        {
            this.tapis = this.unitOfWork.Repository<Aire>();
            this.techniques = this.unitOfWork.Repository<EpreuveTechnique>();
            this.combat = this.unitOfWork.Repository<EpreuveCombat>();
            this.clients = this.unitOfWork.Repository<NetClient>();
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
            var tapis = this.tapis.Read().Select(t => t.ToModel());
            var clients = this.clients.Read().Select(c => c.ToModel());
            var techniques = this.techniques.Read(e => e.Statut == StatutEpreuve.Fermee).Select(e => e.ToModel());
            var combat = this.combat.Read(e => e.Statut == StatutEpreuve.Fermee).Select(e => e.ToModel());
            result.Data = new { tapis = tapis, clients = clients, epreuves = techniques.Union(combat) };
            return result;
        }
    }
}