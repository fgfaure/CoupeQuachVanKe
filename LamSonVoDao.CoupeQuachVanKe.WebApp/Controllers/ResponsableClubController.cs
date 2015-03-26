namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Contracts;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class ResponsableClubController : BaseController<ResponsableClub>, ICrudController<ResponsableClub, ResponsableClubModel>
    {       
        public JsonResult Get()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.repository.GetAll().Select(r => new ResponsableClubModel
            {
                Id = r.Id,
                Adresse = r.Adresse,
                EmailContact = r.EmailContact,
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
                    EmailContact = model.EmailContact,
                    ClubId = model.ClubId,
                    Nom = model.Nom,
                    Prenom = model.Prenom,
                    Telephone = model.Telephone         
                };

                this.repository.Insert(dbitem);
                return Json(model);

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
                var dbmodel = this.repository.Get(m => m.Id == model.Id).First();
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
                var dbmodel = this.repository.Get(m => m.Id == model.Id).First();
                if (dbmodel != null)
                {
                    dbmodel.Adresse = model.Adresse;
                    dbmodel.EmailContact = model.EmailContact;
                    dbmodel.ClubId = model.ClubId;
                    dbmodel.Nom = model.Nom;
                    dbmodel.Prenom = model.Prenom;
                    dbmodel.Telephone = model.Telephone;

                    this.repository.Update(dbmodel);
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
    }
}