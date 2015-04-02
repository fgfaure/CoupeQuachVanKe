namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Contracts;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Helper;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class DisponibiliteController : BaseController<Disponibilite>, ICrudController<Disponibilite, DisponibiliteModel>
    {
        public JsonResult Get()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.repository.GetAll().Select(dispo => new DisponibiliteModel
            {
                Id = dispo.Id,
                Date = dispo.Date,
                EncadrantId = dispo.EncadrantId,
                Matin = dispo.Matin,
                Role = dispo.Role.ToString()
            });
            return result;
        }

        public JsonResult Create(DisponibiliteModel model)
        {
            try
            {
                var dbitem = new Disponibilite
                {
                    Date = model.Date,
                    EncadrantId = model.EncadrantId,
                    Matin = model.Matin,
                    Role = new EnumConverter<Role>().ConvertToEnum(model.Role)
                };

                this.repository.Insert(dbitem);
                return Json(model);
            }
            catch
            {
                throw;
            }
        }

        public JsonResult Delete(DisponibiliteModel model)
        {
            var dbmodel = this.repository.Get(m => m.Id == model.Id).First();
            if (dbmodel != null)
            {
                this.repository.Delete(dbmodel);
                return Json(model);
            }
            else
            {
                throw new ArgumentException("La disponibilité est absente de la base de données", "model");
            }
        }

        public JsonResult Update(DisponibiliteModel model)
        {
            try
            {
                var dbmodel = this.repository.Get(m => m.Id == model.Id).First();
                if (dbmodel != null)
                {
                    dbmodel.EncadrantId = model.EncadrantId;
                    dbmodel.Date = model.Date;
                    dbmodel.Matin = model.Matin;
                    dbmodel.Role = new EnumConverter<Role>().ConvertToEnum(model.Role);                    

                    this.repository.Update(dbmodel);
                    return Json(model);
                }
                else
                {
                    throw new ArgumentException("La disponibilité est absente de la base de données", "model");
                }
            }
            catch
            {
                throw;
            }
        }
    }
}