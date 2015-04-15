
namespace LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public class Club : BaseEntity
    {
        /// <summary>
        /// Gets or sets the nom.
        /// </summary>
        /// <value>
        /// The nom.
        /// </value>
        public string Nom { get; set; }

        /// <summary>
        /// Gets or sets the numero affiliation.
        /// </summary>
        /// <value>
        /// The numero affiliation.
        /// </value>
        public string NumeroAffiliation { get; set; }

        /////// <summary>
        /////// Gets or sets the competiteurs.
        /////// </summary>
        /////// <value>
        /////// The competiteurs.
        /////// </value>
        ////public ICollection<Competiteur> Competiteurs { get; set; }

        /// <summary>
        /// Gets or sets the participants.
        /// </summary>
        /// <value>
        /// The participants.
        /// </value>
         public ICollection<Participant> Participants { get; set; }

        /// <summary>
        /// Gets or sets the encadrants.
        /// </summary>
        /// <value>
        /// The encadrants.
        /// </value>
        public ICollection<Encadrant> Encadrants { get; set; }

        /// <summary>
        /// Gets or sets the responsable.
        /// </summary>
        /// <value>
        /// The responsable.
        /// </value>
        public ResponsableClub Responsable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [inscription is correct].
        /// </summary>
        /// <value>
        /// <c>true</c> if [inscription is correct]; otherwise, <c>false</c>.
        /// </value>
        public bool InscriptionIsCorrect { get; set; }

        /////// <summary>
        /////// Gets or sets the equipes song luyen.
        /////// </summary>
        /////// <value>
        /////// The equipes song luyen.
        /////// </value>
        ////public ICollection<EquipeSongLuyen> EquipesSongLuyen { get; set; }

    }
}
