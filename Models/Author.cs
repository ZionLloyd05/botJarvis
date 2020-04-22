using System.Xml.Serialization;

namespace BookAssistantBot.Models
{
    public class Author
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
