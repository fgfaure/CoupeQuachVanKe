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

    public class ResponsableCoupeController : BaseController<ResponsableCoupe>, ICrudController<ResponsableCoupe, ResponsableCoupeModel>
    {
        public JsonResult Get()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.repository.GetAll().Select(r => new ResponsableCoupeModel
            {
                Id = r.Id,
                Adresse = r.Adresse,
                EmailContact = r.EmailContact,
                CoupeId = r.CoupeId,
                Nom = r.Nom,
                Prenom = r.Prenom,
                Telephone = r.Telephone
            });
            return result;
        }

        public JsonResult Create(ResponsableCoupeModel model)
        {
            try
            {
                var dbitem = new ResponsableCoupe
                {
                    Adresse = model.Adresse,
                    EmailContact = model.EmailContact,
                    CoupeId = model.CoupeId,
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

        public JsonResult Delete(ResponsableCoupeModel model)
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
                    throw new ArgumentException("Le responsable de la coupe est absent de la base de données", "model");
                }
            }
            catch
            {
                throw;
            }
        }

        public JsonResult Update(ResponsableCoupeModel model)
        {
            try
            {
                var dbmodel = this.repository.Get(m => m.Id == model.Id).First();
                if (dbmodel != null)
                {
                    dbmodel.Adresse = model.Adresse;
                    dbmodel.EmailContact = model.EmailContact;
                    dbmodel.CoupeId = model.CoupeId;
                    dbmodel.Nom = model.Nom;
                    dbmodel.Prenom = model.Prenom;
                    dbmodel.Telephone = model.Telephone;

                    this.repository.Update(dbmodel);
                    return Json(model);
                }
                else
                {
                    throw new ArgumentException("Le responsable de la coupe est absent de la base de données", "model");
                }
            }
            catch
            {
                throw;
            }
        }
    }
}