namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Contracts;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Helper;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class EncadrantController : BaseController<Encadrant>, ICrudController<Encadrant, EncadrantModel>
    {
        public JsonResult Get()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.repository.GetAll().Select(enc => enc.ToModel());
            return result;
        }

        public JsonResult Create(EncadrantModel model)
        {
            try
            {
                var dbitem = model.ToDTO();                
                this.repository.Insert(dbitem);
                return Json(model);
            }
            catch
            {
                throw;
            }
        }

        public JsonResult Delete(EncadrantModel model)
        {
            try
            {
                var dbmodel = this.repository.Get(m => m.Id == model.Id).First();
                if (dbmodel != null)
                {
                    this.repository.Delete(dbmodel);
                    return Json(model);
                }
                else
                {
                    throw new ArgumentException("L'encadrant est absent de la base de données", "model");
                }
            }
            catch
            {
                throw;
            }
        }

        public JsonResult Update(EncadrantModel model)
        {
            var dbmodel = this.repository.Get(m => m.Id == model.Id).First();
            if (dbmodel != null)
            {
                dbmodel.ClubId = model.ClubId;
                dbmodel.Nom = model.Nom;
                dbmodel.EstCompetiteur = model.EstCompetiteur;
                dbmodel.MailContact = model.MailContact;
                dbmodel.Prenom = model.Prenom;
                dbmodel.TailleTenue = (TailleTenue)model.TailleTenueId;
                dbmodel.Sexe = (Genre)model.GenreId;                

                this.repository.Update(dbmodel);
                return Json(model);
            }
            else
            {
                throw new ArgumentException("La coupe est absente de la base de données", "model");
            }
        }
    }
}