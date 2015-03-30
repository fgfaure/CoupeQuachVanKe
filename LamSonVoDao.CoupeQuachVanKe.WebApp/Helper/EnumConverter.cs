using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Helper
{
    public class EnumConverter<T>
    {      
        public T ConvertToEnum(string valueToParse)
        {            
            return (T)Enum.Parse(typeof (T), valueToParse);
        }        
    }
}