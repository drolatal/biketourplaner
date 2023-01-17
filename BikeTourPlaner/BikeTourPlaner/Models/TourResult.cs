using System;
using System.Collections.Generic;

namespace BikeTourPlaner.Models;

public partial class TourResult
{
    public long Tid { get; set; }

    public long? Uid { get; set; }

    public float? DailyTemp { get; set; }

    public int? Rain { get; set; }

    public TimeSpan? TravelTime { get; set; }

    public float? DistanceTraveled { get; set; }

    public int? Accident { get; set; }

    public int? Kcalories { get; set; }
}
