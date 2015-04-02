using System.Collections.Generic;

namespace LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect
{
    /// <summary>
    /// 
    /// </summary>
    public class Aire : BaseEntity
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the epreuves.
        /// </summary>
        /// <value>
        /// The epreuves.
        /// </value>
        public ICollection<Epreuve> Epreuves { get; set; }

        /// <summary>
        /// Gets or sets the coupe.
        /// </summary>
        /// <value>
        /// The coupe.
        /// </value>
        public Coupe Coupe { get; set; }

        /// <summary>
        /// Gets or sets the coupe identifier.
        /// </summary>
        /// <value>
        /// The coupe identifier.
        /// </value>
        public int CoupeId { get; set; }

    }
}
