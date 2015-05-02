using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Contracts;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
using Resources;
using LamSonVoDao.CoupeQuachVanKe.AccesPattern;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    public class EpreuveCombatController : BaseController<EpreuveCombat>, ICrudController<EpreuveCombat, EpreuveCombatModel>
    {
        private Repository<CategoriePratiquant> categories = new UnitOfWork().Repository<CategoriePratiquant>();
        private Repository<TypeEpreuve> types = new UnitOfWork().Repository<TypeEpreuve>();

        public JsonResult Get()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.repository.Read().Select(et => et.ToModel());
            return result;
        }

        public JsonResult Create(EpreuveCombatModel model)
        {
            try
            {
                var categorie = this.categories.Read(model.CategorieId).Nom;
                var typeEpreuve = this.types.Read(model.TypeEpreuveId).Nom;
                var genre = GenreEpreuves.ResourceManager.GetString(((GenreEpreuve)model.GenreCategorieId).ToString());
                var grade = Grades.ResourceManager.GetString(((Grade)model.GradeAutoriseId).ToString());

                var nom = BuildEpreuveName(model, categorie, typeEpreuve, genre, grade);

                var dbitem = new EpreuveCombat
                {
                    Nom = nom,
                    CategoriePratiquantId = model.CategorieId,
                    GenreCategorie = (GenreEpreuve)model.GenreCategorieId,
                    GradeAutorise = (Grade)model.GradeAutoriseId,
                    Statut = (StatutEpreuve)model.StatutId,
                    TypeEpreuveId = model.TypeEpreuveId,
                    PoidsMini = model.PoidsMini,
                    PoidsMaxi = model.PoidsMaxi
                };

                this.repository.Create(dbitem);
                return Json(dbitem.ToModel());

            }
            catch
            {
                throw;
            }
        }
    
        public JsonResult Delete(EpreuveCombatModel model)
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
                    throw new ArgumentException("L'epreuve combat est absente de la base de données", "model");
                }
            }
            catch
            {
                throw;
            }
        }

        public JsonResult Update(EpreuveCombatModel model)
        {
            try
            {
                var categorie = this.categories.Read(model.CategorieId).Nom;
                var typeEpreuve = this.types.Read(model.TypeEpreuveId).Nom;
                var genre = GenreEpreuves.ResourceManager.GetString(((GenreEpreuve)model.GenreCategorieId).ToString());
                var grade = Grades.ResourceManager.GetString(((Grade)model.GradeAutoriseId).ToString());
                var nom = BuildEpreuveName(model, categorie, typeEpreuve, genre, grade);
                var dbmodel = this.repository.Read(m => m.Id == model.Id).First();
                if (dbmodel != null)
                {
                    dbmodel.Nom = nom;
                    dbmodel.CategoriePratiquantId = model.CategorieId;
                    dbmodel.GenreCategorie = (GenreEpreuve)model.GenreCategorieId;
                    dbmodel.GradeAutorise = (Grade)model.GradeAutoriseId;
                    dbmodel.Statut = (StatutEpreuve)model.StatutId;
                    dbmodel.TypeEpreuveId = model.TypeEpreuveId;
                    dbmodel.PoidsMini = model.PoidsMini;
                    dbmodel.PoidsMaxi = model.PoidsMaxi;
                    this.repository.Update(dbmodel);
                    return Json(dbmodel.ToModel());
                }
                else
                {
                    throw new ArgumentException("L'epreuve combat est absente de la base de données", "model");
                }
            }
            catch
            {
                throw;
            }
        }

        private static string BuildEpreuveName(EpreuveCombatModel model, string categorie, string typeEpreuve, string genre, string grade)
        {
            var nom = string.Empty;

            if (model.PoidsMini == 0)
            {
                nom = string.Format("{0} {1} {2} {3} -{4} kgs", typeEpreuve, categorie, genre, grade, model.PoidsMaxi);
            }
            else if (model.PoidsMaxi == 1000)
            {
                nom = string.Format("{0} {1} {2} {3} +{4} kgs", typeEpreuve, categorie, genre, grade, model.PoidsMini);
            }
            else
            {
                nom = string.Format("{0} {1} {2} {3} de {4}kgs à {5}kgs", typeEpreuve, categorie, genre, grade, model.PoidsMini, model.PoidsMaxi);
            }
            return nom;
        }

    }
}