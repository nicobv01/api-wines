using System.ComponentModel.DataAnnotations.Schema;

namespace Wine.API.Models
{
    [Table("Wine")]
    public class Wine
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CountryCode { get; set; }
        public int Type { get; set; }
        public DateTime Year { get; set; }
    }
}
