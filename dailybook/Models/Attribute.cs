using System;
using System.Collections.Generic;

namespace dailybook.Models;

public partial class Attribute
{
    public int AttributeId { get; set; }

    public string? Name { get; set; }

    public virtual AttributesPrice? AttributesPrice { get; set; }
}
