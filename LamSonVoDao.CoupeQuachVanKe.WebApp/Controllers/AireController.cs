namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    //using LamSonVoDao.CoupeQuachVanKe.AccesPattern;
    //using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Contracts;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Helper;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;


    public class AireController : BaseController<Aire>, ICrudController<Aire, AireModel>
    {
        public JsonResult Get()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.repository.Read().Select(aire => new AireModel
            {
                Id = aire.Id,
                Description = aire.Description,
                CoupeId = aire.CoupeId,
                NetClientId = aire.NetClientId
            });
            return result;
        }

        public JsonResult Create(AireModel model)
        {
            try
            {
                var dbitem = new Aire
                {
                    Description = model.Description,
                    CoupeId = model.CoupeId,
                    NetClientId = model.NetClientId
                };

                this.repository.Create(dbitem);
                try
                {
                    var clients = this.unitOfWork.Repository<NetClient>();
                    var client = clients.Read(model.NetClientId);
                    client.AireId = dbitem.Id;
                    clients.Update(client);
                }
                catch (Exception)
                {
                    
                    throw;
                }
                return Json(dbitem.ToModel());

            }
            catch
            {
                throw;
            }
        }

        public JsonResult Delete(AireModel model)
        {
            try
            {
                var dbmodel = this.repository.Read(m => m.Id == model.Id).First();
                if (dbmodel != null)
                {
                    this.repository.Delete(dbmodel);
                    try
                    {
                        var clients = this.unitOfWork.Repository<NetClient>();
                        var client = clients.Read(model.NetClientId);
                        client.AireId = 0;
                        clients.Update(client);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    return Json(model);
                }
                else
                {
                    throw new ArgumentException("L'aire est absente de la base de données", "model");
                }
            }
            catch
            {
                throw;
            }
        }

        public JsonResult Update(AireModel model)
        {
            try
            {
                var dbmodel = this.repository.Read(m => m.Id == model.Id).First();
                if (dbmodel != null)
                {
                    dbmodel.Description = model.Description;
                    dbmodel.CoupeId = model.CoupeId;
                    dbmodel.NetClientId = model.NetClientId;
                    this.repository.Update(dbmodel);
                    return Json(model);
                }
                else
                {
                    throw new ArgumentException("L'aire est absente de la base de données", "model");
                }
            }
            catch
            {
                throw;
            }
        }
        
        [HttpGet]
        public JsonResult GetUnboundClients()
        {
            var result = new JsonResult();
            var clients = this.unitOfWork.Repository<NetClient>().Read(nc => nc.AireId == 0).Select(nc => nc.ToModel());
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = clients;
            return result;                        
        }
    }
}