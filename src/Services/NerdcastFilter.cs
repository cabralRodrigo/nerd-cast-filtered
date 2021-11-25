using JovemNerd.Rss.Filter.Models;
using JovemNerd.Rss.Filter.Models.Feed;
using System;
using System.Collections.Generic;

namespace JovemNerd.Rss.Filter.Services
{
    public class NerdcastFilter : INerdcastFilter
    {
        private readonly INerdcastTitleParser nerdcastTitleParser;

        public NerdcastFilter(INerdcastTitleParser nerdcastTitleParser)
        {
            this.nerdcastTitleParser = nerdcastTitleParser ?? throw new ArgumentNullException(nameof(nerdcastTitleParser));
        }

        public List<Episode> FilterEpisodes(List<Episode> episodes, NerdcastKind kind)
        {
            var filtered = new List<Episode>();

            foreach (var episode in episodes)
                if (this.nerdcastTitleParser.ParseTitle(episode.Title) == kind)
                    filtered.Add(episode);

            return filtered;
        }
    }

    public interface INerdcastFilter
    {
        List<Episode> FilterEpisodes(List<Episode> episodes, NerdcastKind kind);
    }
}