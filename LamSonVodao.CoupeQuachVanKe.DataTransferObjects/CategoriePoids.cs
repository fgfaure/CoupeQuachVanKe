
namespace LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect
{
    /// <summary>
    /// 
    /// </summary>
    public class CategoriePoids : BaseEntity
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
        /// Gets or sets the valeur basse.
        /// </summary>
        /// <value>
        /// The valeur basse.
        /// </value>
        public float ValeurBasse { get; set; }

        /// <summary>
        /// Gets or sets the valeur haute.
        /// </summary>
        /// <value>
        /// The valeur haute.
        /// </value>
        public float ValeurHaute { get; set; }

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
    }
}
