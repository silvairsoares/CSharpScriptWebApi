using NJsonSchema.Annotations;

namespace CSharpScriptWebApi.Domain.ViewModels
{
    [JsonSchemaExtensionData("example",
@"{
    ""Value1"": 15,
    ""Value2"": 40,
    ""ValueA"": ""ABC"",
    ""ValueB"": ""DEF""
}")]
    public class SampleVM
    {
        public int Value1 { get; set; }

        public int Value2 { get; set; }

        public string ValueA { get; set; }

        public string ValueB { get; set; }
    }
}
