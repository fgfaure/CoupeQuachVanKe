namespace LamSonVodao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DisponibiliteMapper : DataMapper<Disponibilite>
    {
        public DisponibiliteMapper()
        {
            this.ToTable("Disponibilites");

            this.HasKey(e => e.Id);
            this.Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(e => e.Id).IsRequired();

            this.Property(d => d.Role).IsRequired();

            this.Property(d => d.Date).IsRequired();

            this.Property(d => d.Matin).IsRequired();

            this.HasRequired(d => d.Encadrant)
                .WithMany(encadrant => encadrant.Disponibilites)
                .HasForeignKey(d => d.EncadrantId).WillCascadeOnDelete(true);
        }

    }
}
