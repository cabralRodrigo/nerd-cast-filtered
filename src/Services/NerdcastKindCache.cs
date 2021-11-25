using JovemNerd.Rss.Filter.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;

namespace JovemNerd.Rss.Filter.Services
{
    public class NerdcastKindCache : INerdcastKindCache
    {
        private readonly Lazy<IReadOnlyDictionary<NerdcastKind, string>> cache;

        public NerdcastKindCache() => this.cache = new(this.Factory);

        public IReadOnlyDictionary<NerdcastKind, string> GetKinds() => this.cache.Value;

        private IReadOnlyDictionary<NerdcastKind, string> Factory()
        {
            var values = new Dictionary<NerdcastKind, string>();

            foreach (var kind in Enum.GetValues<NerdcastKind>())
            {
                var attr = typeof(NerdcastKind).GetField(kind.ToString()).GetCustomAttribute<DescriptionAttribute>();
                values.Add(kind, attr.Description);
            }

            return new ReadOnlyDictionary<NerdcastKind, string>(values);
        }
    }

    public interface INerdcastKindCache
    {
        IReadOnlyDictionary<NerdcastKind, string> GetKinds();
    }
}