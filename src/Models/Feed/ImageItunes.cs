using System.Xml.Serialization;

namespace JovemNerd.Rss.Filter.Models.Feed;

[XmlRoot(ElementName = "image", Namespace = "http://www.itunes.com/dtds/podcast-1.0.dtd")]
public class ImageItunes
{
    [XmlAttribute(AttributeName = "href")]
    public string Href { get; set; }
}
