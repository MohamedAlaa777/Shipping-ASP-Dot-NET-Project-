using Domains;
using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class TbSubscriptionPackage : BaseTable
{
    public string PackageName { get; set; } = null!;

    public int ShippimentCount { get; set; }

    public double NumberOfKiloMeters { get; set; }

    public double TotalWeight { get; set; }
    public virtual ICollection<TbUserSubscription> TbUserSubscriptions { get; set; } = new List<TbUserSubscription>();
}
