using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe
{
    /// <summary>
    /// 
    /// </summary>
    public class ResponsableCoupeModel
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
        /// Gets or sets the prenom.
        /// </summary>
        /// <value>
        /// The prenom.
        /// </value>
        public string Prenom { get; set; }

        /// <summary>
        /// Gets or sets the adresse.
        /// </summary>
        /// <value>
        /// The adresse.
        /// </value>
        public string Adresse { get; set; }

        /// <summary>
        /// Gets or sets the telephone.
        /// </summary>
        /// <value>
        /// The telephone.
        /// </value>
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets the email contact.
        /// </summary>
        /// <value>
        /// The email contact.
        /// </value>
        public string MailContact { get; set; }

        /// <summary>
        /// Gets or sets the coupe identifier.
        /// </summary>
        /// <value>
        /// The coupe identifier.
        /// </value>
        public int CoupeId { get; set; }
    }
}