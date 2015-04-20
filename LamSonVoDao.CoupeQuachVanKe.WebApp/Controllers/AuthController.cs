namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Web;
    using System.Web.Mvc;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using LamSonVoDao.CoupeQuachVanKe.AccesPattern;
    using Microsoft.Owin.Security;

    [AllowAnonymous]
    public class AuthController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<NetClient> netClientRepository;
        private Repository<NetClientType> netClientTypesRepository;

        public AuthController()
        {
            this.netClientRepository = this.unitOfWork.Repository<NetClient>();
            this.netClientTypesRepository = this.unitOfWork.Repository<NetClientType>();
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {

                var client = this.netClientRepository.Read(model.AccountId);

                bool isIdentified = string.Compare(client.Password, model.Password) == 0;

                if (isIdentified)
                {
                    var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.NameIdentifier, client.ClientLogInName)
                }, "ApplicationCookie");

                    var ctx = Request.GetOwinContext();
                    var authManager = ctx.Authentication;

                    authManager.SignIn(identity);

                    client.IsConnected = true;
                    client.Ip = this.Request.UserHostAddress;
                    this.netClientRepository.Update(client);

                    return Json(new { success = true, url = GetRedirectUrl(client) });
                }
                ModelState.AddModelError("", "Invalid password");
                return Json(new { success = false });
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string GetRedirectUrl(NetClient client)
        {
            string result;
            switch (client.NetClientTypeId)
            {
                case 1:
                    result = Url.Action("index", "server");
                    break;
                case 2:
                    result = Url.Action("index", "satellite");
                    break;
                case 3:
                    result = Url.Action("index", "saisie");
                    break;
                case 4:
                    result = Url.Action("index", "accueil");
                    break;
                default:
                    result = Url.Action("login", "auth");
                    break;
            }
            return result;
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            var dbitem = this.netClientRepository.Read(nc => nc.ClientLogInName == authManager.User.Claims.First().Value).FirstOrDefault();
            if (dbitem != null)
            {
                dbitem.IsConnected = false;
                this.netClientRepository.Update(dbitem);
            }
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public ActionResult GetClients()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            var list = this.netClientRepository.Read().Where(nc => !nc.IsConnected).Select(nc => new { clientId = nc.Id, logName = nc.ClientLogInName }).ToList();
            list.Insert(0, new { clientId = -1, logName = "Choisissez un compte" });
            result.Data = list;
            return result;
        }       

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }
    }
}
