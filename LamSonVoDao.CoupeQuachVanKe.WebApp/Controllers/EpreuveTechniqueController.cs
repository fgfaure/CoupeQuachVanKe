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

    public class EpreuveTechniqueController : BaseController<EpreuveTechnique>, ICrudController<EpreuveTechnique, EpreuveTechniqueModel>
    {
        public JsonResult Get()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.repository.GetAll().Select(et => et.ToModel());
            return result;
        }

        public JsonResult Create(EpreuveTechniqueModel model)
        {
            try
            {
                var dbitem = new EpreuveTechnique
                {
                    CategoriePratiquant = (CategoriePratiquant)model.CategorieId,
                    Description = model.Description,
                    GenreCategorie = (GenreEpreuve)model.GenreCategorieId,
                    GradeAutorise = (Grade)model.GradeAutoriseId,
                    Nom = model.Nom,
                    Statut = StatutEpreuve.Fermee,
                    TypeEpreuveId = model.TypeEpreuveId
                };

                this.repository.Insert(dbitem);
                return Json(model);

            }
            catch
            {
                throw;
            }
        }

        public JsonResult Delete(EpreuveTechniqueModel model)
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
                    throw new ArgumentException("L'epreuve technique est absente de la base de données", "model");
                }
            }
            catch
            {
                throw;
            }
        }

        public JsonResult Update(EpreuveTechniqueModel model)
        {
            try
            {
                var dbmodel = this.repository.Get(m => m.Id == model.Id).First();
                if (dbmodel != null)
                {
                    dbmodel.CategoriePratiquant = (CategoriePratiquant)model.CategorieId;
                    dbmodel.Description = model.Description;
                    dbmodel.GenreCategorie = (GenreEpreuve)model.GenreCategorieId;
                    dbmodel.GradeAutorise = (Grade)model.GradeAutoriseId;
                    dbmodel.Nom = model.Nom;
                    dbmodel.Statut = StatutEpreuve.Fermee;
                    dbmodel.TypeEpreuveId = model.TypeEpreuveId;

                    this.repository.Update(dbmodel);
                    return Json(model);
                }
                else
                {
                    throw new ArgumentException("L'epreuve technique est absente de la base de données", "model");
                }
            }
            catch
            {
                throw;
            }
        }
    }
}