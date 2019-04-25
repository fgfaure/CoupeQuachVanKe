using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Contracts;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    public class TypeEpreuveController : BaseController<TypeEpreuve>, ICrudController<TypeEpreuve, TypeEpreuveModel>
    {
        public JsonResult Get()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            result.Data = this.repository.Read().Select(m => new TypeEpreuveModel
            {
                Nom = m.Nom,
                Description = m.Description,
                Id = m.Id,
                CoupeId = m.CoupeId,
                Technique = m.Technique,
                UseSwissSystem = m.UseSwissSystem
            });

            return result;
        }


        // POST: Medecin/Create
        [HttpPost]
        public JsonResult Create(TypeEpreuveModel typeEpreuve)
        {
            try
            {
                this.repository.Create(new TypeEpreuve
                {
                    Nom = typeEpreuve.Nom,
                    Description = typeEpreuve.Description,
                    Technique = typeEpreuve.Technique,
                    UseSwissSystem = typeEpreuve.UseSwissSystem,
                    CoupeId = typeEpreuve.CoupeId
                });

                var dbItem = this.repository.Read(m => m.Nom == typeEpreuve.Nom && m.CoupeId == typeEpreuve.CoupeId).First();
                typeEpreuve.Id = dbItem.Id;
                return Json(typeEpreuve);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public JsonResult Update(TypeEpreuveModel model)
        {
            try
            {
                var dbmodel = this.repository.Read(m => m.Id == model.Id).First();
                dbmodel.Description = model.Description;
                dbmodel.Nom = model.Nom;
                dbmodel.CoupeId = model.CoupeId;
                dbmodel.Technique = model.Technique;
                dbmodel.UseSwissSystem = model.UseSwissSystem;
                this.repository.Update(dbmodel);
                return Json(model);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public JsonResult Delete(TypeEpreuveModel model)
        {
            try
            {
                var dbItem = this.repository.Read(model.Id);
                this.repository.Delete(dbItem);
                return Json(model);
            }
            catch
            {
                throw;
            }
        }
    }
}