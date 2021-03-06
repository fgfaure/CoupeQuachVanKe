﻿namespace LamSonVoDao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AireMapper : DataMapper<Aire>
    {
        public AireMapper()
        {
            this.ToTable("Aires");

            this.HasKey(aire => aire.Id);
            this.Property(aire => aire.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(aire => aire.Id).IsRequired();

            this.Property(aire => aire.Description).IsRequired();
            this.Property(aire => aire.Description).HasMaxLength(255);

            this.Property(aire => aire.NetClientId).IsOptional();

            //this.HasRequired(aire => aire.NetClient).WithRequiredPrincipal().WillCascadeOnDelete(false);

            this.HasRequired(aire => aire.Coupe)
                .WithMany(coupe => coupe.Aires)
                .HasForeignKey(aire => aire.CoupeId).WillCascadeOnDelete(false);
        }
    }
}
