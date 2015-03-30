using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe
{
    public class EpreuveModel
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
        public string Statut { get; set; }

        /// <summary>
        /// Gets or sets the type epreuve.
        /// </summary>
        /// <value>
        /// The type epreuve.
        /// </value>
        public string TypeEpreuve { get; set; }

        /// <summary>
        /// Gets or sets the categorie.
        /// </summary>
        /// <value>
        /// The categorie.
        /// </value>
        public string Categorie { get; set; }

        /// <summary>
        /// Gets or sets the genre categorie.
        /// </summary>
        /// <value>
        /// The genre categorie.
        /// </value>
        public string GenreCategorie { get; set; }

        /// <summary>
        /// Gets or sets the grade autorise.
        /// </summary>
        /// <value>
        /// The grade autorise.
        /// </value>
        public string GradeAutorise { get; set; }

        /// <summary>
        /// Gets or sets the categorie poids.
        /// </summary>
        /// <value>
        /// The categorie poids.
        /// </value>
        public CategoriePoidsModel CategoriePoids { get; set; }       
    }
}