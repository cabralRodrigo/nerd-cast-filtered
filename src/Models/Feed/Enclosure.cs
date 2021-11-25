using System.Xml.Serialization;

namespace JovemNerd.Rss.Filter.Models.Feed;

[XmlRoot(ElementName = "enclosure")]
public class Enclosure
{
    [XmlAttribute(AttributeName = "url")]
    public string Url { get; set; }

    [XmlAttribute(AttributeName = "length")]
    public string Length { get; set; }

    [XmlAttribute(AttributeName = "type")]
    public string Type { get; set; }
}
