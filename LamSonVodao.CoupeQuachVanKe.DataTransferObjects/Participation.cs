
namespace LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect
{
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public class Participation : BaseEntity
    {
        /// <summary>
        /// Gets or sets the competiteur.
        /// </summary>
        /// <value>
        /// The competiteur.
        /// </value>
        public Competiteur Competiteur { get; set; }

        /// <summary>
        /// Gets or sets the competiteur identifier.
        /// </summary>
        /// <value>
        /// The competiteur identifier.
        /// </value>
        public int CompetiteurId { get; set; }

        /// <summary>
        /// Gets or sets the epreuve.
        /// </summary>
        /// <value>
        /// The epreuve.
        /// </value>
        public Epreuve Epreuve { get; set; }

        /// <summary>
        /// Gets or sets the epreuve identifier.
        /// </summary>
        /// <value>
        /// The epreuve identifier.
        /// </value>
        public int EpreuveId { get; set; }

        /// <summary>
        /// Gets or sets the resultat.
        /// </summary>
        /// <value>
        /// The resultat.
        /// </value>
        public Resultat Resultat { get; set; }

        /// <summary>
        /// Gets or sets the resultat identifier.
        /// </summary>
        /// <value>
        /// The resultat identifier.
        /// </value>
        public int ResultatId { get; set; }
    }
}
