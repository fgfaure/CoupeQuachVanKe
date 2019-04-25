using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe
{
    /// <summary>
    /// 
    /// </summary>
    public class CategoriePratiquantModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the nom.
        /// </summary>
        /// <value>
        /// The nom.
        /// </value>
        public string Nom { get; set; }

        /// <summary>
        /// Gets or sets the age minimum.
        /// </summary>
        /// <value>
        /// The age minimum.
        /// </value>
        public int AgeMin { get; set; }

        /// <summary>
        /// Gets or sets the age maximum.
        /// </summary>
        /// <value>
        /// The age maximum.
        /// </value>
        public int AgeMax { get; set; }

        /// <summary>
        /// Gets or sets the duree in seconds.
        /// </summary>
        /// <value>
        /// The duree in seconds.
        /// </value>
        public int Duree { get; set; }
    }
}