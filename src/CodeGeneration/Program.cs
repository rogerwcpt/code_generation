using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using CodeGeneration.Generators;
using CodeGeneration.Helpers;
using CodeGeneration.Models;

namespace CodeGeneration
{
    class Program
    {
        private static readonly ICodeGenerator RazorGenerator = new RazorCodeGenerator();
        private static readonly ICodeGenerator T4Generator = new T4CodeGenerator();
        private static readonly ICodeGenerator XslGenerator = new XslCodeGenerator();

        static void Main(string[] args)
        {
            var exePath = Assembly.GetExecutingAssembly().Location;
            var rootPath = Path.GetDirectoryName(exePath);
            
            var model = new PersonModel()
            {
                FullName = "John Smith",
                EmailAddress = "john.smith@microsoft.com",
                Company = "Microsoft",
                Skills = new [] { "C#", "Razor", "XML", "HTML" }
            };

            using (_ = new StopWatchLogger())
            {
                var razorResult = RazorGenerator.Generate(rootPath, "PersonRunTime.razor", model);
                OutputToConsole(RazorGenerator, razorResult);
            }

            using (_ = new StopWatchLogger())
            {
                var t4Result = T4Generator.Generate(rootPath, "PersonCompileTime.tt", model);
                OutputToConsole(RazorGenerator, t4Result);
            }
            
            using (_ = new StopWatchLogger())
            {
                var t4Result = XslGenerator.Generate(rootPath, "PersonRunTime.xsl", model);
                OutputToConsole(RazorGenerator, t4Result);
            }
        }       

        private static void OutputToConsole(ICodeGenerator codeGenerator, string output)
        {
            Console.WriteLine($"Code Output of {codeGenerator.Name}:");
            Console.WriteLine(output);
        }
    }
}
