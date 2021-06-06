using System;
using System.IO;
using System.Reflection;
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
        private static readonly ICodeGenerator LiquidGenerator = new LiquidGenerator();

        static void Main(string[] args)
        {
            var exePath = Assembly.GetExecutingAssembly().Location;
            var rootPath = Path.GetDirectoryName(exePath);
            
            var model = new PersonModel()
            {
                FullName = "John Smith",
                EmailAddress = "john.smith@microsoft.com",
                Company = "Microsoft",
                Skills = new [] { "C#", "HTML", "XML", "HTML" }
            };

            using (_ = new StopWatchLogger())
            {
                var razorResult = RazorGenerator.Generate(rootPath, "PersonRunTime.razor", model);
                OutputToConsole(RazorGenerator, razorResult);
            }
            
            using (_ = new StopWatchLogger())
            {
                var t4Result = T4Generator.Generate(rootPath, "PersonCompileTime.tt", model);
                OutputToConsole(T4Generator, t4Result);
            }
            
            using (_ = new StopWatchLogger())
            {
                var t4Result = XslGenerator.Generate(rootPath, "PersonRunTime.xsl", model);
                OutputToConsole(XslGenerator, t4Result);
            }
            
            using (_ = new StopWatchLogger())
            {
                var liquidResult = LiquidGenerator.Generate(rootPath, "PersonRunTime.liquid", model);
                OutputToConsole(LiquidGenerator, liquidResult);
            }
        }       

        private static void OutputToConsole(ICodeGenerator codeGenerator, string output)
        {
            Console.WriteLine($"Code Output of {codeGenerator.Name}:");
            Console.WriteLine(output);
        }
    }
}
