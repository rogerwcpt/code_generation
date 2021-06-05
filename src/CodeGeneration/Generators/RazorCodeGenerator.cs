using System;
using System.IO;
using CodeGeneration.Models;
using RazorEngineCore;

namespace CodeGeneration.Generators
{
    public class RazorCodeGenerator: ICodeGenerator
    {
        public string Generate(string rootPath, string templateName, PersonModel model)
        {
            var templatePath = Path.Combine(rootPath, "Templates", templateName);
            var templateText = File.ReadAllText(templatePath);
            
            var razorEngine = new RazorEngine();
            var compiledTemplate = razorEngine.Compile<RazorEngineTemplateBase<PersonModel>>(templateText);
            return compiledTemplate.Run(instance => { instance.Model = model; });
        }
    }
}