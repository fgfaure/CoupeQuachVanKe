﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe
{
    /// <summary>
    /// 
    /// </summary>
    public class AireModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the coupe identifier.
        /// </summary>
        /// <value>
        /// The coupe identifier.
        /// </value>
        public int CoupeId { get; set; }

        /// <summary>
        /// Gets or sets the net client identifier.
        /// </summary>
        /// <value>
        /// The net client identifier.
        /// </value>
        public int NetClientId { get; set; }

        /// <summary>
        /// Gets or sets the epreuve identifier.
        /// </summary>
        /// <value>
        /// The epreuve identifier.
        /// </value>
        public string EpreuveId { get; set; }
    }
}