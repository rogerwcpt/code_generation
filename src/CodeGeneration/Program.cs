using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using CodeGeneration.Generators;
using CodeGeneration.Models;

namespace CodeGeneration
{
    class Program
    {
        private static ICodeGenerator razorGenerator = new RazorCodeGenerator(); 
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

            var razorResult = razorGenerator.Generate(rootPath, "Employee.razor", model);
            OutputToConsole<ICodeGenerator>(razorResult);
        }       

        private static void OutputToConsole<T>(string output)
        {
            var generatorType = typeof(T);
            Console.WriteLine($"Code Output of {generatorType}:");
            Console.WriteLine(output);
        }
    }
}
