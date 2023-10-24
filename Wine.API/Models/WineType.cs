using System.ComponentModel;

namespace API.Models
{
    public enum WineType
    {
        [Description("Red Wine")]
        Red = 0,
        [Description("White Wine")]
        White = 1,
        [Description("Rosé Wine")]
        Rose = 2,
        [Description("Sparkling Wine")]
        Sparkling = 3
    }
}
