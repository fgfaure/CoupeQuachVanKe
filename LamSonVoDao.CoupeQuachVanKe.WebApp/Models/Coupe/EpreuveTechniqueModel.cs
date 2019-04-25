using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe
{
    public class EpreuveTechniqueModel
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
        /// Gets or sets the statut.
        /// </summary>
        /// <value>
        /// The statut.
        /// </value>
        public int StatutId { get; set; }

        /// <summary>
        /// Gets or sets the statut.
        /// </summary>
        /// <value>
        /// The statut.
        /// </value>
        public bool IsMerged { get; set; }

        /// <summary>
        /// Gets or sets the type epreuve.
        /// </summary>
        /// <value>
        /// The type epreuve.
        /// </value>
        public int TypeEpreuveId { get; set; }
        
        /// <summary>
        /// Gets or sets the genre categorie.
        /// </summary>
        /// <value>
        /// The genre categorie.
        /// </value>
        public int GenreCategorieId { get; set; }

        /// <summary>
        /// Gets or sets the grade autorise.
        /// </summary>
        /// <value>
        /// The grade autorise.
        /// </value>
        public int GradeAutoriseId { get; set; }

        /// <summary>
        /// Gets or sets the categorie identifier.
        /// </summary>
        /// <value>
        /// The categorie identifier.
        /// </value>
        public int CategorieId { get; set; }
    }
}