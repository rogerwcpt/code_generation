using System.IO;
using System.Text;
using CodeGeneration.Models;
using Stubble.Core.Builders;

namespace CodeGeneration.Generators
{
    public class MustacheGenerator: ICodeGenerator
    {
        public string Generate(string rootPath, string templateName, PersonModel personModel)
        {
            var templatePath = Path.Combine(rootPath, "Templates", templateName);
            var stubble = new StubbleBuilder().Build();
            using (StreamReader streamReader = new StreamReader(templatePath, Encoding.UTF8))
            {
               return stubble.Render(streamReader.ReadToEnd(), personModel);
            }
        }
    }
}