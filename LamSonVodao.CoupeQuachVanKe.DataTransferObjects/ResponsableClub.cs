
namespace LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect
{
    /// <summary>
    /// 
    /// </summary>
    public class ResponsableClub : Responsable
    {
        /// <summary>
        /// Gets or sets the club.
        /// </summary>
        /// <value>
        /// The club.
        /// </value>
        public Club Club { get; set; }

        /// <summary>
        /// Gets or sets the club identifier.
        /// </summary>
        /// <value>
        /// The club identifier.
        /// </value>
        public int ClubId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [inscription is correct].
        /// </summary>
        /// <value>
        /// <c>true</c> if [inscription is correct]; otherwise, <c>false</c>.
        /// </value>
        public bool InscriptionIsCorrect { get; set; }
    }
}
