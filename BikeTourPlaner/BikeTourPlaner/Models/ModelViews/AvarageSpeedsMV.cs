using System.ComponentModel.DataAnnotations;

namespace BikeTourPlaner.Models.ModelViews
{
    public class AvarageSpeedsMV
    {
        [Required]
        public long ChoosenTour { get; set; }
    }
}
