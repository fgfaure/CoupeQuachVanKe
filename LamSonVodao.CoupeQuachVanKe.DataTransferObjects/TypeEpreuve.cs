using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect
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

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TypeEpreuve"/> is technique.
        /// </summary>
        /// <value>
        ///   <c>true</c> if technique; otherwise, <c>false</c>.
        /// </value>
        public bool Technique { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [use swiss system].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use swiss system]; otherwise, <c>false</c>.
        /// </value>
        public bool UseSwissSystem { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Identifier { get; set; }
    }
}
