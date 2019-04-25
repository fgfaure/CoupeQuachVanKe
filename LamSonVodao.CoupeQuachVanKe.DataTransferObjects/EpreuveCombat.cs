using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
using System.Collections.Generic;

namespace LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Epreuve" />
    public class EpreuveCombat : Epreuve
    {
        /// <summary>
        /// Gets or sets the valeur basse.
        /// </summary>
        /// <value>
        /// The valeur basse.
        /// </value>
        public float PoidsMini { get; set; }

        /// <summary>
        /// Gets or sets the valeur haute.
        /// </summary>
        /// <value>
        /// The valeur haute.
        /// </value>
        public float PoidsMaxi { get; set; }     
    }
}
