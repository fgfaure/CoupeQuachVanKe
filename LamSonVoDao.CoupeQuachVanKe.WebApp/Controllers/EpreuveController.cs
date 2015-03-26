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

    public class EpreuveController : BaseController<Epreuve>, ICrudController<Epreuve, EpreuveModel>
    {        
        public JsonResult Get()
        {
            throw new NotImplementedException();
        }

        public JsonResult Create(EpreuveModel model)
        {
            throw new NotImplementedException();
        }

        public JsonResult Delete(EpreuveModel model)
        {
            throw new NotImplementedException();
        }

        public JsonResult Update(EpreuveModel model)
        {
            throw new NotImplementedException();
        }
    }
}