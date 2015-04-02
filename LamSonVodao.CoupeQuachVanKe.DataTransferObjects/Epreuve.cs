using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
using System.Collections.Generic;

namespace LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect
{
    /// <summary>
    /// 
    /// </summary>
    public class Epreuve : BaseEntity
    {
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
        public StatutEpreuve Statut { get; set; }

        /// <summary>
        /// Gets or sets the type epreuve.
        /// </summary>
        /// <value>
        /// The type epreuve.
        /// </value>
        public TypeEpreuve TypeEpreuve { get; set; }

        /// <summary>
        /// Gets or sets the type epreuve identifier.
        /// </summary>
        /// <value>
        /// The type epreuve identifier.
        /// </value>
        public int TypeEpreuveId { get; set; }

        /// <summary>
        /// Gets or sets the categorie.
        /// </summary>
        /// <value>
        /// The categorie.
        /// </value>
        public CategoriePratiquant CategoriePratiquant { get; set; }

        /// <summary>
        /// Gets or sets the genre categorie.
        /// </summary>
        /// <value>
        /// The genre categorie.
        /// </value>
        public GenreEpreuve GenreCategorie { get; set; }

        /// <summary>
        /// Gets or sets the grade autorise.
        /// </summary>
        /// <value>
        /// The grade autorise.
        /// </value>
        public Grade GradeAutorise { get; set; }      

        /// <summary>
        /// Gets or sets the encadrants.
        /// </summary>
        /// <value>
        /// The encadrants.
        /// </value>
        public virtual ICollection<Encadrement> Encadrements { get; set; }

        /// <summary>
        /// Gets or sets the resultats.
        /// </summary>
        /// <value>
        /// The resultats.
        /// </value>
        public virtual ICollection<Resultat> Resultats { get; set; }       
    }
}
