using System.Xml.Serialization;

namespace BookAssistantBot.Models
{
    [XmlRoot("GoodreadsResponse")]
    public class GoodReadsResponse
    {
        [XmlElement("search")]
        public SearchResponse Search { get; set; }
    }

}
