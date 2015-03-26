using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
using System;
using System.Collections.Generic;

namespace LamSonVodao.CoupeQuachVanKe.DataTransferOjbect
{
    /// <summary>
    /// 
    /// </summary>
    public class Competiteur : BaseEntity
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
        /// Gets or sets the grade.
        /// </summary>
        /// <value>
        /// The grade.
        /// </value>
        public Grade Grade { get; set; }

        /// <summary>
        /// Gets or sets the categorie.
        /// </summary>
        /// <value>
        /// The categorie.
        /// </value>
        public CategoriePratiquant Categorie { get; set; }

        /// <summary>
        /// Gets or sets the date naissance.
        /// </summary>
        /// <value>
        /// The date naissance.
        /// </value>
        public DateTime DateNaissance { get; set; }

        /// <summary>
        /// Gets or sets the sexe.
        /// </summary>
        /// <value>
        /// The sexe.
        /// </value>
        public Genre Sexe { get; set; }

        /// <summary>
        /// Gets or sets the licence ffkda.
        /// </summary>
        /// <value>
        /// The licence ffkda.
        /// </value>
        public string LicenceFFKDA { get; set; }

        /// <summary>
        /// Gets or sets the annee pratique.
        /// </summary>
        /// <value>
        /// The annee pratique.
        /// </value>
        public int NbAnneePratique { get; set; }

        /// <summary>
        /// Gets or sets the poids.
        /// </summary>
        /// <value>
        /// The poids.
        /// </value>
        public int Poids { get; set; }

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
        /// Gets or sets the epreuves.
        /// </summary>
        /// <value>
        /// The epreuves.
        /// </value>
        public virtual ICollection<Resultat> Resultats { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [inscrit pour quyen].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [inscrit pour quyen]; otherwise, <c>false</c>.
        /// </value>
        public bool InscritPourQuyen { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [inscrit pour bai vu khi].
        /// </summary>
        /// <value>
        /// <c>true</c> if [inscrit pour bai vu khi]; otherwise, <c>false</c>.
        /// </value>
        public bool InscritPourBaiVuKhi { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [inscrit pour combat].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [inscrit pour combat]; otherwise, <c>false</c>.
        /// </value>
        public bool InscritPourCombat { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [inscrit pour song luyen].
        /// </summary>
        /// <value>
        /// <c>true</c> if [inscrit pour song luyen]; otherwise, <c>false</c>.
        /// </value>
        public bool InscritPourSongLuyen { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [inscription valide pour coupe].
        /// </summary>
        /// <value>
        /// <c>true</c> if [inscription valide pour coupe]; otherwise, <c>false</c>.
        /// </value>
        public bool InscriptionValidePourCoupe { get; set; }

        /// <summary>
        /// Gets or sets the equipe song luyen.
        /// </summary>
        /// <value>
        /// The equipe song luyen.
        /// </value>
        public int EquipeSongLuyen { get; set; }

    }
}
