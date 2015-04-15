/// <copyright file="BaseEntity.cs" company="Lam Son Vo Dao">
/// Copyright (c) 2015 All Right Reserved
/// <author>fgf</author>
/// </copyright>

namespace LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect
{
    using LamSonVoDao.CoupeQuachVanKe.Contracts;

    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseEntity : IDataEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
    }
}
