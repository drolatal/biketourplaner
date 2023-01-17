using System;
using System.Collections.Generic;

namespace BikeTourPlaner.Models;

public partial class Creditential
{
    public long Uid { get; set; }

    public string NickName { get; set; } = null!;

    public string Password { get; set; } = null!;

}
