using Domains;
using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class TbPaymentMethod : BaseTable
{
    public string? MethdAname { get; set; }
    public string? MethodEname { get; set; }
    public double? Commission { get; set; }
    public virtual ICollection<TbShippment> TbShippments { get; set; } = new List<TbShippment>();
}
