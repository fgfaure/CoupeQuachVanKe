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
    public class ResponsableClubController : BaseController<ResponsableClub>, ICrudController<ResponsableClub, ResponsableClubModel>
    {       
        public JsonResult Get()
        {
            throw new NotImplementedException();
        }

        public JsonResult Create(ResponsableClubModel model)
        {
            throw new NotImplementedException();
        }

        public JsonResult Delete(ResponsableClubModel model)
        {
            throw new NotImplementedException();
        }

        public JsonResult Update(ResponsableClubModel model)
        {
            throw new NotImplementedException();
        }
    }
}