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
                    Statut = StatutEpreuve.Fermee,
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
                    dbmodel.Statut = StatutEpreuve.Fermee;
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
        
        //[HttpPost]
        //public JsonResult Merge(IEnumerable<EpreuveTechniqueModel> models)
        //{
        //    var result = new JsonResult();
        //    var merged = new EpreuveTechnique();
        //    models.OrderByDescending(m => m.CategorieId);
        //    var categories = (from cat in this.unitOfWork.Repository<CategoriePratiquant>().Read()
        //                      join model in models on cat.Id equals model.CategorieId
        //                      select cat.Nom);

        //    merged.Nom = string.Join(" ", categories.ToArray());
        //    merged.IsMerged = true;
        //    merged.CategoriePratiquantId = models.First().CategorieId;
        //    var isGenreMerged = models.GroupBy(m => m.GenreCategorieId).Distinct().Count() > 1;
        //    if (isGenreMerged)
        //    {
        //        merged.GenreCategorie = GenreEpreuve.Mixte;
        //    }
        //    else
        //    {
        //        merged.GenreCategorie = (GenreEpreuve)models.First().GenreCategorieId;
        //    }

        //    merged.GradeAutorise = (Grade)models.First().GradeAutoriseId;
        //    merged.Statut = StatutEpreuve.Fermee;
        //    merged.TypeEpreuveId = models.First().TypeEpreuveId;

        //    this.repository.Create(merged);

        //    var idForNewEpreuve = merged.Id;

        //    var partipations = this.unitOfWork.Repository<Participation>();

        //    var participationsToChange = (from participation in partipations.Read()
        //                                  join model in models
        //                                  on participation.EpreuveId equals model.Id
        //                                  select participation).ToList();

        //    for (int i = 0; i < participationsToChange.Count(); i++)
        //    {
        //        participationsToChange[i].EpreuveId = idForNewEpreuve;
        //        partipations.Update(participationsToChange[i]);
        //    }

        //    return result;
        //}
    }
}