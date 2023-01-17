using System.ComponentModel.DataAnnotations;

namespace BikeTourPlaner.Models.ModelViews
{
    public class CaloriesInIntervalMV
    {
        [Required]
        public DateTime IntervalLeft { get; set; }
        [Required]
        public DateTime IntervalRight { get; set; }
    }
}
