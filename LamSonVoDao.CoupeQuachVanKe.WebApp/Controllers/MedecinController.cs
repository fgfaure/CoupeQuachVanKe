using LamSonVodao.CoupeQuachVanKe.AccesPattern;
using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    public class MedecinController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<Medecin> medecinRepository;


        public MedecinController()
        {
            this.medecinRepository = this.unitOfWork.Repository<Medecin>();
        }

        // GET: Medecin
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetMedecins()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            result.Data = this.medecinRepository.GetAll().Select(m => new MedecinModel
            {
                Nom = m.Nom,
                Prenom = m.Prenom,
                Id = m.Id,
                MailContact = m.MailContact,
                Telephone = m.Telephone
            });

            return result;
        }


        // POST: Medecin/Create
        [HttpPost]
        public ActionResult Create(MedecinModel medecin)
        {
            try
            {
                this.medecinRepository.Insert(new Medecin
                {
                    Nom = medecin.Nom,
                    Prenom = medecin.Prenom,
                    Telephone = medecin.Telephone,
                    MailContact = medecin.MailContact,
                    CoupeId = 1
                });

                var dbItem = this.medecinRepository.Get(m => m.Nom == medecin.Nom && m.Prenom == medecin.Prenom).First();
                medecin.Id = dbItem.Id;
                return Json(medecin);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(MedecinModel model)
        {
            try
            {
                var dbmodel = this.medecinRepository.Get(m => m.Id == model.Id).First();
                dbmodel.MailContact = model.MailContact;
                dbmodel.Nom = model.Nom;
                dbmodel.Prenom = model.Prenom;
                dbmodel.Telephone = model.Telephone;
                this.medecinRepository.Update(dbmodel);
                return Json(model);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(MedecinModel model)
        {
            try
            {
                var dbItem = this.medecinRepository.GetById(model.Id);
                this.medecinRepository.Delete(dbItem);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
