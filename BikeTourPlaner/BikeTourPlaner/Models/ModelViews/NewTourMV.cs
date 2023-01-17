using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace BikeTourPlaner.Models.ModelViews
{
    public class NewTourMV
    {
        [Required]
        public DateTime TourDate { get; set; }

        [Required, Range(1.0,float.MaxValue)]
        public float PlannedDistance { get; set; }

        [Required, Range(1,int.MaxValue)]
        public int Cost { get; set; }

        [Required, MaxLength(50)]
        public  string TourName { get; set; }
    }
}
