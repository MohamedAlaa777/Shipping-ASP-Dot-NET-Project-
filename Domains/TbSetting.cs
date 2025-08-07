using Domains;
using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class TbSetting : BaseTable
{
    public double? KiloMeterRate { get; set; }
    public double? KilooGramRate { get; set; }
}
