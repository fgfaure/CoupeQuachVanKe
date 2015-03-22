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

            result.Data = this.medecinRepository.GetAll().Select(m => new MedecinModel{
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
                if (medecin.Id == 0)
                {
                    this.medecinRepository.Insert(new Medecin
                    {
                        Nom = medecin.Nom,
                        Prenom = medecin.Prenom,
                        Telephone = medecin.Telephone,
                        MailContact = medecin.MailContact,
                        CoupeId = 1
                    });
                }
                else{
                    this.medecinRepository.Update(new Medecin
                    {
                        Nom = medecin.Nom,
                        Prenom = medecin.Prenom,
                        Telephone = medecin.Telephone,
                        MailContact = medecin.MailContact
                    });
                }
                return RedirectToAction("Index");
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
                return Json(new[] { model });
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
                this.medecinRepository.Delete(new Medecin
                {
                    Nom = model.Nom,
                    Prenom = model.Prenom,
                    Telephone = model.Telephone,
                    MailContact = model.MailContact
                });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
