using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe
{
    public class CompetiteurConnection
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets from competiteur identifier.
        /// </summary>
        /// <value>
        /// From competiteur identifier.
        /// </value>
        public int FromCompetiteurId { get; set; }

        /// <summary>
        /// Gets or sets to competiteur identifier.
        /// </summary>
        /// <value>
        /// To competiteur identifier.
        /// </value>
        public int ToCompetiteurId { get; set; }

        /// <summary>
        /// Gets or sets from point x.
        /// </summary>
        /// <value>
        /// From point x.
        /// </value>
        public int FromPointX { get; set; }

        /// <summary>
        /// Gets or sets from point y.
        /// </summary>
        /// <value>
        /// From point y.
        /// </value>
        public int FromPointY { get; set; }

        /// <summary>
        /// Gets or sets to point x.
        /// </summary>
        /// <value>
        /// To point x.
        /// </value>
        public int ToPointX { get; set; }

        /// <summary>
        /// Gets or sets to point y.
        /// </summary>
        /// <value>
        /// To point y.
        /// </value>
        public int ToPointY { get; set; }
    }
}