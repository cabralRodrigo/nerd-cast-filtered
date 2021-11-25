using System.Xml.Serialization;

namespace JovemNerd.Rss.Filter.Models.Feed;

[XmlRoot(ElementName = "rss")]
public class RssFeed
{
    [XmlElement(ElementName = "channel")]
    public Podcast Podcast { get; set; }
}
