namespace LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect
{
    using System.Collections.Generic;

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

        /////// <summary>
        /////// Gets or sets the client.
        /////// </summary>
        /////// <value>
        /////// The client.
        /////// </value>
        ////public NetClient NetClient { get; set; }

        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>
        /// The client identifier.
        /// </value>
        public int NetClientId { get; set; }
    }
}
