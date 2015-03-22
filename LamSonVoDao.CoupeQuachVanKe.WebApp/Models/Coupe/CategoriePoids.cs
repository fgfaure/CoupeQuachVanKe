using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe
{
    public class CategoriePoids
    {
        public int Id { get; set; }

          /// <summary>
        /// Gets or sets the nom.
        /// </summary>
        /// <value>
        /// The nom.
        /// </value>
        public string Nom { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the valeur basse.
        /// </summary>
        /// <value>
        /// The valeur basse.
        /// </value>
        public float ValeurBasse { get; set; }

        /// <summary>
        /// Gets or sets the valeur haute.
        /// </summary>
        /// <value>
        /// The valeur haute.
        /// </value>
        public float ValeurHaute { get; set; }
            
    }
}