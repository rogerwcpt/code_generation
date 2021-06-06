using System.IO;
using CodeGeneration.Models;
using Scriban;

namespace CodeGeneration.Generators
{
    public class LiquidGenerator: ICodeGenerator
    {
        public string Generate(string rootPath, string templateName, PersonModel personModel)
        {
            var templatePath = Path.Combine(rootPath, "Templates", templateName);
            var templateText = File.ReadAllText(templatePath);
            
            var template = Template.ParseLiquid(templateText);
            return template.Render(personModel);
        }
    }
}