using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public partial class TbShipingPackging : BaseTable
    {
        public string? ShipingPackgingAname { get; set; }

        public string? ShipingPackgingEname { get; set; }

        public virtual ICollection<TbShippment> TbShippments { get; set; } = new List<TbShippment>();
    }
}
