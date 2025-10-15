using Domains;
using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class TbCarrier : BaseTable
{
    public string CarrierName { get; set; } = null!;
    public virtual ICollection<TbShippment> TbShipments { get; set; } = new List<TbShippment>();
}
