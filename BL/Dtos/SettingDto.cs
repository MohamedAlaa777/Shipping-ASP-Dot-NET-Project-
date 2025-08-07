using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Dtos.Base;

namespace BL.Dtos
{
    public partial class SettingDto : BaseDto
    {
        public float? KiloMeterRate { get; set; }
        public float? KilooGramRate { get; set; }
    }
}
