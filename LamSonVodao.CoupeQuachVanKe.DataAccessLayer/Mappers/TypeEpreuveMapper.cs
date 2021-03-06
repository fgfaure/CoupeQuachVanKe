﻿using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamSonVoDao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    public class TypeEpreuveMapper : DataMapper<TypeEpreuve>
    {
        public TypeEpreuveMapper()
        {
            this.ToTable("TypesEpreuve");

            this.HasKey(te => te.Id);

            this.Property(te => te.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(te => te.Id).IsRequired();

            this.Property(te => te.Nom).IsRequired();
            this.Property(te => te.Nom).HasMaxLength(255);

            this.Property(te => te.Identifier).IsRequired();
            this.Property(te => te.Identifier).HasMaxLength(255);          

            this.Property(te => te.Description).IsOptional();
            this.Property(te => te.Description).IsFixedLength().HasMaxLength(14);

            this.Property(te => te.Technique).IsRequired();

            this.Property(te => te.UseSwissSystem).IsRequired();

            this.HasRequired(te => te.Coupe)
            .WithMany(c => c.TypesEpreuve)
            .HasForeignKey(te => te.CoupeId)
            .WillCascadeOnDelete(true);  

        }
    }
}
