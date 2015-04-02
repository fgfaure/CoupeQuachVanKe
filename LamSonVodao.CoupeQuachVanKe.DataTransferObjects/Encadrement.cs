/// <copyright file="EncadrantEpreuve.cs" company="Lam Son Vo Dao">
/// Copyright (c) 2015 All Right Reserved
/// <author>fgf</author>
/// </copyright>

namespace LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect
{
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;


    /// <summary>
    /// 
    /// </summary>
    public class Encadrement : BaseEntity
    {
        /// <summary>
        /// Gets or sets the epreuve.
        /// </summary>
        /// <value>
        /// The epreuve.
        /// </value>
        public Epreuve Epreuve { get; set; }

        /// <summary>
        /// Gets or sets the epreuve identifier.
        /// </summary>
        /// <value>
        /// The epreuve identifier.
        /// </value>
        public int EpreuveId { get; set; }

        /// <summary>
        /// Gets or sets the encadrant.
        /// </summary>
        /// <value>
        /// The encadrant.
        /// </value>
        public Encadrant Encadrant { get; set; }

        /// <summary>
        /// Gets or sets the encadrant identifier.
        /// </summary>
        /// <value>
        /// The encadrant identifier.
        /// </value>
        public int EncadrantId { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        public Role Role { get; set; }
    }
}
