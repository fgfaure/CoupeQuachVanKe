using System;
using System.Collections.Generic;

namespace LamSonVodao.CoupeQuachVanKe.DataTransferOjbect
{
    /// <summary>
    /// 
    /// </summary>
    public class Coupe : BaseEntity
    {    
        /// <summary>
        /// Gets or sets the nom.
        /// </summary>
        /// <value>
        /// The nom.
        /// </value>
        public string Nom { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the nombre tapis.
        /// </summary>
        /// <value>
        /// The nombre tapis.
        /// </value>
        public int NombreTapis { get; set; }

        /// <summary>
        /// Gets or sets the responsable.
        /// </summary>
        /// <value>
        /// The responsable.
        /// </value>
        public ResponsableCoupe Responsable { get; set; }

        /// <summary>
        /// Gets or sets the voie.
        /// </summary>
        /// <value>
        /// The voie.
        /// </value>
        public string Voie { get; set; }

        /// <summary>
        /// Gets or sets the numero.
        /// </summary>
        /// <value>
        /// The numero.
        /// </value>
        public int Numero { get; set; }

        /// <summary>
        /// Gets or sets the complement.
        /// </summary>
        /// <value>
        /// The complement.
        /// </value>
        public string Complement { get; set; }

        /// <summary>
        /// Gets or sets the code postal.
        /// </summary>
        /// <value>
        /// The code postal.
        /// </value>
        public string CodePostal { get; set; }

        /// <summary>
        /// Gets or sets the ville.
        /// </summary>
        /// <value>
        /// The ville.
        /// </value>
        public string Ville { get; set; }

        /// <summary>
        /// Gets or sets the date debut.
        /// </summary>
        /// <value>
        /// The date debut.
        /// </value>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Gets or sets the date fin.
        /// </summary>
        /// <value>
        /// The date fin.
        /// </value>
        public DateTime DateFin { get; set; }

        /// <summary>
        /// Gets or sets the tapis.
        /// </summary>
        /// <value>
        /// The tapis.
        /// </value>
        public virtual ICollection<Aire> Aires { get; set; }

        /// <summary>
        /// Gets or sets the encadrants.
        /// </summary>
        /// <value>
        /// The encadrants.
        /// </value>
        public virtual ICollection<Encadrant> Encadrants { get; set; }

        /// <summary>
        /// Gets or sets the medecins.
        /// </summary>
        /// <value>
        /// The medecins.
        /// </value>
        public virtual ICollection<Medecin> Medecins { get; set; }
       
    }
}
