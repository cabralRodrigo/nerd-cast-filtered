using JovemNerd.Rss.Filter.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JovemNerd.Rss.Filter;

public static class App
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddHttpClient();

        builder.Services.AddScoped<IOriginalFeedService, OriginalFeedService>();
        builder.Services.AddSingleton<IFeedSerializer, FeedSerializer>();
        builder.Services.AddSingleton<INerdcastTitleParser, NerdcastTitleParser>();
        builder.Services.AddSingleton<INerdcastKindCache, NerdcastKindCache>();
        builder.Services.AddSingleton<INerdcastTitleParser, NerdcastTitleParser>();
        builder.Services.AddSingleton<INerdcastFilter, NerdcastFilter>();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
            app.UseExceptionHandler("/Error");

        app.UseStaticFiles();
        app.UseRouting();
        app.MapControllers();
        app.Run();
    }
}