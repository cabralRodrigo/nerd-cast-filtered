using JovemNerd.Rss.Filter.Models;
using System;

namespace JovemNerd.Rss.Filter.Services
{
    public class NerdcastTitleParser : INerdcastTitleParser
    {
        private readonly INerdcastKindCache nerdcastKindCache;

        public NerdcastTitleParser(INerdcastKindCache nerdcastKindCache)
        {
            this.nerdcastKindCache = nerdcastKindCache ?? throw new ArgumentNullException(nameof(nerdcastKindCache));
        }

        public NerdcastKind ParseTitle(string title)
        {
            foreach (var (kind, name) in this.nerdcastKindCache.GetKinds())
                if (kind != NerdcastKind.Outros && title.StartsWith(name, StringComparison.OrdinalIgnoreCase))
                    return kind;

            return NerdcastKind.Outros;
        }
    }

    public interface INerdcastTitleParser
    {
        NerdcastKind ParseTitle(string title);
    }
}