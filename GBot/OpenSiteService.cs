using Microsoft.Cognitive.LUIS;
using System;
using System.Diagnostics;
using System.Linq;

namespace GBot
{
    public class OpenSiteService
    {
        public void Handle(LuisResult result)
        {
            const string urlEntityName = "builtin.url";
            const string entityName = "site";

            result.Entities.TryGetValue(urlEntityName, out var urlEntity);
            result.Entities.TryGetValue(entityName, out var entity);

            var site = urlEntity?.FirstOrDefault()?.Value ?? entity?.FirstOrDefault()?.Value;
            site = site?.Replace(" ", "").Replace("https://", "").Replace("http://", "");
            site = "http://" + site;

            var url = new Uri(site, UriKind.RelativeOrAbsolute).AbsoluteUri;

            Process.Start(site);
        }
    }
}