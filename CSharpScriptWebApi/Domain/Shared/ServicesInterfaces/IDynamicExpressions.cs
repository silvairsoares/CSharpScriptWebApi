using Microsoft.CodeAnalysis.Scripting;

namespace CSharpScriptWebApi.Domain.Shared.ServicesInterfaces
{
    public interface IDynamicExpressions
    {
        Script<object> CreateScript();
    }
}