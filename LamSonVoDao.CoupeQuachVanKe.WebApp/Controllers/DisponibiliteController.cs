using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Contracts;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    public class DisponibiliteController : BaseController<Disponibilite>, ICrudController<Disponibilite, DisponibiliteModel>
    {
        public JsonResult Get()
        {
            throw new NotImplementedException();
        }

        public JsonResult Create(DisponibiliteModel model)
        {
            throw new NotImplementedException();
        }

        public JsonResult Delete(DisponibiliteModel model)
        {
            throw new NotImplementedException();
        }

        public JsonResult Update(DisponibiliteModel model)
        {
            throw new NotImplementedException();
        }
    }
}