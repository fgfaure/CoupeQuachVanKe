using LamSonVoDao.CoupeQuachVanKe.WebApp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe
{
    public class ParticipationCombatModel : ParticipationModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ParticipationCombatModel"/> is vainqueur.
        /// </summary>
        /// <value>
        ///   <c>true</c> if vainqueur; otherwise, <c>false</c>.
        /// </value>
        public bool? Vainqueur { get; set; }
        /// <summary>
        /// Gets or sets the couleur.
        /// </summary>
        /// <value>
        /// The couleur.
        /// </value>
        public string Couleur { get; set; }

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>
        /// The children.
        /// </value>
        public IEnumerable<ParticipationCombatModel> Children { get; set; }

        /// <summary>
        /// Gets or sets the rank.
        /// </summary>
        /// <value>
        /// The rank.
        /// </value>
        public RankContest Rank { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="ParticipationCombatModel"/> class.
        /// </summary>
        public ParticipationCombatModel()
        {
            this.Couleur = "#00ff00";
            this.Nom = string.Empty;
            this.Prenom = string.Empty;
        }
    }
}