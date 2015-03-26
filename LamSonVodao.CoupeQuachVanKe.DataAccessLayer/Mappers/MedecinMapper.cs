namespace LamSonVodao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MedecinMapper : DataMapper<Medecin>
    {
        public MedecinMapper()
        {
            this.ToTable("Medecins");

            this.HasKey(medecin => medecin.Id);
            this.Property(medecin => medecin.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(medecin => medecin.Id).IsRequired();

            this.Property(medecin => medecin.Nom).IsRequired().HasMaxLength(255);

            this.Property(medecin => medecin.Prenom).IsRequired().HasMaxLength(255);

            this.Property(medecin => medecin.MailContact).IsOptional().HasMaxLength(255);

            this.Property(medecin => medecin.Telephone).IsOptional();

            this.HasRequired(medecin => medecin.Coupe)
                .WithMany(c => c.Medecins)
                .HasForeignKey(medecin => medecin.CoupeId)
                .WillCascadeOnDelete(true);  

        }
    }
}
