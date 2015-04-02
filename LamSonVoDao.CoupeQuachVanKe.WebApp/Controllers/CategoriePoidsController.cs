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

    public class CategoriePoidsController : BaseController<CategoriePoids>, ICrudController<CategoriePoids, CategoriePoidsModel>
    {
        public JsonResult Get()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.repository.GetAll().Select(categorie => new CategoriePoidsModel
            {
                Id = categorie.Id,
                Description = categorie.Description,
                Nom = categorie.Nom,
                ValeurBasse = categorie.ValeurBasse,
                ValeurHaute = categorie.ValeurHaute,
                EpreuveId = categorie.EpreuveId
            });
            return result;
        }

        public JsonResult Create(CategoriePoidsModel model)
        {
            try
            {
                var dbitem = new CategoriePoids
                {
                    Description = model.Description,
                    Nom = model.Nom,
                    ValeurBasse = model.ValeurBasse,
                    ValeurHaute = model.ValeurHaute,
                    EpreuveId = model.EpreuveId                    
                };

                this.repository.Insert(dbitem);
                return Json(model);

            }
            catch
            {
                throw;
            }
        }

        public JsonResult Delete(CategoriePoidsModel model)
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
                    throw new ArgumentException("La catégorie de poids est absente de la base de données", "model");
                }
            }
            catch
            {
                throw;
            }
        }

        public JsonResult Update(CategoriePoidsModel model)
        {
            try
            {
                var dbmodel = this.repository.Get(m => m.Id == model.Id).First();
                if (dbmodel != null)
                {
                    dbmodel.Description = model.Description;
                    dbmodel.Nom = model.Nom;
                    dbmodel.EpreuveId = model.EpreuveId;
                    dbmodel.ValeurBasse = model.ValeurBasse;
                    dbmodel.ValeurHaute = model.ValeurHaute;

                    this.repository.Update(dbmodel);
                    return Json(model);
                }
                else
                {
                    throw new ArgumentException("La catégorie de poids est absente de la base de données", "model");
                }
            }
            catch
            {
                throw;
            }
        }
    }
}