namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Contracts;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class EncadrantController : BaseController<Encadrant>, ICrudController<Encadrant, EncadrantModel>
    {
        public JsonResult Get()
        {
            throw new NotImplementedException();
        }

        public JsonResult Create(EncadrantModel model)
        {
            throw new NotImplementedException();
        }

        public JsonResult Delete(EncadrantModel model)
        {
            throw new NotImplementedException();
        }

        public JsonResult Update(EncadrantModel model)
        {
            throw new NotImplementedException();
        }
    }
}