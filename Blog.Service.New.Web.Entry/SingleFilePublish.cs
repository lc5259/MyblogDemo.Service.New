using Furion;
using System.Reflection;

namespace Blog.Service.New.Web.Entry;

public class SingleFilePublish : ISingleFilePublish
{
    public Assembly[] IncludeAssemblies()
    {
        return Array.Empty<Assembly>();
    }

    public string[] IncludeAssemblyNames()
    {
        return new[]
        {
            "Blog.Service.New.Application",
            "Blog.Service.New.Core",
            "Blog.Service.New.EntityFramework.Core",
            "Blog.Service.New.Web.Core"
        };
    }
}