using Domains;
using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class TbShippingType : BaseTable
{
    public string? ShippingTypeAname { get; set; }
    public string? ShippingTypeEname { get; set; }
    public double ShippingFactor { get; set; }
    public virtual ICollection<TbShippment> TbShippments { get; set; } = new List<TbShippment>();
}
