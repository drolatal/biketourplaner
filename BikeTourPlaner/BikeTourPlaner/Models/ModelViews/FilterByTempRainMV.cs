using System.ComponentModel.DataAnnotations;

namespace BikeTourPlaner.Models.ModelViews
{
    public enum FilterOption
    {
        TEMPERATURE,
        RAIN
    }
    public enum RelationalSignE { 
        LESSER,
        GREATER
    }
    public class FilterByTempRainMV
    {
        [Required]
        public FilterOption FilterType { get; set; }
        [Required]
        public RelationalSignE RelationalSign { get; set; }
        [Required, Range(-20,300)]
        public int Quantity { get; set; }

    }
}
