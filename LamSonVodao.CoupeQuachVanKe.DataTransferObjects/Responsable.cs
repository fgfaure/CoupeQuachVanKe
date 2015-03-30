
namespace LamSonVodao.CoupeQuachVanKe.DataTransferOjbect
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Responsable : BaseEntity
    {
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
        /// Gets or sets the adresse.
        /// </summary>
        /// <value>
        /// The adresse.
        /// </value>
        public string Adresse { get; set; }

        /// <summary>
        /// Gets or sets the telephone.
        /// </summary>
        /// <value>
        /// The telephone.
        /// </value>
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets the email contact.
        /// </summary>
        /// <value>
        /// The email contact.
        /// </value>
        public string MailContact { get; set; }
               
    }
}
