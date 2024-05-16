using UtmBuilder.Core.Extensions;
using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core
{
    public class Utm
    {
        public Utm(Url url, Campaign campaign)
        {
            Url = url;
            Campaign = campaign;
        }

        /// <summary>
        /// URL (Website link)
        /// </summary>
        public Url Url { get; }

        /// <summary>
        /// Campaign details.
        /// </summary>
        public Campaign Campaign { get; }

        public static implicit operator string(Utm utm) => utm.ToString();

        public static implicit operator Utm(string link)
        {
            if (string.IsNullOrEmpty(link))
                throw new InvalidUrlException();

            var url = new Url(link);
            var segments = url.Address.Split("?");
            if(segments.Length == 1 ) throw new InvalidUrlException("No segments were provided.");
        
            var pars = segments[1].Split("&");
            string? source = pars.Where(x => x.StartsWith("utm_source")).FirstOrDefault("").Split("=")[1];
            string? medium = pars.Where(x => x.StartsWith("utm_medium")).FirstOrDefault("").Split("=")[1];
            string? name = pars.Where(x => x.StartsWith("utm_campaign")).FirstOrDefault("").Split("=")[1];
            string? id = pars.Where(x => x.StartsWith("utm_id")).FirstOrDefault("").Split("=")[1];
            string? term = pars.Where(x => x.StartsWith("utm_term")).FirstOrDefault("").Split("=")[1];
            string? content = pars.Where(x => x.StartsWith("utm_content")).FirstOrDefault("").Split("=")[1];

            var utm = new Utm(new Url(segments[0]), new Campaign(source, medium, name, id, term));
            return utm;
        }

        public override string ToString()
        {
            var segments = new List<string>();
            segments.AddIfNotNull("utm_source", Campaign.Source);
            segments.AddIfNotNull("utm_medium", Campaign.Medium);
            segments.AddIfNotNull("utm_campaign", Campaign.Name);
            segments.AddIfNotNull("utm_id", Campaign.Id);
            segments.AddIfNotNull("utm_term", Campaign.Term);
            segments.AddIfNotNull("utm_content", Campaign.Content);

            return $"{Url.Address}?{string.Join("&", segments)}";
        }
    }
}
