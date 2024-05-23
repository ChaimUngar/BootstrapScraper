using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using static System.Net.WebRequestMethods;

namespace Scraper.Web.Services
{
    public class BootstrapIcon
    {
        public string Title { get; set; }
        public string Tags { get; set; }
        public string Category { get; set; }
        public string Url { get; set; }
    }

    public class IconScraper
    {
        public List<BootstrapIcon> Scrape(string text)
        {
            if (text == null)
            {
                text = "";
            }

            var html = GetIconHtml();
            var document = new HtmlParser().ParseDocument(html);

            var icons = document.QuerySelector("#icons-list");
            var iconLis = icons.QuerySelectorAll("li");

            var lowerText = text.ToLower();
            var resultElements = new List<BootstrapIcon>();
            int i = 1;

            foreach (var icon in iconLis)
            {
                var newIcon = ParseElements(icon, i);
                resultElements.Add(newIcon);
                i++;
            }

            return resultElements.Where(e => e.Title.ToLower().Contains(lowerText) ||
                                e.Tags.ToLower().Contains(lowerText) ||
            e.Category.ToLower().Contains(lowerText)).ToList();

        }

        public BootstrapIcon ParseElements(IElement icon, int i)
        {
            var title = icon.Attributes["data-name"].Value;
            var tags = icon.Attributes["data-tags"].Value;
            var categories = icon.Attributes["data-categories"].Value;

            return new BootstrapIcon
            {
                Title = title,
                Tags = tags,
                Category = categories,
                Url = $"https://icons.getbootstrap.com/icons/{title}"
            };
        }

        public string GetIconHtml()
        {
            var url = "https://icons.getbootstrap.com/";

            var handler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate,
                UseCookies = true
            };
            var client = new HttpClient(handler);

            return client.GetStringAsync(url).Result;
        }
    }
}
