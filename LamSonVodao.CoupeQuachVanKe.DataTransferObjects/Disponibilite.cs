using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
using System;

namespace LamSonVodao.CoupeQuachVanKe.DataTransferOjbect
{
    /// <summary>
    /// 
    /// </summary>
    public class Disponibilite : BaseEntity
    {
        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        public Role Role { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Disponibilite"/> is matin.
        /// </summary>
        /// <value>
        ///   <c>true</c> if matin; otherwise, <c>false</c>.
        /// </value>
        public bool Matin { get; set; }

        /// <summary>
        /// Gets or sets the encadrant.
        /// </summary>
        /// <value>
        /// The encadrant.
        /// </value>
        public virtual Encadrant Encadrant { get; set; }

        /// <summary>
        /// Gets or sets the encadrant identifier.
        /// </summary>
        /// <value>
        /// The encadrant identifier.
        /// </value>
        public int EncadrantId { get; set; }
    }
}
