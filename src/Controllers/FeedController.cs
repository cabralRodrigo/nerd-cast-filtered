using JovemNerd.Rss.Filter.Models;
using JovemNerd.Rss.Filter.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace JovemNerd.Rss.Filter.Controllers;

public class FeedController : Controller
{
    private readonly IOriginalFeedService originalFeedService;
    private readonly INerdcastFilter nerdcastFilter;
    private readonly INerdcastKindCache nerdcastKindCache;
    private readonly IFeedSerializer feeSerializer;
    private readonly IAccessLogRepository accessLogRepository;

    public FeedController(IOriginalFeedService originalFeedService, INerdcastFilter nerdcastFilter, INerdcastKindCache nerdcastKindCache, IFeedSerializer feeSerializer, IAccessLogRepository accessLogRepository)
    {
        this.originalFeedService = originalFeedService ?? throw new ArgumentNullException(nameof(originalFeedService));
        this.nerdcastFilter = nerdcastFilter ?? throw new ArgumentNullException(nameof(nerdcastFilter));
        this.nerdcastKindCache = nerdcastKindCache ?? throw new ArgumentNullException(nameof(nerdcastKindCache));
        this.feeSerializer = feeSerializer ?? throw new ArgumentNullException(nameof(feeSerializer));
        this.accessLogRepository = accessLogRepository ?? throw new ArgumentNullException(nameof(accessLogRepository));
    }

    [Route("/")]
    public IActionResult Index()
    {
        var kinds = new List<(Uri, string)>();

        foreach (var (kind, name) in this.nerdcastKindCache.GetKinds())
        {
            var url = this.Url.Action(nameof(Custom), new { kind });
            kinds.Add((new Uri(url, UriKind.Relative), name));
        }

        return this.View(kinds);
    }

    [Route("feed/{kind}")]
    public async Task<IActionResult> Custom(NerdcastKind kind)
    {
        if (!Enum.IsDefined(kind))
            return this.BadRequest();

        var time = Stopwatch.StartNew();
        var feed = await this.originalFeedService.LoadOriginalFeed();
        time.Stop();

        var episodes = this.nerdcastFilter.FilterEpisodes(feed.Podcast.Episodes, kind);

        feed.Podcast.Title += $" ({this.nerdcastKindCache.GetKinds()[kind]})";
        feed.Podcast.Episodes = episodes;

        var xml = this.feeSerializer.Serialize(feed);
        var bytes = Encoding.UTF8.GetBytes(xml);

        await this.accessLogRepository.Log(kind, this.Request.Headers.UserAgent, (int)time.ElapsedMilliseconds);

        return new FileContentResult(bytes, "application/rss+xml; charset=utf-8");
    }
}
