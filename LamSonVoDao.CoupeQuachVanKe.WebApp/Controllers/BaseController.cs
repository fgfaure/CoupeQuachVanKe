namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    using LamSonVoDao.CoupeQuachVanKe.AccesPattern;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public class BaseController<Entity> : Controller where Entity : BaseEntity
    {
        protected UnitOfWork unitOfWork = new UnitOfWork();
        protected Repository<Entity> repository;

        public BaseController()
        {
            this.repository = this.unitOfWork.Repository<Entity>();
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}
