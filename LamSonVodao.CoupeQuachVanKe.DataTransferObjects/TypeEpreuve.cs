using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LamSonVodao.CoupeQuachVanKe.DataTransferOjbect
{
    /// <summary>
    /// 
    /// </summary>
    public class TypeEpreuve : BaseEntity
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
