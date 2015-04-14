
namespace LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect
{
    /// <summary>
    /// 
    /// </summary>
    public class NetClient : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name of the client.
        /// </summary>
        /// <value>
        /// The name of the client.
        /// </value>
        public string ClientName { get; set; }

        /// <summary>
        /// Gets or sets the type of the client.
        /// </summary>
        /// <value>
        /// The type of the client.
        /// </value>
        public NetClientType NetClientType { get; set; }

        /// <summary>
        /// Gets or sets the net client type identifier.
        /// </summary>
        /// <value>
        /// The net client type identifier.
        /// </value>
        public int NetClientTypeId { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is connected.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </value>
        public bool IsConnected { get; set; }

        /// <summary>
        /// Gets or sets the ip.
        /// </summary>
        /// <value>
        /// The ip.
        /// </value>
        public string Ip { get; set; }

        /// <summary>
        /// Gets or sets the aire.
        /// </summary>
        /// <value>
        /// The aire.
        /// </value>
        public Aire Aire { get; set; }

        /// <summary>
        /// Gets or sets the aire identifier.
        /// </summary>
        /// <value>
        /// The aire identifier.
        /// </value>
        public int AireId { get; set; }
    }
}
