using LamSonVoDao.CoupeQuachVanKe.AccesPattern;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Helper;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    public class ClientController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<NetClient> netClientRepository;
        private Repository<NetClientType> netClientTypesRepository;

        public ClientController()
        {
            this.netClientRepository = this.unitOfWork.Repository<NetClient>();
            this.netClientTypesRepository = this.unitOfWork.Repository<NetClientType>();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetClients()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            var list = this.netClientRepository.Read().Select(nc => nc.ToModel()).ToList();
            result.Data = list;
            return result;
        }       

        [HttpGet]
        public ActionResult GetClientTypes()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.netClientTypesRepository.Read();
            return result;
        }

        [HttpPost]
        public ActionResult RegisterClient(NetClient client)
        {
            try
            {
                this.netClientRepository.Create(client);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, reason = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Update(NetClientModel model)
        {
            try
            {
                var dbmodel = this.netClientRepository.Read(m => m.Id == model.Id).First();
                dbmodel.Password = model.Password;
                dbmodel.IsConnected = model.IsConnected;
                dbmodel.ClientName = model.ClientName;
                this.netClientRepository.Update(dbmodel);
                return Json(dbmodel.ToModel());
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public JsonResult Delete(NetClientModel model)
        {
            try
            {
                var dbItem = this.netClientRepository.Read(model.Id);
                this.netClientRepository.Delete(dbItem);
                return Json(new { success = true });
            }
            catch
            {
                throw;
            }
        }
    }
}