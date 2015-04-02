using System.Collections.Generic;

namespace LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect
{
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

        /// <summary>
        /// Gets or sets the competiteurs.
        /// </summary>
        /// <value>
        /// The competiteurs.
        /// </value>
        public ICollection<Competiteur> Competiteurs { get; set; }

        /// <summary>
        /// Gets or sets the encadrants.
        /// </summary>
        /// <value>
        /// The encadrants.
        /// </value>
        public virtual ICollection<Encadrant> Encadrants { get; set; }

        /// <summary>
        /// Gets or sets the responsable.
        /// </summary>
        /// <value>
        /// The responsable.
        /// </value>
        public ResponsableClub Responsable { get; set; }
       
    }
}
