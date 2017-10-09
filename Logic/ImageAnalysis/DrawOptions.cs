using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ImageAnalysis
{
    [Flags]
    public enum DrawOptions
    {
        TopContour = 0x01,

        TopApproxContour = 0x02,

        LiquidContour = 0x04,

        ApproxLiquidContour = 0x08
    }
}
