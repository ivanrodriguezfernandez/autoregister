// using System;
// using System.Diagnostics;
// using System.Linq;
// using Microsoft.CodeAnalysis;
// using Microsoft.CodeAnalysis.Text;
// using System.Text;
// using Microsoft.CodeAnalysis.CSharp.Syntax;
//
// namespace SourceGenerator
// {
//     // public class MapperSyntaxReceiver : ISyntaxReceiver
//     // {
//     //     public MapperSyntaxReceiver()
//     //     {
//     //         
//     //     }
//     //     public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
//     //     {
//     //         if (syntaxNode is ClassDeclarationSyntax)
//     //         {
//     //             ProcessClassDeclaration((ClassDeclarationSyntax)syntaxNode);
//     //         }
//     //     }
//     //     private void ProcessClassDeclaration(ClassDeclarationSyntax classDeclaration)
//     //     {
//     //         var attrs = classDeclaration.AttributeLists.SelectMany(al => al.Attributes);
//     //         foreach (var attr in attrs)
//     //         {
//     //             ProcessAttribute(classDeclaration, attr);
//     //         }
//     //     }
//     //
//     //     private void ProcessAttribute(ClassDeclarationSyntax classDeclaration, AttributeSyntax attr)
//     //     {
//     //         /*if (attr.Name.ToString() == nameof(GenerateDtoAttribute))
//     //         {
//     //             AddClassToDtoList(classDeclaration);
//     //         }*/
//     //     }
//     //     
//     //     public bool GetMappers()
//     //     {
//     //         return true;
//     //     }
//     // }
//     
//     
// //     [Generator]
// //     public class SourceGenerator : ISourceGenerator
// //     {
// //         public void Initialize(GeneratorInitializationContext context)
// //         {
// //             /*
// //             context.RegisterForSyntaxNotifications(()=> new MapperSyntaxReceiver());
// //             
// //             if (!Debugger.IsAttached)
// //             {
// //                 Debugger.Launch();
// //             }*/
// //             Debug.WriteLine("Initialize code generator");
// //         }
// //
// //         public void Execute(GeneratorExecutionContext context)
// //         {
// //             var sourceBuilder = new StringBuilder(@"
// // using System;
// // namespace HelloWorldGenerated
// // {
// //     public static class HelloWorld
// //     {
// //         public static void SayHello()
// //         {
// //             Console.WriteLine(""Hello from generated code!"");
// //             Console.WriteLine(""The following syntax trees existed in the compilation that created this program:"");
// // ");
// //
// //             var syntaxReceiver = (MapperSyntaxReceiver)context.SyntaxReceiver;
// //             //var mappers = syntaxReceiver.GetMappers();
// //             
// //             // using the context, get a list of syntax trees in the users compilation
// //             var syntaxTrees = context.Compilation.SyntaxTrees;
// //
// //             // Add the filepath of each tree to the class we're building
// //             foreach (SyntaxTree tree in syntaxTrees)
// //             {
// //                 sourceBuilder.AppendLine($@"Console.WriteLine(@"" - {tree.FilePath}"");");
// //             }
// //             // finish creating the source to inject
// //             sourceBuilder.Append(@"
// //         }
// //     }
// //
// // }");
// //             // inject the created source into the users compilation
// //             // todo: EnumExtensionsAttribute.g.cs
// //             context.AddSource("helloWorldGenerator", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
// //         }
// //     }
// }