namespace LamSonVoDao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    using LamSonVoDao.CoupeQuachVanKe.Contracts;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public class DataMapper<T> : EntityTypeConfiguration<T> where T : class,IDataEntity
    {      
    }
}
