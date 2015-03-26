/// <copyright file="EpreuveEncadrantMapper.cs" company="fgfaure">
/// <author>fgf</author>
/// </copyright>

namespace LamSonVodao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DataAccessLayer.Mappers;
    using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;

    /// <summary>
    /// Mapper des encadrements
    /// </summary>
    public class EncadrementMapper : DataMapper<Encadrement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EncadrementMapper"/> class.
        /// </summary>
        public EncadrementMapper()
        {
            this.ToTable("EncadrantsEpreuves");

            this.HasKey(ee => ee.Id)
                .Property(ee => ee.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(ee => ee.Role).IsRequired();

            this.HasRequired(ee => ee.Encadrant).WithMany(encadrant => encadrant.EpreuveSurveillees).HasForeignKey(ee => ee.EncadrantId).WillCascadeOnDelete(true);
            this.HasRequired(ee => ee.Epreuve).WithMany(epreuve => epreuve.Encadrements).HasForeignKey(ee => ee.EpreuveId).WillCascadeOnDelete(true);

        }
    }
}
