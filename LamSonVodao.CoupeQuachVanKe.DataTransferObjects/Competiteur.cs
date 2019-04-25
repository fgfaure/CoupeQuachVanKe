namespace LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect
{
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Participant" />
    public class Competiteur : Participant
    {
        /////// <summary>
        /////// Gets or sets the nom.
        /////// </summary>
        /////// <value>
        /////// The nom.
        /////// </value>
        ////public string Nom { get; set; }

        /////// <summary>
        /////// Gets or sets the prenom.
        /////// </summary>
        /////// <value>
        /////// The prenom.
        /////// </value>
        ////public string Prenom { get; set; }

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
        public CategoriePratiquant CategoriePratiquant { get; set; }

        /// <summary>
        /// Gets or sets the categorie pratiquant identifier.
        /// </summary>
        /// <value>
        /// The categorie pratiquant identifier.
        /// </value>
        public int CategoriePratiquantId { get; set; }

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
        public float Poids { get; set; }

        /// <summary>
        /// Gets or sets the nb pesee.
        /// </summary>
        /// <value>
        /// The nb pesee.
        /// </value>
        public int NbPesee { get; set; } 
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
        /// Gets or sets a value indicating whether [inscrit pour quyen dong dien].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [inscrit pour quyen dong dien]; otherwise, <c>false</c>.
        /// </value>
        public bool InscritPourQuyenDongDien { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [inscription valide pour coupe].
        /// </summary>
        /// <value>
        /// <c>true</c> if [inscription valide pour coupe]; otherwise, <c>false</c>.
        /// </value>
        public bool InscriptionValidePourCoupe { get; set; }

        /// <summary>
        /// Gets or sets the numero equipe.
        /// </summary>
        /// <value>
        /// The numero equipe.
        /// </value>
        public int NumeroEquipe { get; set; }

        /// <summary>
        /// Gets or sets the equipe.
        /// </summary>
        /// <value>
        /// The equipe.
        /// </value>
        public virtual Equipe Equipe { get; set; }

        /// <summary>
        /// Gets or sets the equipe identifier.
        /// </summary>
        /// <value>
        /// The equipe identifier.
        /// </value>
        public int? EquipeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [inscription is correct].
        /// </summary>
        /// <value>
        /// <c>true</c> if [inscription is correct]; otherwise, <c>false</c>.
        /// </value>
        public bool ValidImport { get; set; }

    }
}
