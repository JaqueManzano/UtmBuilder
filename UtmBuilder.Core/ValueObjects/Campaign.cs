using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects
{
    public class Campaign : ValueObject
    {
        /// <summary>
        /// Generate a new URL
        /// </summary>
        /// <param name="source">The referrer (e.g. google, newsletter )</param>
        /// <param name="medium">Marketing medium (e.g. cpc, banner, email)</param>
        /// <param name="name">Product, promo code, or slogan (e.g. spring_sale) One of campaign </param>
        /// <param name="id">The ads campaign id.</param>
        /// <param name="term">Identify the paid keeywords</param>
        /// <param name="content">Use to differentiate ads</param>
        public Campaign(string source, string medium, string name, string? id = null, string? term = null, string? content = null)
        {
            Source = source;
            Medium = medium;
            Name = name;
            Id = id;
            Term = term;
            Content = content;

            InvalidCampaignException.ThrowIfNull(source, "Source invalid");
            InvalidCampaignException.ThrowIfNull(medium, "Medium invalid");
            InvalidCampaignException.ThrowIfNull(name, "Name invalid");
        }

        /// <summary>
        /// The ads campaign id.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// The referrer (e.g. google, newsletter )
        /// </summary>
        public string Source { get; }

        /// <summary>
        /// Marketing medium (e.g. cpc, banner, email)
        /// </summary>
        public string Medium { get; set; }

        /// <summary>
        /// Product, promo code, or slogan (e.g. spring_sale) One of campaign 
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Identify the paid keeywords
        /// </summary>
        public string? Term { get; set; }

        /// <summary>
        /// Use to differentiate ads
        /// </summary>
        public string? Content { get; }
    }
}
