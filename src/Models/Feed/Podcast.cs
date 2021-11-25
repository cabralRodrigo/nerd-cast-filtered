using System.Collections.Generic;
using System.Xml.Serialization;

namespace JovemNerd.Rss.Filter.Models.Feed;

[XmlRoot(ElementName = "channel")]
public class Podcast
{
    [XmlElement(ElementName = "title")]
    public string Title { get; set; }

    [XmlElement(ElementName = "author", Namespace = "http://www.google.com/schemas/play-podcasts/1.0")]
    public List<string> Author { get; set; }

    [XmlElement(ElementName = "description")]
    public string Description { get; set; }

    [XmlElement(ElementName = "image", Namespace = "http://www.google.com/schemas/play-podcasts/1.0")]
    public ImageGooglePlay ImageGooglePlay { get; set; }

    [XmlElement(ElementName = "language")]
    public string Language { get; set; }

    [XmlElement(ElementName = "link")]
    public List<string> Link { get; set; }

    [XmlElement(ElementName = "copyright")]
    public string Copyright { get; set; }

    [XmlElement(ElementName = "lastBuildDate")]
    public string LastBuildDate { get; set; }

    [XmlElement(ElementName = "subtitle", Namespace = "http://www.itunes.com/dtds/podcast-1.0.dtd")]
    public string Subtitle { get; set; }

    [XmlElement(ElementName = "summary", Namespace = "http://www.itunes.com/dtds/podcast-1.0.dtd")]
    public string Summary { get; set; }

    [XmlElement(ElementName = "category", Namespace = "http://www.itunes.com/dtds/podcast-1.0.dtd")]
    public CategoryItunes CategoryItunes { get; set; }

    [XmlElement(ElementName = "owner", Namespace = "http://www.itunes.com/dtds/podcast-1.0.dtd")]
    public Owner Owner { get; set; }

    [XmlElement(ElementName = "block", Namespace = "http://www.itunes.com/dtds/podcast-1.0.dtd")]
    public string Block { get; set; }

    [XmlElement(ElementName = "explicit", Namespace = "http://www.itunes.com/dtds/podcast-1.0.dtd")]
    public string Explicit { get; set; }

    [XmlElement(ElementName = "image", Namespace = "http://www.itunes.com/dtds/podcast-1.0.dtd")]
    public ImageItunes ImageItunes { get; set; }

    [XmlElement(ElementName = "category", Namespace = "http://www.google.com/schemas/play-podcasts/1.0")]
    public CategoryGooglePlay CategoryGooglePlay { get; set; }

    [XmlElement(ElementName = "image")]
    public Image Image { get; set; }

    [XmlElement(ElementName = "managingEditor")]
    public string ManagingEditor { get; set; }

    [XmlElement(ElementName = "item")]
    public List<Episode> Episodes { get; set; }
}
