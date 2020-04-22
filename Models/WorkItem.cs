using System.Xml.Serialization;

namespace BookAssistantBot.Models
{
    public class WorkItem
    {
        [XmlElement("best_book")]
        public BookItem BookItem { get; set; }
    }
}
