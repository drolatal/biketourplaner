using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BikeTourPlaner.Models.ModelViews
{
    public class TourResultMV
    {
        [Required]
        public long ChoosenTour { get; set; }
        [Required, Range(-20,40)]
        public float Temperature { get; set; }
        [Required, Range(0,300)]
        public int Rain { get; set; }
        [Required]
        public TimeSpan TravelTime { get; set; }
        [Required]
        public float DistanceTravelled { get; set; }
        [Required]
        public int Accident { get; set; }
        [Required]
        public int KCalories { get; set; }
    }
}
