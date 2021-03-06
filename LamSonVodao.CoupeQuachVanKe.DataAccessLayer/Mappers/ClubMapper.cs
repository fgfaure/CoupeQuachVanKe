﻿namespace LamSonVoDao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;

    public class ClubMapper : DataMapper<Club>
    {
        public ClubMapper()
        {
            this.ToTable("Clubs");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).IsRequired();

            this.Property(c => c.Nom).IsRequired();
            this.Property(c => c.Nom).HasMaxLength(255);

            this.Property(c => c.NumeroAffiliation).HasMaxLength(255);
            this.Property(c => c.NumeroAffiliation).IsRequired();           
        }
    }
}
