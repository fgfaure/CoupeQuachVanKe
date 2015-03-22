using LamSonVodao.CoupeQuachVanKe.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamSonVodao.CoupeQuachVanKe.DataTransferOjbect
{
    public class Periode : IDataEntity
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public bool Matin { get; set; }
    }
}
