using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace SourceGenerator
{
    [Generator]
    public class EnumGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            // Add the marker attribute to the compilation
            context.RegisterPostInitializationOutput(ctx => ctx.AddSource(
                "EnumExtensionsAttribute.g.cs",
                SourceText.From(SourceGenerationHelper.Attribute, Encoding.UTF8)));

            // TODO: implement the remainder of the source generator
        }
    }

    public static class SourceGenerationHelper
    {
        public const string Attribute = @"
namespace EnumGenerators
{
    [System.AttributeUsage(System.AttributeTargets.Enum)]
    public class EnumExtensionsAttribute : System.Attribute
    {
    }
}";
    }
}