﻿using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
using System.Collections.Generic;

namespace LamSonVodao.CoupeQuachVanKe.DataTransferOjbect
{
    /// <summary>
    /// 
    /// </summary>
    public class Encadrant : BaseEntity
    {
        /// <summary>
        /// Gets or sets the nom.
        /// </summary>
        /// <value>
        /// The nom.
        /// </value>
        public string Nom { get; set; }

        /// <summary>
        /// Gets or sets the prenom.
        /// </summary>
        /// <value>
        /// The prenom.
        /// </value>
        public string Prenom { get; set; }

        /// <summary>
        /// Gets or sets the mail contact.
        /// </summary>
        /// <value>
        /// The mail contact.
        /// </value>
        public string MailContact { get; set; }

        /// <summary>
        /// Gets or sets the taille tenue.
        /// </summary>
        /// <value>
        /// The taille tenue.
        /// </value>
        public TailleTenue TailleTenue { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [est competiteur].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [est competiteur]; otherwise, <c>false</c>.
        /// </value>
        public bool EstCompetiteur { get; set; }

        /// <summary>
        /// Gets or sets the sexe.
        /// </summary>
        /// <value>
        /// The sexe.
        /// </value>
        public Genre Sexe { get; set; }

        /// <summary>
        /// Gets or sets the club.
        /// </summary>
        /// <value>
        /// The club.
        /// </value>
        public virtual Club Club { get; set; }

        /// <summary>
        /// Gets or sets the club identifier.
        /// </summary>
        /// <value>
        /// The club identifier.
        /// </value>
        public int ClubId { get; set; }

        /// <summary>
        /// Gets or sets the disponibilites.
        /// </summary>
        /// <value>
        /// The disponibilites.
        /// </value>
        public virtual ICollection<Disponibilite> Disponibilites { get; set; }

        /// <summary>
        /// Gets or sets the epreuves.
        /// </summary>
        /// <value>
        /// The epreuves.
        /// </value>
        public virtual ICollection<Encadrement> EpreuveSurveillees { get; set; }        
    }
}
