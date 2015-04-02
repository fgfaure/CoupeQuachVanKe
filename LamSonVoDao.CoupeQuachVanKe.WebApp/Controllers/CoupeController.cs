namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Contracts;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Helper;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// 
    /// </summary>
    public class CoupeController : BaseController<Coupe>, ICrudController<Coupe, CoupeModel>
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public JsonResult Get()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.repository.GetAll().Select(coupe => new CoupeModel
            {
                Id = coupe.Id,
                Description = coupe.Description,
                Nom = coupe.Nom,
                CodePostal = coupe.CodePostal,
                Complement = coupe.Complement,
                DateDebut = coupe.DateDebut,
                DateFin = coupe.DateFin,
                NombreTapis = coupe.NombreTapis,
                Numero = coupe.Numero,
                Ville = coupe.Ville,
                Voie = coupe.Voie               
            });
            return result;
        }

        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public JsonResult Create(CoupeModel model)
        {
            try
            {
                var dbitem = new Coupe
                {
                    Description = model.Description,
                    Nom = model.Nom,
                    CodePostal = model.CodePostal,
                    Complement = model.Complement,
                    DateDebut = model.DateDebut,
                    DateFin = model.DateFin,
                    NombreTapis = model.NombreTapis,
                    Numero = model.Numero,
                    Ville = model.Ville,
                    Voie = model.Voie               
                };

                this.repository.Insert(dbitem);
                return Json(model);
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
        /// <exception cref="ArgumentException">La coupe est absente de la base de données;model</exception>
        public JsonResult Delete(CoupeModel model)
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
                    throw new ArgumentException("La coupe est absente de la base de données", "model");
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">La coupe est absente de la base de données;model</exception>
        public JsonResult Update(CoupeModel model)
        {
            try
            {
                var dbmodel = this.repository.Get(m => m.Id == model.Id).First();
                if (dbmodel != null)
                {
                    dbmodel.Description = model.Description;
                    dbmodel.Nom = model.Nom;
                    dbmodel.CodePostal = model.CodePostal;
                    dbmodel.Complement = model.Complement;
                    dbmodel.DateDebut = model.DateDebut;
                    dbmodel.DateFin = model.DateFin;
                    dbmodel.NombreTapis = model.NombreTapis;
                    dbmodel.Numero = model.Numero;
                    dbmodel.Ville = model.Ville;
                    dbmodel.Voie = model.Voie;

                    this.repository.Update(dbmodel);
                    return Json(model);
                }
                else
                {
                    throw new ArgumentException("La coupe est absente de la base de données", "model");
                }
            }
            catch
            {
                throw;
            }
        }

        public JsonResult Responsables(string id)
        {
            int parsed;
            if (int.TryParse(id, out parsed))
            {
                var result = new JsonResult();
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                result.Data = this.unitOfWork.Repository<ResponsableCoupe>().GetAll().Where(e => e.CoupeId == parsed).Select(e => e.ToModel());
                return result;
            }
            else
            {
                throw new ArgumentException("Invalid Id", "id");
            }
        }
    }
}