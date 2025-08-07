using Domains;
using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class TbShipmentStatus : BaseTable
{
    public Guid? ShippmentId { get; set; }
    public string? Notes { get; set; }
    public Guid CarrierId { get; set; }
    public virtual TbCarrier Carrier { get; set; } = null!;

    public virtual TbShippment? Shippment { get; set; }
}
