using CodeGeneration.Models;
using CodeGeneration.Templates;

namespace CodeGeneration.Generators
{
    public class T4CodeGenerator: ICodeGenerator
    {
        public string Generate(string rootPath, string templateName, PersonModel personModel)
        {
            //var page = new PersonCompileTime(personModel);
            //return page.TransformText();
            return string.Empty;
        }
    }
}