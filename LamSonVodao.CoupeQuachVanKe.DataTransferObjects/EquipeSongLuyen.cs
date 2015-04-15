using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
using System.Collections.Generic;

namespace LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect
{
    /// <summary>
    /// 
    /// </summary>
    public class EquipeSongLuyen : Participant
    {
        ///// <summary>
        ///// Gets or sets the nom.
        ///// </summary>
        ///// <value>
        ///// The nom.
        ///// </value>
        //public string Nom { get; set; }

        /// <summary>
        /// Gets or sets the numero.
        /// </summary>
        /// <value>
        /// The numero.
        /// </value>
        public int Numero { get; set; }

        /////// <summary>
        /////// Gets or sets the club.
        /////// </summary>
        /////// <value>
        /////// The club.
        /////// </value>
        ////public Club Club { get; set; }

        /////// <summary>
        /////// Gets or sets the club identifier.
        /////// </summary>
        /////// <value>
        /////// The club identifier.
        /////// </value>
        ////public int ClubId { get; set; }

        /// <summary>
        /// Gets or sets the competiteurs.
        /// </summary>
        /// <value>
        /// The competiteurs.
        /// </value>
        public virtual ICollection<Competiteur> Competiteurs { get; set; }
      
    }
}
