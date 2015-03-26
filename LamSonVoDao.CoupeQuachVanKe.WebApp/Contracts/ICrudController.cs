namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Contracts
{
    using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public interface ICrudController<Entity,Model> where Entity:BaseEntity where Model : class
    {
        JsonResult Get();

        [HttpPost]
        JsonResult Create(Model model);

        [HttpPost]
        JsonResult Delete(Model model);

        [HttpPost]
        JsonResult Update(Model model);
    }
}
