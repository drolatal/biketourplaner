using System.ComponentModel.DataAnnotations;

namespace BikeTourPlaner.Models.ModelViews
{
    public class CircleChartMV
    {
        [Required]
        public long ChoosenTour { get; set; }
    }
}
