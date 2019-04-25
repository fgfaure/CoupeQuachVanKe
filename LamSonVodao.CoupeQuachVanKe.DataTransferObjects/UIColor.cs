using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect
{
    public class UIColor : BaseEntity
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the RGB code.
        /// </summary>
        /// <value>
        /// The RGB code.
        /// </value>
        public string RGB_Code { get; set; }
    
        public string Identifier { get; set; }
    }
}
