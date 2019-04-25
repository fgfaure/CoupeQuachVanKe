using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Web;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe
{
    public class DisponibiliteModel
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
        public string Description
        {
            get
            {
                return string.Format("{0} {1}",this.Date.ToString("dddd", new CultureInfo("fr-Fr")), (this.Matin) ? "Matin" : "Après-Midi");
            }
            set
            {
                var date = value.Split(' ')[0];
                var matin = value.Split(' ')[1];

                if (date.ToLowerInvariant() == "samedi")
                {
                    this.Date = new DateTime(2015, 5, 16);
                }
                else
                {
                    this.Date = new DateTime(2015, 5, 17);
                }

                this.Matin = (matin.ToLowerInvariant() == "matin");
            }
        }

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