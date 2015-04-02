namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    using LamSonVoDao.CoupeQuachVanKe.AccesPattern;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Contracts;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class MedecinController : BaseController<Medecin>, ICrudController<Medecin, MedecinModel>
    {         
        public JsonResult Get()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            result.Data = this.repository.GetAll().Select(m => new MedecinModel
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
        public JsonResult Create(MedecinModel medecin)
        {
            try
            {
                this.repository.Insert(new Medecin
                {
                    Nom = medecin.Nom,
                    Prenom = medecin.Prenom,
                    Telephone = medecin.Telephone,
                    MailContact = medecin.MailContact,
                    CoupeId = 1
                });

                var dbItem = this.repository.Get(m => m.Nom == medecin.Nom && m.Prenom == medecin.Prenom).First();
                medecin.Id = dbItem.Id;
                return Json(medecin);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public JsonResult Update(MedecinModel model)
        {
            try
            {
                var dbmodel = this.repository.Get(m => m.Id == model.Id).First();
                dbmodel.MailContact = model.MailContact;
                dbmodel.Nom = model.Nom;
                dbmodel.Prenom = model.Prenom;
                dbmodel.Telephone = model.Telephone;
                this.repository.Update(dbmodel);
                return Json(model);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public JsonResult Delete(MedecinModel model)
        {
            try
            {
                var dbItem = this.repository.GetById(model.Id);
                this.repository.Delete(dbItem);
                return Json(model);
            }
            catch
            {
                throw;
            }
        }
    }
}
