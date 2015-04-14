namespace LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect
{    
    using System.Collections.Generic;
    /// <summary>
    /// 
    /// </summary>
    public class CategoriePratiquant : BaseEntity
    {
        /// <summary>
        /// Gets or sets the nom.
        /// </summary>
        /// <value>
        /// The nom.
        /// </value>
        public string Nom { get; set; }

        /// <summary>
        /// Gets or sets the age maximum.
        /// </summary>
        /// <value>
        /// The age maximum.
        /// </value>
        public int AgeMax { get; set; }

        /// <summary>
        /// Gets or sets the age minimum.
        /// </summary>
        /// <value>
        /// The age minimum.
        /// </value>
        public int AgeMin { get; set; }

        /// <summary>
        /// Gets or sets the epreuves.
        /// </summary>
        /// <value>
        /// The epreuves.
        /// </value>
        public ICollection<Epreuve> Epreuves { get; set; }

        /// <summary>
        /// Gets or sets the competiteurs.
        /// </summary>
        /// <value>
        /// The competiteurs.
        /// </value>
        public ICollection<Competiteur> Competiteurs { get; set; }
    }
}
