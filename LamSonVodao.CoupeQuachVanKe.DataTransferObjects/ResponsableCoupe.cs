
namespace LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect
{
    /// <summary>
    /// 
    /// </summary>
    public class ResponsableCoupe : Responsable
    {
        /// <summary>
        /// Gets or sets the coupe.
        /// </summary>
        /// <value>
        /// The coupe.
        /// </value>
        public Coupe Coupe { get; set; }

        /// <summary>
        /// Gets or sets the coupe identifier.
        /// </summary>
        /// <value>
        /// The coupe identifier.
        /// </value>
        public int CoupeId { get; set; }
        
    }
}
