using BL.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public partial class SubscriptionPackageDto : BaseDto
    {
        public string PackageName { get; set; } = null!;
        public int ShippimentCount { get; set; }
        public float NumberOfKiloMeters { get; set; }
        public float TotalWeight { get; set; }
    }
}
