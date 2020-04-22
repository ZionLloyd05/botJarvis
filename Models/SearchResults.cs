using System.Collections.Generic;
using System.Xml.Serialization;

namespace BookAssistantBot.Models
{
    public class SearchResults
    {
        [XmlElement("work")]
        public List<WorkItem> WorkItems { get; set; }
    }
}
