﻿using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe
{
    public class EncadrantModel
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
        public int TailleTenueId { get; set; }

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
        public int GenreId { get; set; }
      
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
        public IEnumerable<DisponibiliteModel> DispoArbitre { get; set; }

        /// <summary>
        /// Gets or sets the disponibilites.
        /// </summary>
        /// <value>
        /// The disponibilites.
        /// </value>
        public IEnumerable<DisponibiliteModel> DispoAdministrateur { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        public string Role { get; set; }
    }
}