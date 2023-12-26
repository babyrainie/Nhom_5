using System;
using System.Collections.Generic;

namespace dailybook.Models;

public partial class Location
{
    public int LocationId { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public string? Slug { get; set; }

    public string? Namewithtype { get; set; }

    public string? Pathwithtype { get; set; }

    public int? Parentcode { get; set; }

    public int? Levels { get; set; }
}
