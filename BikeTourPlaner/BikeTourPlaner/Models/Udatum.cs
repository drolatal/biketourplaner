using System;
using System.Collections.Generic;

namespace BikeTourPlaner.Models;

public partial class Udatum
{
    public long Uid { get; set; }

    public string Name { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string Email { get; set; } = null!;
}
