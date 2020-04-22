using BookAssistantBot.Models;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BookAssistantBot.API
{
    public class GoodReadsAPIWrapper
    {
        private readonly HttpClient client;

        public GoodReadsAPIWrapper()
        {
            client = new HttpClient();
        }

        public async Task<GoodReadsResponse> GetSearchReponse(string input)
        {
            var baseUrl = "https://www.goodreads.com/search.xml";
            var key = "C2FHPVg8OrmK44g5F4igg";

            var response = await client.GetAsync($"{baseUrl}?key={key}&q={input}");

            var content = await response.Content.ReadAsStringAsync();

            var serializer = new XmlSerializer(typeof(GoodReadsResponse));

            using (var stream = new StringReader(content))
            {
                return (GoodReadsResponse)serializer.Deserialize(stream);
            }
                
        }

    }
    
}
