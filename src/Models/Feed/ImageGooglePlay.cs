using System.Xml.Serialization;

namespace JovemNerd.Rss.Filter.Models.Feed;

[XmlRoot(ElementName = "image", Namespace = "http://www.google.com/schemas/play-podcasts/1.0")]
public class ImageGooglePlay
{
    [XmlAttribute(AttributeName = "href")]
    public string Href { get; set; }
}
