using LamSonVoDao.CoupeQuachVanKe.DataAccessLayer.Mappers;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;

namespace LamSonVoDao.CoupeQuachVanKe.DataAccessLayer.Mappers
{   
    public class UIColorMapper : DataMapper<UIColor>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UIColorMapper" /> class.
        /// </summary>
        public UIColorMapper()
        {
            this.ToTable("UIColors");

            this.Property(c => c.RGB_Code).IsRequired();

            this.Property(c => c.Description).IsRequired();
        }
    }
}
