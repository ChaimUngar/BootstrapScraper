using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scraper.Web.Services;

namespace Scraper.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootstrapScraper : ControllerBase
    {
        [HttpGet("search-icons")]
        public List<BootstrapIcon> Search(string text)
        {
            var scraper = new IconScraper();
            return scraper.Scrape(text);
        }
    }
}
