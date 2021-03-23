namespace SUS.MVC.ViewEngine
{
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;

    public class SusViewEngine : IViewEngine
    {
        public string GetHtml(string template, object viewModel)
        {
            var csharpCode = GenerateCsharpCode(template, viewModel);
            var executableObject = GetObjectFromCsharpCode(csharpCode, viewModel);
            var html = executableObject.GetCleanHtml(viewModel);
            return html;
        }

        private string GenerateCsharpCode(string template, object viewModel)
        {
            var typeofModel = "object";

            if (viewModel != null)
            {
                if (viewModel.GetType().IsGenericType)
                {
                    var genericTypes = viewModel
                            .GetType()
                            .GetGenericArguments()
                            .Select(x => x.FullName);

                    typeofModel = viewModel.GetType().FullName;
                    var commaLocation = typeofModel.IndexOf("`");

                    typeofModel = typeofModel.Substring(0, commaLocation);

                    typeofModel += $"<{string.Join(", ", genericTypes)}>";
                }
                else
                {
                    typeofModel = viewModel.GetType().FullName;
                }
            }

            var methodBody = GenerateMethodBody(template);

            var csharpCode = @"
using System;               
using System.Text;               
using System.Linq;               
using System.Collections.Generic;  
using SUS.MVC.ViewEngine;

namespace ViewNamespace
{
    public class ViewClass : IView
    {
        public string GetCleanHtml(object viewModel)
        {
            var Model = viewModel as " + typeofModel + @";
            var html = new StringBuilder();

            " + methodBody + @"
    
            return html.ToString();
        }
    }       
}
";

            return csharpCode;
        }

        private string GenerateMethodBody(string template)
        {
            const string AppendLineToHtml = "html.AppendLine";
            const string atSign = "@";
            const string openScope = "{";
            const string closeScope = "}";

            var csharpCodeRegex = new Regex(@"[^\""\s&\'\<]+");
            var suportedOperators = new List<string> { "@if", "@else", "@foreach", "@for", "@while"};

            var stringReader = new StringReader(template);

            var sb = new StringBuilder();

            string line;
            while ((line = stringReader.ReadLine()) != null)
            {
                if (suportedOperators.Any(x => line.TrimStart().StartsWith(x)))
                {
                    var atSignLocation = line.IndexOf(atSign);
                    line = line.Remove(atSignLocation, 1);
                    sb.AppendLine(line);
                }
                else if (line.TrimStart().StartsWith(openScope)
                    || line.TrimStart().StartsWith(closeScope))
                {
                    sb.AppendLine(line);
                }
                else
                {
                    sb.Append($"{AppendLineToHtml}({atSign}\"");

                    while (line.Contains(atSign))
                    {
                        var atSignLocation = line.IndexOf(atSign);
                        var htmlBeforeAtSign = line.Substring(0, atSignLocation);

                        sb.Append($"{htmlBeforeAtSign}\" + ");

                        var lineAfterTheAtSign = line.Substring(atSignLocation + 1);

                        var code = csharpCodeRegex.Match(lineAfterTheAtSign).Value;

                        sb.Append($"{code} + \"");

                        line = lineAfterTheAtSign.Substring(code.Length);
                    }

                    sb.AppendLine($"{line.Replace("\"", "\"\"")}\");");
                }
            }

            var output = sb.ToString().TrimEnd();

            return output;
        }

        private IView GetObjectFromCsharpCode(string csharpCode, object viewModel)
        {
            // Creates compile result of type dll and add references to object and Iviewmodel
            var compileResult = CSharpCompilation
                .Create("ViewAssembly")
                .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
                .AddReferences(MetadataReference.CreateFromFile(typeof(IView).Assembly.Location));

            // Checks if csharpCode has view model and if yes add reference to it
            if (viewModel != null)
            {
                compileResult = compileResult
                    .AddReferences(MetadataReference
                        .CreateFromFile(viewModel
                            .GetType().Assembly.Location));
            }

            // Gets all netstandard libraries 
            var dotnetLibrariesAsseblies = Assembly
                    .Load(new AssemblyName("netstandard"))
                    .GetReferencedAssemblies();

            // Adds references to all netstandard libraries to our code compiler
            foreach (var libraryAssembly in dotnetLibrariesAsseblies)
            {
                compileResult = compileResult
                    .AddReferences(MetadataReference
                        .CreateFromFile(Assembly
                            .Load(libraryAssembly).Location));
            }

            // Add syntax tree of csharp code to compile result
            compileResult = compileResult
                .AddSyntaxTrees(SyntaxFactory
                    .ParseSyntaxTree(csharpCode));

            using var memoryStream = new MemoryStream();
            var emitResult = compileResult
                    .Emit(memoryStream);

            if (!emitResult.Success)
            {
                return new ErrorView(emitResult.Diagnostics
                        .Where(x => x.Severity == DiagnosticSeverity.Error)
                        .Select(x => x.GetMessage()), csharpCode);
            }

            try
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                var byteAssembly = memoryStream.ToArray();
                var assemblyType = Assembly
                        .Load(byteAssembly)
                            .GetType("ViewNamespace.ViewClass");

                var viewClass = Activator.CreateInstance(assemblyType) as IView;

                return viewClass ?? new ErrorView(new List<string> { "Instance is null" }, csharpCode);

            }
            catch (Exception ex)
            {
                return new ErrorView(new List<string> { ex.Message }, csharpCode);
            }
        }
    }
}
