using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Areas.HelpPage.ModelDescriptions
{
    public class EnumTypeModelDescription : ModelDescription
    {
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        public Collection<EnumValueDescription> Values { get; private set; }
    }
}