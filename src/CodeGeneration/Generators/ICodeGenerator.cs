using CodeGeneration.Models;

namespace CodeGeneration.Generators
{
    public interface ICodeGenerator
    {
        string Generate(string rootPath, string templateName, PersonModel personModel);
    }
}