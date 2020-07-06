using CSharpScriptWebApi.Domain.Shared.ServicesInterfaces;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace CSharpScriptWebApi.Domain.Shared.Services
{
    public class DynamicExpressions : IDynamicExpressions
    {
        private static Script<object> baseScript;

        static DynamicExpressions()
        {
            baseScript = CSharpScript.Create("");
        }

        public Script<object> CreateScript()
        {
            return baseScript;
        }
    }
}