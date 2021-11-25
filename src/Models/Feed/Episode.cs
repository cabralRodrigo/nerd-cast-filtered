using System.Xml.Serialization;

namespace JovemNerd.Rss.Filter.Models.Feed;

[XmlRoot(ElementName = "item")]
public class Episode
{
    [XmlElement(ElementName = "title")]
    public string Title { get; set; }

    [XmlElement(ElementName = "link")]
    public string Link { get; set; }

    [XmlElement(ElementName = "summary", Namespace = "http://www.itunes.com/dtds/podcast-1.0.dtd")]
    public string Summary { get; set; }

    [XmlElement(ElementName = "image", Namespace = "http://www.itunes.com/dtds/podcast-1.0.dtd")]
    public ImageItunes ImageItunes { get; set; }

    [XmlElement(ElementName = "duration", Namespace = "http://www.itunes.com/dtds/podcast-1.0.dtd")]
    public string Duration { get; set; }

    [XmlElement(ElementName = "enclosure")]
    public Enclosure Enclosure { get; set; }

    [XmlElement(ElementName = "pubDate")]
    public string PubDate { get; set; }

    [XmlElement(ElementName = "guid")]
    public string Guid { get; set; }

    [XmlElement(ElementName = "description")]
    public string Description { get; set; }
}
