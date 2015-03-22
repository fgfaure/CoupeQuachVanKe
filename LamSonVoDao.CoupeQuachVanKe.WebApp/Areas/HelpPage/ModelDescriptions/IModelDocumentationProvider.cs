using System;
using System.Reflection;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}