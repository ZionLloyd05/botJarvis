using System.Xml.Serialization;

namespace BookAssistantBot.Models
{
    public class BookItem
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("author")]
        public Author Author { get; set; }

        [XmlElement("small_image_url")]
        public string ImageUrl { get; set; }
    }
}
