using System.ComponentModel.DataAnnotations;

namespace BikeTourPlaner.Models.ModelViews
{
    public class OneTourInfosMV
    {
        [Required]
        public long TId { get; set; }
    }
}
