using System.IO;
using System.Text;
using System.Xml.Xsl;
using CodeGeneration.Factories;
using CodeGeneration.Models;

namespace CodeGeneration.Generators
{
    public class XslCodeGenerator: ICodeGenerator
    {
        public string Generate(string rootPath, string templateName, PersonModel personModel)
        {
            string result;
            
            var templatePath = Path.Combine(rootPath, "Templates", templateName);
            
            var xmlDocument = XmlDocumentFactory.NewFromObject(personModel);
            
            var xslCompiledTransform = new XslCompiledTransform();
            xslCompiledTransform.Load(templatePath);
            
            var stringBuilder = new StringBuilder();
            using (var stringWriter = new StringWriter(stringBuilder))
            {
                xslCompiledTransform.Transform(xmlDocument, null, stringWriter);
                result = stringWriter.ToString();
            }

            return result;
        }
    }
}