using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe
{
    public class DisponibiliteModel
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Disponibilite"/> is matin.
        /// </summary>
        /// <value>
        ///   <c>true</c> if matin; otherwise, <c>false</c>.
        /// </value>
        public bool Matin { get; set; }

        /// <summary>
        /// Gets or sets the encadrant identifier.
        /// </summary>
        /// <value>
        /// The encadrant identifier.
        /// </value>
        public int EncadrantId { get; set; }
    }
}