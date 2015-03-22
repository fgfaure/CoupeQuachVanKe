using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamSonVodao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    public class CoupeMapper : DataMapper<Coupe>
    {
        public CoupeMapper()
        {
            this.ToTable("Coupes");

            this.HasKey(coupe => coupe.Id);
            this.Property(coupe => coupe.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(coupe => coupe.Id).IsRequired();

            this.Property(coupe => coupe.Nom).IsRequired().HasMaxLength(255);

            this.Property(coupe => coupe.Description).IsRequired().HasMaxLength(255);

            this.Property(coupe => coupe.NombreTapis).IsRequired();

            this.Property(coupe => coupe.Voie).IsOptional().HasMaxLength(255);

            this.Property(coupe => coupe.Numero).IsOptional();

            this.Property(coupe => coupe.Complement).IsOptional().HasMaxLength(255);

            this.Property(coupe => coupe.CodePostal).IsRequired().IsFixedLength().HasMaxLength(5);

            this.Property(coupe => coupe.Ville).IsRequired().HasMaxLength(255);

            this.Property(coupe => coupe.DateDebut).IsRequired();

            this.Property(coupe => coupe.DateFin).IsRequired();

//            this.HasRequired(coupe => coupe.Responsable).WithRequiredPrincipal(responsable => responsable.Coupe);
        }
    }
}
