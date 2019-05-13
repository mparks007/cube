using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CubeSolver.Utils;

namespace CubeSolver.Enums
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
