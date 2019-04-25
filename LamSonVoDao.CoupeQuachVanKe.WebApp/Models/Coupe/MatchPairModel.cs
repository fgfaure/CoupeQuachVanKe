using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe
{
    /// <summary>
    /// 
    /// </summary>
    public class MatchPairModel
    {
        /// <summary>
        /// Gets or sets the red.
        /// </summary>
        /// <value>
        /// The red.
        /// </value>
        public ParticipationCombatModel Red { get; set; }

        /// <summary>
        /// Gets or sets the blue.
        /// </summary>
        /// <value>
        /// The blue.
        /// </value>
        public ParticipationCombatModel Blue { get; set; }

        /// <summary>
        /// Gets or sets the rencontre.
        /// </summary>
        /// <value>
        /// The rencontre.
        /// </value>
        public string Rencontre { get; set; }
    }
}