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
    public class ResponsableCoupeController : BaseController<ResponsableCoupe>, ICrudController<ResponsableCoupe, ResponsableCoupeModel>
    {      
        public JsonResult Get()
        {
            throw new NotImplementedException();
        }

        public JsonResult Create(ResponsableCoupeModel model)
        {
            throw new NotImplementedException();
        }

        public JsonResult Delete(ResponsableCoupeModel model)
        {
            throw new NotImplementedException();
        }

        public JsonResult Update(ResponsableCoupeModel model)
        {
            throw new NotImplementedException();
        }
    }
}