﻿using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamSonVodao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    public class NetClientMapper : DataMapper<NetClient>
    {
        public NetClientMapper()
        {
            this.ToTable("NetClient");

            this.HasKey(netc => netc.Id);

            this.Property(netc => netc.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(netc => netc.IsConnected).IsRequired();            

            this.Property(netc => netc.ClientName).IsRequired();

            this.Property(netc => netc.Ip).IsOptional();

            this.Property(netc => netc.Password).IsRequired();

            this.HasRequired(netc => netc.ClientType).WithMany().HasForeignKey(netc => netc.NetClientTypeId);
        }
    }
}