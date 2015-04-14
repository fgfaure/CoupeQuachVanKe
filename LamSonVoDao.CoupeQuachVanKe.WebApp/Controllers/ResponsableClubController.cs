namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Contracts;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Helper;

    public class ResponsableClubController : BaseController<ResponsableClub>, ICrudController<ResponsableClub, ResponsableClubModel>
    {       
        public JsonResult Get()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.repository.Read().Select(r => new ResponsableClubModel
            {
                Id = r.Id,
                Adresse = r.Adresse,
                MailContact = r.MailContact,
                ClubId = r.ClubId,
                Nom = r.Nom,
                Prenom = r.Prenom,
                Telephone = r.Telephone                
            });
            return result;
        }

        public JsonResult Create(ResponsableClubModel model)
        {
            try
            {
                var dbitem = new ResponsableClub
                {                    
                    Adresse = model.Adresse,
                    MailContact = model.MailContact,
                    ClubId = model.ClubId,
                    Nom = model.Nom,
                    Prenom = model.Prenom,
                    Telephone = model.Telephone         
                };

                this.repository.Create(dbitem);
                return Json(dbitem.ToModel());

            }
            catch
            {
                throw;
            }
        }

        public JsonResult Delete(ResponsableClubModel model)
        {
            try
            {
                var dbmodel = this.repository.Read(m => m.Id == model.Id).First();
                if (dbmodel != null)
                {
                    this.repository.Delete(dbmodel);
                    return Json(model);
                }
                else
                {
                    throw new ArgumentException("Le responsable du club est absent de la base de données", "model");
                }
            }
            catch
            {
                throw;
            }
        }

        public JsonResult Update(ResponsableClubModel model)
        {
            try
            {
                var dbmodel = this.repository.Read(m => m.Id == model.Id).First();
                if (dbmodel != null)
                {
                    dbmodel.Adresse = model.Adresse;
                    dbmodel.MailContact = model.MailContact;
                    dbmodel.ClubId = model.ClubId;
                    dbmodel.Nom = model.Nom;
                    dbmodel.Prenom = model.Prenom;
                    dbmodel.Telephone = model.Telephone;

                    this.repository.Update(dbmodel);
                    return Json(dbmodel.ToModel());
                }
                else
                {
                    throw new ArgumentException("Le responsable du club est absent de la base de données", "model");
                }
            }
            catch
            {
                throw;
            }
        }
    }
}