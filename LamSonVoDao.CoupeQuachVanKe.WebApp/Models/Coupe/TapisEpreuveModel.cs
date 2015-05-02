using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe
{
    public class TapisEpreuveModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int EpreuveId { get; set; }

    }
}