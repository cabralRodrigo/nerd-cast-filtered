using JovemNerd.Rss.Filter.Models.Feed;
using System.IO;
using System.Xml.Serialization;

namespace JovemNerd.Rss.Filter.Services
{
    public class FeedSerializer : IFeedSerializer
    {
        public RssFeed Deserialize(string xml)
        {
            var serializer = new XmlSerializer(typeof(RssFeed));

            using var reader = new StringReader(xml);
            return (RssFeed)serializer.Deserialize(reader);
        }

        public string Serialize(RssFeed feed)
        {
            var serializer = new XmlSerializer(typeof(RssFeed));

            using var writer = new StringWriter();
            serializer.Serialize(writer, feed);

            return writer.ToString();
        }
    }

    public interface IFeedSerializer
    {
        RssFeed Deserialize(string xml);
        string Serialize(RssFeed feed);
    }
}