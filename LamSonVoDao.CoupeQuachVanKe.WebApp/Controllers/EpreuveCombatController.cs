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

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    public class EpreuveCombatController : BaseController<EpreuveCombat>, ICrudController<EpreuveCombat, EpreuveCombatModel>
    {

        public JsonResult Get()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.repository.GetAll().Select(et => et.ToModel());
            return result;
        }

        public JsonResult Create(EpreuveCombatModel model)
        {
            try
            {
                var dbitem = new EpreuveCombat
                {
                    CategoriePratiquant = (CategoriePratiquant)model.CategorieId,
                    GenreCategorie = (GenreEpreuve)model.GenreCategorieId,
                    GradeAutorise = (Grade)model.GradeAutoriseId,
                    Statut = StatutEpreuve.Fermee,
                    TypeEpreuveId = model.TypeEpreuveId,
                    PoidsMini = model.PoidsMini,
                    PoidsMaxi = model.PoidsMaxi
                };

                this.repository.Insert(dbitem);
                return Json(model);

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
                var dbmodel = this.repository.Get(m => m.Id == model.Id).First();
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
                var dbmodel = this.repository.Get(m => m.Id == model.Id).First();
                if (dbmodel != null)
                {
                    dbmodel.CategoriePratiquant = (CategoriePratiquant)model.CategorieId;
                    dbmodel.GenreCategorie = (GenreEpreuve)model.GenreCategorieId;
                    dbmodel.GradeAutorise = (Grade)model.GradeAutoriseId;
                    dbmodel.Statut = StatutEpreuve.Fermee;
                    dbmodel.TypeEpreuveId = model.TypeEpreuveId;
                    dbmodel.PoidsMini = model.PoidsMini;
                    dbmodel.PoidsMaxi = model.PoidsMaxi;
                    this.repository.Update(dbmodel);
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
    }
}