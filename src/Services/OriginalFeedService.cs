using JovemNerd.Rss.Filter.Models.Feed;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace JovemNerd.Rss.Filter.Services
{
    public class OriginalFeedService : IOriginalFeedService
    {
        private readonly HttpClient httpClient;
        private readonly IFeedSerializer serializer;

        public OriginalFeedService(HttpClient httpClient, IFeedSerializer serializer)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
        }

        public async Task<RssFeed> LoadOriginalFeed()
        {
            var xml = await this.httpClient.GetStringAsync("https://jovemnerd.com.br/feed-nerdcast/");
            return this.serializer.Deserialize(xml);
        }
    }

    public interface IOriginalFeedService
    {
        Task<RssFeed> LoadOriginalFeed();
    }
}