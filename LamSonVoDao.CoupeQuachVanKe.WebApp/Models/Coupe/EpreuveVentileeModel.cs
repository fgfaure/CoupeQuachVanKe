using System.Collections.Generic;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe
{
    public class EpreuveVentileeModel
    {
        /// <summary>
        /// Gets or sets the epreuve identifier.
        /// </summary>
        /// <value>
        /// The epreuve identifier.
        /// </value>
        public int EpreuveId { get; set; }
        /// <summary>
        /// Gets or sets the participation models.
        /// </summary>
        /// <value>
        /// The participation models.
        /// </value>
        public List<ParticipationModel> ParticipationModels { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="EpreuveVentileeModel"/> class.
        /// </summary>
        public EpreuveVentileeModel()
        {
            ParticipationModels = new List<ParticipationModel>();
        }
    }
}