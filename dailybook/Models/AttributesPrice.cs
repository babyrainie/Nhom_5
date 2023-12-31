﻿using System;
using System.Collections.Generic;

namespace dailybook.Models;

public partial class AttributesPrice
{
    public int AttributesPriceId { get; set; }

    public int AttributeId { get; set; }

    public int ProductId { get; set; }

    public int? Price { get; set; }

    public bool? Active { get; set; }

    public virtual Attribute AttributesPriceNavigation { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
