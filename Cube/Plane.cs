using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeSolver
{
    public enum Plane
    {
        [Description("Horizontal")]
        Horizontal,
        [Description("Vertical (Depth)")]
        VerticalDepth,
        [Description("Vertical (Width)")]
        VerticalWidth
    }
}
