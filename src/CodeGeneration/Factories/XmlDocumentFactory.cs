using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CodeGeneration.Factories
{
    public static class XmlDocumentFactory
    {
        public static XmlDocument NewFromObject(object instance)
        {
            var xmlSerializer = new XmlSerializer(instance.GetType());
            var xmlDocument = new XmlDocument();

            XmlReaderSettings settings = new XmlReaderSettings {IgnoreWhitespace = true};
            using (var memStm = new MemoryStream())
            {
                xmlSerializer.Serialize(memStm, instance);
                memStm.Position = 0;
                using(var xmlReader = XmlReader.Create(memStm, settings))
                {  
                    xmlDocument.Load(xmlReader);
                }
            }
#if DEBUG
            xmlDocument.Save("personmodel.xml");
#endif            

            return xmlDocument; 
        }
    }
}