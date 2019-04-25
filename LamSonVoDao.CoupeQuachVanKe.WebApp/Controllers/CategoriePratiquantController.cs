using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Contracts;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Helper;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers.BaseController{LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.CategoriePratiquant}" />
    /// <seealso cref="LamSonVoDao.CoupeQuachVanKe.WebApp.Contracts.ICrudController{LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.CategoriePratiquant, LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe.CategoriePratiquantModel}" />
    public class CategoriePratiquantController : BaseController<CategoriePratiquant>, ICrudController<CategoriePratiquant, CategoriePratiquantModel>
    {
        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public JsonResult Create(CategoriePratiquantModel model)
        {
            try
            {
                var dbitem = new CategoriePratiquant
                {
                    Nom = model.Nom,
                    AgeMin = model.AgeMin,
                    AgeMax = model.AgeMax,
                    Duree = model.Duree,
                    Competiteurs = new List<Competiteur>(),
                    Epreuves = new List<Epreuve>(),
                };

                this.repository.Create(dbitem);
                return Json(dbitem.ToModel());
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public JsonResult Delete(CategoriePratiquantModel model)
        {
            try
            {
                var dbItem = this.repository.Read(model.Id);
                if (dbItem != null)
                {
                    repository.Delete(dbItem);
                    return Json(new { success = true });
                }
                return Json(new { success = false });
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>

        [AllowAnonymous]
        public JsonResult Get()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.repository.Read().Select(categorie => new CategoriePratiquantModel
            {
                Id = categorie.Id,
                Nom = categorie.Nom,
                AgeMax = categorie.AgeMax,
                AgeMin = categorie.AgeMin,
                Duree = categorie.Duree
            }).OrderBy(cat => cat.AgeMin);
            return result;
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public JsonResult Update(CategoriePratiquantModel model)
        {
            try
            {
                var dbmodel = this.repository.Read(m => m.Id == model.Id).First();
                dbmodel.AgeMax = model.AgeMax;
                dbmodel.AgeMin = model.AgeMin;
                dbmodel.Duree = model.Duree;
                dbmodel.Nom = model.Nom;

                this.repository.Update(dbmodel);
                return Json(dbmodel.ToModel());
            }
            catch
            {
                throw;
            }
        }
    }
}