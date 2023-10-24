using API.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Wine")]
    public class Wine
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CountryCode { get; set; }
        public WineType? Type { get; set; }
        [NotMapped]
        public string TypeDescription => Type?.GetDescription() ?? "Unknown";
        public DateTime Year { get; set; }

    }
}
