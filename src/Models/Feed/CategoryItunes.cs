using System.Xml.Serialization;

namespace JovemNerd.Rss.Filter.Models.Feed;

[XmlRoot(ElementName = "category", Namespace = "http://www.itunes.com/dtds/podcast-1.0.dtd")]
public class CategoryItunes
{
    [XmlAttribute(AttributeName = "text")]
    public string Text { get; set; }
}
