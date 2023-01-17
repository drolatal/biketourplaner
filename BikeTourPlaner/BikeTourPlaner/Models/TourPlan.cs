using System;
using System.Collections.Generic;

namespace BikeTourPlaner.Models;

public partial class TourPlan
{
    public long Tid { get; set; }

    public DateTime TourDate { get; set; }

    public float PlannedDistance { get; set; }

    public int Cost { get; set; }

    public string TourName { get; set; } = null!;
}
