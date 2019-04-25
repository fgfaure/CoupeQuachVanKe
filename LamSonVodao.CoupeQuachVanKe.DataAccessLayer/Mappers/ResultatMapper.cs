namespace LamSonVoDao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ResultatMapper : DataMapper<Resultat>
    {
        public ResultatMapper()
        {
            this.ToTable("Resultats");

            this.HasKey(resultat => resultat.Id);
            //this.Property(resultat => resultat.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //this.Property(resultat => resultat.Id).IsRequired();

            this.Property(resultat => resultat.Classement).IsRequired();            

            this.Property(resultat => resultat.Score).IsRequired();

            this.Property(resultat => resultat.Abandon).IsRequired();

            this.Property(resultat => resultat.Blessure).IsRequired();

            this.Property(resultat => resultat.Disqualification).IsRequired();

            this.Property(resultat => resultat.Absence).IsRequired();

            this.Property(resultat => resultat.Renvoi).IsRequired();

            this.Property(resultat => resultat.Date).IsRequired();

            this.HasRequired(resultat => resultat.Participation).WithRequiredDependent(participation => participation.Resultat).WillCascadeOnDelete(true);
        }
    }
}
