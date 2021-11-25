using System.Xml.Serialization;

namespace JovemNerd.Rss.Filter.Models.Feed;

[XmlRoot(ElementName = "category", Namespace = "http://www.google.com/schemas/play-podcasts/1.0")]
public class CategoryGooglePlay
{
    [XmlAttribute(AttributeName = "text")]
    public string Text { get; set; }
}
