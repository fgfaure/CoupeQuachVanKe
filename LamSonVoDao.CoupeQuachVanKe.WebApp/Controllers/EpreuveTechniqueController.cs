namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Contracts;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Helper;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
    using Resources;
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using LamSonVoDao.CoupeQuachVanKe.AccesPattern;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;

    public class EpreuveTechniqueController : BaseController<EpreuveTechnique>, ICrudController<EpreuveTechnique, EpreuveTechniqueModel>
    {
        private Repository<CategoriePratiquant> categories = new UnitOfWork().Repository<CategoriePratiquant>();
        private Repository<TypeEpreuve> types = new UnitOfWork().Repository<TypeEpreuve>();


        public JsonResult Get()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.repository.Read().Select(e => e.ToModel());
            return result;
        }

        public JsonResult Create(EpreuveTechniqueModel model)
        {
            try
            {
                var categorie = this.categories.Read(model.CategorieId).Nom;
                var typeEpreuve = this.types.Read(model.TypeEpreuveId).Nom;
                var genre = GenreEpreuves.ResourceManager.GetString(((GenreEpreuve)model.GenreCategorieId).ToString());
                var grade = Grades.ResourceManager.GetString(((Grade)model.GradeAutoriseId).ToString());
                var dbitem = new EpreuveTechnique
                {
                    Nom = string.Format("{0} {1} {2} {3}", typeEpreuve, categorie, genre, grade),
                    CategoriePratiquantId = model.CategorieId,
                    GenreCategorie = (GenreEpreuve)model.GenreCategorieId,
                    GradeAutorise = (Grade)model.GradeAutoriseId,
                    Statut = (StatutEpreuve)model.StatutId,
                    TypeEpreuveId = model.TypeEpreuveId
                };

                this.repository.Create(dbitem);
                return Json(dbitem.ToModel());

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
                var dbmodel = this.repository.Read(m => m.Id == model.Id).First();
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
                var dbmodel = this.repository.Read(m => m.Id == model.Id).First();
                if (dbmodel != null)
                {
                    dbmodel.CategoriePratiquantId = model.CategorieId;
                    dbmodel.GenreCategorie = (GenreEpreuve)model.GenreCategorieId;
                    dbmodel.GradeAutorise = (Grade)model.GradeAutoriseId;
                    dbmodel.Statut = (StatutEpreuve)model.StatutId;
                    dbmodel.TypeEpreuveId = model.TypeEpreuveId;

                    this.repository.Update(dbmodel);
                    return Json(dbmodel.ToModel());
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

        [HttpPost]
        public ActionResult ExcelSave(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
    }
}