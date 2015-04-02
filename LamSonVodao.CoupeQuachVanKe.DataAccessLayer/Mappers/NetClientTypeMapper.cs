/// <copyright file="NetClientTypeMapper.cs" company="ITESOFT">
/// Copyright (c) 2015 All Right Reserved
/// <author>fgf</author>
/// </copyright>

namespace LamSonVoDao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;

    public class NetClientTypeMapper : DataMapper<NetClientType>
    {
        public NetClientTypeMapper()
        {
            this.ToTable("NetClientTypes");

            this.HasKey(nct => nct.Id);

            this.Property(nct => nct.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(nct => nct.ClientType);
        }
    }
}
