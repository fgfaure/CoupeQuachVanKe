using LamSonVodao.CoupeQuachVanKe.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LamSonVodao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    public class DataMapper<T> : EntityTypeConfiguration<T> where T : class,IDataEntity
    {      
    }
}
