/// <copyright file="CompetiteurEpreuve.cs" company="Lam Son Vo Dao">
/// Copyright (c) 2015 All Right Reserved
/// <author>fgf</author>
/// </copyright>

namespace LamSonVodao.CoupeQuachVanKe.DataTransferOjbect
{


    /// <summary>
    /// 
    /// </summary>
    public class Resultat : BaseEntity
    {
        /// <summary>
        /// Gets or sets the competiteur.
        /// </summary>
        /// <value>
        /// The competiteur.
        /// </value>
        public virtual Competiteur Competiteur { get; set; }

        /// <summary>
        /// Gets or sets the competiteur identifier.
        /// </summary>
        /// <value>
        /// The competiteur identifier.
        /// </value>
        public int CompetiteurId { get; set; }

        /// <summary>
        /// Gets or sets the epreuve.
        /// </summary>
        /// <value>
        /// The epreuve.
        /// </value>
        public virtual Epreuve Epreuve { get; set; }

        /// <summary>
        /// Gets or sets the epreuve identifier.
        /// </summary>
        /// <value>
        /// The epreuve identifier.
        /// </value>
        public int EpreuveId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [inscription validee].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [inscription validee]; otherwise, <c>false</c>.
        /// </value>
        public bool InscriptionValidee { get; set; }

        /// <summary>
        /// Gets or sets the classement.
        /// </summary>
        /// <value>
        /// The classement.
        /// </value>
        public int Classement { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>
        /// The score.
        /// </value>
        public int Score { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Resultat" /> is abandon.
        /// </summary>
        /// <value>
        ///   <c>true</c> if abandon; otherwise, <c>false</c>.
        /// </value>
        public bool Abandon { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Resultat" /> is blessure.
        /// </summary>
        /// <value>
        ///   <c>true</c> if blessure; otherwise, <c>false</c>.
        /// </value>
        public bool Blessure { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Resultat" /> is disqualification.
        /// </summary>
        /// <value>
        ///   <c>true</c> if disqualification; otherwise, <c>false</c>.
        /// </value>
        public bool Disqualification { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Resultat" /> is absence.
        /// </summary>
        /// <value>
        ///   <c>true</c> if absence; otherwise, <c>false</c>.
        /// </value>
        public bool Absence { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Resultat" /> is renvoi.
        /// </summary>
        /// <value>
        ///   <c>true</c> if renvoi; otherwise, <c>false</c>.
        /// </value>
        public bool Renvoi { get; set; }
    }
}
