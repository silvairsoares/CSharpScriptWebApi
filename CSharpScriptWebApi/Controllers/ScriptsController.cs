using Microsoft.AspNetCore.Mvc;
using CSharpScriptWebApi.Domain.Shared.ServicesInterfaces;
using System.Threading.Tasks;
using CSharpScriptWebApi.Domain.ViewModels;
using ServiceStack;
using System;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using System.Diagnostics;

namespace CSharpScriptWebApi.Controllers
{
    public class ScriptsController : Controller
    {
        private readonly IDynamicExpressions _DynamicExpressions;
        private readonly string DynamicRule = "(Value1 > 10 && Value2 < 50 && ValueA == 'ABC' && ValueB == 'DEF')";
        private readonly Stopwatch Timer = new Stopwatch();

        public ScriptsController(IDynamicExpressions dynamicExpressions)
        {
            Timer.Restart();
            _DynamicExpressions = dynamicExpressions;
        }

        [HttpPost("api/script/GlobalsParameter")]
        public async Task<IActionResult> GlobalsParameter([FromBody] SampleVM sampleVM)
        {
            string expression = DynamicRule.Replace("\'", "\"");

            var resultScript = CSharpScript.EvaluateAsync(expression, globals: sampleVM).Result;

            var result = new
            {
                time = GetTime(),
                expression,
                result = resultScript
            };

            return Ok(result);
        }

        [HttpPost("api/script/SimplifyExpression")]
        public async Task<IActionResult> Simplify([FromBody] SampleVM sampleVM)
        {
            string expression = SimplifyExpression(sampleVM);

            var resultScript = _DynamicExpressions.CreateScript().ContinueWith(expression).RunAsync().GetResult().ReturnValue;

            var result = new
            {
                time = GetTime(),
                expression,
                result = resultScript
            };

            return Ok(result);
        }        

        private string GetTime()
        {
            Timer.Stop();

            TimeSpan ts = Timer.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            return "Response time: " + elapsedTime;
        }

        private string SimplifyExpression(SampleVM sampleVM)
        {
            string expression = DynamicRule.Replace("\'", "\"");

            expression = expression.Replace("Value1", sampleVM.Value1.ToString());
            expression = expression.Replace("Value2", sampleVM.Value2.ToString());
            expression = expression.Replace("ValueA", "\"" + sampleVM.ValueA.ToString() + "\"");
            expression = expression.Replace("ValueB", "\"" + sampleVM.ValueB.ToString() + "\"");

            return expression;
        }
    }
}