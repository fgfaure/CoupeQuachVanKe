namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe
{
    /// <summary>
    /// 
    /// </summary>
    public class ParticipationModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParticipationModel"/> class.
        /// </summary>
        /// <param name="participantId">The participant identifier.</param>
        /// <param name="epreuveId">The epreuve identifier.</param>
        public ParticipationModel(int participantId, int epreuveId)
        {
            ParticipantId = participantId;
            EpreuveId = epreuveId;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ParticipationModel"/> class.
        /// </summary>
        public ParticipationModel()
        {

        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ParticipantId { get; set; }

        /// <summary>
        /// Gets or sets the nom.
        /// </summary>
        /// <value>
        /// The nom.
        /// </value>
        public string Nom { get; set; }

        /// <summary>
        /// Gets or sets the prenom.
        /// </summary>
        /// <value>
        /// The prenom.
        /// </value>
        public string Prenom { get; set; }

        /// <summary>
        /// Gets or sets the club.
        /// </summary>
        /// <value>
        /// The club.
        /// </value>
        public string Club { get; set; }

        /// <summary>
        /// Gets or sets the club identifier.
        /// </summary>
        /// <value>
        /// The club identifier.
        /// </value>
        public int ClubId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ParticipationModel"/> is present.
        /// </summary>
        /// <value>
        ///   <c>true</c> if present; otherwise, <c>false</c>.
        /// </value>
        public bool Present { get; set; }

        /// <summary>
        /// Gets or sets the epreuve identifier.
        /// </summary>
        /// <value>
        /// The epreuve identifier.
        /// </value>
        public int EpreuveId { get; set; }

        /// <summary>
        /// Gets or sets the classement.
        /// </summary>
        /// <value>
        /// The classement.
        /// </value>
        public string Classement { get; set; }

        /// <summary>
        /// Gets or sets the categorie id for pratiquant.
        /// </summary>
        /// <value>
        /// The categorie id for pratiquant.
        /// </value>
        public int CategoriePratiquantId { get; set; }
    }
}