using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe
{
    public class EpreuveCombatModel : EpreuveTechniqueModel
    {       
        /// <summary>
        /// Gets or sets the valeur basse.
        /// </summary>
        /// <value>
        /// The valeur basse.
        /// </value>
        public float PoidsMini { get; set; }

        /// <summary>
        /// Gets or sets the valeur haute.
        /// </summary>
        /// <value>
        /// The valeur haute.
        /// </value>
        public float PoidsMaxi { get; set; }
    }
}