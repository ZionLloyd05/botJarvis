using System.Xml.Serialization;

namespace BookAssistantBot.Models
{
    public class SearchResponse
    {
        [XmlElement("total-results")]
        public int TotalResults { get; set; }

        [XmlElement("results")]
        public SearchResults Results { get; set; }
    }
}
